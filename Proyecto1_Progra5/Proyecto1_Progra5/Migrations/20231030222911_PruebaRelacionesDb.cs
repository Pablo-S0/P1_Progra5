using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto1_Progra5.Migrations
{
    /// <inheritdoc />
    public partial class PruebaRelacionesDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "ElementosCarritos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductosId",
                table: "ElementosCarritos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Carritos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Carritos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Bitacoras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TiposProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProducto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementosCarritos_CarritoId",
                table: "ElementosCarritos",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementosCarritos_ProductosId",
                table: "ElementosCarritos",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_ReservaId",
                table: "Carritos",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_UsuarioId",
                table: "Carritos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacoras_UsuarioId",
                table: "Bitacoras",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bitacoras_Usuarios_UsuarioId",
                table: "Bitacoras",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Reservas_ReservaId",
                table: "Carritos",
                column: "ReservaId",
                principalTable: "Reservas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioId",
                table: "Carritos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementosCarritos_Carritos_CarritoId",
                table: "ElementosCarritos",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementosCarritos_Productos_ProductosId",
                table: "ElementosCarritos",
                column: "ProductosId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bitacoras_Usuarios_UsuarioId",
                table: "Bitacoras");

            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Reservas_ReservaId",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioId",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementosCarritos_Carritos_CarritoId",
                table: "ElementosCarritos");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementosCarritos_Productos_ProductosId",
                table: "ElementosCarritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposProducto");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_ElementosCarritos_CarritoId",
                table: "ElementosCarritos");

            migrationBuilder.DropIndex(
                name: "IX_ElementosCarritos_ProductosId",
                table: "ElementosCarritos");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_ReservaId",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_UsuarioId",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Bitacoras_UsuarioId",
                table: "Bitacoras");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "ElementosCarritos");

            migrationBuilder.DropColumn(
                name: "ProductosId",
                table: "ElementosCarritos");

            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Bitacoras");
        }
    }
}
