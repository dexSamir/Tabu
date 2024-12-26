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

        public async Task<GameStatusDto> End(Guid id)
        {
            var status = _getCurrentGame(id);
            _cache.Remove(id);
            return new GameStatusDto
            {
                Score = status.Score,
                Fail = status.Fail,
                Skip = status.Skip,
                Success = status.Success
            }; 
        }

        public async Task<WordForGameDto> Fail(Guid id)
        {
            var status = _getCurrentGame(id);
            var currentWord = status.Words.Pop();
            status.Fail++;
            status.Score--;
            setCache(id, status);
            return currentWord; 
        }

        public async Task<WordForGameDto> Skip(Guid id)
        {
            var status = _getCurrentGame(id);
            if(status.Skip <= status.MaxSkipCount)
            {
                var currentWord = status.Words.Pop();
                status.Skip++;
                setCache(id, status);
                return currentWord; 
            }
            return null; 
        }

        public async Task<WordForGameDto> Start(Guid id)
        {
            var game = await _context.Games.FindAsync(id); 
            if (game == null || game.Score != null)
                throw new GamesNotFoundException();

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

            setCache(id, status);
            return currentWord; 
        }

        public async Task<WordForGameDto> Success(Guid id)
        {
            var status = _getCurrentGame(id);
            status.Success++;
            status.Score++; 
            var currentWord = status.Words.Pop();
            setCache(id, status); 
            return currentWord; 
        }

        GameStatusDto _getCurrentGame(Guid id)
        {
            var result = _cache.Get<GameStatusDto>(id);
            if (result == null)
                throw new GamesNotFoundException();

            return result; 
        }
        void setCache(Guid id, GameStatusDto status)
        {
            _cache.Set(id, status, TimeSpan.FromSeconds(300)); 
        }
    }
}

