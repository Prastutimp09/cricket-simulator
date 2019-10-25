using System;
using System.Collections.Generic;
using System.Linq;

namespace Run_Simulator
{
    public static class Probability
    {
        private static Dictionary<Player, List<KeyValuePair<int,double>>> scoreRates => new Dictionary<Player, List<KeyValuePair<int, double>>>
        {
            {
                new Player("Pravin", 1), new List<KeyValuePair<int,double>>()
            {
                new KeyValuePair<int,double>(5,0.01),
                new KeyValuePair<int,double>(0,0.05) ,
                new KeyValuePair<int,double>(7,0.05),
                new KeyValuePair<int,double>(6,0.09),
                new KeyValuePair<int,double>(3,0.1),
                new KeyValuePair<int,double>(4,0.15),
                new KeyValuePair<int,double>(2, 0.25) ,
                new KeyValuePair<int,double> (1, 0.30),
            }
            },
             {
                   new Player("Irfan", 2), new List<KeyValuePair<int,double>>()
            {
                new KeyValuePair<int,double>(5,0.01),
                new KeyValuePair<int,double>(6,0.04) ,
                new KeyValuePair<int,double>(3,0.05),
                new KeyValuePair<int,double>(0,0.1),
                new KeyValuePair<int,double>(4,0.1),
                new KeyValuePair<int,double>(7,0.1),
                new KeyValuePair<int,double>(2, 0.2) ,
                new KeyValuePair<int,double> (1, 0.4),
            }
            },
              {
                  new Player("Jalinder", 3), new List<KeyValuePair<int,double>>()
            {
                new KeyValuePair<int,double>(3,0.0),
                new KeyValuePair<int,double>(5,0.01),
                new KeyValuePair<int,double>(6,0.04),
                new KeyValuePair<int,double>(2,0.05),
                new KeyValuePair<int,double>(4,0.05),
                new KeyValuePair<int,double>(1,0.25),
                new KeyValuePair<int,double>(7,0.3),
                new KeyValuePair<int,double>(0, 0.3),
              }
            },
               {
                  new Player("Vaishali", 4), new List<KeyValuePair<int,double>>()
            {
                new KeyValuePair<int,double>(5,0.01),
                new KeyValuePair<int,double>(1,0.05) ,
                new KeyValuePair<int,double>(7,0.05),
                new KeyValuePair<int,double>(6,0.09),
                new KeyValuePair<int,double>(3,0.1),
                new KeyValuePair<int,double>(4,0.15),
                new KeyValuePair<int,double>(2, 0.25) ,
                new KeyValuePair<int,double> (1, 0.30),
            }
            },
        };

        /// <summary>
        /// Generates run based on probability
        /// </summary>
        /// <param name="player">current player</param>
        /// <returns></returns>
        public static int GetRunOnPrabability(Player player)
        {
            var ramdomizer = new Random();
            double ranNum = ramdomizer.NextDouble();
            double cumulative = 0.0;

            var playerRates = scoreRates.First(x => x.Key.Id.Equals(player.Id)).Value;
            for(int i =0; i<playerRates.Count(); i ++)
            {
                cumulative += playerRates[i].Value;
                if (ranNum < cumulative)
                {
                   return playerRates[i].Key;
                }
            }
            return 0;
        }
    }
}
