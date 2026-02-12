namespace Discografias.Api.DTOs
{
    public class CreateBandDto
    {
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public int StudioAlbumsCount { get; set; }
        public int SongsCount { get; set; }
    }
}
