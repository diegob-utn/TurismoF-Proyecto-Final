using Microsoft.EntityFrameworkCore;

namespace TurismoF.Data.Data
{
    public class Context1 : DbContext
    {
        public Context1(DbContextOptions<Context1> options)
            : base(options)
        {
        }

        public DbSet<TurismoF.Modelos.Asiento> Asientos { get; set; } = default!;
        public DbSet<TurismoF.Modelos.Boleto> Boletos { get; set; } = default!;
        public DbSet<TurismoF.Modelos.ApplicationUser> ApplicationUsers { get; set; } = default!;
        public DbSet<TurismoF.Modelos.Pago> Pagos { get; set; } = default!;
        public DbSet<TurismoF.Modelos.PrecioConfiguracion> PreciosConfiguracion { get; set; } = default!;
        public DbSet<TurismoF.Modelos.Reserva> Reservas { get; set; } = default!;
        public DbSet<TurismoF.Modelos.Ruta> Rutas { get; set; } = default!;
        public DbSet<TurismoF.Modelos.Tren> Trenes { get; set; } = default!;
        public DbSet<TurismoF.Modelos.Vagon> Vagones { get; set; } = default!;
        public DbSet<TurismoF.Modelos.Viaje> Viajes { get; set; } = default!;
    }
}
