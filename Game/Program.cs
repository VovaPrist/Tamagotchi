Tamagotchi tamagotchi = new();
tamagotchi.Hi();
tamagotchi.PrintStats();

while (tamagotchi.GetAlive())
{
    tamagotchi.Choice();
    tamagotchi.PrintStats();
}
tamagotchi.CauseOfDeath();