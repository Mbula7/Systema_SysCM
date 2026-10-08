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
    public class FormacaoReciclagemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormacaoReciclagemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormacaoReciclagems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FormacaoReciclagems.Include(f => f.Condutor).Include(f => f.Curso);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FormacaoReciclagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacaoReciclagem = await _context.FormacaoReciclagems
                .Include(f => f.Condutor)
                .Include(f => f.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formacaoReciclagem == null)
            {
                return NotFound();
            }

            return View(formacaoReciclagem);
        }

        // GET: FormacaoReciclagems/Create
        public IActionResult Create()
        {
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id");
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id");
            return View();
        }

        // POST: FormacaoReciclagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CondutorId,CursoId,DataInscricao,DataConclusao,Nota,Resultado,CertificadoNumero,Estado")] FormacaoReciclagem formacaoReciclagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formacaoReciclagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", formacaoReciclagem.CondutorId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id", formacaoReciclagem.CursoId);
            return View(formacaoReciclagem);
        }

        // GET: FormacaoReciclagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacaoReciclagem = await _context.FormacaoReciclagems.FindAsync(id);
            if (formacaoReciclagem == null)
            {
                return NotFound();
            }
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", formacaoReciclagem.CondutorId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id", formacaoReciclagem.CursoId);
            return View(formacaoReciclagem);
        }

        // POST: FormacaoReciclagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CondutorId,CursoId,DataInscricao,DataConclusao,Nota,Resultado,CertificadoNumero,Estado")] FormacaoReciclagem formacaoReciclagem)
        {
            if (id != formacaoReciclagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formacaoReciclagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormacaoReciclagemExists(formacaoReciclagem.Id))
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
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", formacaoReciclagem.CondutorId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id", formacaoReciclagem.CursoId);
            return View(formacaoReciclagem);
        }

        // GET: FormacaoReciclagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacaoReciclagem = await _context.FormacaoReciclagems
                .Include(f => f.Condutor)
                .Include(f => f.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formacaoReciclagem == null)
            {
                return NotFound();
            }

            return View(formacaoReciclagem);
        }

        // POST: FormacaoReciclagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formacaoReciclagem = await _context.FormacaoReciclagems.FindAsync(id);
            if (formacaoReciclagem != null)
            {
                _context.FormacaoReciclagems.Remove(formacaoReciclagem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormacaoReciclagemExists(int id)
        {
            return _context.FormacaoReciclagems.Any(e => e.Id == id);
        }
    }
}
