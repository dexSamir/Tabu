using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabuProject.DAL;
using TabuProject.DTOs.Games;
using TabuProject.Entities;
using TabuProject.Exceptions.Games;
using TabuProject.Services.Abstracts;

namespace TabuProject.Services.Implements
{
	public class GameService : IGameService
	{
        readonly IMapper _mapper;
        readonly TabuDbContext _context;

        public GameService(TabuDbContext context, IMapper mapper)
        {
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

        public async Task<IEnumerable<GameGetDto>> Start(Guid id)
        {
            var game = await _context.Games.Include(x => x.Language).FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
                throw new GamesNotFoundException($"{id}-li oyun tapilmadi!");

            var games = await _context.Games.Include(x => x.Language).ToListAsync();
            return _mapper.Map<IEnumerable<GameGetDto>>(games); 
        }
    }
}

