using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Model;
using DataAccess;
using Microsoft.AspNetCore.Authorization;

namespace WebCRM.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Customers")]
    //[Authorize]
    public class CustomersController : Controller
    {
        private readonly IWebCRMRepository _repo;

        public CustomersController(IWebCRMRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<dynamic> GetCustomer()
        {
            return _repo.GetCustomers();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            var customer = await _repo.GetCustomer(id);


            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
           await _repo.UpdateCustomer(customer);



            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           int x = await _repo.SaveCustomer(customer);

            return Ok();

          
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.DeleteCustomer(id);

            return Ok();
        }

        
    }
}