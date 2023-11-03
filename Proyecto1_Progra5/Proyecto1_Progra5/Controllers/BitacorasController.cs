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
    public class BitacorasController : Controller
    {
        private readonly AppDbContext _context;

        public BitacorasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Bitacoras
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Bitacoras.Include(b => b.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Bitacoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bitacoras == null)
            {
                return NotFound();
            }

            var bitacora = await _context.Bitacoras
                .Include(b => b.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bitacora == null)
            {
                return NotFound();
            }

            return View(bitacora);
        }

        // GET: Bitacoras/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NombreCompleto");
            return View();
        }

        // POST: Bitacoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaHoraInicio,FechaHoraFinal,Descripcion,UsuarioId")] Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bitacora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NombreCompleto", bitacora.UsuarioId);
            return View(bitacora);
        }

        // GET: Bitacoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bitacoras == null)
            {
                return NotFound();
            }

            var bitacora = await _context.Bitacoras.FindAsync(id);
            if (bitacora == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NombreCompleto", bitacora.UsuarioId);
            return View(bitacora);
        }

        // POST: Bitacoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHoraInicio,FechaHoraFinal,Descripcion,UsuarioId")] Bitacora bitacora)
        {
            if (id != bitacora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bitacora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BitacoraExists(bitacora.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NombreCompleto", bitacora.UsuarioId);
            return View(bitacora);
        }

        // GET: Bitacoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bitacoras == null)
            {
                return NotFound();
            }

            var bitacora = await _context.Bitacoras
                .Include(b => b.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bitacora == null)
            {
                return NotFound();
            }

            return View(bitacora);
        }

        // POST: Bitacoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bitacoras == null)
            {
                return Problem("Entity set 'AppDbContext.Bitacoras'  is null.");
            }
            var bitacora = await _context.Bitacoras.FindAsync(id);
            if (bitacora != null)
            {
                _context.Bitacoras.Remove(bitacora);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Calendar(int? id)
        {
            if (id != null)
            {
                
                var reservasUsuario = await _context.Reservas
                    .Where(r => r.UsuarioId == id)
                    .ToListAsync();

                
                var bitacorasIds = reservasUsuario.Select(r => r.UsuarioId).ToList();

                
                var listBitacora = await _context.Bitacoras
                    .Where(b => bitacorasIds.Contains(b.Id))
                    .ToListAsync();

                
                return View(listBitacora);
            }

            return View(new List<Bitacora>()); 
        }
        private bool BitacoraExists(int id)
        {
          return (_context.Bitacoras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
