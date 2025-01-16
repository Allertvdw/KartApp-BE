using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.BLL.Services;
using KartAppBE.DAL.Data;
using KartAppBE.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString = $"server={Environment.GetEnvironmentVariable("DB_HOST")};user={Environment.GetEnvironmentVariable("DB_USER")};database={Environment.GetEnvironmentVariable("DB_NAME")};port={Environment.GetEnvironmentVariable("DB_PORT")};password={Environment.GetEnvironmentVariable("DB_PASSWORD")};";

//string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
//	throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAnyOrigin",
		policy => policy.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader());
});

//builder.Services.AddCors(options =>
//{
//	options.AddDefaultPolicy(corsPolicyBuilder =>
//	{
//		corsPolicyBuilder.WithOrigins("https://kart-app-fe.vercel.app")
//			.AllowAnyHeader()
//			.AllowAnyMethod()
//			.AllowCredentials();
//	});
//});

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IKartService, KartService>();
builder.Services.AddScoped<IKartRepository, KartRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IBookingUserService, BookingUserService>();
builder.Services.AddScoped<IBookingUserRepository, BookingUserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey
	});

	options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseMySql(
		connectionString,
		new MySqlServerVersion(new Version(8, 0, 39)),
		mySqlOptions => mySqlOptions.MigrationsAssembly("KartAppBE.DAL")
		));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey =
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value!))
	});
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
