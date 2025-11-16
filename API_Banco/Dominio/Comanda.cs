namespace Dominio;
public class Comanda
{
    public int Id { get; set; }
    public string ClienteNome { get; set; }
    public List<ProdutoComanda> Produtos { get; set; }
}