using System;

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
        public int Play(Player playerOnStrike, int totalBalls, Random randomizer, int over, int ball)
        {
            var run = randomizer.Next(8);
            int rate = Probability.GetProbability(playerOnStrike, totalBalls - (ball - 1), run);
            if (rate > 0)
            {
                return run;
            }
            else
            {
                Play(playerOnStrike, totalBalls, randomizer, over, ball);
            }
            return run;
        }
    }
}
