using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TabuProject.DAL;
using TabuProject.DTOs.Games;
using TabuProject.DTOs.Words;
using TabuProject.Entities;
using TabuProject.Exceptions.Games;
using TabuProject.Extension;
using TabuProject.Services.Abstracts;

namespace TabuProject.Services.Implements
{
	public class GameService : IGameService
	{
        readonly IMapper _mapper;
        readonly TabuDbContext _context;
        readonly IMemoryCache _cache;

        public GameService(TabuDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _cache = cache; 
            _context = context;
            _mapper = mapper; 
        }

        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game); 
            await _context.SaveChangesAsync();
            return game.Id; 
        }

        public Task End(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Fail(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<WordForGameDto> Skip(Guid id)
        {
            var status = _getCurrentGame(id);
            if(status.Skip <= status.MaxSkipCount)
            {
                var currentWord = status.Words.Pop();
                status.Skip++; 
                _cache.Set(id, status, TimeSpan.FromSeconds(300));
                return currentWord; 
            }
            return null; 
        }

        public async Task<WordForGameDto> Start(Guid id)
        {
            var game = await _context.Games.FindAsync(id); 
            if (game == null || game.Score != null)
                throw new Exception();

            IQueryable<Word> query = _context.Words.Where(x => x.LangCode == game.LangCode);

            var words = await query.Select(x => new WordForGameDto
                {
                    Id = x.Id, 
                    Word = x.Text,
                    BannedWords = x.BannedWords.Select(x=> x.Text)
                })
                .Random(await query.CountAsync())
                .Take(20)
                .ToListAsync();

            var WordsStack = new Stack<WordForGameDto>(words);
            WordForGameDto currentWord = WordsStack.Pop();

            GameStatusDto status = new GameStatusDto()
            {
                Fail = 0,
                Success = 0,
                Skip = 0,
                Words = WordsStack,
                MaxSkipCount = game.SkipCount, 
                UsedWordsId = words.Select(x => x.Id)
            };

            _cache.Set(id, status, TimeSpan.FromSeconds(300));
            return currentWord; 
        }

        public Task Success(Guid id)
        {
            throw new NotImplementedException();
        }

        GameStatusDto _getCurrentGame(Guid id)
        {
            var result = _cache.Get<GameStatusDto>(id);
            if (result == null)
                throw new Exception();

            return result; 
        }
    }
}

