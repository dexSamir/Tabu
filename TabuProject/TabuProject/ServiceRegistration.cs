using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using TabuProject.Exceptions;
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
		public static IApplicationBuilder UseTabuExceptionHandler(this IApplicationBuilder app)
		{
            app.UseExceptionHandler(
            opt =>
            {
                opt.Run(async context =>
                {
                    var feature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();
                    var exception = feature.Error;
                    if (exception is IBaseException bEx)
                    {
                        context.Response.StatusCode = bEx.StatusCode;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Message = bEx.ErrorMessage
                        });
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Message = "Bir xeta bash verdi!"
                        });
                    }
                });
            });
            return app;
        }
	}
}

