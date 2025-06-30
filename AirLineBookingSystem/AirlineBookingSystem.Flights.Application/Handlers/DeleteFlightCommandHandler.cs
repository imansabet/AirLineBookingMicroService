using AirlineBookingSystem.Flights.Application.Commands;
using AirlineBookingSystem.Flights.Core.Repositories;
using MediatR;
using MediatR.Pipeline;

namespace AirlineBookingSystem.Flights.Application.Handlers;

public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand>
{
    private readonly IFlightRepository _flightRepository;

    public DeleteFlightCommandHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }
    public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        await _flightRepository.DeleteFlightAsync(request.Id);
    }
}
