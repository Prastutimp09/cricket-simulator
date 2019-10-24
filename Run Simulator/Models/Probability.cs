using System.Collections.Generic;
using System.Linq;

namespace Run_Simulator
{
    public static class Probability
    {
        private static Dictionary<Player, List<ScoreRate>> scoreRates => new Dictionary<Player, List<ScoreRate>>
        {
            {
                new Player("Pravin", 1), new List<ScoreRate>()
            {
                new ScoreRate { Score = 0, Rate = 5},
                new ScoreRate { Score = 1, Rate = 30},
                new ScoreRate { Score = 2, Rate = 25},
                new ScoreRate { Score = 3, Rate = 10},
                new ScoreRate { Score = 4, Rate = 15},
                new ScoreRate { Score = 5, Rate = 1},
                new ScoreRate { Score = 6, Rate = 9},
                new ScoreRate { Score = 7, Rate = 5}
            }
            },
             {
                new Player("Irfan", 2), new List<ScoreRate>()
            {
                new ScoreRate { Score = 0, Rate = 10},
                new ScoreRate { Score = 1, Rate = 40},
                new ScoreRate { Score = 2, Rate = 20},
                new ScoreRate { Score = 3, Rate = 5},
                new ScoreRate { Score = 4, Rate = 10},
                new ScoreRate { Score = 5, Rate = 1},
                new ScoreRate { Score = 6, Rate = 4},
                new ScoreRate { Score = 7, Rate = 10}
            }
            },
              {
                new Player("Jalinder", 3), new List<ScoreRate>()
            {
                new ScoreRate { Score = 0, Rate = 20},
                new ScoreRate { Score = 1, Rate = 30},
                new ScoreRate { Score = 2, Rate = 15},
                new ScoreRate { Score = 3, Rate = 5},
                new ScoreRate { Score = 4, Rate = 5},
                new ScoreRate { Score = 5, Rate = 1},
                new ScoreRate { Score = 6, Rate = 4},
                new ScoreRate { Score = 7, Rate = 20}
            }
            },
               {
                new Player("Vaishali", 4), new List<ScoreRate>()
            {
                new ScoreRate { Score = 0, Rate = 30},
                new ScoreRate { Score = 1, Rate = 25},
                new ScoreRate { Score = 2, Rate = 5},
                new ScoreRate { Score = 3, Rate = 0},
                new ScoreRate { Score = 4, Rate = 5},
                new ScoreRate { Score = 5, Rate = 1},
                new ScoreRate { Score = 6, Rate = 4},
                new ScoreRate { Score = 7, Rate = 30}
            }
            },
        };
        public static int GetProbability(Player player, int remainingBalls, int run)
        {

            return (GetPercentage(player.Id, run) * remainingBalls) / 100;
        }
        private static int GetPercentage(int playerId, int run)
        {
            return scoreRates.First(x => x.Key.Id.Equals(playerId)).Value.First(y => y.Score.Equals(run)).Rate;
        }
    }
}
