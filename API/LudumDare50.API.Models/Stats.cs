using System;

namespace LudumDare50.API.Models;

public class Stats : BaseResource
{
    public int TimePlayed { get; set; }
    public int RoundsPlayed { get; set; }
    public int LongestRound { get; set; }
    public int MostCansCollected { get; set; }
    public int CansCollected { get; set; }
    
    public Stats() {}

    public Stats(string gameName, string clientId, Stats request)
    {
        Id = clientId;
        GameName = gameName;
        Version = 1;
        TimePlayed = request.TimePlayed;
        RoundsPlayed = request.RoundsPlayed;
        LongestRound = request.LongestRound;
        MostCansCollected = request.MostCansCollected;
        CansCollected = request.CansCollected;
    }
    
    public Stats(Stats request)
    {
        Id = request.Id;
        GameName = request.GameName;
        Version = request.Version;
        CreatedAt = request.CreatedAt;
        TimePlayed = request.TimePlayed;
        RoundsPlayed = request.RoundsPlayed;
        LongestRound = request.LongestRound;
        MostCansCollected = request.MostCansCollected;
        CansCollected = request.CansCollected;
    }
}