using Discografias.Domain;

namespace Discografias.Services;

public class BandaService
{
    private List<Banda> bandas = new();
    
    public bool RegistrarBanda(
        string nome,
        string nacionalidade,
        int numeroAlbunsEstudio,
        int numeroMusicas)
    {
        bool bandaJaExiste = bandas.Any(
            b => b.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

        if (bandaJaExiste) return false;

        var banda = new Banda(
            nome, 
            nacionalidade, 
            numeroAlbunsEstudio, 
            numeroMusicas
        );

        bandas.Add(banda);
        return true;
    }

    public List<Banda> ExibirBandas()
    {  
        return bandas;
    }

    public bool AvaliarBanda(string nome, int nota)
    {
        var banda = bandas.FirstOrDefault(b => b.Nome == nome);
        if (banda != null)
        {
            banda.AvaliarBanda(nota);
            return true;
        }

        return false;
    }

    public int QuantidadeDeBandas()
    {
        return bandas.Count;
    }
}