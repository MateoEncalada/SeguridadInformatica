using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeguridadInformatica.Data;
using SeguridadInformatica.Models;

namespace SeguridadInformatica.Controllers
{
    public class AmenzasController : Controller
    {
        private readonly SeguridadInformaticaContext _context;

        public AmenzasController(SeguridadInformaticaContext context)
        {
            _context = context;
        }

        // GET: Amenzas
        public async Task<IActionResult> Index()
        {
              return _context.Amenzas != null ? 
                          View(await _context.Amenzas.ToListAsync()) :
                          Problem("Entity set 'SeguridadInformaticaContext.Amenzas'  is null.");
        }

        // GET: Amenzas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Amenzas == null)
            {
                return NotFound();
            }

            var amenzas = await _context.Amenzas
                .FirstOrDefaultAsync(m => m.AmenazasId == id);
            if (amenzas == null)
            {
                return NotFound();
            }

            return View(amenzas);
        }

        // GET: Amenzas/Create
        public IActionResult Create()
        {
            ViewData["Tipo"] = new SelectList(_context.Activos, "Tipo", "Tipo");
            ViewData["Evaluacion"] = new SelectList(_context.Dimensiones, "Evaluacion", "Evaluacion");
            return View();
        }

        // POST: Amenzas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenazasId,Amenaza,Valor,Control,Imacto,Riesgo,ActivosId,DimensionesId")] Amenzas amenzas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amenzas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amenzas);
        }

        // GET: Amenzas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Amenzas == null)
            {
                return NotFound();
            }

            var amenzas = await _context.Amenzas.FindAsync(id);
            if (amenzas == null)
            {
                return NotFound();
            }
            return View(amenzas);
        }

        // POST: Amenzas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmenazasId,Amenaza,Valor,Control,Impacto,Riesgo,ActivosId,DimensionesId")] Amenzas amenzas)
        {
            if (id != amenzas.AmenazasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amenzas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenzasExists(amenzas.AmenazasId))
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
            return View(amenzas);
        }

        // GET: Amenzas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Amenzas == null)
            {
                return NotFound();
            }

            var amenzas = await _context.Amenzas
                .FirstOrDefaultAsync(m => m.AmenazasId == id);
            if (amenzas == null)
            {
                return NotFound();
            }

            return View(amenzas);
        }

        // POST: Amenzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Amenzas == null)
            {
                return Problem("Entity set 'SeguridadInformaticaContext.Amenzas'  is null.");
            }
            var amenzas = await _context.Amenzas.FindAsync(id);
            if (amenzas != null)
            {
                _context.Amenzas.Remove(amenzas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmenzasExists(int id)
        {
          return (_context.Amenzas?.Any(e => e.AmenazasId == id)).GetValueOrDefault();
        }
    }
}
