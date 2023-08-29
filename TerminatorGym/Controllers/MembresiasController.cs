using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TerminatorGym.Models;

namespace TerminatorGym.Controllers
{
    public class MembresiasController : Controller
    {
        private readonly TerminatorGymContext _context;

        public MembresiasController(TerminatorGymContext context)
        {
            _context = context;
        }

        // GET: Membresias
        public async Task<IActionResult> Index()
        {
            var terminatorGymContext = _context.Membresias.Include(m => m.Miembro);
            return View(await terminatorGymContext.ToListAsync());
        }

        // GET: Membresias/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null || _context.Membresias == null)
            {
                return NotFound();
            }

            var membresia = await _context.Membresias
                .Include(m => m.Miembro)
                .FirstOrDefaultAsync(m => m.MembresiaId == id);
            if (membresia == null)
            {
                return NotFound();
            }

            return View(membresia);
        }

        // GET: Membresias/Create
        public IActionResult Create()
        {
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "MiembroId", "MiembroId");
            return View();
        }

        // POST: Membresias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembresiaId,MiembroId,Precio,FechaInicio,FechaVencimiento,TipoMembresia")] Membresia membresia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membresia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "MiembroId", "MiembroId", membresia.MiembroId);
            return View(membresia);
        }

        // GET: Membresias/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null || _context.Membresias == null)
            {
                return NotFound();
            }

            var membresia = await _context.Membresias.FindAsync(id);
            if (membresia == null)
            {
                return NotFound();
            }
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "MiembroId", "MiembroId", membresia.MiembroId);
            return View(membresia);
        }

        // POST: Membresias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("MembresiaId,MiembroId,Precio,FechaInicio,FechaVencimiento,TipoMembresia")] Membresia membresia)
        {
            if (id != membresia.MembresiaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membresia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembresiaExists(membresia.MembresiaId))
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
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "MiembroId", "MiembroId", membresia.MiembroId);
            return View(membresia);
        }

        // GET: Membresias/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null || _context.Membresias == null)
            {
                return NotFound();
            }

            var membresia = await _context.Membresias
                .Include(m => m.Miembro)
                .FirstOrDefaultAsync(m => m.MembresiaId == id);
            if (membresia == null)
            {
                return NotFound();
            }

            return View(membresia);
        }

        // POST: Membresias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            if (_context.Membresias == null)
            {
                return Problem("Entity set 'TerminatorGymContext.Membresias'  is null.");
            }
            var membresia = await _context.Membresias.FindAsync(id);
            if (membresia != null)
            {
                _context.Membresias.Remove(membresia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembresiaExists(short id)
        {
          return (_context.Membresias?.Any(e => e.MembresiaId == id)).GetValueOrDefault();
        }
    }
}
