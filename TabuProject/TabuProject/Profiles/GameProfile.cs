using System;
using AutoMapper;
using TabuProject.DTOs.Games;
using TabuProject.Entities;

namespace TabuProject.Profiles
{
	public class GameProfile : Profile
	{
		public GameProfile()
		{
			CreateMap<GameCreateDto, Game>();
			CreateMap<Game, GameGetDto>()
				.ForMember(dest => dest.Words, opt => opt.MapFrom(src=> src.Language.Words.Select(x=> x.Text).ToList())); 
		}
	}
}

