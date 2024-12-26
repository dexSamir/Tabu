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
		}
	}
}

