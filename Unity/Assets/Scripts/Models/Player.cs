using System;

namespace LudumDare50.Models
{
    public class Player
    {
        public int CurrentAir { get; private set; } = 1000;
        public string CurrentAirString => $"{CurrentAir / 10}%";

        public event Action OnAddAir;
        
        public void AddAir()
        {
            CurrentAir += 250;
            OnAddAir?.Invoke();
        }
    }
}