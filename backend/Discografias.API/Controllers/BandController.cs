using Discografias.Api.DTOs;
using Discografias.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Discografias.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BandsController : ControllerBase
{
    private readonly BandService bandService;

    public BandsController(BandService bandService)
    {
        this.bandService = bandService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var bands = bandService.ShowBands();
        return Ok(bands);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateBandDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return BadRequest("O nome da banda é obrigatório");
        }

        bool sucess = bandService.RegisterBand(
            dto.Name,
            dto.Nationality,
            dto.StudioAlbumsCount,
            dto.SongsCount
        );

        if (!sucess) return Conflict($"A banda {dto.Name} já está registrada");

        return CreatedAtAction(nameof(Get), null);
    }
} 