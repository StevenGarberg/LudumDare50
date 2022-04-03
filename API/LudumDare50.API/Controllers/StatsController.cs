using Microsoft.AspNetCore.Mvc;

namespace LudumDare50.API.Controllers;

[ApiController]
[Route("games/{gameName}/client/{id:guid}/stats")]
public class StatsController : ControllerBase
{
    
}