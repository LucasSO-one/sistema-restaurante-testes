using System.Text.Json.Serialization;

namespace Dominio;
public class ProdutoCardapio
{
    public int Id { get; set; }
    public int ProdutoID { get; set; }
    
    [JsonIgnore]
    public Produto Produto { get; set; }
    
    public int CardapioID { get; set; }

    [JsonIgnore]
    public Cardapio Cardapio { get; set; }

}