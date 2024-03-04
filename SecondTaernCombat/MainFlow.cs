using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTaernCombat
{
    public static class MainFlow
    {
        public static void Run(Character[] firstTeam, Character[] secondTeam)
        {
            //While there is living character in any team do one full turn of Combat
            while (firstTeam.Any(character => character.health > 0) && secondTeam.Any(character => character.health > 0))
            {
                DoOneTurn(firstTeam, secondTeam);
            }
            //Increase win counter for the winning team
            if (firstTeam.Any(character => character.health > 0)) { WinsCounter.IncreaseWinCounter(0); }
            else WinsCounter.IncreaseWinCounter(1);
        }
        private static void DoOneTurn(Character[] firstTeam, Character[] secondTeam)
        {
            DetermineInitiative(firstTeam.Concat(secondTeam).ToArray());
            List<Ability> sortedInitiativeList = CreateAbilityInitiative(firstTeam, secondTeam);
            while (sortedInitiativeList.Count > 0)
            {
                bool didAttackSucceeded = false;

                // If attacker is dead Remove all of their attacks from the list
                if (sortedInitiativeList.First().IsUserDead()) 
                {
                    sortedInitiativeList
                        .RemoveAll(ability => ability.user == sortedInitiativeList.First().user); 
                }
                UseAbility(sortedInitiativeList.First(), sortedInitiativeList.First().user, firstTeam, secondTeam, out didAttackSucceeded);

                // if the Target is dead remove attack from the beggining of the list and put it int the end of it
                if (didAttackSucceeded == false)
                {
                    sortedInitiativeList.Add(sortedInitiativeList.First());
                    sortedInitiativeList.Remove(sortedInitiativeList.First());
                }
                else 
                {
                    // remove successful attack from the List
                    sortedInitiativeList.Remove(sortedInitiativeList.First());
                }
                if (firstTeam.All(character => character.health <= 0) || secondTeam.All(character => character.health <= 0)) { break; }
            }
        }
        private static void UseAbility(Ability ability, Character attacker, Character[] firstTeam, Character[] secondTeam, out bool didAttackSucceeded)
        {
            if (ability.IsTargetDead() == true)
            {
                // If target is dead find a new living target
                ability.SetTarget(ChooseTarget(attacker, firstTeam, secondTeam));
                didAttackSucceeded = false;
                return;
            }
            ability.ExecuteAbilityEffect();
            didAttackSucceeded = true;
        }
        private static List<Ability> CreateAbilityInitiative(Character[] firstTeam, Character[] secondTeam)
        {
            var AllCharacters = firstTeam.Concat(secondTeam).ToArray();
            var abilityInitiativeList = new List<Ability>();

            foreach (Character character in AllCharacters)
            {
                // Add all attacks of a character into the ability list
                if (character.health <= 0) { continue; }
                abilityInitiativeList.AddRange(ChooseAbilities(character, ChooseTarget(character, firstTeam, secondTeam)));
            }
            // Sort the initiative list by the attack type and then by character initiative
            return abilityInitiativeList
                .OrderBy(ability => ability.AttackType)
                .ThenBy(ability => ability.user.Initiative)
                .ToList();
        }
        private static void DetermineInitiative(Character[] characters)
        {
            Random rand = new Random();
            rand.Shuffle(characters);
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].SetInitiative(i);
            }
        }
        private static Character ChooseTarget(Character attacker, Character[] firstTeam, Character[] secondTeam)
        {
            return ChooseLivingCharacter(ChooseEnemyTeam(attacker, firstTeam, secondTeam));
        }
        private static Character[] ChooseEnemyTeam(Character attacker, Character[] firstTeam, Character[] secondTeam)
        {
            // Return team that the character is not a part of
            if (firstTeam.Any(character => character.id == attacker.id)) { return secondTeam; }
            else return firstTeam;
        }
        private static Character ChooseLivingCharacter(Character[] enemyTeam)
        {
            Character targetCharacter = null;
            //Choose a random character from enemy team, if it is alive return it, if it is dead start once again 
            do
            {
                Random rand = new Random();
                targetCharacter = enemyTeam[rand.Next(enemyTeam.Length)];
            }
            while (targetCharacter.health < 0);
            return targetCharacter;
        }
        private static List<Ability> ChooseAbilities(Character attacker, Character defender)
        {
            var abilities = new List<Ability>();
            //choose 5 random abilities from a character
            for (int i = 0; i < 5; i++)
            {
                Ability ability = attacker.ChooseRandomAbility();
                ability.SetUserAndTarget(attacker, defender);
                abilities.Add(ability);
            }
            return abilities;
        }
    }
}
