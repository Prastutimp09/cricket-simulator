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
        static void Main(string[] args)
        {
            var randomizer = new Random();

            for (int over = 0; over < totalOvers; over++)
            {
                if (totalRunsScored >= totalRunstoWin)
                {
                    break;
                }
                Console.WriteLine($"{totalOvers - over} overs left. {totalRunstoWin - totalRunsScored} runs to win.");
                for (int ball = 1; ball <= 6; ball++)
                {
                    if (totalRunsScored >= totalRunstoWin)
                    {
                        break;
                    }
                    int run = playerOnStrike.Play(playerOnStrike, totalBalls, randomizer, over, ball);

                    if (run == 7)
                    {
                        Console.WriteLine($"{playerOnStrike.Name} is out");
                        AssignNewPlayer();
                    }
                    if (run != 7)
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

        private static void AssignNewPlayer()
        {
            playerOnStrike = players.First(x => x.Id.Equals(lastPlayer + 1));
            lastPlayer = playerOnStrike.Id;
        }

        private static void UpdateMetrics(int run)
        {
            totalRunsScored += run;
            playerOnStrike.TotalRuns += run;
            playerOnStrike.TotalBalls++;
        }

        private static void DisplayResult()
        {
            if (totalRunsScored >= totalRunstoWin)
            {
                int remainingballs = totalBalls - 0;
                players.Select(x => x.TotalBalls).ToList().ForEach(x =>
                {
                    remainingballs = remainingballs - x;
                });

                Console.WriteLine($"Remus won by {players.Count - lastPlayer} wicket with {remainingballs} balls remaining. ");

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

        private static List<Player> GetPlayers() => new List<Player>
            {
             new Player("Pravin", 1),
             new Player("Irfan", 2),
             new Player("Jalinder", 3),
             new Player("Vaishali", 4),
            };

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
    }

