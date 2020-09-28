using System;

namespace PlaceholderGame
{
    public class Player
    {


        //default constructor
        public Player()
        {
            GetName = "NO_NAME";
            GetGender = "NO_GENDER";
            GetClass = "NO_CLASS";
            GetTrait = "NO_TRAIT";
        }

        //custom constructor
        public Player(CharacterCreation charCreate, PlayerStats playerstats)
        {
            Identifiers(charCreate);
            if (charCreate.GetPersonalityTrait == "Hard-Headed")
            {
                playerstats.AddStrength(5);
            }
            Console.WriteLine(playerstats.ToString(charCreate));
            Console.WriteLine("\nSTATS COMPLETED");
        }

        public void Attack(PlayerStats playerstats, Random rand, TestDummy testdummy, MobStats mobstats)
        {
            string userInput;
            Console.WriteLine("\nChoose an attack: " + "\n(1) Mighty Slash" + "\n\n\n\n\n(5)Flee");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Melee();
                    break;

                case "5":
                    Console.WriteLine("Fleeing. Too hard for you?");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Unknown ability.");
                    Attack(playerstats, rand, testdummy, mobstats);
                    break;
            }

            //Normal Melee
            void Melee()
            {
                playerstats.RandomBaseMeleeDamage();
                int totalCritChance = playerstats.GetCritChance;
                int critChance = rand.Next(0, 101);
                //Console.WriteLine("\ncrit roll, must be lower than total crit for crit strike: " + critChance);
                //Console.WriteLine("total crit: " + totalCritChance + "\n");
                if (critChance <= totalCritChance)
                {
                    double crit = playerstats.GetMeleeDamage * 2;
                    mobstats.GetHealth -= crit;
                    if (mobstats.GetHealth < 0)
                    {
                        mobstats.GetHealth = 0;
                        Console.WriteLine("\nYou CRITICALLY damaged " + testdummy.GetName + " for " + crit +
                        ".");
                    }
                    else
                    {
                        Console.WriteLine("\nYou CRITICALLY damaged " + testdummy.GetName + " for " + crit +
                        ".");
                    }
                }

                else
                {
                    mobstats.GetHealth -= playerstats.GetMeleeDamage;
                    if (mobstats.GetHealth < 0)
                    {
                        mobstats.GetHealth = 0;
                        Console.WriteLine("\nYou damaged " + testdummy.GetName + " for " + playerstats.GetMeleeDamage +
                                          ".");
                    }
                    else
                    {
                        Console.WriteLine("\nYou damaged " + testdummy.GetName + " for " + playerstats.GetMeleeDamage +
                                          ".");
                    }
                }
            }
        }

        public string Dialogue()
        {
            throw new NotImplementedException();
        }

        public void Identifiers(CharacterCreation charCreate)
        {
            GetName = charCreate.GetName;
            GetGender = charCreate.GetGender;
            GetClass = charCreate.GetClass;
            GetTrait = charCreate.GetPersonalityTrait;
        }

        public string GetName { get; private set; }
        public string GetGender { get; private set; }
        public string GetClass { get; private set; }
        public string GetTrait { get; private set; }

        //IDENTITY TESTER
        private string PrintStats()
        {
            return "\nName: " + GetName + "\nGender: " + GetGender + "\nClass: " + GetClass + "\nTrait: " + GetTrait;
        }


    }
}