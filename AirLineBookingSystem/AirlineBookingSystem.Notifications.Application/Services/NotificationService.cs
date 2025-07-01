using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;
using System.Security.Cryptography.X509Certificates;

namespace AirlineBookingSystem.Notifications.Application.Services;

public class NotificationService : INotificationService
{
    public async Task SendNotificationAsync(Notification notification)
    {
        // Simulate Sending Notif
        Console.WriteLine($"Notif To :  {notification.Recipient} Message:{notification.Message} ");
    }
}
