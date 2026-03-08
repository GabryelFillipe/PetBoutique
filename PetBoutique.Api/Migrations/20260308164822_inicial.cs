using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetBoutique.Api.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IconCSS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrinho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrinho_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    CarrinhoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoItens_Carrinho_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoItens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "IconCSS", "Nome" },
                values: new object[,]
                {
                    { 1, "fas fa-bone", "Rações" },
                    { 2, "fas fa-futbol", "Brinquedos" },
                    { 3, "fas fa-tag", "Acessórios" },
                    { 4, "fas fa-bath", "Higiene" },
                    { 5, "fas fa-bed", "Caminhas" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "NomeUsuario" },
                values: new object[,]
                {
                    { 1, "Gabryel" },
                    { 2, "Guilherme" },
                    { 3, "Breno" },
                    { 4, "Macoratti" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "ImagemUrl", "Nome", "Preco", "Quantidade" },
                values: new object[,]
                {
                    { 1, 1, "Ração premium sabor frango e carne para cães adultos de médio e grande porte.", "/Imagens/Racoes/golden15kg.png", "Ração Golden Special Cães Adultos 15kg", 135.50m, 50 },
                    { 2, 1, "Alimento Super Premium para cães adultos que vivem dentro de casa.", "/Imagens/Racoes/premier12kg.png", "Ração Premier Ambientes Internos 12kg", 210.90m, 30 },
                    { 3, 1, "Nutrição específica para cães da raça Shih Tzu.", "/Imagens/Racoes/royalshih.png", "Ração Royal Canin Shih Tzu 2.5kg", 145.00m, 20 },
                    { 4, 1, "Ração sabor carne para cães adultos.", "/Imagens/Racoes/pedigree10kg.png", "Ração Pedigree Nutrição Essencial 10kg", 89.90m, 60 },
                    { 5, 1, "Petisco crocante para cães de todos os portes.", "/Imagens/Racoes/biscrok.png", "Biscoito Pedigree Biscrok 500g", 15.50m, 100 },
                    { 6, 2, "Bolinha super resistente para cães com mordida forte.", "/Imagens/Brinquedos/bolinhamacica.png", "Bolinha de Borracha Maciça", 25.00m, 40 },
                    { 7, 2, "Corda resistente, ajuda na limpeza dos dentes enquanto o cão brinca.", "/Imagens/Brinquedos/cordano.png", "Corda com Nó para Morder", 18.90m, 55 },
                    { 8, 2, "Bolinha com textura e cores de bola de vôlei para diversão em quadra ou no parque.", "/Imagens/Brinquedos/bolapets.png", "Bolinha estilo Vôlei Penalty para Pets", 22.50m, 30 },
                    { 9, 2, "Frisbee de silicone que não machuca a boca do seu pet.", "/Imagens/Brinquedos/frisbee.png", "Frisbee Flexível", 35.00m, 25 },
                    { 10, 2, "Brinquedo de pelúcia macio que emite som ao ser apertado.", "/Imagens/Brinquedos/pelucia.png", "Pelúcia com Apito", 28.90m, 45 },
                    { 11, 3, "Proporciona passeios mais tranquilos sem machucar o pescoço do animal.", "/Imagens/Acessorios/peitoral.png", "Coleira Peitoral Antipuxão", 75.00m, 35 },
                    { 12, 3, "Liberdade com segurança durante os passeios.", "/Imagens/Acessorios/guiaretratil.png", "Guia Retrátil 5 metros", 55.90m, 40 },
                    { 13, 3, "Comedouro durável e fácil de limpar.", "/Imagens/Acessorios/comedouroinox.png", "Comedouro de Inox Antiderrapante", 32.00m, 60 },
                    { 14, 3, "Água corrente e filtrada o dia todo para o seu pet.", "/Imagens/Acessorios/fonteagua.png", "Bebedouro Fonte Automática", 140.00m, 15 },
                    { 15, 3, "Pingente de osso para gravação de nome e telefone.", "/Imagens/Acessorios/plaquinha.png", "Plaquinha de Identificação Personalizável", 12.50m, 100 },
                    { 16, 4, "Tapetes com atrativo canino e fitas adesivas para fixação.", "/Imagens/Higiene/tapete.png", "Tapete Higiênico Super Absorvente (30 un)", 65.00m, 80 },
                    { 17, 4, "Shampoo suave que realça a cor dos pelos.", "/Imagens/Higiene/shampoo.png", "Shampoo Neutro Pelos Claros", 26.90m, 50 },
                    { 18, 4, "Remove pelos mortos e evita a formação de nós.", "/Imagens/Higiene/rasqueadeira.png", "Escova Rasqueadeira", 30.00m, 40 },
                    { 19, 5, "Cama super macia com bordas elevadas para maior conforto.", "/Imagens/Caminhas/camapremium.png", "Cama Almofadada Premium", 189.90m, 20 },
                    { 20, 5, "Ideal para cães pequenos que gostam de se esconder para dormir.", "/Imagens/Caminhas/iglu.png", "Cama Iglu Conforto", 120.00m, 15 },
                    { 21, 5, "Colchonete prático, fácil de limpar e transportar.", "/Imagens/Caminhas/colchonete.png", "Colchonete Impermeável", 85.00m, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItens_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItens_ProdutoId",
                table: "CarrinhoItens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoItens");

            migrationBuilder.DropTable(
                name: "Carrinho");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
