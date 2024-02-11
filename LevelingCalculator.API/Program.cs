using LevelingCalculator.Business;
using LevelingCalculator.Business.Abstraction;
using LevelingCalculator.Business.Kafka;
using LevelingCalculator.Business.Kafka.MessageHandler.Factory;
using LevelingCalculator.Business.Profiles;
using LevelingCalculator.Repository;
using LevelingCalculator.Repository.Abstraction;
using LevelingCalculator.Repository.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<LevelingCalculatorDbContext>(options =>
    options.UseSqlServer("name=ConnectionStrings:LevelingCalculatorDbContext",
    a => a.MigrationsAssembly("LevelingCalculator.API")));
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddAutoMapper(typeof(AssemblyMarker));

builder.Services.AddHttpClient<Character.ClientHTTP.Abstraction.IClientHTTP, Character.ClientHTTP.ClientHTTP>("CharacterClientHTTP", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("CharacterClientHTTP:BaseAddress").Value);
});
builder.Services.AddHttpClient<Resource.ClientHTTP.Abstraction.IClientHTTP, Resource.ClientHTTP.ClientHTTP>("ResourceClientHTTP", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("ResourceClientHTTP:BaseAddress").Value);
});
builder.Services.AddKafkaConsumerService<KafkaTopicsInput, MessageHandlerFactory>(builder.Configuration);
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
