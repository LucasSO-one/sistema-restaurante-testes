namespace Dominio;
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public List<ProdutoComanda> ProdutoComandas { get; set; }
    public List<ProdutoCardapio> ProdutoCardapios { get; set; }

    public Produto()
    {
        ProdutoComandas = new List<ProdutoComanda>();
        ProdutoCardapios = new List<ProdutoCardapio>();
    }

}