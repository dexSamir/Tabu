using System;
using System.Collections;
using TabuProject.DTOs.Games;
using TabuProject.DTOs.Words;

namespace TabuProject.Services.Abstracts
{
	public interface IGameService
	{
		Task<Guid> CreateAsync(GameCreateDto dto);
		Task<WordForGameDto> Start(Guid id);
		Task<WordForGameDto> Fail(Guid id);
		Task<WordForGameDto> Success(Guid id);
		Task<WordForGameDto> Skip(Guid id);
		Task<GameStatusDto> End(Guid id); 
	}
}

