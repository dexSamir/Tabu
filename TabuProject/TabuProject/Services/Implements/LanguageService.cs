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

        //CREATE
        public async Task CreateAsync(CreateLanguageDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException(); 
            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
            await _context.SaveChangesAsync();
        }

        //GET ALL 
        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var datas = await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(datas);
        }

        //DELETE 
        public async Task DeleteAsync(string code)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(x=> x.Code == code);
            if(language != null)
            {
                _context.Languages.Remove(language);
            }
            await _context.SaveChangesAsync();
        }

        //UPDATE
        public async Task<bool> UpdateAsync(LanguageUpdateDto dto, string? code)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
            if (language == null)
                return false;

            _mapper.Map(dto, language);

            await _context.SaveChangesAsync();
            return true;
        }

        //GET SINGLE 
        public async Task<LanguageGetDto> GetByCodeAsync(string? code)
        {
            var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
            if (data == null)
                return null;
            
            return _mapper.Map<LanguageGetDto>(data); 
        }
    }
}

