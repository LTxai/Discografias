namespace Discografias.Api.Domain;

public class Band
{
    public string Name { get; }
    public string Nationality { get; }
    public int StudioAlbumsCount { get; }
    public int SongsCount { get; }
    public int Score { get; set; }

    public Band(
        string name,
        string nationality, 
        int studioAlbumsCount, 
        int songsCount)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome da banda é obrigatório.");

        if (string.IsNullOrWhiteSpace(nationality))
            throw new ArgumentException("Nacionalidade é obrigatória");

        if (studioAlbumsCount <= 0)
            throw new ArgumentException("Número de álbuns precisa ser maior que 0");

        if (songsCount <= 0)
            throw new ArgumentException("Número de músicas precisa ser maior que 0");

        Name = name;
        Nationality = nationality;
        StudioAlbumsCount = studioAlbumsCount;
        SongsCount = songsCount;
        Score = 0;
    }

    public void ReviewDiscography(int score)
    {
        Score = score;
    }
}
