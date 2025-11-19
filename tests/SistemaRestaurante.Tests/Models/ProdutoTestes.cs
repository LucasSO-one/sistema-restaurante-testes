using Xunit;

namespace SistemaRestaurante.Tests.Models
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_DeveInicializarListas_NoConstrutor()
        {
            // Arrange & Act
            var produto = new global::Dominio.Produto();

            // Assert
            Assert.NotNull(produto.ProdutoComandas);
            Assert.NotNull(produto.ProdutoCardapios);
        }

        [Fact]
        public void Produto_ComDadosValidos_DeveSerCriadoCorretamente()
        {
            // Arrange & Act
            var produto = new global::Dominio.Produto
            { 
                Id = 1, 
                Nome = "Hambúrguer", 
                Preco = 25.90 
            };

            // Assert
            Assert.Equal(1, produto.Id);
            Assert.Equal("Hambúrguer", produto.Nome);
            Assert.Equal(25.90, produto.Preco);
        }
        
        [Fact]
        public void Produto_ComPrecoZero_DeveSerPermitido()
        {
            var produto = new global::Dominio.Produto 
            { 
                Nome = "Amostra Grátis", 
                Preco = 0 
            };
            Assert.Equal(0, produto.Preco);
        }

        [Fact]
        public void Produto_ComNomeLongo_DeveSerPermitido()
        {
            var produto = new global::Dominio.Produto 
            { 
                Nome = "Hambúrguer Artesanal com Queijo e Bacon", 
                Preco = 35.90 
            };
            Assert.Equal("Hambúrguer Artesanal com Queijo e Bacon", produto.Nome);
        }
    }
}