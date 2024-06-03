using CustomerMicroService.Models;
using CustomerMicroService.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerRepository.GetCustomers();

            return new OkObjectResult(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            return new OkObjectResult(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            using (var scope = new TransactionScope())
            {
                _customerRepository.InsertCustomert(customer);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (customer != null)
            {
                using (var scope = new TransactionScope())
                {
                    _customerRepository.UpdateCustomer(customer);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _customerRepository.DeleteCustomer(id);
                return new OkResult();
            }
            return new NotFoundResult();
        }
    }
}
