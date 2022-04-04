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

    [HttpGet("~/games/{gameName}/stats")]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<Stats>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByGameName([FromRoute] string gameName)
    {
        return Ok(await _repository.GetByGameName(gameName));
    }
    
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Stats))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByClientId([FromRoute] string clientId)
    {
        return Ok(await _repository.GetById(clientId));
    }

    [HttpPut]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Stats))]
    [SwaggerResponse(StatusCodes.Status201Created, null, typeof(Stats))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Upsert([FromRoute] string gameName, [FromRoute] string clientId, Stats request)
    {
        var statsToUpdate = await _repository.GetById(clientId);
        if (statsToUpdate == null)
        {
            var newStats = new Stats(gameName, clientId, request);
            return Created($"/games/{gameName}/client/{clientId}/stats", await _repository.Create(newStats));
        }

        statsToUpdate.GameName = gameName;
        statsToUpdate.Id = clientId;
        var stats = new Stats(statsToUpdate);
        return Ok(await _repository.Update(clientId, stats));
    }

    [HttpDelete]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] string clientId)
    {
        await _repository.Delete(clientId);
        return NoContent();
    }
}