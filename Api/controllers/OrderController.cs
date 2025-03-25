using Api.services.interfaces;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> GetOrders()
    {
        var entities = await _orderService.GetAll();
        return entities is not null && entities.Any() ? Ok(entities) : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetOrder(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid order ID.");
        }

        var entity = await _orderService.GetById(id);
        return entity is not null ? Ok(entity) : NotFound($"Order with ID {id} not found.");
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] OrderNoIdDto order)
    {
        if (order == null)
        {
            return BadRequest("Invalid order data.");
        }

        var response = await _orderService.Add(order);
        return CreatedAtAction(nameof(GetOrder), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<OrderDto>> UpdateOrder([FromRoute] int id, [FromBody] OrderDto order)
    {
        if (order == null || id != order.Id)
        {
            return BadRequest("Invalid data. Ensure IDs match and request body is correct.");
        }

        var existingOrder = await _orderService.GetById(id);
        if (existingOrder == null)
        {
            return NotFound($"Order with ID {id} not found.");
        }

        var updatedEntity = await _orderService.Put(order);
        return Ok(updatedEntity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid order ID.");
        }

        var existingOrder = await _orderService.GetById(id);
        if (existingOrder == null)
        {
            return NotFound($"Order with ID {id} not found.");
        }

        var response = await _orderService.Delete(id);
        return response ? NoContent() : BadRequest("Failed to delete the order.");
    }
}
