using Management.Customer.Service.Application.Commands.CreateCustomer;
using Management.Customer.Service.Application.Commands.EditCustomer;
using Management.Customer.Service.Application.Queries.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Management.Customer.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            
            return Ok(result.Customers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerStateRepresentation customerStateRepresentation)
        {
            var result = await _mediator.Send(new CreateCustomerCommand(customerStateRepresentation.Name, customerStateRepresentation.Password));
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomer([FromRoute] Guid id, [FromBody] CustomerStateRepresentation customerStateRepresentation)
        {
            await _mediator.Send(new EditCustomerCommand(id, customerStateRepresentation.Name, customerStateRepresentation.Password));
            
            return Ok();
        }
    }
}
