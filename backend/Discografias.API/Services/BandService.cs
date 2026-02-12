using Discografias.Api.Domain;
using System.Text.Json;

namespace Discografias.Api.Services;

public class BandService
{
    private readonly string filePath = Path.Combine("Data", "bands.json");
    private List<Band> bands = new();

    public BandService()
    {
        GetBandsFromJson();
    }

    private void GetBandsFromJson()
    {
        var filePath = Path.Combine("Data", "bands.json");

        if (!File.Exists(filePath)) return;

        var json = File.ReadAllText(filePath);

        var jsonBandsList = JsonSerializer.Deserialize<List<BandJson>>(json);

        if (jsonBandsList == null) return;

        foreach (var band in jsonBandsList)
        {
            RegisterBand(
                band.Name,
                band.Nationality,
                band.StudioAlbumsCount,
                band.SongsCount,
                save: false
                );
        }
    }
    
    public bool RegisterBand(
        string name,
        string nationality,
        int studioAlbumsCount,
        int songsCount,
        bool save = true)
    {
        bool bandlreadyExists = bands.Any(
            b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (bandlreadyExists) return false;

        var band = new Band(
            name, 
            nationality, 
            studioAlbumsCount, 
            songsCount
        );

        bands.Add(band);

        if (save) SaveBandsToJson();

        return true;
    }

    public List<Band> ShowBands()
    {  
        return bands;
    }

    public bool ReviewDiscography(string name, int score)
    {
        var band = bands.FirstOrDefault(b => b.Name == name);
        if (band != null)
        {
            band.ReviewDiscography(score);
            return true;
        }

        return false;
    }

    public int BandsAmount()
    {
        return bands.Count;
    }

    private void SaveBandsToJson()
    {
        var bandsToSave = bands.Select(b => new BandJson
        {
            Name = b.Name,
            Nationality = b.Nationality,
            StudioAlbumsCount = b.StudioAlbumsCount,
            SongsCount = b.SongsCount,
        }).ToList();

        var json = JsonSerializer.Serialize(
            bandsToSave,
            new JsonSerializerOptions { WriteIndented = true }
        );

        Directory.CreateDirectory("Data");

        File.WriteAllText(filePath, json);
    }

    private class BandJson
    {
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public int StudioAlbumsCount { get; set; }
        public int SongsCount { get; set; }
    }
}