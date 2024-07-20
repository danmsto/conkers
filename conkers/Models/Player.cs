namespace conkers.Models
{
    public class Player(string handle, int wins, int losses)
    {
        public string Handle { get; set; } = handle;

        public int Wins { get; set; } = wins;

        public int Losses { get; set; } = losses;
    }
}
