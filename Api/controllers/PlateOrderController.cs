using Api.services.interfaces;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[ApiController]
[Route("api/[controller]")]
public class PlateOrderController : ControllerBase
{
    private readonly IPlateOrderService _plateOrderService;

    public PlateOrderController(IPlateOrderService plateOrderService)
    {
        _plateOrderService = plateOrderService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlateOrderDto>>> GetAll()
    {
        var response = await _plateOrderService.GetAll();
        return response is not null && response.Any() ? Ok(response) : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlateOrderDto>> Get(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid PlateOrder ID.");
        }

        var response = await _plateOrderService.GetById(id);
        return response is not null ? Ok(response) : NotFound($"PlateOrder with ID {id} not found.");
    }

    [HttpPost]
    public async Task<ActionResult<PlateOrderDto>> Post([FromBody] PlateOrderNoIdDto plateOrder)
    {
        if (plateOrder == null)
        {
            return BadRequest("Invalid PlateOrder data.");
        }

        var response = await _plateOrderService.Add(plateOrder);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlateOrderDto>> Put([FromRoute] int id, [FromBody] PlateOrderDto plateOrder)
    {
        if (plateOrder == null || id != plateOrder.Id)
        {
            return BadRequest("Invalid data. Ensure IDs match and request body is correct.");
        }

        var existingPlateOrder = await _plateOrderService.GetById(id);
        if (existingPlateOrder == null)
        {
            return NotFound($"PlateOrder with ID {id} not found.");
        }

        var updatedEntity = await _plateOrderService.Put(plateOrder);
        return Ok(updatedEntity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid PlateOrder ID.");
        }

        var existingPlateOrder = await _plateOrderService.GetById(id);
        if (existingPlateOrder == null)
        {
            return NotFound($"PlateOrder with ID {id} not found.");
        }

        var response = await _plateOrderService.Delete(id);
        return response ? NoContent() : BadRequest("Failed to delete the PlateOrder.");
    }
}
