using System;
using AutoMapper;
using TabuProject.DTOs.Languages;
using TabuProject.Entities;

namespace TabuProject.Profiles
{
	public class LanguageProfile : Profile
	{
		public LanguageProfile()
		{
			CreateMap<CreateLanguageDto, Language>()
				.ForMember(l => l.Icon, lcd => lcd.MapFrom(x=> x.IconUrl));
			CreateMap<Language, LanguageGetDto>(); 
			CreateMap<LanguageUpdateDto, Language>()
				.ForMember(dest => dest.Code, src => src.Ignore()); 


		}
	}
}

