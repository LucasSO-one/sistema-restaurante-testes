using DataAccess;
using Dominio;
public class ComandaRepositorio : IComandaRepositorio
{
    private readonly Contexto _contexto;
    public ComandaRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }
    public void AdicionarComanda(Comanda comanda)
    {
        _contexto.Comandas.Add(comanda);
        _contexto.SaveChanges();
    }

    public Comanda BuscarComanda(int ComandaID)
    {
        var comanda = _contexto.Comandas.FirstOrDefault(comanda => comanda.Id == ComandaID);
        return comanda;
    }

    public List<Comanda> ListarComanda()
    {

        return _contexto.Comandas.ToList();
    }

    public void DeletaComanda(Comanda comanda)
    {
        _contexto.Comandas.Remove(comanda);
    }
}