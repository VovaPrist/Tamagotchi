using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Channels;

public class Tamagotchi
{
    private int hunger;
    private int boredom;
    private List<String> words;
    private bool isAlive;
    public string Name;

    public void Feed()
    {
        hunger += 5;
        if (hunger >= 10) hunger = 10;
    }

    public void Hi()
    {
        print("Welcome to Tamagotchi");
        print("Name your Tamagotchi: ");
        while (true)
        {
            string temp = Console.ReadLine();

            if (temp.Length < 2)
            {
                print("Name must be at least 3 characters long, try again");
                continue;
            }
            else
            {
                print($"Confirm that your Tamagotchi name will be {temp}");
                print("Y/N");
                while (true)
                {
                    string confirm = Console.ReadLine();
                    if (confirm == "Y")
                    {
                        Name = temp;
                        break;
                    }
                    else if (confirm == "N") break;
                    else continue;
                }
                if (Name.Length > 2) break;
            }
        }
        print($"Everyone, welcome our new Tamagotchi - {Name}");
        Console.ReadLine();
    }

    public void Greet()
    {
        print($"Hi {Name}!");
        print("Decreased boredom by 2 points");
        ReduceBoredom(2);
    }

    public void Teach(string word)
    {
        words.Add(word);
        ReduceBoredom(4);
    }

    public void DoNothing()
    {
        print("doing nothing...");
    }

    public void Tick()
    {
        hunger -= 1;
        boredom += 1;

    }

    public void PrintStats()
    {
        print($"Name: {Name}");
        print($"Alive: {isAlive}");
        print($"Hunger: {hunger}");
        print($"Boredom: {boredom}");
        print($"Words: {words}");
    }

    public bool GetAlive()
    {
        if (boredom < 10 && hunger > 0) return true;
        else return false;
    }
    public void CauseOfDeath()
    {
        if (boredom >= 10 && hunger <= 0)
        {
            print($"{Name} died because you starved him to death furthermore didn't give him any attention, I'm calling 911");
        }
        else if (boredom >= 10)
        {
            print($"{Name} died because of your ruthlessness and lack of paying attention");
        }
        else if (hunger <= 0)
        {
            print($"{Name} died.. because you starved him...");
        }
        else print("Something wrong in the code, you shouldn't see this message");
    }

    private void ReduceBoredom(int points)
    {
        boredom -= points;
        if (boredom <= 0) boredom = 0;
    }

    public void Choice()
    {
        
            print($"Choose what do you want to do with {Name}:");

            print($"1. Teach {Name} a new word");
            print($"2. Greet {Name}");
            print($"3. Feed {Name}");
            print("4. Do nuttin'");
            print("1/2/3/4");

            while (true)
            {
                string choice = Console.ReadLine();

                if(choice == "1")
                {
                    Choice1();
                    break;
                }
                else if(choice == "2")
                {
                    Greet();
                    break;
                }
                else if(choice == "3")
                {
                    Feed();
                    break;
                }
                else if(choice == "4")
                {
                    DoNothing();
                    break;
                }
                else
                {
                    print("Choose between 1, 2, 3 or 4");
                    continue;
                }
            }
            Tick();

    }

    public void Choice1()
    {
        print($"Choose a word you wanna teach {Name}");
                while (true)
                {
                    string word = Console.ReadLine();
                    bool didTeach = false;

                    if (word.Length >= 1)
                    {
                        print($"Are you sure you want to teach {Name} word {word}");
                        print("Y/N");
                        while(true)
                        {
                            string temp = Console.ReadLine();

                            if (temp == "Y")
                            {
                                Teach(word);
                                didTeach = true;
                                break;
                            }
                            else if (temp == "N")
                            {
                                didTeach = false;
                                break;
                            }
                            else
                            {
                                print("write Y or N");
                            }
                        }
                        if (didTeach)
                        {
                            print($"Good job teaching {Name} word {word}");
                            break;
                        }
                    }
                    else
                    {
                        print("The word has to be at least 1 character long, try again");
                    }
                }
    }

    private void print(string text)
    {
        Console.WriteLine(text);
    }
}