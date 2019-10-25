using System;
using System.Collections.Generic;
using System.Linq;

namespace Run_Simulator
{
    class Program
    {
        static List<Player> players = GetPlayers();
        static Player playerOnStrike = players[0];
        static Player player2 = players[1];
        static int totalOvers = 4;
        static int lastPlayer = player2.Id;
        static int totalRunstoWin = 40;
        static int totalRunsScored = 0;
        static int totalBalls = totalOvers * 6;
        static bool allOut = false;
        static void Main(string[] args)
        {
            var randomizer = new Random();

            for (int over = 0; over < totalOvers; over++)
            {
                if (totalRunsScored >= totalRunstoWin || allOut)
                {
                    break;
                }
                Console.WriteLine($"{totalOvers - over} overs left. {totalRunstoWin - totalRunsScored} runs to win.");
                for (int ball = 1; ball <= 6; ball++)
                {
                    if (totalRunsScored >= totalRunstoWin || allOut)
                    {
                        break;
                    }
                    int run = playerOnStrike.Play(playerOnStrike);

                    if (run == 7)
                    {
                        Console.WriteLine($"{playerOnStrike.Name} is out");
                        if (players.Count() != lastPlayer)
                        {
                            AssignNewPlayer();
                        }
                        else
                        {
                            allOut = true;
                            break;
                        }
                    }
                    if (run != 7) // 7 is considered out
                    {
                        Console.WriteLine($"{over}.{ball} {playerOnStrike.Name} Scores {run} run");
                        UpdateMetrics(run);

                    }
                    if (ChangeStrike(run))
                    {
                        SwapPlayers(ref playerOnStrike, ref player2);
                    }
                }
                Console.WriteLine("\n");
            }
            DisplayResult();
            Console.ReadLine();
        }

        /// <summary>
        /// Assigns next player in the queue when the player on strike is out.
        /// </summary>
        private static void AssignNewPlayer()
        {
            playerOnStrike = players.First(x => x.Id.Equals(lastPlayer + 1));
            lastPlayer = playerOnStrike.Id;
        }

        /// <summary>
        /// updates totalruns scored and runs scored by player on strike.
        /// </summary>
        /// <param name="run"></param>
        private static void UpdateMetrics(int run)
        {
            totalRunsScored += run;
            playerOnStrike.TotalRuns += run;
            playerOnStrike.TotalBalls++;
        }

        /// <summary>
        /// Calculates and displays the final outcome of the match
        /// </summary>
        private static void DisplayResult()
        {
            if (totalRunsScored >= totalRunstoWin)
            {
                int remainingballs = GetRemainingBalls();

                Console.WriteLine($"Remus won by {players.Count - (lastPlayer - 1)} wicket with {remainingballs} balls remaining. ");

                foreach (var player in players)
                {
                    Console.WriteLine($"{player.Name} - {player.TotalRuns} ({player.TotalBalls}) balls");
                }

            }
            else
            {
                Console.WriteLine($"Nibiru won by {totalRunstoWin - totalRunsScored} runs. ");
            }
        }

        private static int GetRemainingBalls()
        {
            int remainingballs = totalBalls - 0;
            players.Select(x => x.TotalBalls).ToList().ForEach(x =>
            {
                remainingballs = remainingballs - x;
            });
            return remainingballs;
        }

        /// <summary>
        /// initializes and returns players.
        /// </summary>
        /// <returns></returns>
        private static List<Player> GetPlayers() => new List<Player>
            {
             new Player("Pravin", 1),
             new Player("Irfan", 2),
             new Player("Jalinder", 3),
             new Player("Vaishali", 4),
            };

        /// <summary>
        /// swaps players on strike change.
        /// </summary>
        /// <param name="playerOnStrike"></param>
        /// <param name="player2"></param>
        private static void SwapPlayers(ref Player playerOnStrike, ref Player player2)
        {
            var temp = playerOnStrike;
            playerOnStrike = player2;
            player2 = temp;
        }

        /// <summary>
        /// determines whether players should change strike or not.
        /// </summary>
        /// <param name="run"></param>
        /// <returns></returns>
        public static bool ChangeStrike(int run)
        {
          if(run == 1 || run == 3 || run == 5)
            {
                return true; 
            }
            return false;
        }

        }
    }

