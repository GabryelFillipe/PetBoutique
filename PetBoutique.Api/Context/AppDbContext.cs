using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PetBoutique.Api.Entities;

namespace PetBoutique.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Carrinho>? Carrinho { get; set; }
    public DbSet<CarrinhoItem>? CarrinhoItens { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Usuario>? Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Script único para adicionar todas as Categorias
        modelBuilder.Entity<Categoria>().HasData(new Categoria[]
        {
            new Categoria { Id = 1, Nome = "Rações", IconCSS = "fas fa-bone" },
            new Categoria { Id = 2, Nome = "Brinquedos", IconCSS = "fas fa-futbol" },
            new Categoria { Id = 3, Nome = "Acessórios", IconCSS = "fas fa-tag" },
            new Categoria { Id = 4, Nome = "Higiene", IconCSS = "fas fa-bath" },
            new Categoria { Id = 5, Nome = "Caminhas", IconCSS = "fas fa-bed" }
        });

        // 2. Script único para adicionar todos os Produtos
        modelBuilder.Entity<Produto>().HasData(new Produto[]
        {
            // Categoria 1: Rações
            new Produto { Id = 1, Nome = "Ração Golden Special Cães Adultos 15kg", Descricao = "Ração premium sabor frango e carne para cães adultos de médio e grande porte.", ImagemUrl = "/Imagens/Racoes/golden15kg.png", Preco = 135.50m, Quantidade = 50, CategoriaId = 1 },
            new Produto { Id = 2, Nome = "Ração Premier Ambientes Internos 12kg", Descricao = "Alimento Super Premium para cães adultos que vivem dentro de casa.", ImagemUrl = "/Imagens/Racoes/premier12kg.png", Preco = 210.90m, Quantidade = 30, CategoriaId = 1 },
            new Produto { Id = 3, Nome = "Ração Royal Canin Shih Tzu 2.5kg", Descricao = "Nutrição específica para cães da raça Shih Tzu.", ImagemUrl = "/Imagens/Racoes/royalshih.png", Preco = 145.00m, Quantidade = 20, CategoriaId = 1 },
            new Produto { Id = 4, Nome = "Ração Pedigree Nutrição Essencial 10kg", Descricao = "Ração sabor carne para cães adultos.", ImagemUrl = "/Imagens/Racoes/pedigree10kg.png", Preco = 89.90m, Quantidade = 60, CategoriaId = 1 },
            new Produto { Id = 5, Nome = "Biscoito Pedigree Biscrok 500g", Descricao = "Petisco crocante para cães de todos os portes.", ImagemUrl = "/Imagens/Racoes/biscrok.png", Preco = 15.50m, Quantidade = 100, CategoriaId = 1 },

            // Categoria 2: Brinquedos
            new Produto { Id = 6, Nome = "Bolinha de Borracha Maciça", Descricao = "Bolinha super resistente para cães com mordida forte.", ImagemUrl = "/Imagens/Brinquedos/bolinhamacica.png", Preco = 25.00m, Quantidade = 40, CategoriaId = 2 },
            new Produto { Id = 7, Nome = "Corda com Nó para Morder", Descricao = "Corda resistente, ajuda na limpeza dos dentes enquanto o cão brinca.", ImagemUrl = "/Imagens/Brinquedos/cordano.png", Preco = 18.90m, Quantidade = 55, CategoriaId = 2 },
            new Produto { Id = 8, Nome = "Bolinha estilo Vôlei Penalty para Pets", Descricao = "Bolinha com textura e cores de bola de vôlei para diversão em quadra ou no parque.", ImagemUrl = "/Imagens/Brinquedos/bolapets.png", Preco = 22.50m, Quantidade = 30, CategoriaId = 2 },
            new Produto { Id = 9, Nome = "Frisbee Flexível", Descricao = "Frisbee de silicone que não machuca a boca do seu pet.", ImagemUrl = "/Imagens/Brinquedos/frisbee.png", Preco = 35.00m, Quantidade = 25, CategoriaId = 2 },
            new Produto { Id = 10, Nome = "Pelúcia com Apito", Descricao = "Brinquedo de pelúcia macio que emite som ao ser apertado.", ImagemUrl = "/Imagens/Brinquedos/pelucia.png", Preco = 28.90m, Quantidade = 45, CategoriaId = 2 },

            // Categoria 3: Acessórios
            new Produto { Id = 11, Nome = "Coleira Peitoral Antipuxão", Descricao = "Proporciona passeios mais tranquilos sem machucar o pescoço do animal.", ImagemUrl = "/Imagens/Acessorios/peitoral.png", Preco = 75.00m, Quantidade = 35, CategoriaId = 3 },
            new Produto { Id = 12, Nome = "Guia Retrátil 5 metros", Descricao = "Liberdade com segurança durante os passeios.", ImagemUrl = "/Imagens/Acessorios/guiaretratil.png", Preco = 55.90m, Quantidade = 40, CategoriaId = 3 },
            new Produto { Id = 13, Nome = "Comedouro de Inox Antiderrapante", Descricao = "Comedouro durável e fácil de limpar.", ImagemUrl = "/Imagens/Acessorios/comedouroinox.png", Preco = 32.00m, Quantidade = 60, CategoriaId = 3 },
            new Produto { Id = 14, Nome = "Bebedouro Fonte Automática", Descricao = "Água corrente e filtrada o dia todo para o seu pet.", ImagemUrl = "/Imagens/Acessorios/fonteagua.png", Preco = 140.00m, Quantidade = 15, CategoriaId = 3 },
            new Produto { Id = 15, Nome = "Plaquinha de Identificação Personalizável", Descricao = "Pingente de osso para gravação de nome e telefone.", ImagemUrl = "/Imagens/Acessorios/plaquinha.png", Preco = 12.50m, Quantidade = 100, CategoriaId = 3 },

            // Categoria 4: Higiene
            new Produto { Id = 16, Nome = "Tapete Higiênico Super Absorvente (30 un)", Descricao = "Tapetes com atrativo canino e fitas adesivas para fixação.", ImagemUrl = "/Imagens/Higiene/tapete.png", Preco = 65.00m, Quantidade = 80, CategoriaId = 4 },
            new Produto { Id = 17, Nome = "Shampoo Neutro Pelos Claros", Descricao = "Shampoo suave que realça a cor dos pelos.", ImagemUrl = "/Imagens/Higiene/shampoo.png", Preco = 26.90m, Quantidade = 50, CategoriaId = 4 },
            new Produto { Id = 18, Nome = "Escova Rasqueadeira", Descricao = "Remove pelos mortos e evita a formação de nós.", ImagemUrl = "/Imagens/Higiene/rasqueadeira.png", Preco = 30.00m, Quantidade = 40, CategoriaId = 4 },

            // Categoria 5: Caminhas
            new Produto { Id = 19, Nome = "Cama Almofadada Premium", Descricao = "Cama super macia com bordas elevadas para maior conforto.", ImagemUrl = "/Imagens/Caminhas/camapremium.png", Preco = 189.90m, Quantidade = 20, CategoriaId = 5 },
            new Produto { Id = 20, Nome = "Cama Iglu Conforto", Descricao = "Ideal para cães pequenos que gostam de se esconder para dormir.", ImagemUrl = "/Imagens/Caminhas/iglu.png", Preco = 120.00m, Quantidade = 15, CategoriaId = 5 },
            new Produto { Id = 21, Nome = "Colchonete Impermeável", Descricao = "Colchonete prático, fácil de limpar e transportar.", ImagemUrl = "/Imagens/Caminhas/colchonete.png", Preco = 85.00m, Quantidade = 30, CategoriaId = 5 }
        });

        // 3. Script único para adicionar os Usuários
        modelBuilder.Entity<Usuario>().HasData(new Usuario[]
        {
            new Usuario { Id = 1, NomeUsuario = "Gabryel" },
            new Usuario { Id = 2, NomeUsuario = "Guilherme" },
            new Usuario { Id = 3, NomeUsuario = "Breno" },
            new Usuario { Id = 4, NomeUsuario = "Macoratti" }
        });
    }
}