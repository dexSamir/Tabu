using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabuProject.DAL;
using TabuProject.DTOs.Languages;
using TabuProject.Entities;
using TabuProject.Exceptions.Languages;
using TabuProject.Services.Abstracts;

namespace TabuProject.Services.Implements
{
    public class LanguageService : ILanguageService
    {
        readonly TabuDbContext _context;
        readonly IMapper _mapper; 
        public LanguageService(TabuDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }
        public async Task CreateAsync(CreateLanguageDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException(); 
            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var datas = await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(datas);
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

