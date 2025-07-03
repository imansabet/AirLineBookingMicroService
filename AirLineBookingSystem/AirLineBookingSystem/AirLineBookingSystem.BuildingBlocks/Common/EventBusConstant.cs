using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirLineBookingSystem.BuildingBlocks.Common;

public class EventBusConstant
{
    public const string FlightBookedQueue = "flight_booked_queue";
    public const string PaymentProcessedQueue = "payment_processed_queue";
    public const string NotificationSentQueue = "notification_sent_queue";


}
