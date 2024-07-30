using AutoMapper;
using CustomerAPI.Interfaces;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var customerId = await _customerService.CreateCustomer(customerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customerId }, customerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            if (id != customerDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _customerService.UpdateCustomer(customerDto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }


}
