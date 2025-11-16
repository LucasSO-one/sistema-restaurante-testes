using DataAccess;
using Dominio;
using Microsoft.EntityFrameworkCore;
public class CardapioRepositorio : ICardapioRepositorio
{
    private readonly Contexto _contexto;
    public CardapioRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    public void AdicionarCardapio(Cardapio cardapio)
    {
        _contexto.Cardapios.Add(cardapio);
        _contexto.SaveChanges();
    }


    public Cardapio BuscarCardapio(int CardapioID)
    {
        var cardapio = _contexto.Cardapios.Include(x => x.Produtos).FirstOrDefault(cardapio => cardapio.Id == CardapioID);
        return cardapio;
    }

    public List<Cardapio> ListarCardapio()
    {
        return _contexto.Cardapios.Include(x => x.Produtos).ToList();
    }

    public void DeletaCardapio(Cardapio cardapio)
    {
        _contexto.Cardapios.Remove(cardapio);
    }
}