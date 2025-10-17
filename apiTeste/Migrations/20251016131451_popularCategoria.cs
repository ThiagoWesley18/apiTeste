using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiTeste.Migrations
{
    /// <inheritdoc />
    public partial class popularCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categorias(Nome, Image) Values('Bebidas','Bebida.jpg')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}
