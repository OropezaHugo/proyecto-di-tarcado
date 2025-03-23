using Api.services.interfaces;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[ApiController]
[Route("/api/[controller]")]
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
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlateOrderDto>> Get(int id)
    {
        var response = await _plateOrderService.GetById(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<PlateOrderDto>> Post([FromBody] PlateOrderNoIdDto plateOrder)
    {
        var response = await _plateOrderService.Add(plateOrder);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlateOrderDto>> Put([FromRoute] int id, [FromBody] PlateOrderDto plateOrder)
    {
        if (id != plateOrder.Id)
            return BadRequest("Ids do not match");
        
        var updatedEntity = await _plateOrderService.Put(plateOrder);
        return Ok(updatedEntity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var response = await _plateOrderService.Delete(id);
        return Ok(response);
    }
}

