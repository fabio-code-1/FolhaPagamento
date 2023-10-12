using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FolhaPagamento.Models;

namespace FolhaPagamento.Controllers
{
    public class FeriasController : Controller
    {
        private readonly Contexto _context;

        public FeriasController(Contexto context)
        {
            _context = context;
        }

        // GET: Ferias
        public async Task<IActionResult> Index()
        {
              return _context.Feria != null ? 
                          View(await _context.Feria.ToListAsync()) :
                          Problem("Entity set 'Contexto.Feria'  is null.");
        }

        // GET: Ferias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Feria == null)
            {
                return NotFound();
            }

            var feria = await _context.Feria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feria == null)
            {
                return NotFound();
            }

            return View(feria);
        }

        // GET: Ferias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ferias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataInicio,DataFim,Status")] Feria feria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feria);
        }

        // GET: Ferias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Feria == null)
            {
                return NotFound();
            }

            var feria = await _context.Feria.FindAsync(id);
            if (feria == null)
            {
                return NotFound();
            }
            return View(feria);
        }

        // POST: Ferias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataInicio,DataFim,Status")] Feria feria)
        {
            if (id != feria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeriaExists(feria.Id))
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
            return View(feria);
        }

        // GET: Ferias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Feria == null)
            {
                return NotFound();
            }

            var feria = await _context.Feria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feria == null)
            {
                return NotFound();
            }

            return View(feria);
        }

        // POST: Ferias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Feria == null)
            {
                return Problem("Entity set 'Contexto.Feria'  is null.");
            }
            var feria = await _context.Feria.FindAsync(id);
            if (feria != null)
            {
                _context.Feria.Remove(feria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeriaExists(int id)
        {
          return (_context.Feria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
