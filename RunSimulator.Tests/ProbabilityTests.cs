using Run_Simulator;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RunSimulator.Tests
{
    public class ProbabilityTests
    {
        private readonly List<Player> players = new List<Player>
            {
             new Player("Pravin", 1),
             new Player("Irfan", 2),
             new Player("Jalinder", 3),
             new Player("Vaishali", 4),
            };
        public ProbabilityTests()
        {

        }
        [Fact]
        public void GetRunOnPrabability_RerurnResults()
        {
            players.ForEach(p =>
            {
                int run = Probability.GetRunOnPrabability(players.First());
                Assert.True(run >= 0 && run <= 7);
            });
            
        }
    }
}
