using Microsoft.EntityFrameworkCore;
using Dominio;

namespace DataAccess;

public class Contexto : DbContext
{
    internal int length;

    public DbSet<ProdutoCardapio> ProdutosCardapio { get; set; }
    public DbSet<ProdutoComanda> ProdutosComanda { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Comanda> Comandas { get; set; }
    public DbSet<Cardapio> Cardapios { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=GerenciamentoDeComandas;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        modelBuilder.ApplyConfiguration(new ProdutoCardapioConfiguration());
        modelBuilder.ApplyConfiguration(new ProdutoComandaConfiguration());
        modelBuilder.ApplyConfiguration(new ComandaConfiguration());
        modelBuilder.ApplyConfiguration(new CardapioConfiguration());
    }
}