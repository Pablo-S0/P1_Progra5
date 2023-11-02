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
    public class CarritosController : Controller
    {
        private readonly AppDbContext _context;

        public CarritosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Carritos
        public async Task<IActionResult> Index()
        {
              return _context.Carritos != null ? 
                          View(await _context.Carritos.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Carritos'  is null.");
        }

        // GET: Carritos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // GET: Carritos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carritos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrito);
        }

        // GET: Carritos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            return View(carrito);
        }

        // POST: Carritos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario")] Carrito carrito)
        {
            if (id != carrito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoExists(carrito.Id))
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
            return View(carrito);
        }

        // GET: Carritos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // POST: Carritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carritos == null)
            {
                return Problem("Entity set 'AppDbContext.Carritos'  is null.");
            }
            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito != null)
            {
                _context.Carritos.Remove(carrito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoExists(int id)
        {
          return (_context.Carritos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<Producto> GetProducto(int prId)
        {
            Producto prEncontrado = await _context.Productos.Where(u => u.Id == prId)
            .FirstOrDefaultAsync();

            return prEncontrado;
        }

        public async Task<IActionResult> AgregarAlCarrito(int prId, int cant = 1)
        {
            Producto prEncontrado = await GetProducto(prId);

            var user = _context.Usuarios.FirstOrDefaultAsync(x => x.Correo == User.Identity!.Name);

            var carrito = _context.Carritos.SingleOrDefault(c => c.IdUsuario == user.Id.ToString());

            if (carrito == null)
            {
                carrito = new Carrito
                {
                    IdUsuario = User.Identity.Name,
                };
                _context.Carritos.Add(carrito);
            }
            _context.SaveChanges();


            var ItemCarrito = _context.ElementosCarritos
                                  .FirstOrDefault(a => a.ProductoId == prId);
            if (ItemCarrito is not null)
            {
                ItemCarrito.Cantidad += cant;
            }
            else
            {
                var pr = _context.Productos.Find(prId);
                ItemCarrito = new ElementosCarrito
                {
                    ProductoId = prId,
                    CarritoId = carrito.Id,
                    Cantidad = cant,
                    NombreProducto = pr.Nombre,
                    PrecioProducto = pr.Precio
                };
                _context.ElementosCarritos.Add(ItemCarrito);
            }
            _context.SaveChanges();
            return RedirectToAction("Reservar", "Home");
        }
    }
}
