using System;
using System.Collections.Generic;
using TurismoF.Modelos;

namespace TurismoF.Modelos.Factory
{
    public class TrenCompletoFactory
    {
        /// <summary>
        /// Crea un tren completo con numeración individual por vagon y diferenciando tipo y ubicación de asientos.
        /// </summary>
        public static Tren CrearTrenCompleto(
            string nombre,
            EstadoTren estado,
            int cantidadVagones,
            int cantidadVagonesPreferenciales,
            int filasPorVagon,
            int asientosPorFila)
        {
            var tren = new Tren
            {
                Nombre = nombre,
                Estado = estado,
                CantidadVagones = cantidadVagones,
                CantidadAsientosPorVagon = filasPorVagon * asientosPorFila,
                Vagones = new List<Vagon>()
            };

            for(int i = 1; i <= cantidadVagones; i++)
            {
                // Asigna tipo de vagón según el índice
                TipoVagon tipoVagon = i <= cantidadVagonesPreferenciales ? TipoVagon.Preferencial : TipoVagon.Economico;

                var vagon = new Vagon
                {
                    Numero = i,
                    TipoVagon = tipoVagon,
                    EsPreferencial = tipoVagon == TipoVagon.Preferencial,
                    Asientos = new List<Asiento>()
                };

                int contadorAsientoVagon = 1; // Reinicia en cada vagón

                for(int f = 0; f < filasPorVagon; f++)
                {
                    for(int n = 1; n <= asientosPorFila; n++)
                    {
                        // TipoAsiento y UbicacionAsiento son enums distintos
                        TipoAsiento tipoAsiento = tipoVagon == TipoVagon.Preferencial ? TipoAsiento.Preferencial : TipoAsiento.Economico;
                        UbicacionAsiento ubicacion;
                        string sufijoTipo;

                        if(n == 1 || n == asientosPorFila) // extremos = ventana
                        {
                            ubicacion = UbicacionAsiento.Ventana;
                            sufijoTipo = "V";
                        }
                        else
                        {
                            ubicacion = UbicacionAsiento.Pasillo;
                            sufijoTipo = "P";
                        }

                        string codigoAsiento = $"{sufijoTipo}{contadorAsientoVagon++}";

                        var asiento = new Asiento
                        {
                            // NO ASIGNES Id, EF Core/BD lo hará automáticamente
                            Codigo = codigoAsiento,
                            TipoAsiento = tipoAsiento,      // Preferencial/Economico
                            Ubicacion = ubicacion,          // Ventana/Pasillo
                            Fila = "",                      // Puedes ajustar si necesitas filas tipo "A", "B", etc.
                            Numero = n,
                            Vagon = vagon,
                            VagonId = vagon.Numero,
                            Boletos = new List<Boleto>()
                        };

                        var boleto = new Boleto
                        {
                            Asiento = asiento,
                            // AsientoId se asigna automáticamente al guardar en la BD si usas relaciones bien configuradas.
                            Estado = EstadoBoleto.Disponible,
                            TipoAsiento = asiento.TipoAsiento,
                            Categoria = CategoriaPasajero.SinAsignar
                        };

                        asiento.Boletos.Add(boleto);
                        vagon.Asientos.Add(asiento);
                    }
                }

                tren.Vagones.Add(vagon);
            }

            return tren;
        }
    }
}