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
    public class HealthAccessController : Controller
    {
        private readonly YourHealthNowContext _context;

        public HealthAccessController(YourHealthNowContext context)
        {
            _context = context;
        }

        // GET: HealthAccess
        public async Task<IActionResult> Index()
        {
              return _context.HealthAccess != null ? 
                          View(await _context.HealthAccess.ToListAsync()) :
                          Problem("Entity set 'YourHealthNowContext.HealthAccess'  is null.");
        }

        // GET: HealthAccess/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HealthAccess == null)
            {
                return NotFound();
            }

            var healthAccess = await _context.HealthAccess
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthAccess == null)
            {
                return NotFound();
            }

            return View(healthAccess);
        }

        // GET: HealthAccess/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthAccess/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] HealthAccess healthAccess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthAccess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(healthAccess);
        }

        // GET: HealthAccess/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HealthAccess == null)
            {
                return NotFound();
            }

            var healthAccess = await _context.HealthAccess.FindAsync(id);
            if (healthAccess == null)
            {
                return NotFound();
            }
            return View(healthAccess);
        }

        // POST: HealthAccess/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] HealthAccess healthAccess)
        {
            if (id != healthAccess.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthAccess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthAccessExists(healthAccess.Id))
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
            return View(healthAccess);
        }

        // GET: HealthAccess/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HealthAccess == null)
            {
                return NotFound();
            }

            var healthAccess = await _context.HealthAccess
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthAccess == null)
            {
                return NotFound();
            }

            return View(healthAccess);
        }

        // POST: HealthAccess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HealthAccess == null)
            {
                return Problem("Entity set 'YourHealthNowContext.HealthAccess'  is null.");
            }
            var healthAccess = await _context.HealthAccess.FindAsync(id);
            if (healthAccess != null)
            {
                _context.HealthAccess.Remove(healthAccess);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthAccessExists(int id)
        {
          return (_context.HealthAccess?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
