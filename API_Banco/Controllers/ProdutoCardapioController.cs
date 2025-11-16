using Microsoft.AspNetCore.Mvc;
using Dominio;
using DataAccess;

//URL https://api.itera360.com.br/ProdutoCardapio
[Route("api/[controller]")]
[ApiController]
public class ProdutoCardapioController : ControllerBase
{
    private ProdutoCardapioRepositorio produtoRepositorio;

    public ProdutoCardapioController()
    {
        Contexto contexto = new Contexto();
        produtoRepositorio = new ProdutoCardapioRepositorio(contexto);
    }


    //Procurar Um Produto Pelo ID
    [HttpGet("{ProdutoID}")]
    public IActionResult ProdutoCardapioPeloId([FromRoute] int ProdutoID)
    {
        var Produto = produtoRepositorio.BuscarProdutoCardapio(ProdutoID);
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
    public IActionResult ListarProdutosCardapio()
    {
        var list = produtoRepositorio.ListarProdutoCardapio();
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
    public IActionResult DeletaProdutoCardapio([FromRoute] int ProdutoID)
    {
        var Produto = produtoRepositorio.BuscarProdutoCardapio(ProdutoID);
        if (Produto == null)
        {
            return NotFound();
        }

        produtoRepositorio.DeletaProdutoCardapio(Produto);
        return NoContent();
    }

    //Adicionar Produto
    [HttpPost]
    public IActionResult AdicionarProdutoCardapio([FromBody] ProdutoCardapio Produto)
    {
        produtoRepositorio.AdicionarProdutoCardapio(Produto);

        return Ok(new { Id = Produto.Id });
    }
}