using System;
using Microsoft.EntityFrameworkCore;
using TabuProject.DAL;
using TabuProject.DTOs.Languages;
using TabuProject.Entities;
using TabuProject.Services.Abstracts;

namespace TabuProject.Services.Implements
{
    public class LanguageService : ILanguageService
    {
        readonly TabuDbContext _context;

        public LanguageService(TabuDbContext context)
        {
            _context = context; 
        }
        public async Task CreateAsync(CreateLanguageDto dto)
        {
            await _context.Languages.AddAsync(new Language
            {
                Name = dto.Name,
                Icon = dto.IconUrl,
                Code = dto.Code
            });
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await _context.Languages.Select(x => new LanguageGetDto
            {
                Name = x.Name,
                Code = x.Code,
                Icon = x.Icon
            }).ToListAsync(); 
        }
        public async Task DeleteAsync(string code)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(x=> x.Code == code);
            if(language != null)
            {
                _context.Languages.Remove(language);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LanguageUpdateDto dto, string? code)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
            if(language != null)
            {
                if(dto.Icon != null)
                {
                    language.Icon = dto.Icon;
                }
                if (dto.Name != null)
                {
                    language.Name = dto.Name;
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}

