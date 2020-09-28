using System;
using System.Threading;
namespace PlaceholderGame
{
    public class StartFight
    {
        public StartFight(Player player, PlayerStats playerstats, Random rand, TestDummy testdummy, MobStats mobstats)
        {
            double dead = 0;
            Console.WriteLine("****************************************");
            Console.WriteLine("\nA fight has begun!");

            while (playerstats.GetHealth > dead && mobstats.GetHealth > dead)
            {
                //PlayerAttacks
                player.Attack(playerstats, rand, testdummy, mobstats);

                if (playerstats.GetHealth <= dead)
                {
                    Console.WriteLine("You died. Your adventure is over.");
                }

                Thread.Sleep(5);
                testdummy.Attack(mobstats, player, rand, playerstats, testdummy);
                if (mobstats.GetHealth <= dead)
                {
                    Console.WriteLine("\nCongratulations, you defeated the enemy!");
                }

                Console.WriteLine(player.GetName + ": " + playerstats.GetTotalHealth + "/" + playerstats.GetHealth
                + "\n" + testdummy.GetName + ": " + mobstats.GetTotalHealth + "/" + mobstats.GetHealth);
            }
            Console.WriteLine("****************************************");
        }
    }
}
