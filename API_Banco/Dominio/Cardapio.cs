namespace Dominio;
public class Cardapio
{
    public int Id { get; set; }
    public string TipoCardapio { get; set; }
    public List<ProdutoCardapio> Produtos { get; set; }
}