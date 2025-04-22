using Amazon.SQS;
using Amazon.Runtime;
using AnalyticsService.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Register AWS credentials (from env vars, user secrets, etc.)
builder.Services.AddAWSService<IAmazonSQS>();

// Register your background worker
builder.Services.AddHostedService<SqsPollingService>();

// Swagger (optional — no controllers for now, but you can keep it)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers(); // Currently unused — but safe to keep

app.Run();
