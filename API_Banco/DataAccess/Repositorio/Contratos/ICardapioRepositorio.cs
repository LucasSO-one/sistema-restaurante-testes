using Dominio;

public interface ICardapioRepositorio
{
    void AdicionarCardapio(Cardapio cardapio);
    Cardapio BuscarCardapio(int CardapioID);
    public List<Cardapio> ListarCardapio();
    void DeletaCardapio(Cardapio cardapio);
}   