using System;
using System.Collections;
using TabuProject.DTOs.Games;

namespace TabuProject.Services.Abstracts
{
	public interface IGameService
	{
		Task<Guid> CreateAsync(GameCreateDto dto);
		Task<IEnumerable<GameGetDto>> Start(Guid id); 
	}
}

