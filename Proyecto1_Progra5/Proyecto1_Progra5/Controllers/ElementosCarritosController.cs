using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto1_Progra5.Data;
using Proyecto1_Progra5.Models;

namespace Proyecto1_Progra5.Controllers
{
    public class ElementosCarritosController : Controller
    {
        private readonly AppDbContext _context;

        public ElementosCarritosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ElementosCarritos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ElementosCarritos.Include(e => e.Carrito).Include(e => e.Productos);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ElementosCarritos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ElementosCarritos == null)
            {
                return NotFound();
            }

            var elementosCarrito = await _context.ElementosCarritos
                .Include(e => e.Carrito)
                .Include(e => e.Productos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elementosCarrito == null)
            {
                return NotFound();
            }

            return View(elementosCarrito);
        }

        // GET: ElementosCarritos/Create
        public IActionResult Create()
        {
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "Id", "IdUsuario");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Descripcion");
            return View();
        }

        // POST: ElementosCarritos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarritoId,ProductoId,Cantidad,NombreProducto,PrecioProducto")] ElementosCarrito elementosCarrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elementosCarrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "Id", "IdUsuario", elementosCarrito.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Descripcion", elementosCarrito.ProductoId);
            return View(elementosCarrito);
        }

        // GET: ElementosCarritos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ElementosCarritos == null)
            {
                return NotFound();
            }

            var elementosCarrito = await _context.ElementosCarritos.FindAsync(id);
            if (elementosCarrito == null)
            {
                return NotFound();
            }
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "Id", "IdUsuario", elementosCarrito.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Descripcion", elementosCarrito.ProductoId);
            return View(elementosCarrito);
        }

        // POST: ElementosCarritos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarritoId,ProductoId,Cantidad,NombreProducto,PrecioProducto")] ElementosCarrito elementosCarrito)
        {
            if (id != elementosCarrito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elementosCarrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElementosCarritoExists(elementosCarrito.Id))
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
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "Id", "IdUsuario", elementosCarrito.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Descripcion", elementosCarrito.ProductoId);
            return View(elementosCarrito);
        }

        // GET: ElementosCarritos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ElementosCarritos == null)
            {
                return NotFound();
            }

            var elementosCarrito = await _context.ElementosCarritos
                .Include(e => e.Carrito)
                .Include(e => e.Productos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elementosCarrito == null)
            {
                return NotFound();
            }

            return View(elementosCarrito);
        }

        // POST: ElementosCarritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ElementosCarritos == null)
            {
                return Problem("Entity set 'AppDbContext.ElementosCarritos'  is null.");
            }
            var elementosCarrito = await _context.ElementosCarritos.FindAsync(id);
            if (elementosCarrito != null)
            {
                _context.ElementosCarritos.Remove(elementosCarrito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElementosCarritoExists(int id)
        {
          return (_context.ElementosCarritos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
