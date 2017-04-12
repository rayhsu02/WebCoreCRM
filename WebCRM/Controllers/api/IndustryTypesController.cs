using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Model;
using DataAccess;

namespace WebCRM.Controllers.api
{
    [Produces("application/json")]
    [Route("api/IndustryTypes")]
    public class IndustryTypesController : Controller
    {
        private readonly IWebCRMRepository _repo;

        public IndustryTypesController(IWebCRMRepository repo)
        {
            _repo = repo;
        }

        // GET: api/IndustryTypes
        [HttpGet]
        public IEnumerable<IndustryType> GetIndustryType()
        {
            return _repo.GetIndustryTypes();
        }

        //// GET: api/IndustryTypes/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetIndustryType([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var industryType = await _context.IndustryType.SingleOrDefaultAsync(m => m.IndustryTypeId == id);

        //    if (industryType == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(industryType);
        //}

        //// PUT: api/IndustryTypes/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutIndustryType([FromRoute] int id, [FromBody] IndustryType industryType)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != industryType.IndustryTypeId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(industryType).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!IndustryTypeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/IndustryTypes
        //[HttpPost]
        //public async Task<IActionResult> PostIndustryType([FromBody] IndustryType industryType)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.IndustryType.Add(industryType);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetIndustryType", new { id = industryType.IndustryTypeId }, industryType);
        //}

        //// DELETE: api/IndustryTypes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteIndustryType([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var industryType = await _context.IndustryType.SingleOrDefaultAsync(m => m.IndustryTypeId == id);
        //    if (industryType == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.IndustryType.Remove(industryType);
        //    await _context.SaveChangesAsync();

        //    return Ok(industryType);
        //}

        //private bool IndustryTypeExists(int id)
        //{
        //    return _context.IndustryType.Any(e => e.IndustryTypeId == id);
        //}
    }
}