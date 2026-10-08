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
    public class LicencasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LicencasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Licencas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Licencas.Include(l => l.Condutor).Include(l => l.Motorizada).Include(l => l.Municipio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Licencas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenca = await _context.Licencas
                .Include(l => l.Condutor)
                .Include(l => l.Motorizada)
                .Include(l => l.Municipio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licenca == null)
            {
                return NotFound();
            }

            return View(licenca);
        }

        // GET: Licencas/Create
        public IActionResult Create()
        {
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id");
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id");
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id");
            return View();
        }

        // POST: Licencas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroLicenca,TipoLicenca,Valor,Estado,MotivoCancelamento,DataEmissao,DataInicio,DataValidade,DataCancelamento,MunicipioId,CondutorId,MotorizadaId")] Licenca licenca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licenca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", licenca.CondutorId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", licenca.MotorizadaId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", licenca.MunicipioId);
            return View(licenca);
        }

        // GET: Licencas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenca = await _context.Licencas.FindAsync(id);
            if (licenca == null)
            {
                return NotFound();
            }
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", licenca.CondutorId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", licenca.MotorizadaId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", licenca.MunicipioId);
            return View(licenca);
        }

        // POST: Licencas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroLicenca,TipoLicenca,Valor,Estado,MotivoCancelamento,DataEmissao,DataInicio,DataValidade,DataCancelamento,MunicipioId,CondutorId,MotorizadaId")] Licenca licenca)
        {
            if (id != licenca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licenca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicencaExists(licenca.Id))
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
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", licenca.CondutorId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", licenca.MotorizadaId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", licenca.MunicipioId);
            return View(licenca);
        }

        // GET: Licencas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenca = await _context.Licencas
                .Include(l => l.Condutor)
                .Include(l => l.Motorizada)
                .Include(l => l.Municipio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licenca == null)
            {
                return NotFound();
            }

            return View(licenca);
        }

        // POST: Licencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licenca = await _context.Licencas.FindAsync(id);
            if (licenca != null)
            {
                _context.Licencas.Remove(licenca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicencaExists(int id)
        {
            return _context.Licencas.Any(e => e.Id == id);
        }
    }
}
