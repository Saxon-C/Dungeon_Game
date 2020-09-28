using System;
using System.Reflection.Metadata.Ecma335;
using System.Security;

namespace PlaceholderGame
{
    public class TestDummy
    {
        string dummyName;
        string dummyGender;
        string dummyClass;
        string dummyTrait;

        public TestDummy()
        {
            dummyName = "Training Dummy";
            dummyGender = "NO_GENDER";
            dummyClass = "NO_CLASS";
            dummyTrait = "NO_TRAIT";
        }

        public TestDummy(Player player, MobDesign mob)
        {
            Identifiers(mob);
        }

        public void Attack(MobStats mobstats, Player player, Random rand, PlayerStats playerstats, TestDummy testdummy)
        {
            int mobInput;
            mobInput = rand.Next(1, 2);
            switch (Convert.ToString(mobInput))
            {
                case "1":
                    Melee();
                    break;

                default:
                    Attack(mobstats, player, rand, playerstats, testdummy);
                    break;
            }
            void Melee()
            {
                mobstats.RandomBaseMeleeDamage();
                int totalCritChance = mobstats.GetCritChance;
                int critChance = rand.Next(0, 101);
                if (critChance <= totalCritChance)
                {
                    double crit = mobstats.GetMeleeDamage * 2;
                    playerstats.GetHealth -= crit;
                    if (playerstats.GetHealth < 0)
                    {
                        playerstats.GetHealth = 0;
                        Console.WriteLine(testdummy.GetName + " CRITICALLY damaged " + player.GetName + " for " + crit +
                        ".");
                    }
                    else
                    {
                        Console.WriteLine(testdummy.GetName + " CRITICALLY damaged " + player.GetName + " for " + crit +
                        ".");
                    }
                }

                else
                {
                    playerstats.GetHealth -= mobstats.GetMeleeDamage;
                    if (playerstats.GetHealth < 0)
                    {
                        playerstats.GetHealth = 0;
                        Console.WriteLine(testdummy.GetName + " damaged " + player.GetName + " for " + mobstats.GetMeleeDamage +
                                          ".");
                    }
                    else
                    {
                        Console.WriteLine(testdummy.GetName + " damaged " + player.GetName + " for " + mobstats.GetMeleeDamage +
                                          ".");
                    }
                }
            }
        }

        public string Dialogue()
        {
            throw new NotImplementedException();
        }

        public void Identifiers(MobDesign mob)
        {
            dummyName = mob.GetName;
            dummyGender = mob.GetGender;
            dummyClass = mob.GetClass;
            dummyTrait = mob.GetPersonalityTrait;
        }


        public string GetName { get { return dummyName; } }
        public string GetGender { get { return dummyGender; } }
        public string GetClass { get { return dummyClass; } }
        public string GetTrait { get { return dummyTrait; } }

        //STAT TESTER
        private string PrintStats()
        {
            return "\nName: " + dummyName + "\nGender: " + dummyGender + "\nClass: " + dummyClass + "\nTrait: " + dummyTrait;

        }
    }
}
