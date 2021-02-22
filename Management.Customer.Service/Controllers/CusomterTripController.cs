using Management.Customer.Service.Application.Commands.AssignCustomerToTrip;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Management.Customer.Service.Controllers
{
    [ApiController]
    public class CusomterTripController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CusomterTripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/customers/{customerId}/trips/{tripId}")]
        public async Task<IActionResult> AssignCustomerToTrip([FromRoute] Guid customerId, Guid tripId)
        {
            var result = await _mediator.Send(new AssignCustomerToTripCommand(customerId, tripId));

            return Ok(result);
        }
    }
}
