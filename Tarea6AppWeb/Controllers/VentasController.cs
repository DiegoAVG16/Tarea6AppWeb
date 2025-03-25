using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea6AppWeb.Models;

namespace Tarea6AppWeb.Controllers
{
    public class VentasController : Controller
    {
        private readonly TiendaCelularesContext _context;

        public VentasController(TiendaCelularesContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var tiendaCelularesContext = _context.Ventas
                .Include(v => v.IdCelularNavigation)
                .Include(v => v.IdClienteNavigation);
            return View(await tiendaCelularesContext.ToListAsync());
        }

       

       

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                 return NotFound();
            }



            var venta = await _context.Ventas
                .Include(v => v.IdCelularNavigation)
                .Include(v => v.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);

            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Celulares, "IdCelular", "IdCelular");
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,IdCelular,IdCliente,FechaVenta,Cantidad")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Celulares, "IdCelular", "IdCelular", venta.IdCelular);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", venta.IdCliente);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Celulares, "IdCelular", "IdCelular", venta.IdCelular);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", venta.IdCliente);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,IdCelular,IdCliente,FechaVenta,Cantidad")] Venta venta)
        {
            if (id != venta.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.IdVenta))
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
            ViewData["IdCelular"] = new SelectList(_context.Celulares, "IdCelular", "IdCelular", venta.IdCelular);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", venta.IdCliente);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.IdCelularNavigation)
                .Include(v => v.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.IdVenta == id);
        }
    }
}
