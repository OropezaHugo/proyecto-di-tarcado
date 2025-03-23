using Api.services.interfaces;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Microsoft.AspNetCore.Http.HttpResults;
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
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlateDto>> GetPlate(int id)
    {
        var response = await _plateService.GetById(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<PlateDto>> CreatePlate([FromBody] PlateNoIdDto entity)
    {
        var response = await _plateService.Add(entity);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlateDto>> UpdatePlate([FromRoute] int id, [FromBody] PlateDto entity)
    {
        var updatedEntity = await _plateService.Put(entity);
        return Ok(updatedEntity);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var response = await _plateService.Delete(id);
        if (response)
            return NoContent();
        return Ok(Response);
    }
}