using Amazon.SQS;
using SensorService.Api.Services;
using SensorService.Application.Interfaces;
using SensorService.Infrastructure.Repositories;
using Amazon.Runtime;
using Amazon.Extensions.NETCore.Setup;
var builder = WebApplication.CreateBuilder(args);
var awsOptions = builder.Configuration.GetAWSOptions();

builder.Services.AddDefaultAWSOptions(awsOptions);
builder.Services.AddAWSService<IAmazonSQS>();
// Add services to the container.
builder.Services.AddSingleton<IVehicleEventRepository, InMemoryVehicleEventRepository>();
builder.Services.AddAWSService<IAmazonSQS>();
builder.Services.AddSingleton<SqsSender>();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
