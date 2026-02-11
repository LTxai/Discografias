using Discografias.API.DTOs;
using Discografias.Services;
using Microsoft.AspNetCore.Mvc;

namespace Discografias.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BandasController : ControllerBase
{
    private readonly BandaService bandaService;

    public BandasController(BandaService bandaService)
    {
        this.bandaService = bandaService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var bandas = bandaService.ExibirBandas();
        return Ok(bandas);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CriarBandaDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome))
        {
            return BadRequest("O nome da banda é obrigatório");
        }

        bool sucesso = bandaService.RegistrarBanda(
            dto.Nome,
            dto.Nacionalidade,
            dto.NumeroAlbunsEstudio,
            dto.NumeroMusicas
        );

        if (!sucesso) return Conflict($"A banda {dto.Nome} já está registrada");

        return CreatedAtAction(nameof(Get), null);
    }
} 