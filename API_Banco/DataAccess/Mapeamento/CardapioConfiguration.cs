using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;
class CardapioConfiguration : IEntityTypeConfiguration<Cardapio>
{
    public void Configure(EntityTypeBuilder<Cardapio> builder)
    {
        builder.ToTable("Cardapio").HasKey(Cardapio => Cardapio.Id);

        builder.Property(Cardapio => Cardapio.Id).HasColumnName("ID").IsRequired();
        builder.Property(Cardapio => Cardapio.TipoCardapio).HasColumnName("TipoCardapio");   
    }
}