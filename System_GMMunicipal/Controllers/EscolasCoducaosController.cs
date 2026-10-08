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
    public class EscolasCoducaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EscolasCoducaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EscolasCoducaos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.escolasCoducaos.Include(e => e.Municipio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EscolasCoducaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolasCoducao = await _context.escolasCoducaos
                .Include(e => e.Municipio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escolasCoducao == null)
            {
                return NotFound();
            }

            return View(escolasCoducao);
        }

        // GET: EscolasCoducaos/Create
        public IActionResult Create()
        {
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id");
            return View();
        }

        // POST: EscolasCoducaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,NUIT,Telefone,Email,Endereco,MunicipioId,Licencas,DataLicenciamento,Estado,CreateDate")] EscolasCoducao escolasCoducao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escolasCoducao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", escolasCoducao.MunicipioId);
            return View(escolasCoducao);
        }

        // GET: EscolasCoducaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolasCoducao = await _context.escolasCoducaos.FindAsync(id);
            if (escolasCoducao == null)
            {
                return NotFound();
            }
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", escolasCoducao.MunicipioId);
            return View(escolasCoducao);
        }

        // POST: EscolasCoducaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,NUIT,Telefone,Email,Endereco,MunicipioId,Licencas,DataLicenciamento,Estado,CreateDate")] EscolasCoducao escolasCoducao)
        {
            if (id != escolasCoducao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escolasCoducao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolasCoducaoExists(escolasCoducao.Id))
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
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", escolasCoducao.MunicipioId);
            return View(escolasCoducao);
        }

        // GET: EscolasCoducaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolasCoducao = await _context.escolasCoducaos
                .Include(e => e.Municipio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escolasCoducao == null)
            {
                return NotFound();
            }

            return View(escolasCoducao);
        }

        // POST: EscolasCoducaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escolasCoducao = await _context.escolasCoducaos.FindAsync(id);
            if (escolasCoducao != null)
            {
                _context.escolasCoducaos.Remove(escolasCoducao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolasCoducaoExists(int id)
        {
            return _context.escolasCoducaos.Any(e => e.Id == id);
        }
    }
}
