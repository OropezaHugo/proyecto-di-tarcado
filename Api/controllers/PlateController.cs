using Api.services.interfaces;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[ApiController]
[Route("api/[controller]")]
public class PlateController : ControllerBase
{
    private readonly IPlateService _plateService;

    public PlateController(IPlateService plateService)
    {
        _plateService = plateService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlateDto>>> GetPlates()
    {
        var response = await _plateService.GetAll();
        return response is not null && response.Any() ? Ok(response) : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlateDto>> GetPlate(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid plate ID.");
        }

        var response = await _plateService.GetById(id);
        return response is not null ? Ok(response) : NotFound($"Plate with ID {id} not found.");
    }

    [HttpPost]
    public async Task<ActionResult<PlateDto>> CreatePlate([FromBody] PlateNoIdDto entity)
    {
        if (entity == null)
        {
            return BadRequest("Invalid plate data.");
        }

        var response = await _plateService.Add(entity);
        return CreatedAtAction(nameof(GetPlate), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlateDto>> UpdatePlate([FromRoute] int id, [FromBody] PlateDto entity)
    {
        if (entity == null || id != entity.Id)
        {
            return BadRequest("Invalid data. Ensure IDs match and request body is correct.");
        }

        var existingPlate = await _plateService.GetById(id);
        if (existingPlate == null)
        {
            return NotFound($"Plate with ID {id} not found.");
        }

        var updatedEntity = await _plateService.Put(entity);
        return Ok(updatedEntity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePlate([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid plate ID.");
        }

        var existingPlate = await _plateService.GetById(id);
        if (existingPlate == null)
        {
            return NotFound($"Plate with ID {id} not found.");
        }

        var response = await _plateService.Delete(id);
        return response ? NoContent() : BadRequest("Failed to delete the plate.");
    }
}
