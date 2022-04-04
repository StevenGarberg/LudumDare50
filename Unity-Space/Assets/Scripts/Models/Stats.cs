using System;

namespace LudumDare50.Models
{
    public class Stats
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Version { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string GameName { get; set; } = "out-of-air";

        public int TimePlayed { get; set; } = 0;
        public int RoundsPlayed { get; set; } = 0;
        public int LongestRound { get; set; } = 0;
        public int MostCansCollected { get; set; } = 0;
        public int CansCollected { get; set; } = 0;
    }
}