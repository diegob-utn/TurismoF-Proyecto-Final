using Microsoft.AspNetCore.Mvc;
using TurismoF.Modelos;
using TurismoF.Modelos.Factory;
using TurismoF.Data.Data;

namespace TurismoF.MVC.Controllers
{
    public class AdminTrenController:Controller
    {
        private readonly Context1 _context;
        public AdminTrenController(Context1 context)
        {
            _context = context;
        }

        // GET: Formulario para crear tren
        public IActionResult CrearTrenCompleto()
        {
            return View();
        }

        // POST: Genera tren usando el factory y guarda en la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearTrenCompleto(string nombre, EstadoTren estado, int cantidadVagones, int cantidadPreferenciales, int filasPorVagon, int asientosPorFila)
        {
            var tren = TrenCompletoFactory.CrearTrenCompleto(nombre, estado, cantidadVagones, cantidadPreferenciales, filasPorVagon, asientosPorFila);
            _context.Trenes.Add(tren);
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = "¡Tren creado correctamente!";
            return RedirectToAction("CrearTrenCompleto");
        }
    }
}
