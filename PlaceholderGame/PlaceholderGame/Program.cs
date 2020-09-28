using System;
using System.Timers;

namespace PlaceholderGame
{
    enum ArmorTypes { Light, Medium, Heavy };
    enum WeaponTypes { Dagger, One_Handed_Sword, Two_Handed_Sword, Stave };

    class Program
    {
        static void Main(string[] args)
        {

            Credits cred = new Credits();
            MainMenu menu = new MainMenu();
            Random rand = new Random();
            string userInput;
            userInput = Console.ReadLine();
            while (userInput != "10")
            {
                switch (userInput)
                {
                    case "1": //START GAME
                        CharacterCreation newChar = new CharacterCreation();
                        MobDesign mob = new MobDesign();
                        PlayerStats playerstats = new PlayerStats(newChar);
                        _ = new Inventory(newChar, playerstats);
                        Player player = new Player(newChar, playerstats);
                        TestDummy testdummy = new TestDummy();
                        MobStats mobstats = new MobStats(mob);
                        _ = new StartFight(player, playerstats, rand, testdummy, mobstats);

                        //to reduce clutter, when testing, exit
                        Console.WriteLine("END OF CASE 1, EXITING");
                        Environment.Exit(0);
                        break;

                    case "2": //LOAD GAME
                        Console.WriteLine("Option 2 Works\n");
                        break;

                    case "3": //OPTIONS
                        Console.WriteLine("Option 3 Works\n");
                        break;

                    case "7":
                        _ = new Help();
                        break;

                    case "8":
                        cred.PrintCredits();
                        break;

                    case "9":
                        //Quit
                        Console.WriteLine("Ending Session...");
                        cred.PrintCredits();
                        _ = new Quit();

                        break;

                    default:
                        Console.WriteLine("\nInvalid Option |" + userInput + "|" + "\n" + "Try again\n");
                        break;
                }
                menu.CallMenu();
                userInput = Console.ReadLine();
            }
        }
    }
}