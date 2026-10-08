using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System_GMMunicipal.Data;
using System_GMMunicipal.Models;

namespace System_GMMunicipal.Controllers
{
    public class InfracaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InfracaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Infracaos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Infracaos.Include(i => i.Condutor).Include(i => i.FiscalUtilizador).Include(i => i.Motorizada).Include(i => i.TiposInfracoe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Infracaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infracao = await _context.Infracaos
                .Include(i => i.Condutor)
                .Include(i => i.FiscalUtilizador)
                .Include(i => i.Motorizada)
                .Include(i => i.TiposInfracoe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infracao == null)
            {
                return NotFound();
            }

            return View(infracao);
        }

        // GET: Infracaos/Create
        public IActionResult Create()
        {
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id");
            ViewData["FiscalId"] = new SelectList(_context.FiscalUtilizadors, "Id", "Id");
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id");
            ViewData["TipoInfracaoId"] = new SelectList(_context.TiposInfracoes, "Id", "Id");
            return View();
        }

        // POST: Infracaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CondutorId,MotorizadaId,FiscalId,TipoInfracaoId,DataHora,Local,Latitude,Longitude,Descricao,ValorMulta,Estado,DataPagamento,Observacoes")] Infracao infracao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infracao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", infracao.CondutorId);
            ViewData["FiscalId"] = new SelectList(_context.FiscalUtilizadors, "Id", "Id", infracao.FiscalId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", infracao.MotorizadaId);
            ViewData["TipoInfracaoId"] = new SelectList(_context.TiposInfracoes, "Id", "Id", infracao.TipoInfracaoId);
            return View(infracao);
        }

        // GET: Infracaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infracao = await _context.Infracaos.FindAsync(id);
            if (infracao == null)
            {
                return NotFound();
            }
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", infracao.CondutorId);
            ViewData["FiscalId"] = new SelectList(_context.FiscalUtilizadors, "Id", "Id", infracao.FiscalId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", infracao.MotorizadaId);
            ViewData["TipoInfracaoId"] = new SelectList(_context.TiposInfracoes, "Id", "Id", infracao.TipoInfracaoId);
            return View(infracao);
        }

        // POST: Infracaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CondutorId,MotorizadaId,FiscalId,TipoInfracaoId,DataHora,Local,Latitude,Longitude,Descricao,ValorMulta,Estado,DataPagamento,Observacoes")] Infracao infracao)
        {
            if (id != infracao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infracao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfracaoExists(infracao.Id))
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
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", infracao.CondutorId);
            ViewData["FiscalId"] = new SelectList(_context.FiscalUtilizadors, "Id", "Id", infracao.FiscalId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", infracao.MotorizadaId);
            ViewData["TipoInfracaoId"] = new SelectList(_context.TiposInfracoes, "Id", "Id", infracao.TipoInfracaoId);
            return View(infracao);
        }

        // GET: Infracaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infracao = await _context.Infracaos
                .Include(i => i.Condutor)
                .Include(i => i.FiscalUtilizador)
                .Include(i => i.Motorizada)
                .Include(i => i.TiposInfracoe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infracao == null)
            {
                return NotFound();
            }

            return View(infracao);
        }

        // POST: Infracaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infracao = await _context.Infracaos.FindAsync(id);
            if (infracao != null)
            {
                _context.Infracaos.Remove(infracao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfracaoExists(int id)
        {
            return _context.Infracaos.Any(e => e.Id == id);
        }
    }
}
