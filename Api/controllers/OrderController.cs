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
        var entites = await _orderService.GetAll();
        return Ok(entites);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetOrder(int id)
    {
        var entity = await _orderService.GetById(id);
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var response = await _orderService.Delete(id);
        if (response)
            return NoContent();
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> Post([FromBody] OrderNoIdDto order)
    {
        var response = await _orderService.Add(order);
        return Ok(response); 
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<OrderDto>> Put([FromRoute] int id, [FromBody] OrderDto order)
    {
        if(id != order.Id)
            return BadRequest("Ids are not equal");
        var updatedEntity = await _orderService.Put(order);
        return Ok(updatedEntity);
    }
}
