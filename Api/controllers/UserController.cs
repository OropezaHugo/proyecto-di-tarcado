using Api.services.interfaces;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
        var user = await _userService.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] UserNoIdDto entity)
    {
        var response = await _userService.Add(entity);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> Update([FromRoute] int id, [FromBody] UserDto entity)
    {
        if (id != entity.Id)
        {
            return BadRequest("Ids are not equal.");
        }
        var updatedEntity = await _userService.Put(entity);
        return Ok(updatedEntity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var response = await _userService.Delete(id);
        if (response)
            return NoContent();
        return Ok(response);
    }
}
