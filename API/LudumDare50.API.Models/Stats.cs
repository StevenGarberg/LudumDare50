using System;

namespace LudumDare50.API.Models;

public class Stats : BaseResource
{
    public string GameName { get; set; }
    public Stats() {}

    public Stats(string ownerId, string gameName, Stats request)
    {
        this.Id = Guid.NewGuid().ToString();
        this.OwnerId = ownerId;
        this.GameName = gameName;
        //TODO: Map incoming request stats to constructed stats
    }
}