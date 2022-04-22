using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Models
{
    public class Dto
    {
        public int No { get; set; }
        public string TeamName { get; set; }
        public int GamesPlayed { get; set; } = 0;
        public int GamesWon { get; set; } = 0;
        public int GamesDrawn { get; set; } = 0;
        public int GamesLost { get; set; } = 0;
        public int GoalFor { get; set; } = 0;
        public int GoalsAgainst { get; set; } = 0;
        public int GoalDifference { get; set; } = 0;
        public int Points { get; set; } = 0;
    }
}
