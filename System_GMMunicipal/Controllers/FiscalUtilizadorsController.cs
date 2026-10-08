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
    public class FiscalUtilizadorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FiscalUtilizadorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FiscalUtilizadors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FiscalUtilizadors.Include(f => f.Municipio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FiscalUtilizadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiscalUtilizador = await _context.FiscalUtilizadors
                .Include(f => f.Municipio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fiscalUtilizador == null)
            {
                return NotFound();
            }

            return View(fiscalUtilizador);
        }

        // GET: FiscalUtilizadors/Create
        public IActionResult Create()
        {
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id");
            return View();
        }

        // POST: FiscalUtilizadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCompleto,NumeroIdentificacao,Telefone,Cargo,Instituicao,MunicipioId,Estado,CreateDate")] FiscalUtilizador fiscalUtilizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fiscalUtilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", fiscalUtilizador.MunicipioId);
            return View(fiscalUtilizador);
        }

        // GET: FiscalUtilizadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiscalUtilizador = await _context.FiscalUtilizadors.FindAsync(id);
            if (fiscalUtilizador == null)
            {
                return NotFound();
            }
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", fiscalUtilizador.MunicipioId);
            return View(fiscalUtilizador);
        }

        // POST: FiscalUtilizadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCompleto,NumeroIdentificacao,Telefone,Cargo,Instituicao,MunicipioId,Estado,CreateDate")] FiscalUtilizador fiscalUtilizador)
        {
            if (id != fiscalUtilizador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fiscalUtilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiscalUtilizadorExists(fiscalUtilizador.Id))
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
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", fiscalUtilizador.MunicipioId);
            return View(fiscalUtilizador);
        }

        // GET: FiscalUtilizadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiscalUtilizador = await _context.FiscalUtilizadors
                .Include(f => f.Municipio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fiscalUtilizador == null)
            {
                return NotFound();
            }

            return View(fiscalUtilizador);
        }

        // POST: FiscalUtilizadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fiscalUtilizador = await _context.FiscalUtilizadors.FindAsync(id);
            if (fiscalUtilizador != null)
            {
                _context.FiscalUtilizadors.Remove(fiscalUtilizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiscalUtilizadorExists(int id)
        {
            return _context.FiscalUtilizadors.Any(e => e.Id == id);
        }
    }
}
