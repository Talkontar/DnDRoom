using DnDRoom.Data;
using DnDRoom.Contracts;
using DnDRoom.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using DnDRoom.Mapping;

namespace DnDRoom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllers();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
                    )
                };
            });

            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddTransient<IUserRepo, UserRepo>();
            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddTransient<IRoomRepo, RoomRepo>();
            builder.Services.AddTransient<IRoomService, RoomService>();

            builder.Services.AddTransient<ICharacterRepo, CharacterRepo>();
            builder.Services.AddTransient<ICharacterService, CharacterService>();

            builder.Services.AddSingleton<IMapper>(MappingHelper.GetMapper());

            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}