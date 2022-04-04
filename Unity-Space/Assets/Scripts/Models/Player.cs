namespace LudumDare50.Models
{
    public class Player
    {
        public int CurrentAir { get; private set; } = 1000;
        public string CurrentAirString => $"{CurrentAir / 10}%";

        public void AddAir()
        {
            CurrentAir += 100;
            
            if (CurrentAir > 1000)
                CurrentAir = 1000;
        }

        public void RemoveAir()
        {
            CurrentAir--;
            
            if (CurrentAir < 0)
                CurrentAir = 0;
        }
    }
}