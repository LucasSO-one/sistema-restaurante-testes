using DataAccess;
using Dominio;
public class ProdutoCardapioRepositorio : IProdutoRepositorioCardapio
{
    private readonly Contexto _contexto;
    public ProdutoCardapioRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    public void AdicionarProdutoCardapio(ProdutoCardapio produto)
    {
        _contexto.ProdutosCardapio.Add(produto);
        _contexto.SaveChanges();
    }

    public ProdutoCardapio BuscarProdutoCardapio(int ProdutoCardapioID)
    {
        var produtoCardapio = _contexto.ProdutosCardapio.FirstOrDefault(produtoCardapio => produtoCardapio.Id == ProdutoCardapioID);
        return produtoCardapio;
    }

    public void DeletaProdutoCardapio(ProdutoCardapio produto)
    {
        _contexto.ProdutosCardapio.Remove(produto);
    }

    public List<ProdutoCardapio> ListarProdutoCardapio()
    {
        return _contexto.ProdutosCardapio.ToList();
    }
}

