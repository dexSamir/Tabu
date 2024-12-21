
using Microsoft.EntityFrameworkCore;
using TabuProject.DAL;
using TabuProject.Services.Implements;
using TabuProject.Services.Abstracts;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace TabuProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(typeof(Program)); 
        builder.Services.AddControllers();
        builder.Services.AddDbContext<TabuDbContext>(x=> x.UseNpgsql
        (builder.Configuration.GetConnectionString("PostgreSQL")));
        builder.Services.AddFluentValidationAutoValidation(); 
        builder.Services.AddValidatorsFromAssemblyContaining<Program>(); 
        builder.Services.AddScoped<ILanguageService, LanguageService>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

