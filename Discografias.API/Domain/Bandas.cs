namespace Discografias.Domain;

public class Banda
{
    public string Nome { get; }
    public string Nacionalidade { get; }
    public int NumeroAlbunsEstudio { get; }
    public int NumeroMusicas { get; }
    public int Nota { get; set; }

    public Banda(
        string nome,
        string nacionalidade, 
        int numeroAlbunsEstudio, 
        int numeroMusicas)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome da banda é obrigatório.");

        if (string.IsNullOrWhiteSpace(nacionalidade))
            throw new ArgumentException("Nacionalidade é obrigatória");

        if (numeroAlbunsEstudio <= 0)
            throw new ArgumentException("Número de álbuns precisa ser maior que 0");

        if (numeroMusicas <= 0)
            throw new ArgumentException("Número de músicas precisa ser maior que 0");

        Nome = nome;
        Nacionalidade = nacionalidade;
        NumeroAlbunsEstudio = numeroAlbunsEstudio;
        NumeroMusicas = numeroMusicas;
        Nota = 0;
    }

    public void AvaliarBanda(int nota)
    {
        Nota = nota;
    }
}
