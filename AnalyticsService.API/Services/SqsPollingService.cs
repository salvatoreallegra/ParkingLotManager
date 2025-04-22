using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace AnalyticsService.Api.Services;

public class SqsPollingService : BackgroundService
{
    private readonly IAmazonSQS _sqs;
    private readonly string _queueUrl;

    public SqsPollingService(IAmazonSQS sqs, IConfiguration config)
    {
        _sqs = sqs;
        _queueUrl = config["AWS:QueueUrl"]!;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("🚀 AnalyticsService is now listening to SQS...");

        while (!stoppingToken.IsCancellationRequested)
        {
            var request = new ReceiveMessageRequest
            {
                QueueUrl = _queueUrl,
                MaxNumberOfMessages = 5,
                WaitTimeSeconds = 10 // enable long polling
            };

            var response = await _sqs.ReceiveMessageAsync(request, stoppingToken);

            foreach (var message in response.Messages)
            {
                Console.WriteLine("📥 Message received:");
                Console.WriteLine(message.Body);

                // You can deserialize here if you want
                // var vehicleEvent = JsonSerializer.Deserialize<VehicleEvent>(message.Body);

                await _sqs.DeleteMessageAsync(_queueUrl, message.ReceiptHandle, stoppingToken);
            }
        }
    }
}
