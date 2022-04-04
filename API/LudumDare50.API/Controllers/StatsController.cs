using LudumDare50.API.Models;
using LudumDare50.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LudumDare50.API.Controllers;

[ApiController]
[Route("games/{gameName}/client/{clientId}/stats")]
public class StatsController : ControllerBase
{
    private readonly IMongoRepository<Stats> _repository;

    public StatsController(IMongoRepository<Stats> repository)
    {
        _repository = repository;
    }
    
    [HttpGet("~/stats")]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Stats))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        return Ok(await _repository.GetAll());
    }
    
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<Stats>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByClientId([FromRoute] string clientId)
    {
        return Ok(await _repository.GetByOwnerId(clientId));
    }
    
    [HttpGet("~/games/{gameName}/stats")]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<Stats>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByGameName([FromRoute] string gameName)
    {
        return Ok(await _repository.GetByGameName(gameName));
    }
    
    [HttpGet("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Stats))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        return Ok(await _repository.GetById(id));
    }

    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, null, typeof(Stats))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromRoute] string gameName, [FromRoute] string clientId, Stats request)
    {
        var stats = new Stats(gameName, clientId, request);
        return Created($"/games/{gameName}/client/{clientId}/stats/{stats.Id}", await _repository.Create(stats));
    }

    [HttpPut("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Stats))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update([FromRoute] string gameName, [FromRoute] string clientId, [FromRoute] string id, Stats request)
    {
        var statsToUpdate = await _repository.GetById(id);
        return Ok(await _repository.Update(id, new Stats(statsToUpdate)));
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _repository.Delete(id);
        return NoContent();
    }
}