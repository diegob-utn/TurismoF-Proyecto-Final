using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    // Enums auxiliares

    public enum CategoriaPasajero
    {
        SinAsignar = -1, // <-- agregado para boletos "en inventario"
        Niño = 0,
        Adulto = 1,
        TerceraEdad = 2
    }

    public enum TipoAsiento
    {
        Preferencial = 0,
        Economico = 1
    }

    public enum TipoVagon
    {
        Preferencial = 0,
        Economico = 1
    }

    public enum EstadoReserva
    {
        Activa = 0,
        Cancelada = 1
    }

    public enum EstadoPago
    {
        Registrado = 0,
        Realizado = 1,
        Rechazado = 2
    }

    public enum EstadoViaje
    {
        Programado = 0,
        Finalizado = 1,
        Cancelado = 2
    }

    public enum EstadoTren
    {
        Activo = 0,
        Inactivo = 1
    }

    public enum EstadoBoleto
    {
        Disponible = -1, // <-- agregado para boletos "en inventario"
        Reservado = 0,
        Emitido = 1,
        Anulado = 2
    }

    public enum UbicacionAsiento
    {
        Ventana,
        Pasillo
    }
}