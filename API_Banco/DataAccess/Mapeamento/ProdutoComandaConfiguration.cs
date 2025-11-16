using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;
class ProdutoComandaConfiguration : IEntityTypeConfiguration<ProdutoComanda>
{
  public void Configure(EntityTypeBuilder<ProdutoComanda> builder)
  {
    builder.ToTable("ProdutosComanda").HasKey(ProdutoComanda => ProdutoComanda.Id);

    builder.Property(ProdutoComanda => ProdutoComanda.Id).HasColumnName("ID").IsRequired();
    builder.Property(ProdutoComanda => ProdutoComanda.ProdutoID).HasColumnName("IDProduto").IsRequired();
    builder.Property(ProdutoComanda => ProdutoComanda.ComandaID).HasColumnName("IDComanda").IsRequired();

    builder
      .HasOne(ProdutoComanda => ProdutoComanda.Produto)
      .WithMany(Produto => Produto.ProdutoComandas)
      .HasForeignKey(ProdutoComanda => ProdutoComanda.ProdutoID);
    builder
      .HasOne(ProdutoComanda => ProdutoComanda.Comanda)
      .WithMany(Comanda => Comanda.Produtos)
      .HasForeignKey(ProdutoComanda => ProdutoComanda.ComandaID);
  }

}