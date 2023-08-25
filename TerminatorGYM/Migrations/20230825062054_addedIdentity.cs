using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerminatorGYM.Migrations
{
    /// <inheritdoc />
    public partial class addedIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Fecha_Evento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoID", x => x.EventoID);
                });

            migrationBuilder.CreateTable(
                name: "Miembros",
                columns: table => new
                {
                    MiembroID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiembroID", x => x.MiembroID);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    ContactoID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiembroID = table.Column<short>(type: "smallint", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Correo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoID", x => x.ContactoID);
                    table.ForeignKey(
                        name: "FK_Miembros_MiembroID",
                        column: x => x.MiembroID,
                        principalTable: "Miembros",
                        principalColumn: "MiembroID");
                });

            migrationBuilder.CreateTable(
                name: "Membresias",
                columns: table => new
                {
                    MembresiaID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiembroID = table.Column<short>(type: "smallint", nullable: false),
                    Precio = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Fecha_Vencimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Tipo_Membresia = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembresiaID", x => x.MembresiaID);
                    table.ForeignKey(
                        name: "FK_M_Miembros_MiembroID",
                        column: x => x.MiembroID,
                        principalTable: "Miembros",
                        principalColumn: "MiembroID");
                });

            migrationBuilder.CreateTable(
                name: "Miembros_Eventos",
                columns: table => new
                {
                    MiembroID = table.Column<short>(type: "smallint", nullable: false),
                    EventoID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ME_Eventos_EventoID",
                        column: x => x.EventoID,
                        principalTable: "Eventos",
                        principalColumn: "EventoID");
                    table.ForeignKey(
                        name: "FK_ME_Miembros_MiembroID",
                        column: x => x.MiembroID,
                        principalTable: "Miembros",
                        principalColumn: "MiembroID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_MiembroID",
                table: "Contacto",
                column: "MiembroID");

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_MiembroID",
                table: "Membresias",
                column: "MiembroID");

            migrationBuilder.CreateIndex(
                name: "IX_Miembros_Eventos_EventoID",
                table: "Miembros_Eventos",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_Miembros_Eventos_MiembroID",
                table: "Miembros_Eventos",
                column: "MiembroID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Membresias");

            migrationBuilder.DropTable(
                name: "Miembros_Eventos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Miembros");
        }
    }
}
