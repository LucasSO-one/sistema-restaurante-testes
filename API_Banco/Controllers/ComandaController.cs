using Microsoft.AspNetCore.Mvc;
using Dominio;
using DataAccess;

//URL https://api.itera360.com.br/Comanda
[Route("api/[controller]")]
[ApiController]
public class ComandaController : ControllerBase
{
    private ComandaRepositorio comandaRepositorio;

    public ComandaController()
    {
        Contexto contexto = new Contexto();
        comandaRepositorio = new ComandaRepositorio(contexto);
    }


    //Procurar Um Comanda Pelo ID
    [HttpGet("{ComandaID}")]
    public IActionResult ComandaPeloId([FromRoute] int ComandaID)
    {
        var Comanda = comandaRepositorio.BuscarComanda(ComandaID);
        if (Comanda != null)
        {
            return Ok(Comanda);
        }
        else
        {
            return NotFound();
        }
    }

    //Listar Comandas Disponiveis
    [HttpGet]
    public IActionResult ListarComandas()
    {
        var list = comandaRepositorio.ListarComanda();
        if (list.Count > 0)
        {
            return Ok(comandaRepositorio);
        }
        else if (list.Count <= 0)
        {
            return NotFound();
        }
        return NoContent();
    }

    //Deletar Comanda Pelo ID
    [HttpDelete("{ComandaID}")]
    public IActionResult DeletaComanda([FromRoute] int ComandaID)
    {
        var Comanda = comandaRepositorio.BuscarComanda(ComandaID);
        if (Comanda == null)
        {
            return NotFound();
        }

        comandaRepositorio.DeletaComanda(Comanda);
        return NoContent();
    }

    //Adicionar Comanda
    [HttpPost]
    public IActionResult AdicionarComanda([FromBody] Comanda Comanda)
    {
        comandaRepositorio.AdicionarComanda(Comanda);

        return Ok(new { Id = Comanda.Id });
    }
}