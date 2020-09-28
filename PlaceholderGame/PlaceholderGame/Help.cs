using System;
namespace PlaceholderGame
{
    public class Help
    {
        public Help()
        {
            string userInput;
            string cont = "no";
            while (cont == "no")
            {
                Console.WriteLine("\nWhat do you need help with?");
                Console.WriteLine("(1) Stat Information");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\nHealth: The numerical value of your life. If it hits '0' then you're dead. Base value is 100." +
                                          "\nResource: The cost of using your abilities. If it's 0, you cannot use abilities. Base value is 100." +
                                          "\nDefense: Armor amount, decreases damage taken by <placeholder> per point." +
                                          "\nMelee Damage: How much damage your weapon does every swing. Can crit. Base value is random betwee 2-4." +
                                          "\nStamina: Every Stamina gives you +10 health." +
                                          "\nStrength: Makes you do more damage with Melee weapons. Every Strength is 2 Attack Power." +
                                          "\nAttack Power: Makes you do more damage with Melee weapons. Every 2 Attack Power gives your Melee " +
                                          "increased damage of (Attack Power / 3)." +
                                          "\nAgility: Increases your crit and hit chance." +
                                          "\nIntelligence: (Only for Mage) Increases Resource amount by 15 for every Intelligence point." +
                                          "\nSpeed: Increases dodge chance." +
                                          "\nDodge: Chance to avoid melee attacks." +
                                          "\nHit Chance: Chance to successfully hit your target.");

                        Console.WriteLine("\nBack to Main Menu? Yes or No?");
                        cont = Console.ReadLine();
                        if (cont.ToLower() == "yes")
                        {
                            break;
                        }
                        if (cont.ToLower() == "no")
                        {
                            _ = new Help();
                        }

                        break;

                    default:

                        break;
                }
            }
        }
    }
}
