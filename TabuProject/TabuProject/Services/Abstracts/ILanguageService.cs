using System;
using TabuProject.Controllers;
using TabuProject.DTOs.Languages;

namespace TabuProject.Services.Abstracts
{
	public interface ILanguageService
	{
		Task DeleteAsync(string code);
		Task<bool> UpdateAsync(LanguageUpdateDto dto, string? code);
		Task CreateAsync(CreateLanguageDto dto);
		Task<IEnumerable<LanguageGetDto>> GetAllAsync();
		Task<LanguageGetDto> GetByCodeAsync(string? code); 
    }
}

