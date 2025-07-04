using AirlineBookingSystem.Flights.Application.Commands;
using AirlineBookingSystem.Flights.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Bookings.Api.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight([FromBody] CreateFlightCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetFlights), new { id }, command);
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _mediator.Send(new GetAllFlightsQuery());
            return Ok(flights);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(Guid id)
        {
            await _mediator.Send(new DeleteFlightCommand(id));
            return NoContent();
        }


    }
}
