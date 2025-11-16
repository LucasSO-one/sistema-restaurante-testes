namespace Dominio;
public class ProdutoComanda 
{
    public int Id { get; set; }
    public int ProdutoID { get; set; }
    public Produto Produto { get; set; }
    public int ComandaID { get; set; }
    public Comanda Comanda { get; set; }
    
}