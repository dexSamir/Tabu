﻿using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabuProject.DAL;
using TabuProject.DTOs.Word;
using TabuProject.Entities;
using TabuProject.Exceptions.Languages;
using TabuProject.Exceptions.Words;
using TabuProject.Services.Abstracts;

namespace TabuProject.Services.Implements
{
    public class WordService : IWordService
    {
        readonly TabuDbContext _context;
        readonly IMapper _mapper; 
        public WordService(TabuDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        //CREATE
        public async Task CreateAsync(WordCreateDto dto)
        {
            if (await _context.Words.AnyAsync(x => x.Id == dto.Id))
                throw new WordExitsException();
            if (!await _context.Languages.AnyAsync(x => x.Code == dto.LangCode))
                throw new LanguageNotFoundException($"{dto.LangCode} dil kodu movcud deyil!");

            var word = _mapper.Map<Word>(dto);
            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAysnc(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id),"Id null ola bilmez!");

            var word = await _context.Words.FindAsync(id);
            if (word == null)
                throw new WordNotFoundException();

            _context.Words.Remove(word);
            await _context.SaveChangesAsync(); 
        }

        public async Task<WordGetDto> FindById(int? id)
        {
            if(id == null)
                throw new ArgumentNullException(nameof(id), "Id null ola bilmez!");
            var word = await _context.Words.FindAsync(id);

            if (word == null)
                throw new WordNotFoundException();

            return _mapper.Map<WordGetDto>(word); 
        }

        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            var datas = await _context.Words.ToListAsync();
            return _mapper.Map<IEnumerable<WordGetDto>>(datas);
        }

        public async Task<bool> UpdateAsync(int? id, WordUpdateDto dto)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "Id null ola bilmez!");

            var word = await _context.Words.FindAsync(id);
            if (word == null) 
                throw new WordNotFoundException();
            _mapper.Map(dto, word);
            await _context.SaveChangesAsync(); 
            return true ; 

        }
    }
}
