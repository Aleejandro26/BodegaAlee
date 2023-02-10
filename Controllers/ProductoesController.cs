using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bodega.Data;
using Bodega.Models;
using Bodega.Configuration;

namespace Bodega.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly BodegaContext _context;
        private readonly IUnidadTrabajo _unidadTrabajo;

        public ProductoesController(BodegaContext context, IUnidadTrabajo unidadTrabajo)
        {
            _context = context;
            _unidadTrabajo = unidadTrabajo;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            return View(await _unidadTrabajo.ProductoRepositorio.GetAllSync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var producto = await _unidadTrabajo.ProductoRepositorio.GetByIdAsybc(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Existencia,PrecioVenta,PrecioCosto,Estado,Categoria,IdFactura")] Producto producto)
        {
            _unidadTrabajo.ProductoRepositorio.Add(producto);
            _unidadTrabajo.Commit();
            return RedirectToAction(nameof(Index));
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _unidadTrabajo.ProductoRepositorio.GetByIdAsybc(id);

            if (producto == null)
            {
                return NotFound();
            }
            ViewData["IdFactura"] = new SelectList(_context.Factura, "Id", "id", producto.Id);
            return View(producto); //aca me quede XD
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Existencia,PrecioVenta,PrecioCosto,Estado,Categoria,IdFactura")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            try
            {
                _unidadTrabajo.ProductoRepositorio.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(producto.Id))
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
        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            var producto = await _unidadTrabajo.ProductoRepositorio.GetByIdAsybc(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Producto == null)
            {
                return Problem("Entity set 'BodegaContext.Producto'  is null.");
            }

            _unidadTrabajo.ProductoRepositorio.Delete(id);
            _unidadTrabajo.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _unidadTrabajo.ProductoRepositorio.GetByIdAsybc(id) != null;
        }
    }
}
