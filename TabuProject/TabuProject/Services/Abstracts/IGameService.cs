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
		Task Fail(Guid id);
		Task Success(Guid id);
		Task<WordForGameDto> Skip(Guid id);
		Task End(Guid id); 
	}
}

