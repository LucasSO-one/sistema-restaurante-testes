using Dominio;

public interface IProdutoRepositorio
{
    void AdicionarProduto(Produto produto);
    Produto BuscarProduto(int ProdutoID);
    public List<Produto> ListarProduto();
    void DeletaProduto(Produto produto);
}