using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TurismoF.Data.Migrations
{
    /// <inheritdoc />
    public partial class v1post : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    UbicacionInicio = table.Column<string>(type: "text", nullable: false),
                    UbicacionFin = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    CantidadVagones = table.Column<int>(type: "integer", nullable: false),
                    CantidadAsientosPorVagon = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreciosConfiguracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Categoria = table.Column<int>(type: "integer", nullable: false),
                    TipoAsiento = table.Column<int>(type: "integer", nullable: false),
                    PrecioBase = table.Column<decimal>(type: "numeric", nullable: false),
                    Descuento = table.Column<decimal>(type: "numeric", nullable: false),
                    RutaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreciosConfiguracion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreciosConfiguracion_Rutas_RutaId",
                        column: x => x.RutaId,
                        principalTable: "Rutas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vagones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    TipoVagon = table.Column<int>(type: "integer", nullable: false),
                    EsPreferencial = table.Column<bool>(type: "boolean", nullable: false),
                    TrenId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vagones_Trenes_TrenId",
                        column: x => x.TrenId,
                        principalTable: "Trenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaSalida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoraSalida = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    RutaId = table.Column<int>(type: "integer", nullable: false),
                    TrenId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viajes_Rutas_RutaId",
                        column: x => x.RutaId,
                        principalTable: "Rutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Viajes_Trenes_TrenId",
                        column: x => x.TrenId,
                        principalTable: "Trenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    TipoAsiento = table.Column<int>(type: "integer", nullable: false),
                    Ubicacion = table.Column<int>(type: "integer", nullable: false),
                    Fila = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    VagonId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asientos_Vagones_VagonId",
                        column: x => x.VagonId,
                        principalTable: "Vagones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaReserva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "integer", nullable: false),
                    ViajeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Viajes_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boletos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Categoria = table.Column<int>(type: "integer", nullable: false),
                    TipoAsiento = table.Column<int>(type: "integer", nullable: false),
                    PrecioFinal = table.Column<decimal>(type: "numeric", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    ReservaId = table.Column<int>(type: "integer", nullable: true),
                    ViajeId = table.Column<int>(type: "integer", nullable: true),
                    AsientoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boletos_Asientos_AsientoId",
                        column: x => x.AsientoId,
                        principalTable: "Asientos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Boletos_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Boletos_Viajes_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viajes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaPago = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Monto = table.Column<decimal>(type: "numeric", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    ReservaId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_VagonId",
                table: "Asientos",
                column: "VagonId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_AsientoId",
                table: "Boletos",
                column: "AsientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_ReservaId",
                table: "Boletos",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_ViajeId",
                table: "Boletos",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ApplicationUserId",
                table: "Pagos",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ReservaId",
                table: "Pagos",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_PreciosConfiguracion_RutaId",
                table: "PreciosConfiguracion",
                column: "RutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ApplicationUserId",
                table: "Reservas",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ViajeId",
                table: "Reservas",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vagones_TrenId",
                table: "Vagones",
                column: "TrenId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_RutaId",
                table: "Viajes",
                column: "RutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_TrenId",
                table: "Viajes",
                column: "TrenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletos");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "PreciosConfiguracion");

            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Vagones");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Trenes");
        }
    }
}
