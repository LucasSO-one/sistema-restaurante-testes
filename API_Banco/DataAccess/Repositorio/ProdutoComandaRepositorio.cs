using DataAccess;
using Dominio;
public class ProdutoComandaRepositorio : IProdutoRepositorioComanda
{
    private readonly Contexto _contexto;
    public ProdutoComandaRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    public void AdicionarProdutoComanda(ProdutoComanda produto)
    {
        _contexto.ProdutosComanda.Add(produto);
        _contexto.SaveChanges();
    }

    public ProdutoComanda BuscarProdutoComanda(int ProdutoComandaID)
    {
        var produtoComanda = _contexto.ProdutosComanda.FirstOrDefault(produtoComanda => produtoComanda.Id == ProdutoComandaID);
        return produtoComanda;
    }

    public void DeletaProdutoComanda(ProdutoComanda produto)
    {
        _contexto.ProdutosComanda.Remove(produto);
    }

    public List<ProdutoComanda> ListarProdutoComanda()
    {
        return _contexto.ProdutosComanda.ToList();
    }
}

