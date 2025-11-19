using DataAccess;
using Dominio;
using Microsoft.AspNetCore.Mvc;

//URL https://api.itera360.com.br/Cardapio
[Route("api/[controller]")]
[ApiController]
public class CardapioController : ControllerBase
{
    private CardapioRepositorio cardapioRepositorio;

    public CardapioController()
    {
        Contexto contexto = new Contexto();
        cardapioRepositorio = new CardapioRepositorio(contexto);
    }

    //Procurar Um Cardapio Pelo ID
    [HttpGet("{CardapioID}")]
    public IActionResult CardapioPeloId([FromRoute] int CardapioID)
    {
        var cardapio = cardapioRepositorio.BuscarCardapio(CardapioID);
        if (cardapio != null)
        {
            return Ok(cardapio);
        }
        else
        {
            return NotFound();
        }
    }

    //Listar Cardapios Disponiveis
    // CORREÇÃO 1: Retornar a lista em vez do repositório
    [HttpGet]
    public IActionResult ListarCardapios()
    {
        var list = cardapioRepositorio.ListarCardapio();
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

    //Deletar Cardapio Pelo ID
    [HttpDelete("{CardapioID}")]
    public IActionResult DeletaCardapio([FromRoute] int CardapioID)
    {
        var cardapio = cardapioRepositorio.BuscarCardapio(CardapioID);
        if (cardapio == null)
        {
            return NotFound();
        }

        cardapioRepositorio.DeletaCardapio(cardapio);
        return NoContent();
    }

    //Adicionar Cardapio
    [HttpPost]
    public IActionResult AdicionarCardapio([FromBody] Cardapio cardapio)
    {
        cardapioRepositorio.AdicionarCardapio(cardapio);
        return Ok();
    }
}