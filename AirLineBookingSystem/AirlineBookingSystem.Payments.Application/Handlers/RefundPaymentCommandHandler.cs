using AirlineBookingSystem.Payments.Application.Commands;
using AirlineBookingSystem.Payments.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Payments.Application.Handlers;

public class RefundPaymentCommandHandler : IRequestHandler<RefundPaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;

    public RefundPaymentCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    public async Task Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
    {
        await _paymentRepository.RefundPaymentAsync(request.PaymentId);
    }
}
