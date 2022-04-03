using System;

namespace LudumDare50.API.Models;

public class Stats : BaseResource
{
    public string GameName { get; set; }
    public Stats() {}

    public Stats(string ownerId, string gameName, Stats request)
    {
        Id = string.IsNullOrEmpty(request.Id) ? Guid.NewGuid().ToString() : request.Id;
        OwnerId = ownerId;
        GameName = gameName;
        //TODO: Map incoming request stats to constructed stats
    }
}