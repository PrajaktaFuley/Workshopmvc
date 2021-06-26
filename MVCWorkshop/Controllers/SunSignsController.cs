using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWorkshop.Data;
using MVCWorkshop.Models;

namespace MVCWorkshop.Controllers
{
    public class SunSignsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SunSignsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SunSigns
        public async Task<IActionResult> Index()
        {
            return View(await _context.SunSign.ToListAsync());
        }

        // GET: SunSigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sunSign = await _context.SunSign
                .FirstOrDefaultAsync(m => m.SignId == id);
            if (sunSign == null)
            {
                return NotFound();
            }

            return View(sunSign);
        }

        // GET: SunSigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SunSigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SignId,SignName,SignDate,id")] SunSign sunSign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sunSign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sunSign);
        }

        // GET: SunSigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sunSign = await _context.SunSign.FindAsync(id);
            if (sunSign == null)
            {
                return NotFound();
            }
            return View(sunSign);
        }

        // POST: SunSigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SignId,SignName,SignDate,id")] SunSign sunSign)
        {
            if (id != sunSign.SignId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sunSign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SunSignExists(sunSign.SignId))
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
            return View(sunSign);
        }

        // GET: SunSigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sunSign = await _context.SunSign
                .FirstOrDefaultAsync(m => m.SignId == id);
            if (sunSign == null)
            {
                return NotFound();
            }

            return View(sunSign);
        }

        // POST: SunSigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sunSign = await _context.SunSign.FindAsync(id);
            _context.SunSign.Remove(sunSign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SunSignExists(int id)
        {
            return _context.SunSign.Any(e => e.SignId == id);
        }
    }
}
