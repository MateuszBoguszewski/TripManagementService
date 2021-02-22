using Management.Trip.Service.Application.Commands.CreateTrip;
using Management.Trip.Service.Application.Commands.CancelTrip;
using Management.Trip.Service.Application.Commands.EditTrip;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Management.Trip.Service.Application.Queries.GetAllTrips;

namespace Management.Trip.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrips()
        {
            var result = await _mediator.Send(new GetAllTripsQuery());
            
            return Ok(result.Trips);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] TripStateRepresentation tripStateRepresentation)
        {
            var result = await _mediator.Send(new CreateTripCommand(tripStateRepresentation.Name, tripStateRepresentation.StartDate, tripStateRepresentation.EndDate));
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTrip([FromRoute] Guid id, [FromBody] TripStateRepresentation tripStateRepresentation)
        {
            await _mediator.Send(new EditTripCommand(id, tripStateRepresentation.Name, tripStateRepresentation.StartDate, tripStateRepresentation.EndDate));
            
            return Ok();
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelTrip([FromRoute] Guid id)
        {
            await _mediator.Send(new CancelTripCommand(id));
            
            return Ok();
        }
    }
}
