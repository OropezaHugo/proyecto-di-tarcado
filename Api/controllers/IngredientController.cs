using Api.services.interfaces;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController: ControllerBase
{
  private readonly IIngredientService _service;

  public IngredientController(IIngredientService service)
  {
    _service = service;
  }
  
  [HttpGet]
  public async Task<ActionResult<List<IngredientDto>>> GetAll()
  {
    var entities = await _service.GetAll();
    return Ok(entities);  
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<IngredientDto?>> Get([FromRoute] int id)
  {
    var entity = await _service.GetById(id);
    return Ok(entity);  
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete([FromRoute] int id)
  {
    var response = await _service.Delete(id);
    if (response)
      return NoContent();
    return Ok(response);
  }
  
  [HttpPost]
  public async Task<ActionResult<IngredientDto>> AddPet([FromBody] IngredientNoIdDto entity)
  {
    var response = await _service.Add(entity);
    return Ok(response);
  }
  
  [HttpPut("{id}")]
  public async Task<ActionResult<IngredientDto>> Update([FromRoute] int id, [FromBody] IngredientDto entity)
  {
    if (id != entity.Id)
    {
      return BadRequest("Ids are not equal.");
    }

    var updatedEntity = await _service.Put(entity);
    return Ok(updatedEntity);
  }

}
