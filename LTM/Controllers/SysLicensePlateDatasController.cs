using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LTM.Models;

namespace LTM.Controllers
{
    public class SysLicensePlateDatasController : Controller
    {
        private readonly Peter_DBContext _context;

        public SysLicensePlateDatasController(Peter_DBContext context)
        {
            _context = context;    
        }

        // GET: SysLicensePlateDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.SysLicensePlateData.ToListAsync());
        }

        // GET: SysLicensePlateDatas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysLicensePlateData = await _context.SysLicensePlateData
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sysLicensePlateData == null)
            {
                return NotFound();
            }

            return View(sysLicensePlateData);
        }

        // GET: SysLicensePlateDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SysLicensePlateDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Licenseplatetype,Licenseplate,Password,Createdate,Createuserid,Authstatus,Authpassdate,Authpassuserid,Authunpassdate,Anthunpassuserid")] SysLicensePlateData sysLicensePlateData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sysLicensePlateData);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sysLicensePlateData);
        }

        // GET: SysLicensePlateDatas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysLicensePlateData = await _context.SysLicensePlateData.SingleOrDefaultAsync(m => m.Id == id);
            if (sysLicensePlateData == null)
            {
                return NotFound();
            }
            return View(sysLicensePlateData);
        }

        // POST: SysLicensePlateDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Licenseplatetype,Licenseplate,Password,Createdate,Createuserid,Authstatus,Authpassdate,Authpassuserid,Authunpassdate,Anthunpassuserid")] SysLicensePlateData sysLicensePlateData)
        {
            if (id != sysLicensePlateData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sysLicensePlateData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SysLicensePlateDataExists(sysLicensePlateData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(sysLicensePlateData);
        }

        // GET: SysLicensePlateDatas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysLicensePlateData = await _context.SysLicensePlateData
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sysLicensePlateData == null)
            {
                return NotFound();
            }

            return View(sysLicensePlateData);
        }

        // POST: SysLicensePlateDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sysLicensePlateData = await _context.SysLicensePlateData.SingleOrDefaultAsync(m => m.Id == id);
            _context.SysLicensePlateData.Remove(sysLicensePlateData);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SysLicensePlateDataExists(long id)
        {
            return _context.SysLicensePlateData.Any(e => e.Id == id);
        }
    }
}
