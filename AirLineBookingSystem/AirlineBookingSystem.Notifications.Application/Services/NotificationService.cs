using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;
using AirLineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using System.Security.Cryptography.X509Certificates;

namespace AirlineBookingSystem.Notifications.Application.Services;

public class NotificationService : INotificationService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public NotificationService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    public async Task SendNotificationAsync(Notification notification)
    {
        // Simulate Sending Notif
        Console.WriteLine($"Notif To :  {notification.Recipient} Message:{notification.Message} ");

        // publish event 
        var notificationEvent = new NotificationEvent(notification.Recipient, notification.Message, notification.Type);
        await _publishEndpoint.Publish(notificationEvent);

    }
}
