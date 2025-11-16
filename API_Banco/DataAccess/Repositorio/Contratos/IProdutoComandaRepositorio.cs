using Dominio;

public interface IProdutoRepositorioComanda
{
    void AdicionarProdutoComanda(ProdutoComanda produtoComanda);
    ProdutoComanda BuscarProdutoComanda(int ProdutoComandaID);
    public List<ProdutoComanda> ListarProdutoComanda();
    void DeletaProdutoComanda(ProdutoComanda produtoComanda);
}