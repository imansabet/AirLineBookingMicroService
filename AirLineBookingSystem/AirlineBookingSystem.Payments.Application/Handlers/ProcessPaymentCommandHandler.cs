using AirlineBookingSystem.Payments.Application.Commands;
using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repositories;
using AirLineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Payments.Application.Handlers;

public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, Guid>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public ProcessPaymentCommandHandler(IPaymentRepository paymentRepository,IPublishEndpoint publishEndpoint)
    {
        _paymentRepository = paymentRepository;
        _publishEndpoint = publishEndpoint;
    }
    public async Task<Guid> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = new Payment
        {
            Id = Guid.NewGuid(),
            BookingId = request.BookingId,
            Amount = request.Amount,
            PaymentDate = DateTime.UtcNow,
        };
        
        await _paymentRepository.ProcessPaymentAsync(payment);

        // publish payment proc event
        await _publishEndpoint.Publish(new PaymentProcessedEvent
            (
                payment.Id,
                payment.BookingId,
                payment.Amount,
                payment.PaymentDate
            ));

        return payment.Id; 
    }
}
