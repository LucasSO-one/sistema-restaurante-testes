using Microsoft.AspNetCore.Mvc;
using Dominio;
using DataAccess;

//URL https://api.itera360.com.br/Produto
[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private ProdutoRepositorio produtoRepositorio;

    public ProdutoController()
    {
        Contexto contexto = new Contexto();
        produtoRepositorio = new ProdutoRepositorio(contexto);
    }


    //Procurar Um Produto Pelo ID
    [HttpGet("{ProdutoID}")]
    public IActionResult ProdutoPeloId([FromRoute] int ProdutoID)
    {
        var Produto = produtoRepositorio.BuscarProduto(ProdutoID);
        if (Produto != null)
        {
            return Ok(Produto);
        }
        else
        {
            return NotFound();
        }
    }

    //Listar Produtos Disponiveis
    [HttpGet]
    public IActionResult ListarProdutos()
    {
        var list = produtoRepositorio.ListarProduto();
        if (list.Count > 0)
        {
            return Ok(list);
        }
        else if (list.Count <= 0)
        {
            return NotFound();
        }
        return NoContent();
    }

    //Deletar Produto Pelo ID
    [HttpDelete("{ProdutoID}")]
    public IActionResult DeletaProduto([FromRoute] int ProdutoID)
    {
        var Produto = produtoRepositorio.BuscarProduto(ProdutoID);
        if (Produto == null)
        {
            return NotFound();
        }

        produtoRepositorio.DeletaProduto(Produto);
        return NoContent();
    }

    //Adicionar Produto
    [HttpPost]
    public IActionResult AdicionarProduto([FromBody] Produto Produto)
    {
        produtoRepositorio.AdicionarProduto(Produto);

        return Ok(new { Id = Produto.Id });
    }
}