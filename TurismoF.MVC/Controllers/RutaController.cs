using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurismoF.Data.Data;
using TurismoF.Modelos;
using System.Text.Json;

namespace TurismoF.MVC.Controllers
{
    public class RutasController:Controller
    {
        private readonly Context1 _context;

        public RutasController(Context1 context)
        {
            _context = context;
        }

        // VIEW: Selección de Ruta y Mapa (NUEVO)
        public IActionResult SeleccionarRuta()
        {
            // Solo retorna la vista (la carga de rutas es vía JS usando AllJson)
            return View();
        }

        // En RutasController.cs
        public IActionResult Mapas(int id)
        {
            var ruta = _context.Rutas.Find(id);
            if(ruta == null) return NotFound();
            return View(ruta);
        }

        // GET: Rutas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rutas.ToListAsync());
        }

        // GET: Rutas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ruta = await _context.Rutas
                .FirstOrDefaultAsync(m => m.Id == id);
            if(ruta == null)
            {
                return NotFound();
            }

            // Serializa la ruta para que el JS de la vista la use fácilmente
            ViewBag.RutaJson = JsonSerializer.Serialize(new
            {
                nombre = ruta.Nombre,
                descripcion = ruta.Descripcion,
                ubicacionInicio = ruta.UbicacionInicio,
                ubicacionFin = ruta.UbicacionFin,
            });

            return View(ruta);
        }

        // GET: Rutas/AllJson
        // Útil si quieres mostrar todas las rutas en el mapa (Index)
        [HttpGet]
        public async Task<IActionResult> AllJson()
        {
            var rutas = await _context.Rutas.ToListAsync();
            var rutasJson = rutas.Select(r => new
            {
                id = r.Id,
                nombre = r.Nombre,
                descripcion = r.Descripcion,
                ubicacionInicio = r.UbicacionInicio,
                ubicacionFin = r.UbicacionFin,
            });
            return Json(rutasJson);
        }

        // GET: Rutas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rutas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,UbicacionInicio,UbicacionFin")] Ruta ruta)
        {
            if(ModelState.IsValid)
            {
                _context.Add(ruta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ruta);
        }

        // GET: Rutas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ruta = await _context.Rutas.FindAsync(id);
            if(ruta == null)
            {
                return NotFound();
            }
            return View(ruta);
        }

        // POST: Rutas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,UbicacionInicio,UbicacionFin")] Ruta ruta)
        {
            if(id != ruta.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(ruta);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!RutaExists(ruta.Id))
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
            return View(ruta);
        }

        // GET: Rutas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ruta = await _context.Rutas
                .FirstOrDefaultAsync(m => m.Id == id);
            if(ruta == null)
            {
                return NotFound();
            }

            return View(ruta);
        }

        // POST: Rutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);
            if(ruta != null)
            {
                _context.Rutas.Remove(ruta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RutaExists(int id)
        {
            return _context.Rutas.Any(e => e.Id == id);
        }
    }
}