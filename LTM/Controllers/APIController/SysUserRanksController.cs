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
    [Route("api/SysUserRanks")]
    public class SysUserRanksController : Controller
    {
        private readonly Peter_DBContext _context;

        public SysUserRanksController(Peter_DBContext context)
        {
            _context = context;
        }

        // GET: api/SysUserRanks
        [HttpGet]
        public IEnumerable<SysUserRank> GetSysUserRank()
        {
            return _context.SysUserRank;
        }

        // GET: api/SysUserRanks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSysUserRank([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sysUserRank = await _context.SysUserRank.SingleOrDefaultAsync(m => m.Id == id);

            if (sysUserRank == null)
            {
                return NotFound();
            }

            return Ok(sysUserRank);
        }

        // PUT: api/SysUserRanks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSysUserRank([FromRoute] long id, [FromBody] SysUserRank sysUserRank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sysUserRank.Id)
            {
                return BadRequest();
            }

            _context.Entry(sysUserRank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SysUserRankExists(id))
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

        // POST: api/SysUserRanks
        [HttpPost]
        public async Task<IActionResult> PostSysUserRank([FromBody] SysUserRank sysUserRank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SysUserRank.Add(sysUserRank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSysUserRank", new { id = sysUserRank.Id }, sysUserRank);
        }

        // DELETE: api/SysUserRanks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSysUserRank([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sysUserRank = await _context.SysUserRank.SingleOrDefaultAsync(m => m.Id == id);
            if (sysUserRank == null)
            {
                return NotFound();
            }

            _context.SysUserRank.Remove(sysUserRank);
            await _context.SaveChangesAsync();

            return Ok(sysUserRank);
        }

        private bool SysUserRankExists(long id)
        {
            return _context.SysUserRank.Any(e => e.Id == id);
        }
    }
}