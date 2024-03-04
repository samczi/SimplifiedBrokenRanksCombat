using SecondTaernCombat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{

    [TestClass]
    public class CharacterTest
    {
        private Character testCharacter;

        [TestInitialize]
        public void Init()
        {
            testCharacter = new Character(69, 1000, 1000, 500m, 500m, 1000, 0, 0);
        }

        [TestMethod]
        public void Receive10DamageTest()
        {
            testCharacter.ReceiveDamage(10);
            Assert.AreEqual(testCharacter.maxHealth - 10, testCharacter.health);
        }

        [TestMethod]
        public void Receive0DamageTest()
        {
            testCharacter.ReceiveDamage(0);
            Assert.AreEqual(testCharacter.maxHealth - 0, testCharacter.health);
        }

        [TestMethod]
        public void Receive1000DamageTest()
        {
            testCharacter.ReceiveDamage(1000);
            Assert.AreEqual(testCharacter.maxHealth - 1000, testCharacter.health);
        }

        [TestMethod]
        public void Receive10000DamageTest()
        {
            testCharacter.ReceiveDamage(10000);
            Assert.AreEqual(testCharacter.maxHealth - 10000, testCharacter.health);
        }

        [TestMethod]
        public void ReceiveNegative10DamageTest()
        {
            testCharacter.ReceiveDamage(-10);
            Assert.AreEqual(testCharacter.maxHealth - -10, testCharacter.health);
        }
    }
}
