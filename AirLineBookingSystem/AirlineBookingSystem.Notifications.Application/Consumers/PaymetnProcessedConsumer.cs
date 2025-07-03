using AirlineBookingSystem.Notifications.Application.Commands;
using AirLineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using MassTransit.Mediator;

namespace AirlineBookingSystem.Notifications.Application.Consumers;

public class PaymetnProcessedConsumer : IConsumer<PaymentProcessedEvent>
{
    private readonly IMediator _mediator;

    public PaymetnProcessedConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
    {
        var paymentProcessedEvent = context.Message;
        var message = $"Payment of ${paymentProcessedEvent.Amount} for Booking Id : {paymentProcessedEvent.BookingId} was processed successfully.";

        var command = new SendNotificationCommand("dev.imansabet@gmail.com", message, "Email");

        await _mediator.Send(command);   
    }
}
