using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Championship
{
    public class Team
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }

        public int Wins { get; set; }

        public int Lose { get; set; }

        public int Draw { get; set; }

        public int ScoredGoals { get; set; }
        public int ConcededGoals { get; set; }

        public List<Player> Players { get; set; }

    }
}
