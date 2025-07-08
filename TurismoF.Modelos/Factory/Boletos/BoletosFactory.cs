using System;
using System.Collections.Generic;
using TurismoF.Modelos;

namespace TurismoF.Modelos.Factory.Boletos
{
    public static class BoletosFactory
    {
        public static Boleto CrearBoleto(CategoriaPasajero categoria, Asiento asiento)
        {
            Boleto boleto;
            if(asiento.TipoAsiento == TipoAsiento.Preferencial)
                boleto = new BoletoPreferencial();
            else
                boleto = new BoletoEstandar();

            boleto.Categoria = categoria;
            boleto.TipoAsiento = asiento.TipoAsiento;
            boleto.AsientoId = asiento.Id;
            boleto.Estado = EstadoBoleto.Disponible;
            boleto.PrecioFinal = 0;
            boleto.FechaEmision = DateTime.MinValue;
            boleto.ReservaId = null;
            boleto.ViajeId = null;
            boleto.Asiento = asiento;

            return boleto;
        }

        public static List<Boleto> GenerarBoletosParaTren(Tren tren, CategoriaPasajero categoria)
        {
            var boletos = new List<Boleto>();
            if(tren.Vagones == null) return boletos;
            foreach(var vagon in tren.Vagones)
            {
                if(vagon.Asientos == null) continue;
                foreach(var asiento in vagon.Asientos)
                {
                    var boleto = CrearBoleto(categoria, asiento);
                    boletos.Add(boleto);

                    // Relación inversa
                    if(asiento.Boletos == null)
                        asiento.Boletos = new List<Boleto>();
                    asiento.Boletos.Add(boleto);
                }
            }
            return boletos;
        }
    }
}