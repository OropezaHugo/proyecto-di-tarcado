using Api.services.interfaces;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _service;

    public IngredientController(IIngredientService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<IngredientDto>>> GetAllIngredients()
    {
        var entities = await _service.GetAll();
        return entities is not null && entities.Any() ? Ok(entities) : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IngredientDto>> GetIngredient([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid ingredient ID.");
        }

        var entity = await _service.GetById(id);
        return entity is not null ? Ok(entity) : NotFound($"Ingredient with ID {id} not found.");
    }

    [HttpPost]
    public async Task<ActionResult<IngredientDto>> AddIngredient([FromBody] IngredientNoIdDto entity)
    {
        if (entity == null)
        {
            return BadRequest("Invalid ingredient data.");
        }

        var response = await _service.Add(entity);
        return CreatedAtAction(nameof(GetIngredient), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<IngredientDto>> UpdateIngredient([FromRoute] int id, [FromBody] IngredientDto entity)
    {
        if (entity == null || id != entity.Id)
        {
            return BadRequest("Invalid data. Ensure IDs match and request body is correct.");
        }

        var existingIngredient = await _service.GetById(id);
        if (existingIngredient == null)
        {
            return NotFound($"Ingredient with ID {id} not found.");
        }

        var updatedEntity = await _service.Put(entity);
        return Ok(updatedEntity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteIngredient([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid ingredient ID.");
        }

        var existingIngredient = await _service.GetById(id);
        if (existingIngredient == null)
        {
            return NotFound($"Ingredient with ID {id} not found.");
        }

        var response = await _service.Delete(id);
        return response ? NoContent() : BadRequest("Failed to delete the ingredient.");
    }
}
