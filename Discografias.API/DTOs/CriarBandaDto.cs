namespace Discografias.API.DTOs
{
    public class CriarBandaDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;
        public int NumeroAlbunsEstudio { get; set; }
        public int NumeroMusicas { get; set; }
    }
}
