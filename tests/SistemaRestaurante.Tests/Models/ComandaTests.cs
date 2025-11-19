using Xunit;

namespace SistemaRestaurante.Tests.Models
{
    public class ComandaTests
    {
        [Fact]
        public void Comanda_DeveSerCriadaComIdCorreto()
        {
            // Arrange & Act
            var comanda = new global::Dominio.Comanda { Id = 1 };

            // Assert
            Assert.Equal(1, comanda.Id);
        }

        [Fact]
        public void Comanda_DevePermitirAtribuirListaProdutos()
        {
            // Arrange & Act
            var comanda = new global::Dominio.Comanda();
            
            // Simular que a lista foi atribuída (como acontece no Entity Framework)
            comanda.Produtos = new List<global::Dominio.ProdutoComanda>();

            // Assert
            Assert.NotNull(comanda.Produtos);
            Assert.Empty(comanda.Produtos);
        }
    }
}