﻿using AirlineBookingSystem.Flights.Application.Queries;
using AirlineBookingSystem.Flights.Core.Entities;
using AirlineBookingSystem.Flights.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers;

public class GetAllFlightsQueryHandler : IRequestHandler<GetAllFlightsQuery, IEnumerable<Flight>>
{
    private readonly IFlightRepository _flightRepository;

    public GetAllFlightsQueryHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }
    public async Task<IEnumerable<Flight>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
    {
        return await _flightRepository.GetFlightsAsync();
    }
}
