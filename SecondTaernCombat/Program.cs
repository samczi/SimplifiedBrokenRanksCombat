using SecondTaernCombat;

Ability[] Melee = { new Ability("Overhead Strike", 2, 1.2m, 1.0m), new Ability("Precise Strike", 2, 1.0m, 1.2m) };
Ability[] Ranged = { new Ability("Powerfull Shot", 1, 1.2m, 1.0m), new Ability("Precise Shot", 1, 1.0m, 1.2m) };
Ability[] Magic = { new Ability("Strong Curse", 0, 1.2m, 1.0m), new Ability("Accurate Curse", 0, 1.0m, 1.2m) };
Ability[] Mixed = { new Ability("Overhead Strike", 2, 1.2m, 1.0m), new Ability("Precise Strike", 2, 1.0m, 1.2m), new Ability("Powerfull Shot", 1, 1.2m, 1.0m), new Ability("Precise Shot", 1, 1.0m, 1.2m), new Ability("Strong Curse", 0, 1.2m, 1.0m), new Ability("Accurate Curse", 0, 1.0m, 1.2m) };

for (int i = 0; i < 10000; i++)
{
    //Initialize Characters used for Simulation
    Character Char1 = new Character(1000, 1000, (500m*1.27m), 500m, 1000, 0,0, Melee);
    Character Char2 = new Character(1000, 1000, 500m, 500m, 1000, 0.135m,0,Melee);
    Character Char3 = new Character(1000, 1000, 500m, 500m, 1000, 0,0, Mixed);
    Character Char4 = new Character(1000, 1000, 500m, 500m, 1000, 0,0, Mixed);
    Character Char5 = new Character(1000, 1000, 500m, 500m, 1000, 0,0,Ranged);
    Character Char6 = new Character(1000, 1000, 500m, 500m, 1000, 0,0, Magic);

    //Start a fight between team1 and team2
    MainFlow.Run([Char3], [Char4]);
}

Console.WriteLine($"{WinsCounter.firstTeamWins} {WinsCounter.secondTeamWins}");
Console.ReadKey();