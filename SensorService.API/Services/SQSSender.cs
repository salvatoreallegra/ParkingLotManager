using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using SensorService.Domain.Entities;

namespace SensorService.Api.Services;

public class SqsSender
{
    private readonly IAmazonSQS _sqs;
    private readonly string _queueUrl;

    public SqsSender(IAmazonSQS sqs, IConfiguration config)
    {
        _sqs = sqs;
        _queueUrl = config["AWS:QueueUrl"]!;
    }

    public async Task SendVehicleEventAsync(VehicleEvent vehicleEvent)
    {
        var messageBody = JsonSerializer.Serialize(vehicleEvent);

        var request = new SendMessageRequest
        {
            QueueUrl = _queueUrl,
            MessageBody = messageBody
        };

        var response = await _sqs.SendMessageAsync(request);
        Console.WriteLine($"SQS Response Status: {response.HttpStatusCode}");
        Console.WriteLine($"Message ID: {response.MessageId}");
    }
}
