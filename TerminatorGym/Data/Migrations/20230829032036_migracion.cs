using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerminatorGym.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Miembro",
                columns: table => new
                {
                    MiembroId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miembro", x => x.MiembroId);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    ContactoId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiembroId = table.Column<short>(type: "smallint", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.ContactoId);
                    table.ForeignKey(
                        name: "FK_Contacto_Miembro_MiembroId",
                        column: x => x.MiembroId,
                        principalTable: "Miembro",
                        principalColumn: "MiembroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membresia",
                columns: table => new
                {
                    MembresiaId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiembroId = table.Column<short>(type: "smallint", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoMembresia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membresia", x => x.MembresiaId);
                    table.ForeignKey(
                        name: "FK_Membresia_Miembro_MiembroId",
                        column: x => x.MiembroId,
                        principalTable: "Miembro",
                        principalColumn: "MiembroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_MiembroId",
                table: "Contacto",
                column: "MiembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Membresia_MiembroId",
                table: "Membresia",
                column: "MiembroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Membresia");

            migrationBuilder.DropTable(
                name: "Miembro");
        }
    }
}
