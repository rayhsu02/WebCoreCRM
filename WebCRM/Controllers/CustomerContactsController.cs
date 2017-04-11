using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Model;
using Microsoft.AspNetCore.Authorization;
using DataAccess;

namespace WebCRM.Controllers
{
    [Produces("application/json")]
    [Route("api/CustomerContacts")]
    //[Authorize]
    public class CustomerContactsController : Controller
    {
        private readonly IWebCRMRepository _repo;

        public CustomerContactsController(IWebCRMRepository repo)
        {
            _repo = repo;
        }

        // GET: api/CustomerContacts
        [HttpGet]
        [Route("~/api/CustomerContacts/GetCustomerContactsByCustomerID/{id}")]
        public IEnumerable<CustomerContacts> GetCustomerContactsByCustomerID([FromRoute] int id)
        {
            return _repo.GetCustomerContacts(id);
        }

        // GET: api/CustomerContacts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerContacts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerContacts = await _repo.GetContact(id); 

            if (customerContacts == null)
            {
                return NotFound();
            }

            return Ok(customerContacts);
        }

        // PUT: api/CustomerContacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerContacts([FromRoute] int id, [FromBody] CustomerContacts customerContacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerContacts.CustomerContactId)
            {
                return BadRequest();
            }

            await _repo.UpdateContact(customerContacts);

            return NoContent();
        }

        // POST: api/CustomerContacts
        [HttpPost]
        public async Task<IActionResult> PostCustomerContacts([FromBody] CustomerContacts customerContacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int x = await _repo.SaveContact(customerContacts);

            return Ok();
        }

        // DELETE: api/CustomerContacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerContacts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.DeleteContact(id);

            return Ok();
        }

       
    }
}