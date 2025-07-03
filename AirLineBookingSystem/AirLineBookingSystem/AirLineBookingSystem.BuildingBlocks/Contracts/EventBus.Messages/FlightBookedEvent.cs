using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
    public record  FlightBookedEvent
    (
        Guid BookingId ,
        Guid FightId,
        string PassengerName,
        string SeatNumber,
        DateTime BookingDate
    );
    

    

