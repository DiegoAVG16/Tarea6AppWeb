using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea6AppWeb.Models;

namespace Tarea6AppWeb.Controllers
{
    public class CelularesController : Controller
    {
        private readonly TiendaCelularesContext _context;

        public CelularesController(TiendaCelularesContext context)
        {
            _context = context;
        }

        // GET: Celulares
        public async Task<IActionResult> Index()
        {
            return View(await _context.Celulares.ToListAsync());
        }


        public List<Celulare> ListaCelulares()
        {
            return _context.Celulares.ToList();
        }

        // GET: Celulares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celulare = await _context.Celulares
                .FirstOrDefaultAsync(m => m.IdCelular == id);
            if (celulare == null)
            {
                return NotFound();
            }

            return View(celulare);
        }

        // GET: Celulares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Celulares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCelular,Marca,Modelo,Precio,Stock")] Celulare celulare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celulare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(celulare);
        }

        // GET: Celulares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celulare = await _context.Celulares.FindAsync(id);
            if (celulare == null)
            {
                return NotFound();
            }
            return View(celulare);
        }

        // POST: Celulares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCelular,Marca,Modelo,Precio,Stock")] Celulare celulare)
        {
            if (id != celulare.IdCelular)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celulare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelulareExists(celulare.IdCelular))
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
            return View(celulare);
        }

        // GET: Celulares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celulare = await _context.Celulares
                .FirstOrDefaultAsync(m => m.IdCelular == id);
            if (celulare == null)
            {
                return NotFound();
            }

            return View(celulare);
        }

        // POST: Celulares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celulare = await _context.Celulares.FindAsync(id);
            if (celulare != null)
            {
                _context.Celulares.Remove(celulare);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelulareExists(int id)
        {
            return _context.Celulares.Any(e => e.IdCelular == id);
        }
    }
}
