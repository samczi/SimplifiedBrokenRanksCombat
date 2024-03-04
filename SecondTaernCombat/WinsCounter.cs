using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTaernCombat
{
    public class WinsCounter
    {
        public static int firstTeamWins { get; set; } = 0;
        public static int secondTeamWins { get; set; } = 0;
        public static void IncreaseWinCounter(int winner)
        {
            if (winner == 0) { firstTeamWins++; }
            else { secondTeamWins++; }
        }
    }
}
