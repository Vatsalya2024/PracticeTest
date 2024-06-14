
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PracticeTest.Context;
using PracticeTest.Interfaces;
using PracticeTest.Models;
using PracticeTest.Repositories;
using PracticeTest.Services;
using System.Text;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Capstone_Project;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddJsonOptions(opts =>
        {
            opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opts.JsonSerializerOptions.WriteIndented = true;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("ReactPolicy", opts =>
            {
                opts.WithOrigins("http://localhost:3000", "null").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
            });
        });


        builder.Services.AddDbContext<PracticeContext>(opts =>
        {
            opts.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnectionString"));
        });
        #region Repository
        builder.Services.AddScoped<MemberRepository>();
        builder.Services.AddScoped< UserRepository>();
        

        #endregion

        #region Services
        builder.Services.AddScoped<IMemberService, MemberService>();
        builder.Services.AddScoped<IUserService, UserService>();






        var app = builder.Build();
        #endregion



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("ReactPolicy");
        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}