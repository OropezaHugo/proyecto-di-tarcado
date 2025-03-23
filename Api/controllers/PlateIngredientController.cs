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
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlateIngredientDto>> Get(int id)
    {
        var entity = await _service.GetById(id);
        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<PlateIngredientDto>> Post(PlateIngredientNoIdDto entity)
    {
        var response = await _service.Add(entity);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlateIngredientDto>> Put([FromRoute] int id, [FromBody] PlateIngredientDto entity)
    {
        if (id != entity.Id)
            return BadRequest("Ids are not equal");
        
        var updatedEntity = await _service.Put(entity);
        return Ok(updatedEntity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var response = await _service.Delete(id);
        if (response)
            return NoContent();
        return Ok(response);
    }
}
