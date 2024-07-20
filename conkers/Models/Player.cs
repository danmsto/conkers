namespace conkers.Models
{
    public class Player
    {
        public Player(string handle, int wins, int losses)
        {
            Handle = handle;
            Wins = wins;
            Losses = losses;
        }

        public string Handle { get; set; }

        public int Wins { get; set; } = 0;

        public int Losses { get; set; } = 0;
    }
}
