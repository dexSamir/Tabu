using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabuProject.DAL;
using TabuProject.DTOs.BannedWord;
using TabuProject.Entities;
using TabuProject.Exceptions.BannedWords;
using TabuProject.Exceptions.Words;
using TabuProject.Services.Abstracts;

namespace TabuProject.Services.Implements
{
	public class BannedWordService : IBannedWordService 
	{
        readonly TabuDbContext _context;
        readonly IMapper _mapper; 
		public BannedWordService(TabuDbContext context, IMapper mapper)
		{
            _mapper = mapper; 
            _context = context; 
		}

        public async Task CreateAsync(BannedWordCreateDto dto, int? wordId)
        {
            if (wordId == null)
                throw new ArgumentNullException(nameof(wordId), "Word Id null olamaz!");

            var word = await _context.Words
                .Include(w => w.BannedWords) 
                .FirstOrDefaultAsync(w => w.Id == wordId);

            if (word == null)
                throw new WordNotFoundException();

            if (word.BannedWords.Any(b => b.Text == dto.Text))
                throw new BannerWordExistsException();

            var bannedWord = _mapper.Map<BannedWord>(dto);
            bannedWord.WordId = word.Id; 
            await _context.BannedWords.AddAsync(bannedWord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id), "Id null ola bilmez!");
            var data = await _context.BannedWords.FindAsync(id);
            if (data == null)
                throw new NotFoundBannedWordException();

            _context.BannedWords.Remove(data);
            await _context.SaveChangesAsync(); 
        }

        public async Task<BannedWordGetDto> FindById(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id), "Id null ola bilmez!");

            var data = await _context.BannedWords.FindAsync(id);
            if (data == null)
                throw new NotFoundBannedWordException();

            return _mapper.Map<BannedWordGetDto>(data); 

        }

        public async Task<IEnumerable<BannedWordGetDto>> GetAllAsync()
        {
            var datas = await _context.BannedWords.Include(x=> x.Word).ToListAsync();
            return _mapper.Map<IEnumerable<BannedWordGetDto>>(datas); 
        }

        public async Task<bool> UpdateAsync(int? id, BannedWordUpdateDto dto)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "Id null ola bilmez!");

            var bannedWord = await _context.BannedWords.FindAsync(id);
            if (bannedWord == null)
                return false;
            _mapper.Map(dto, bannedWord);
            await _context.SaveChangesAsync();
            return true; 
        }
    }
}

