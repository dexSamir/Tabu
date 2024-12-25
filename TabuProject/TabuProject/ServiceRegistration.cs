using System;
using TabuProject.Services.Abstracts;
using TabuProject.Services.Implements;

namespace TabuProject
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddService(this IServiceCollection services)
		{
            services.AddScoped<IBannedWordService, BannedWordService>();
			services.AddScoped<IWordService, WordService>();
            services.AddScoped<ILanguageService, LanguageService>();
			services.AddScoped<IGameService, GameService>(); 
            return services; 
		}
	}
}

