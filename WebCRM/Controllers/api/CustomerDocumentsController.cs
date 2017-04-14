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
using DataAccess;
using WebCRM.DocusignClient;

namespace WebCRM.Controllers.api
{
    [Produces("application/json")]
    [Route("api/CustomerDocuments")]
    public class CustomerDocumentsController : Controller
    {
        private readonly IWebCRMRepository _repo;
        private IHostingEnvironment _environment;

        public CustomerDocumentsController(IWebCRMRepository repo, IHostingEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
        }

        // GET: api/CustomerDocuments
        [HttpGet]
        [Route("~/api/CustomerDocuments/GetCustomerDocumentsByCustomerID/{id}")]
        public IEnumerable<CustomerDocument> GetCustomerDocumentsByCustomerID([FromRoute] int id)
        {
            return _repo.GetCustomerDocuments(id);
        }

        // GET: api/CustomerDocuments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDocument([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomerDocument customerDocument = await _repo.GetCustomerDocumentById(id);

            if (customerDocument == null)
            {
                return NotFound();
            }

            var stream = customerDocument.FileContent;
            var response = File(stream, customerDocument.ContentType); // FileStreamResult
            return response;

           
        }

        // PUT: api/CustomerDocuments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDocument([FromRoute] string id, [FromBody] CustomerDocument customerDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != customerDocument.FileId)
            //{
            //    return BadRequest();
            //}

           await _repo.UpdateCustomerDocument(customerDocument);

            return NoContent();
        }


        [HttpPost]
        [Consumes("multipart/form-data", "application/json")]
        public async Task<IActionResult> PostCustomerDocument()
        {
           
            var files = Request.Form.Files;
            var strigValue = Request.Form.Keys;
            var customerId = Convert.ToInt32(Request.Form["customerId"]);

            //var uploads = Path.Combine(_environment.WebRootPath, "uploads");

            foreach(var f in files)
            {
               
                var customerDoc = new CustomerDocument
                {
                    CustomerId = customerId,
                    FileName = f.FileName,
                    ContentType = f.ContentType
                };
                
                using (var fileStream = f.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    customerDoc.FileContent = fileBytes;
                    await _repo.SaveCustomerDocument(customerDoc);
                }

                //using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                //{
                //    await f.CopyToAsync(fileStream);

                //    await _repo.SaveCustomerDocument(customerDoc);
                //}
            }
          
            return Ok(true);

        }

        // DELETE: api/CustomerDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDocument([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await _repo.DeleteCustomerDocument(id);

            return Ok();
           
        }

        [HttpGet]
        [Route("~/api/CustomerDocuments/RequestSignatureOnDocument/{id}")]
        public async Task<IActionResult> RequestSignatureOnDocument([FromRoute] string id)
        {
            DocusignAPIClient client = new DocusignAPIClient();

            CustomerDocument customerDocument = await _repo.GetCustomerDocumentById(id);

            if (customerDocument == null)
            {
                return NotFound();
            }

            var stream = customerDocument.FileContent;

            string toEmail = "rayhsu02@yahoo.com";

            client.requestSignatureOnDocumentTest(customerDocument.FileName, customerDocument.FileContent, "Ray Hsu", toEmail);

            return Ok();
        }



    }
}