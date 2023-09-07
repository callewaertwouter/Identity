using IMI.Identity.Core.Infrastructure;
using IMI.Identity.Core.Services;
using IMI.Identity.Core.Services.Interfaces;
using IMI.Identity.Infrastructure.Data;
using IMI.Identity.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString
("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

builder.Services.AddScoped<IUsersService, UsersService>();

// Identity configuration
builder.Services.AddDefaultIdentity<IdentityUser>(options => { 
	// Password configurations
	options.Password.RequiredLength = 6; 
	options.Password.RequireNonAlphanumeric = true; 
	options.Password.RequireLowercase = true; 
	options.Password.RequireUppercase = true; 
	options.Password.RequireDigit = true; 
	options.Password.RequiredUniqueChars = 1; 
	
	// User configurations
	options.User.RequireUniqueEmail = true; 
	options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+"; 
	
	// SignIn options
	options.SignIn.RequireConfirmedAccount = true; 
	options.SignIn.RequireConfirmedEmail = false;	
	options.SignIn.RequireConfirmedPhoneNumber = false; 
	
	// Lockout options
	options.Lockout.AllowedForNewUsers = true; 
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3); 
	options.Lockout.MaxFailedAccessAttempts = 5; 
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddCors();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder => builder.AllowAnyOrigin()
	.AllowAnyHeader()
	.AllowAnyMethod());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
