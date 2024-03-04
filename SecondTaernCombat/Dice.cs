using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTaernCombat
{
    public static class Dice
    {
        public static decimal Roll(int sides = 0)
        {
            if (sides <= 0) { return 0; } 
            var rand = new Random();
            return Convert.ToDecimal(rand.Next(1, sides+1));
        }
    }
}
