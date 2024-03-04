using SecondTaernCombat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class DiceTest
    {
        [TestMethod]
        public void RollTestSides0()
        {
            Assert.AreEqual(0, Dice.Roll(0));
        }

        [TestMethod]
        public void RollTestSidesNegative()
        {
            Assert.AreEqual(0, Dice.Roll(-1));
        }

        [TestMethod]
        public void RollTestSides10()
        {
            Assert.IsTrue(Dice.Roll(10) <= 10 && Dice.Roll(10) > 0);
        }
    }
}
