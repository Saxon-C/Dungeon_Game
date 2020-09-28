using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PlaceholderGame
{
    public class Inventory
    {
        public Inventory(CharacterCreation character, PlayerStats playerstats)
        {
            /*List<Inventory> Armor = new List<Inventory>();
            List<Inventory> Weapons = new List<Inventory>();
            List<Inventory> Miscellaneous = new List<Inventory>();*/

            if (character.GetClass == "Warrior")
            {
                playerstats.AddStrength(5, character);
            }

            if (character.GetClass == "Rogue")
            {
                playerstats.AddAgility(5);
            }

            if (character.GetClass == "Mage")
            {
                playerstats.AddIntelligence(5, character);
            }


        }
    }
}
