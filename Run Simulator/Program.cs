using System;
using System.Collections.Generic;
using System.Linq;

namespace Run_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>
            {
             new Player("Pravin", 1),
             new Player("Irfan", 2),
             new Player("Jalinder", 3),
             new Player("Vaishali", 4),
            };

            Player playerOnStrike = players[0];
            Player player2 = players[1];
            int totalBalls = 24;
            int totalOvers = 4;
            int lastPlayer = player2.Id;
            int totalRunstoWin = 40;
            int totalRunsScored = 0;
            int remainingballs = 24;
           
            var randomizer = new Random();

            for (int over = 0; over < totalOvers; over++)
            {
                if (totalRunstoWin == totalRunsScored)
                {
                    remainingballs = remainingballs - ((totalOvers - over) * 6);
                    break;
                }
                Console.WriteLine($"{4- over} overs left. {totalRunstoWin} runs to win.");
                for (int ball = 1; ball <= 6; ball++)
                {
                    if(totalRunstoWin == totalRunsScored)
                    {
                        remainingballs = remainingballs - (((totalOvers - over) * 6) +( 6 - ball));
                        break;
                    }
                    int run = playerOnStrike.Play(playerOnStrike, totalBalls, randomizer, over, ball);
                  
                    if (run == 7)
                    {
                        playerOnStrike = players.First(x => x.Id.Equals(lastPlayer+1));
                        lastPlayer = playerOnStrike.Id;
                    }
                    if (run != 7)
                    {
                        totalRunsScored += run;
                        playerOnStrike.TotalRuns += run;
                        playerOnStrike.TotalBalls++;

                    }
                    if (ChangeStrike(run))
                    {

                        SwapPlayers(ref playerOnStrike, ref player2);
                    }
                }
                Console.WriteLine("\n\n");
            }
            Console.WriteLine($"Remus won by {players.Count - lastPlayer} wicket with {remainingballs} balls remaining. ");
            foreach(var player in players)
            {
                Console.WriteLine($"{player.Name} - {player.TotalRuns} ({player.TotalBalls}) balls");
            }
            
            Console.ReadLine();
        }

        private static void SwapPlayers(ref Player playerOnStrike, ref Player player2)
        {
            var temp = playerOnStrike;
            playerOnStrike = player2;
            player2 = temp;
        }

        public static bool ChangeStrike(int run)
        {
          if(run == 1 || run == 3 || run == 5)
            {
                return true; 
            }
            return false;
        }

        }

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
        public class ScoreRate
        {
            public int Score { get; set; }

            public int Rate { get; set; }
        }
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
                var run = randomizer.Next(0, 7);
                int rate = Probability.GetProbability(playerOnStrike, totalBalls - (ball - 1), run);
                if (rate > 0)
                {
                if (run != 7)
                {
                    Console.WriteLine($"{over}.{ball} {playerOnStrike.Name} Scores {run} run");
                }
                else
                {
                    Console.WriteLine($"{playerOnStrike.Name} is out");
                }
                }
                else
                {
                    Play(playerOnStrike, totalBalls, randomizer, over, ball);
                }
                return run;
            }
        }
    }

