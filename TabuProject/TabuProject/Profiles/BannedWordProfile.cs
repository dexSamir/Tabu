using System;
using AutoMapper;
using TabuProject.DTOs.BannedWord;
using TabuProject.Entities;

namespace TabuProject.Profiles
{
	public class BannedWordProfile : Profile
	{
		public BannedWordProfile()
		{
			CreateMap<BannedWordCreateDto, BannedWord>();
			CreateMap<BannedWord, BannedWordGetDto>();
            CreateMap<BannedWordUpdateDto, BannedWord>();
		}
	}
}

