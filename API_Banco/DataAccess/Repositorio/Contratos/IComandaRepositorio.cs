using Dominio;

public interface IComandaRepositorio
{
    void AdicionarComanda(Comanda comanda);
    Comanda BuscarComanda(int ComandaID);
    public List<Comanda> ListarComanda();
    void DeletaComanda(Comanda comanda);
}