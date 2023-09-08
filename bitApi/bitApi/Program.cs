using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using bitApi.Data;
using bitApi;
using bitApi.Background;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<bitApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("bitApiContext") ?? throw new InvalidOperationException("Connection string 'bitApiContext' not found.")), ServiceLifetime.Singleton);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<IntegracionApi>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseAuthorization();

app.MapControllers();

app.MapannouncementEndpoints();

app.Run();
