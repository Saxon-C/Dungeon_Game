using System;
using System.Reflection;

namespace PlaceholderGame
{
    public class Warrior
    {
        public Warrior()
        {

        }
        
        public void HeavingBlow(PlayerStats playerstats, MobStats mobstats)
        {
            if (playerstats.GetResource >= 20)
            {
                playerstats.GetResource -= 20;
                double heavingblow = playerstats.GetMeleeDamage * 1.5;
                mobstats.GetHealth -= heavingblow;
            }
        }

        public void AbilityTooltips(PlayerStats playerstats)
        {
            Console.WriteLine("(1) Mighty Slash" +
                              "\nA heavy slash to your foe causing " + playerstats.GetMeleeDamage + " damage. Cost: 0 Rage" +
                              "\n(2) Heaving Blow" +
                              "\nA powerful blow that deals " + playerstats.GetMeleeDamage * 1.5 + " damage. Cost: 20 Rage");
        }

        public void Attack(PlayerStats playerstats, Random rand, TestDummy testdummy, MobStats mobstats)
        {
            string userInput;
            Console.WriteLine("\nChoose an attack: " + "\n(1) Mighty Slash" + "\n(2) Heaving Blow" + "\n\n\n\n\n(5)Flee");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    OutputDamage();
                    break;

                case "2":
                    HeavingBlow(playerstats, mobstats);
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

            void OutputDamage()
            {
                playerstats.RandomBaseMeleeDamage();
                int totalCritChance = playerstats.GetCritChance;
                int critChance = rand.Next(0, 101);
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
    }
}
