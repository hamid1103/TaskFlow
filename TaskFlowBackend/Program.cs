using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskFlowBackend.Data;
using TaskFlowBackend.Models;
using Scalar.AspNetCore;
using TaskFlowBackend.Repositories.TaskRepository;
using TaskFlowBackend.Repositories.UserRepository;
using TaskFlowBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

//Define secret vars
//var predictionApiKey = builder.Configuration.GetValue<string>("PredictionKey");
var postgresApiKey = builder.Configuration.GetValue<string>("PostgresApiKey");
var Key = Encoding.UTF8.GetBytes(builder.Configuration["Key"]);

//Adding DBContexts
builder.Services.AddDbContext<TaskContext>(options =>
{
    options.UseNpgsql(postgresApiKey,
        o =>
        {
            o.MapEnum<RecurringType>("recurring");
        });
});

//Adding repositories/services
//builder.Services.AddScoped<IDataRepository, DataDbContextRepository>();
//builder.Services.AddScoped<AfvalMonitoring.Services.AfvalService>();

builder.Services.AddScoped<ITaskRepository, TaskContextTaskRepository>();
builder.Services.AddScoped<IUserRepository, TaskContextUserRepository>();
builder.Services.AddScoped<AuthService>();

var jwtSettings = builder.Configuration.GetSection("Jwt");


builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Key),
            NameClaimType = JwtRegisteredClaimNames.Name
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapOpenApi();
app.MapScalarApiReference("/docs");

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllers();



app.Run();
