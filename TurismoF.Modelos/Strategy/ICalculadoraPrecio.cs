using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurismoF.Modelos;
using System.Collections.Generic;

using TurismoF.Modelos;

using System.Collections.Generic;
using TurismoF.Modelos;

using System;
using System.Collections.Generic;
using System.Linq;
using TurismoF.Modelos;
using TurismoF.Modelos.Factory;

namespace TurismoF.Modelos.Strategy
{
    public interface ICalculadoraPrecio
    {
        decimal CalcularPrecioTotal(List<Boleto> boletos);
    }

    // 1. Estrategia: Descuento por grupo homogéneo (tu lógica actual)
    public class CalculadoraPrecioHomogeneo:ICalculadoraPrecio
    {
        private readonly Dictionary<(TipoAsiento, CategoriaPasajero), (decimal precio, decimal descuento)> _precios;

        public CalculadoraPrecioHomogeneo()
        {
            _precios = new()
            {
                { (TipoAsiento.Preferencial, CategoriaPasajero.Niño), (20m, 0.10m) },            // 10%
                { (TipoAsiento.Preferencial, CategoriaPasajero.Adulto), (35m, 0.05m) },         // 5%
                { (TipoAsiento.Preferencial, CategoriaPasajero.TerceraEdad), (25m, 0.10m) },   // 10%
                { (TipoAsiento.Economico, CategoriaPasajero.Niño), (14m, 0.20m) },             // 20%
                { (TipoAsiento.Economico, CategoriaPasajero.Adulto), (25m, 0.10m) },           // 10%
                { (TipoAsiento.Economico, CategoriaPasajero.TerceraEdad), (18m, 0.20m) }       // 20%
            };
        }

        public decimal CalcularPrecioTotal(List<Boleto> boletos)
        {
            decimal total = 0;

            // Agrupar por tipo y categoría
            var grupos = boletos
                .GroupBy(b => (b.TipoAsiento, b.Categoria));

            foreach(var grupo in grupos)
            {
                var key = grupo.Key;
                var cantidad = grupo.Count();
                var (precio, descuento) = _precios[key];

                if(cantidad >= 3)
                {
                    total += cantidad * precio * (1 - descuento);
                }
                else
                {
                    total += cantidad * precio;
                }
            }

            return total;
        }
    }

    // 2. Estrategia: Descuento general por cantidad (3 o más de cualquier tipo)
    public class CalculadoraPrecioGeneral:ICalculadoraPrecio
    {
        private readonly Dictionary<(TipoAsiento, CategoriaPasajero), decimal> _precios;
        private readonly decimal _descuentoGeneral; // Por ejemplo, 10% para 3 o más boletos

        public CalculadoraPrecioGeneral()
        {
            _precios = new()
            {
                { (TipoAsiento.Preferencial, CategoriaPasajero.Niño), 20m },
                { (TipoAsiento.Preferencial, CategoriaPasajero.Adulto), 35m },
                { (TipoAsiento.Preferencial, CategoriaPasajero.TerceraEdad), 25m },
                { (TipoAsiento.Economico, CategoriaPasajero.Niño), 14m },
                { (TipoAsiento.Economico, CategoriaPasajero.Adulto), 25m },
                { (TipoAsiento.Economico, CategoriaPasajero.TerceraEdad), 18m }
            };
            _descuentoGeneral = 0.10m; // 10% de descuento general por 3 o más boletos
        }

        public decimal CalcularPrecioTotal(List<Boleto> boletos)
        {
            decimal total = 0;

            foreach(var boleto in boletos)
            {
                total += _precios[(boleto.TipoAsiento, boleto.Categoria)];
            }

            if(boletos.Count >= 3)
            {
                total *= (1 - _descuentoGeneral);
            }

            return total;
        }
    }

    // 3. Estrategia: la que te da más descuento
    public class CalculadoraPrecioMayorDescuento:ICalculadoraPrecio
    {
        private readonly ICalculadoraPrecio _homogeneo;
        private readonly ICalculadoraPrecio _general;

        public CalculadoraPrecioMayorDescuento()
        {
            _homogeneo = new CalculadoraPrecioHomogeneo();
            _general = new CalculadoraPrecioGeneral();
        }

        public decimal CalcularPrecioTotal(List<Boleto> boletos)
        {
            decimal totalHomogeneo = _homogeneo.CalcularPrecioTotal(boletos);
            decimal totalGeneral = _general.CalcularPrecioTotal(boletos);
            return Math.Min(totalHomogeneo, totalGeneral);
        }
    }
}
