using Dominio;

public interface IProdutoRepositorioCardapio
{
    void AdicionarProdutoCardapio(ProdutoCardapio produtoCardapio);
    ProdutoCardapio BuscarProdutoCardapio(int ProdutoCardapioID);
    public List<ProdutoCardapio> ListarProdutoCardapio();
    void DeletaProdutoCardapio(ProdutoCardapio produtoCardapio);
}