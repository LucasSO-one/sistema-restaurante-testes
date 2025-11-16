using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;

class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos").HasKey(Produto => Produto.Id);

        builder.Property(Produto => Produto.Id).HasColumnName("ID").IsRequired();
        builder.Property(Produto => Produto.Nome).HasColumnName("NomeProduto").IsRequired();
        builder.Property(Produto => Produto.Preco).HasColumnName("PrecoProduto").IsRequired();    
    }

}