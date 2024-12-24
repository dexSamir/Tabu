using System;
using TabuProject.DTOs.Word;

namespace TabuProject.Services.Abstracts
{
	public interface IWordService
	{
		Task<int> CreateAsync(WordCreateDto dto);
		Task DeleteAysnc(int? id);
		Task<IEnumerable<WordGetDto>> GetAllAsync();
		Task<bool> UpdateAsync(int? id, WordUpdateDto dto); 
		Task<WordGetDto> FindById(int? id); 
	}
}

