using System;
using TabuProject.DTOs.BannedWord;

namespace TabuProject.Services.Abstracts
{
	public interface IBannedWordService
	{
		Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
		Task<BannedWordGetDto> FindById(int? id);
		Task CreateAsync(BannedWordCreateDto dto, int? id);
		Task<bool> UpdateAsync(int? id, BannedWordUpdateDto dto);
		Task DeleteAsync(int? id); 
	}
}

