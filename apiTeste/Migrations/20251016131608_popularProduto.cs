using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiTeste.Migrations
{
    /// <inheritdoc />
    public partial class popularProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produtos(Nome,Preco, Estoque, Imagem, DataCadastro, CategoriaId) Values('coca',8.00,20,'coca.png',GETDATE(),5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
