using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TurismoF.Modelos;
using TurismoF.Modelos.Strategy;
using TurismoF.MVC.ViewModels;

namespace TurismoF.MVC.Controllers
{
    public class CompraController:Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new CompraViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Resumen(CompraViewModel model)
        {
            // Validación básica
            if(model.Cantidad < 1)
            {
                ModelState.AddModelError("Cantidad", "Debe ingresar una cantidad válida.");
                return View("Index", model);
            }

            var boletos = new List<Boleto>();
            for(int i = 0; i < model.Cantidad; i++)
            {
                boletos.Add(new Boleto
                {
                    TipoAsiento = model.TipoAsiento,
                    Categoria = model.Categoria
                });
            }

            ICalculadoraPrecio calculadora = new CalculadoraPrecioMayorDescuento();
            model.PrecioTotal = calculadora.CalcularPrecioTotal(boletos);

            return View(model);
        }

        [HttpPost]
        public IActionResult Confirmar(CompraViewModel model)
        {
            model.Mensaje = "¡Compra realizada con éxito!";
            return View("Exito", model);
        }
    }
}