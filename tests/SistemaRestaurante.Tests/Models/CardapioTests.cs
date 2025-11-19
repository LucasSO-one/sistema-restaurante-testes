using Xunit;

namespace SistemaRestaurante.Tests.Models
{
    public class CardapioTests
    {
        [Fact]
        public void Cardapio_DeveInicializarListaProdutos_NoConstrutor()
        {
            // Arrange & Act
            var cardapio = new global::Dominio.Cardapio();

            // Assert
            Assert.NotNull(cardapio.Produtos);
            Assert.Empty(cardapio.Produtos);
        }

        [Fact]
        public void Cardapio_ComTipoCardapio_DeveSerCriadoCorretamente()
        {
            var cardapio = new global::Dominio.Cardapio 
            { 
                Id = 1, 
                TipoCardapio = "Jantar" 
            };
            Assert.Equal(1, cardapio.Id);
            Assert.Equal("Jantar", cardapio.TipoCardapio);
        }
    }
}