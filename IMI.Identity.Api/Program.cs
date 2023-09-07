using IMI.Identity.Core.Entities;
using IMI.Identity.Core.Infrastructure;
using IMI.Identity.Core.Services;
using IMI.Identity.Core.Services.Interfaces;
using IMI.Identity.Infrastructure.Data;
using IMI.Identity.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString
("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

builder.Services.AddScoped<IUsersService, UsersService>();

// Identity configuration
builder.Services.AddIdentity<User, IdentityRole>(options => {
	//// Password configurations
	//options.Password.RequiredLength = 6;
	//options.Password.RequireNonAlphanumeric = true;
	//options.Password.RequireLowercase = true;
	//options.Password.RequireUppercase = true;
	//options.Password.RequireDigit = true;
	//options.Password.RequiredUniqueChars = 1;

	//// User configurations
	//options.User.RequireUniqueEmail = true;
	//options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+";

	//// SignIn options
	//options.SignIn.RequireConfirmedAccount = true;
	options.SignIn.RequireConfirmedEmail = false;
	//options.SignIn.RequireConfirmedPhoneNumber = false;

	//// Lockout options
	//options.Lockout.AllowedForNewUsers = true;
	//options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
	//options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddCors();

builder.Services.AddControllers();

builder.Services.AddAuthentication(option => { 
	option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
	option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
}).AddJwtBearer(jwtOptions => { 
	jwtOptions.TokenValidationParameters = new TokenValidationParameters() 
	{ 
		ValidateActor = true, 
		ValidateAudience = true, 
		ValidateLifetime = true, 
		ValidIssuer = builder.Configuration["JWTConfiguration:Issuer"], 
		ValidAudience = builder.Configuration["JWTConfiguration:Audience"], 
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:SigningKey"])) 
	}; 
});

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

app.UseCors(builder => builder.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
