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
    public class InspencaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InspencaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inspencaos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Inspencaos.Include(i => i.FiscalUtilizador).Include(i => i.Motorizada);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Inspencaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspencao = await _context.Inspencaos
                .Include(i => i.FiscalUtilizador)
                .Include(i => i.Motorizada)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspencao == null)
            {
                return NotFound();
            }

            return View(inspencao);
        }

        // GET: Inspencaos/Create
        public IActionResult Create()
        {
            ViewData["FiscalId"] = new SelectList(_context.FiscalUtilizadors, "Id", "Id");
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id");
            return View();
        }

        // POST: Inspencaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MotorizadaId,FiscalId,DataInspeccao,EstadoMotorizada,Travões,Pneus,Luzes,Espelhos,Documentacao,Resultado,Observacoes")] Inspencao inspencao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FiscalId"] = new SelectList(_context.FiscalUtilizadors, "Id", "Id", inspencao.FiscalId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", inspencao.MotorizadaId);
            return View(inspencao);
        }

        // GET: Inspencaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspencao = await _context.Inspencaos.FindAsync(id);
            if (inspencao == null)
            {
                return NotFound();
            }
            ViewData["FiscalId"] = new SelectList(_context.FiscalUtilizadors, "Id", "Id", inspencao.FiscalId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", inspencao.MotorizadaId);
            return View(inspencao);
        }

        // POST: Inspencaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MotorizadaId,FiscalId,DataInspeccao,EstadoMotorizada,Travões,Pneus,Luzes,Espelhos,Documentacao,Resultado,Observacoes")] Inspencao inspencao)
        {
            if (id != inspencao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspencaoExists(inspencao.Id))
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
            ViewData["FiscalId"] = new SelectList(_context.FiscalUtilizadors, "Id", "Id", inspencao.FiscalId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", inspencao.MotorizadaId);
            return View(inspencao);
        }

        // GET: Inspencaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspencao = await _context.Inspencaos
                .Include(i => i.FiscalUtilizador)
                .Include(i => i.Motorizada)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspencao == null)
            {
                return NotFound();
            }

            return View(inspencao);
        }

        // POST: Inspencaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inspencao = await _context.Inspencaos.FindAsync(id);
            if (inspencao != null)
            {
                _context.Inspencaos.Remove(inspencao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspencaoExists(int id)
        {
            return _context.Inspencaos.Any(e => e.Id == id);
        }
    }
}
