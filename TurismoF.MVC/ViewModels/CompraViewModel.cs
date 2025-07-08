using System.Collections.Generic;
using TurismoF.Modelos;

namespace TurismoF.MVC.ViewModels
{
    public class CompraViewModel
    {
        public TipoAsiento TipoAsiento { get; set; }
        public CategoriaPasajero Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
        public string Mensaje { get; set; }
    }
}
