using Api.services.interfaces;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[ApiController]
[Route("api/[controller]")]
public class PlateIngredientController : ControllerBase
{
    private readonly IPlateIngredientService _service;

    public PlateIngredientController(IPlateIngredientService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlateIngredientDto>>> GetAll()
    {
        var entities = await _service.GetAll();
        return entities is not null && entities.Any() ? Ok(entities) : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlateIngredientDto>> Get(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid PlateIngredient ID.");
        }

        var entity = await _service.GetById(id);
        return entity is not null ? Ok(entity) : NotFound($"PlateIngredient with ID {id} not found.");
    }

    [HttpPost]
    public async Task<ActionResult<PlateIngredientDto>> Post([FromBody] PlateIngredientNoIdDto entity)
    {
        if (entity == null || entity.PlateId <= 0 || entity.IngredientId <= 0)
        {
            return BadRequest("Invalid PlateIngredient data. PlateId and IngredientId must be valid.");
        }

        var response = await _service.Add(entity);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlateIngredientDto>> Put([FromRoute] int id, [FromBody] PlateIngredientDto entity)
    {
        if (entity == null || id != entity.Id)
        {
            return BadRequest("Invalid data. Ensure IDs match and request body is correct.");
        }

        var existingRelation = await _service.GetById(id);
        if (existingRelation == null)
        {
            return NotFound($"PlateIngredient with ID {id} not found.");
        }

        var updatedEntity = await _service.Put(entity);
        return Ok(updatedEntity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid PlateIngredient ID.");
        }

        var existingRelation = await _service.GetById(id);
        if (existingRelation == null)
        {
            return NotFound($"PlateIngredient with ID {id} not found.");
        }

        var response = await _service.Delete(id);
        return response ? NoContent() : BadRequest("Failed to delete the PlateIngredient.");
    }
}
