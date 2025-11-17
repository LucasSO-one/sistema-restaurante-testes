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
    }
}