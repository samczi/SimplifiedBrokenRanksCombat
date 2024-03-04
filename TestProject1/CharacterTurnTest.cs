using SecondTaernCombat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class CharacterTurnTest
    {
        private Character Attacker, Defender;

        [TestInitialize]
        public void Init()
        {
            Attacker = new Character(69, 1000, 1000, 500m, 500m, 1000, 0, 0);
            Defender = new Character(420, 1000, 1000, 500m, 500m, 1000, 0, 0);
        }

        [TestMethod]
        [TestCategory("DoCharacterTurnTests")]
        public void AttackMissWithNoDoubleHit()
        {
            CharacterTurn turn = new CharacterTurn(Attacker, Defender);
            turn.DoCharacterTurn();
            Assert.AreEqual(Defender.maxHealth, Defender.health);
        }

        [TestMethod]
        [TestCategory("DoCharacterTurnTests")]
        public void AttackMissWithDoubleHit()
        {
            CharacterTurn turn = new CharacterTurn(Attacker, Defender);
            turn.DoCharacterTurn();
            Assert.AreEqual(Defender.maxHealth, Defender.health);

        }
    }
}
