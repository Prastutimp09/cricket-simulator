
namespace Run_Simulator
{
    public class Player
    {
        public Player(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; set; }

        public int Id { get; set; }

        public int TotalRuns { get; set; }

        public int TotalBalls { get; set; }

        /// <summary>
        /// Generates run based on randomizer and probability.
        /// </summary>
        /// <param name="playerOnStrike">current player</param>
        /// <param name="totalBalls">total balls</param>
        /// <param name="randomizer"></param>
        /// <param name="over"></param>
        /// <param name="ball"></param>
        /// <returns></returns>
        public int Play(Player playerOnStrike)
        {
            return Probability.GetRunOnPrabability(playerOnStrike);
        }
    }
}
