using Microsoft.AspNetCore.Mvc;
using Dominio;
using DataAccess;

//URL https://api.itera360.com.br/ProdutoComanda
[Route("api/[controller]")]
[ApiController]
public class ProdutoComandaController : ControllerBase
{
    private ProdutoComandaRepositorio produtoRepositorio;

    public ProdutoComandaController()
    {
        Contexto contexto = new Contexto();
        produtoRepositorio = new ProdutoComandaRepositorio(contexto);
    }


    //Procurar Um Produto Pelo ID
    [HttpGet("{ProdutoID}")]
    public IActionResult ProdutoComandaPeloId([FromRoute] int ProdutoID)
    {
        var Produto = produtoRepositorio.BuscarProdutoComanda(ProdutoID);
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
    public IActionResult ListarProdutosComanda()
    {
        var list = produtoRepositorio.ListarProdutoComanda();
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
    public IActionResult DeletaProdutoComanda([FromRoute] int ProdutoID)
    {
        var Produto = produtoRepositorio.BuscarProdutoComanda(ProdutoID);
        if (Produto == null)
        {
            return NotFound();
        }

        produtoRepositorio.DeletaProdutoComanda(Produto);
        return NoContent();
    }

    //Adicionar Produto
    [HttpPost]
    public IActionResult AdicionarProdutoComanda([FromBody] ProdutoComanda Produto)
    {
        produtoRepositorio.AdicionarProdutoComanda(Produto);

        return Ok(new { Id = Produto.Id });
    }
}