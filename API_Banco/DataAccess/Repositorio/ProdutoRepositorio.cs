using DataAccess;
using Dominio;
public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly Contexto _contexto;
    public ProdutoRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    public void AdicionarProduto(Produto produto)
    {
        _contexto.Produtos.Add(produto);
        _contexto.SaveChanges();
    }

    public Produto BuscarProduto(int ProdutoID)
    {
        var produto = _contexto.Produtos.FirstOrDefault(produto => produto.Id == ProdutoID);
        return produto;
    }

    public void DeletaProduto(Produto produto)
    {
        _contexto.Produtos.Remove(produto);
    }

    public List<Produto> ListarProduto()
    {
        return _contexto.Produtos.ToList();
    }
}

