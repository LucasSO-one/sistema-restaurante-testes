using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;
class ComandaConfiguration : IEntityTypeConfiguration<Comanda>
{
    public void Configure(EntityTypeBuilder<Comanda> builder)
    {
        builder.ToTable("Comanda").HasKey(Comanda => Comanda.Id);

        builder.Property(Comanda => Comanda.Id).HasColumnName("ID").IsRequired();
        builder.Property(Comanda => Comanda.ClienteNome).HasColumnName("NomeDoCliente").IsRequired();
    }
}