using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Channels;

public class Tamagotchi
{
    private int hunger;
    private int boredom;
    private List<String> words = new List<string>();
    private bool isAlive;
    public string Name;
    public void Main()
    {
        Hi();
        PrintStats();

        while (GetAlive())
        {
            Choice();
            PrintStats();
        }
        CauseOfDeath();
    }

    public void Feed()
    {
        hunger += 5;
        if (hunger >= 11) hunger = 11;
    }

    public void Hi()
    {
        print("Welcome to Tamagotchi");
        while (true)
        {
            print("Name your Tamagotchi: ");
            string temp = Console.ReadLine();

            if (temp != null && temp.Length < 2)
            {
                print("Name must be at least 3 characters long, try again");
                continue;
            }
            else if (temp != null)
            {
                print($"Confirm that your Tamagotchi name will be {temp}");
                while (true)
                {
                    print("Y/N");
                    string confirm = Console.ReadLine().ToLower();
                    if (confirm == null)
                    {
                        print("The field was empty, try again!");
                    }
                    else if (confirm == "y")
                    {
                        Name = temp;
                        break;
                    }
                    else if (confirm == "n") break;
                    else continue;
                }
                if (Name != null) break;
                else continue;
            }
            else print("The name is null");
        }
        print($"Everyone, welcome our new Tamagotchi - {Name}");
        boredom = 0;
        hunger = 10;
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
        isAlive = GetAlive();
        print("Stats: ");
        print($"Name: {Name}");
        print($"Alive: {isAlive}");
        print($"Hunger: {hunger}");
        print($"Boredom: {boredom}");
        print($"Words: {string.Join(", ", words)}");
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
        if (boredom <= -1) boredom = -1;
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
                    bool didTeach;

                    if (word != null && word.Length >= 1)
                    {
                        print($"Are you sure you want to teach {Name} word {word}");
                        while(true)
                        {
                            print("Y/N");
                            string temp = Console.ReadLine().ToLower();

                            if (temp == "y")
                            {
                                Teach(word);
                                didTeach = true;
                                break;
                            }
                            else if (temp == "n")
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