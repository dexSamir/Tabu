using System;
using AutoMapper;
using TabuProject.DTOs.Word;
using TabuProject.Entities;

namespace TabuProject.Profiles
{
	public class WordProfile : Profile
	{
		public WordProfile()
		{
			CreateMap<WordCreateDto, Word>()
				.ForMember(dest => dest.BannedWords, opt => opt.MapFrom(src=>
					src.BannedWords.Select(x => new BannedWord { Text = x}).ToList()));
			CreateMap<Word, WordGetDto>()
				.ForMember(dest => dest.BannedWords, opt => opt.MapFrom(src => src.BannedWords));   
            CreateMap<WordUpdateDto, Word>();
		}
	}
}

