using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Banco.Migrations
{
    /// <inheritdoc />
    public partial class Cavalo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardapio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCardapio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoProduto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosCardapio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    IDCardapio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosCardapio", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProdutosCardapio_Cardapio_IDCardapio",
                        column: x => x.IDCardapio,
                        principalTable: "Cardapio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosCardapio_Produtos_IDProduto",
                        column: x => x.IDProduto,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosComanda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    IDComanda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosComanda", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProdutosComanda_Comanda_IDComanda",
                        column: x => x.IDComanda,
                        principalTable: "Comanda",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosComanda_Produtos_IDProduto",
                        column: x => x.IDProduto,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosCardapio_IDCardapio",
                table: "ProdutosCardapio",
                column: "IDCardapio");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosCardapio_IDProduto",
                table: "ProdutosCardapio",
                column: "IDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosComanda_IDComanda",
                table: "ProdutosComanda",
                column: "IDComanda");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosComanda_IDProduto",
                table: "ProdutosComanda",
                column: "IDProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosCardapio");

            migrationBuilder.DropTable(
                name: "ProdutosComanda");

            migrationBuilder.DropTable(
                name: "Cardapio");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
