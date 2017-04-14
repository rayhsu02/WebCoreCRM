using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Model;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebCRM.Controllers.api
{
    [Produces("application/json")]
    [Route("api/CustomerDocuments")]
    public class CustomerDocumentsController : Controller
    {
        private readonly WebCRMDBContext _context;
        private IHostingEnvironment _environment;

        public CustomerDocumentsController(WebCRMDBContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: api/CustomerDocuments
        [HttpGet]
        public IEnumerable<CustomerDocument> GetCustomerDocument()
        {
            return _context.CustomerDocument;
        }

        // GET: api/CustomerDocuments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDocument([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDocument = await _context.CustomerDocument.SingleOrDefaultAsync(m => m.FilePathId == id);

            if (customerDocument == null)
            {
                return NotFound();
            }

            return Ok(customerDocument);
        }

        // PUT: api/CustomerDocuments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDocument([FromRoute] int id, [FromBody] CustomerDocument customerDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerDocument.FilePathId)
            {
                return BadRequest();
            }

            _context.Entry(customerDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDocumentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //// POST: api/CustomerDocuments
        //[HttpPost]
        //public async Task<IActionResult> PostCustomerDocument([FromBody] CustomerDocument customerDocument)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.CustomerDocument.Add(customerDocument);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCustomerDocument", new { id = customerDocument.FilePathId }, customerDocument);
        //}

        [HttpPost]
        [Consumes("multipart/form-data", "application/json")]
        public async Task<IActionResult> PostCustomerDocument()
        {
            //Read all files from angularjs FormData post request
            var files = Request.Form.Files;
            var strigValue = Request.Form.Keys;
            var customerId = Convert.ToString(Request.Form["customerId"]);

            var uploads = Path.Combine(_environment.WebRootPath, "uploads");

            foreach(var f in files)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, f.FileName), FileMode.Create))
                {
                    await f.CopyToAsync(fileStream);
                }
            }
          
            return Ok();

        }

        //// POST: api/CustomerDocuments
        //[HttpPost]
        //[Consumes("multipart/form-data", "application/json")]
        //public async Task<IActionResult> PostCustomerDocument(IFormFile file)
        //{
        //    //var stream = file.OpenReadStream();
        //    //var name = file.FileName;

        //    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
        //    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
        //    {
        //        await file.CopyToAsync(fileStream);
        //    }
        //    return Ok(); //null just to make error free
        //}

        // DELETE: api/CustomerDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDocument([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDocument = await _context.CustomerDocument.SingleOrDefaultAsync(m => m.FilePathId == id);
            if (customerDocument == null)
            {
                return NotFound();
            }

            _context.CustomerDocument.Remove(customerDocument);
            await _context.SaveChangesAsync();

            return Ok(customerDocument);
        }

        private bool CustomerDocumentExists(int id)
        {
            return _context.CustomerDocument.Any(e => e.FilePathId == id);
        }
    }
}