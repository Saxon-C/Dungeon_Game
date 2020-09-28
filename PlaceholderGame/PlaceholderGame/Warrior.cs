using System;

namespace PlaceholderGame
{
    public class Warrior
    {
        public Warrior()
        {

        }

        public void HeavingBlow(PlayerStats playerstats, MobStats mobstats)
        {
            double heavingblow = playerstats.GetMeleeDamage * 1.5;
            mobstats.GetHealth -= heavingblow;

        }

        public void AbilityTooltips(PlayerStats playerstats)
        {
            Console.WriteLine("(1) Mighty Slash" +
                              "\nA heavy slash to your foe causing " + playerstats.GetMeleeDamage + " damage. Cost: 0 Rage" +
                              "\n(2) Heaving Blow" +
                              "\nA powerful blow that deals " + playerstats.GetMeleeDamage * 1.5 + " damage. Cost: 20 Rage");

        }
    }
}
