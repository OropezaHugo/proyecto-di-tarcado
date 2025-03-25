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
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        var users = await _userService.GetAll();
        return users is not null && users.Any() ? Ok(users) : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        var user = await _userService.GetById(id);
        return user is not null ? Ok(user) : NotFound($"User with ID {id} not found.");
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserNoIdDto entity)
    {
        if (entity == null)
        {
            return BadRequest("Invalid user data.");
        }

        var response = await _userService.Add(entity);
        return CreatedAtAction(nameof(GetUser), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUser([FromRoute] int id, [FromBody] UserDto entity)
    {
        if (entity == null || id != entity.Id)
        {
            return BadRequest("Invalid data. Ensure IDs match and request body is correct.");
        }

        var existingUser = await _userService.GetById(id);
        if (existingUser == null)
        {
            return NotFound($"User with ID {id} not found.");
        }

        var updatedEntity = await _userService.Put(entity);
        return Ok(updatedEntity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid user ID.");
        }
        
        var existingUser = await _userService.GetById(id);
        if (existingUser == null)
        {
            return NotFound($"User with ID {id} not found.");
        }

        var response = await _userService.Delete(id);
        return response ? NoContent() : BadRequest("Failed to delete the user.");
    }
}
