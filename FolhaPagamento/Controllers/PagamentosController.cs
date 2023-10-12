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
    public class PagamentosController : Controller
    {
        private readonly Contexto _context;

        public PagamentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Pagamentos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Pagamentos.Include(p => p.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Pagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PagamentoID == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamentos/MyDetails
        public async Task<IActionResult> MyDetails()
        {
            var userName = User.Identity.Name;

            if (userName == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Usuario.Username == userName);

            if (pagamento == null)
            {
                return NotFound();
            }

            return View("Details", pagamento); // Reutilize a View "Details" existente
        }


        // GET: Pagamentos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioID"] = new SelectList(_context.Users, "Id", "Nome");
            return View();
        }

        // POST: Pagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoID,UsuarioID,DataPagamento,ValorTotal,Descontos,Bonus,HorasExtras,ValorLiquido,EstadoPagamento")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioID"] = new SelectList(_context.Users, "Id", "Nome", pagamento.UsuarioID);
            return View(pagamento);
        }

        // GET: Pagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            ViewData["UsuarioID"] = new SelectList(_context.Users, "Id", "Nome", pagamento.UsuarioID);
            return View(pagamento);
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoID,UsuarioID,DataPagamento,ValorTotal,Descontos,Bonus,HorasExtras,ValorLiquido,EstadoPagamento")] Pagamento pagamento)
        {
            if (id != pagamento.PagamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.PagamentoID))
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
            ViewData["UsuarioID"] = new SelectList(_context.Users, "Id", "Nome", pagamento.UsuarioID);
            return View(pagamento);
        }

        // GET: Pagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PagamentoID == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagamentos == null)
            {
                return Problem("Entity set 'Contexto.Pagamentos'  is null.");
            }
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento != null)
            {
                _context.Pagamentos.Remove(pagamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
          return (_context.Pagamentos?.Any(e => e.PagamentoID == id)).GetValueOrDefault();
        }
    }
}
