using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LTM.Models;

namespace LTM.Controllers.APIController
{
    [Produces("application/json")]
    [Route("api/SysLicensePlateDatas")]
    public class SysLicensePlateDatasController : Controller
    {
        private readonly Peter_DBContext _context;

        public SysLicensePlateDatasController(Peter_DBContext context)
        {
            _context = context;
        }

        // GET: api/SysLicensePlateDatas
        [HttpGet]
        public IEnumerable<SysLicensePlateData> GetSysLicensePlateData()
        {
            return _context.SysLicensePlateData;
        }

        // GET: api/SysLicensePlateDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSysLicensePlateData([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sysLicensePlateData = await _context.SysLicensePlateData.SingleOrDefaultAsync(m => m.Id == id);

            if (sysLicensePlateData == null)
            {
                return NotFound();
            }

            return Ok(sysLicensePlateData);
        }

        // PUT: api/SysLicensePlateDatas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSysLicensePlateData([FromRoute] long id, [FromBody] SysLicensePlateData sysLicensePlateData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sysLicensePlateData.Id)
            {
                return BadRequest();
            }

            _context.Entry(sysLicensePlateData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SysLicensePlateDataExists(id))
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

        // POST: api/SysLicensePlateDatas
        [HttpPost]
        public async Task<IActionResult> PostSysLicensePlateData([FromBody] SysLicensePlateData sysLicensePlateData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SysLicensePlateData.Add(sysLicensePlateData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSysLicensePlateData", new { id = sysLicensePlateData.Id }, sysLicensePlateData);
        }

        // DELETE: api/SysLicensePlateDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSysLicensePlateData([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sysLicensePlateData = await _context.SysLicensePlateData.SingleOrDefaultAsync(m => m.Id == id);
            if (sysLicensePlateData == null)
            {
                return NotFound();
            }

            _context.SysLicensePlateData.Remove(sysLicensePlateData);
            await _context.SaveChangesAsync();

            return Ok(sysLicensePlateData);
        }

        private bool SysLicensePlateDataExists(long id)
        {
            return _context.SysLicensePlateData.Any(e => e.Id == id);
        }
    }
}