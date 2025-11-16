using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;
class ProdutoCardapioConfiguration : IEntityTypeConfiguration<ProdutoCardapio>
{
  public void Configure(EntityTypeBuilder<ProdutoCardapio> builder)
  {
    builder.ToTable("ProdutosCardapio").HasKey(ProdutoCardapio => ProdutoCardapio.Id);

    builder.Property(ProdutoCardapio => ProdutoCardapio.Id).HasColumnName("ID").IsRequired();
    builder.Property(ProdutoCardapio => ProdutoCardapio.ProdutoID).HasColumnName("IDProduto").IsRequired();
    builder.Property(ProdutoCardapio => ProdutoCardapio.CardapioID).HasColumnName("IDCardapio").IsRequired();

    builder
      .HasOne(ProdutoCardapio => ProdutoCardapio.Produto)
      .WithMany(Produto => Produto.ProdutoCardapios)
      .HasForeignKey(ProdutoCardapio => ProdutoCardapio.ProdutoID);
    builder
      .HasOne(ProdutoCardapio => ProdutoCardapio.Cardapio)
      .WithMany(Cardapio => Cardapio.Produtos)
      .HasForeignKey(ProdutoCardapio => ProdutoCardapio.CardapioID);

  }
}