using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YourHealthNow.Data;
using YourHealthNow.Models;

namespace YourHealthNow.Controllers
{
    public class HealthInfoController : Controller
    {
        private readonly YourHealthNowContext _context;

        public HealthInfoController(YourHealthNowContext context)
        {
            _context = context;
        }

        // GET: HealthInfo
        public async Task<IActionResult> Index()
        {
              return _context.HealthInfo != null ? 
                          View(await _context.HealthInfo.ToListAsync()) :
                          Problem("Entity set 'YourHealthNowContext.HealthInfo'  is null.");
        }

        // GET: HealthInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HealthInfo == null)
            {
                return NotFound();
            }

            var healthInfo = await _context.HealthInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthInfo == null)
            {
                return NotFound();
            }

            return View(healthInfo);
        }

        // GET: HealthInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] HealthInfo healthInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(healthInfo);
        }

        // GET: HealthInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HealthInfo == null)
            {
                return NotFound();
            }

            var healthInfo = await _context.HealthInfo.FindAsync(id);
            if (healthInfo == null)
            {
                return NotFound();
            }
            return View(healthInfo);
        }

        // POST: HealthInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] HealthInfo healthInfo)
        {
            if (id != healthInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthInfoExists(healthInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(healthInfo);
        }

        // GET: HealthInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HealthInfo == null)
            {
                return NotFound();
            }

            var healthInfo = await _context.HealthInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthInfo == null)
            {
                return NotFound();
            }

            return View(healthInfo);
        }

        // POST: HealthInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HealthInfo == null)
            {
                return Problem("Entity set 'YourHealthNowContext.HealthInfo'  is null.");
            }
            var healthInfo = await _context.HealthInfo.FindAsync(id);
            if (healthInfo != null)
            {
                _context.HealthInfo.Remove(healthInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthInfoExists(int id)
        {
          return (_context.HealthInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
