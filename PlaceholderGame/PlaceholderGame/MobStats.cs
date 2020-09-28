using System;

namespace PlaceholderGame
{
    public class MobStats
    {
        //private double totalHealth;

        //private readonly int missChance = 30;
        private int totalHitChance;

        //private readonly int dodge;

        private double totalArmor = 5; //default 5

        private double meleeDamage;

        private int totalAttackPower = 5;

        private double totalStamina = 10;

        private int totalStrength = 5;

        private int totalAgility = 5;

        private int totalIntelligence = 15;

        private int totalSpeed;

        private double crit;
        private int critChance;
        private int totalCritChance = 5;

        public MobStats(MobDesign mob)
        {
            AddStamina(0);
            AddStrength(0);
            AddAgility(0);
            AddIntelligence(0, mob);
            AddSpeed(0);
            RandomBaseMeleeDamage();
            InitializeMeleeDamage();
            AddCritChance(0);
            AddHitChance(0);
            AddDefense(0);
            TotalHealth();
            //Console.WriteLine(ToString());

        }


        //Add - secondary stats ALPHABETICAL ORDER
        public void AddAgility(int amountOfAgility)
        {
            totalAgility = amountOfAgility + totalAgility;
        }

        public void AddCritChance(int amountOfCrit)
        {
            int addOneCritFromAgility;
            addOneCritFromAgility = (totalAgility / 5);

            if (addOneCritFromAgility >= 1)
            {
                totalCritChance += addOneCritFromAgility;
            }

            totalCritChance = amountOfCrit + totalCritChance; // 0 += 5
        }

        //split this into two, adddefense and a method to take it and reduce damage
        //instead of reducing overall meleedamage.
        //right now it reduces overall meleedamage, when it should actually
        //take enemy armor and reduce dmg taken for that one fight.
        public void AddDefense(int amountOfArmor)
        {
            double armorReduction;

            totalArmor = amountOfArmor + totalArmor;
            armorReduction = (totalArmor * 0.05);
            meleeDamage -= armorReduction;
        }

        public void AddIntelligence(int amountOfIntelligence, MobDesign mob)
        {
            totalIntelligence = amountOfIntelligence + totalIntelligence;
            if (mob.GetClass == "Warrior")
            {
                GetResource = 100;
            }
            if (mob.GetClass == "Rogue")
            {
                GetResource = 100;
            }
            if (mob.GetClass == "Mage")
            {
                GetResource = totalIntelligence * 15;
            }
        }

        //not in use
        public void AddHitChance(int amountOfHit)
        {
            int addOneHitFromAgility;
            addOneHitFromAgility = (totalAgility / 5);

            if (addOneHitFromAgility >= 1)
            {
                totalHitChance += addOneHitFromAgility;
            }

            totalHitChance = amountOfHit + totalHitChance;
        }

        //not in use
        public void AddSpeed(int amountOfSpeed)
        {
            totalSpeed = amountOfSpeed + totalSpeed;
        }

        public void AddStamina(double amountOfStamina)
        {
            totalStamina = amountOfStamina + totalStamina;
            GetHealth = (totalStamina * 10);
        }

        public void AddStrength(int amountOfStrength)
        {
            totalStrength = amountOfStrength + totalStrength;
            totalAttackPower = (totalStrength * 2) + totalAttackPower;
            meleeDamage = (totalAttackPower / 4) + meleeDamage;
        }

        //if crit chance is in target zone, it comes here and crits
        public void Crit(PlayerStats playerstats, Player player)
        {
            crit = meleeDamage * 2;
            playerstats.GetHealth -= crit;
            if (playerstats.GetHealth < 0)
            {
                playerstats.GetHealth = 0;
                Console.WriteLine("\nYou CRITICALLY damaged " + player.GetName + " for " + crit +
                "." + "\n" + player.GetName + " HP: " + playerstats.GetTotalHealth + "/" + playerstats.GetHealth + "*DECEASED*");
            }
            else
            {
                Console.WriteLine("\nYou CRITICALLY damaged " + player.GetName + " for " + crit +
                "." + "\n" + player.GetName + " HP: " + playerstats.GetHealth);
            }
        }

        //checks if attack is a crit, if not, it's normal hit
        public void CritChance(int totalCritChance, Player player, Random rand, PlayerStats playerstats)
        {
            critChance = rand.Next(0, 101);
            //Console.WriteLine("\ncrit roll, must be lower than total crit for crit strike: " + critChance);
            //Console.WriteLine("total crit: " + totalCritChance + "\n");
            if (critChance <= totalCritChance)
            {
                Crit(playerstats, player);
            }

            else
            {
                playerstats.GetHealth -= meleeDamage;
                if (playerstats.GetHealth < 0)
                {
                    playerstats.GetHealth = 0;
                    Console.WriteLine("\nYou damaged " + player.GetName + " for " + GetMeleeDamage +
                                      "." + "\n" + player.GetName + " HP: " + playerstats.GetHealth + "*DECEASED*");
                }
                else
                {
                    Console.WriteLine("\nYou damaged " + player.GetName + " for " + GetMeleeDamage +
                                      "." + "\n" + player.GetName + " HP: " + playerstats.GetTotalHealth + "/" + playerstats.GetHealth);

                }
            }
        }

        //NYI
        public void Defense()
        {

        }

        //NYI
        public void Dodge()
        {

        }

        //if hit > miss, it's hit, if hit < miss, it's miss
        /*public void HitChance(Player player, Random rand, MobStats playerstats)
        {
            Console.WriteLine(totalHitChance);
            hitChance = rand.Next(0, 101);
            //Console.WriteLine("hitChance, must be > misschance " + hitChance);
            //Console.WriteLine("miss chance: " + missChance);
            if (hitChance >= missChance)
            {
                Hit(player, rand, playerstats);
            }
            else
            {
                Miss();
            }

            /* //hit method
             void Hit(Player player, Random rand, MobStats playerstats)
             {
                 MeleeDamage(player, rand, playerstats);
             }

             //miss method
             static void Miss()
             {
                 Console.WriteLine("Your attack missed.");
             }
        }*/

        public void TotalHealth()
        {
            GetTotalHealth = GetHealth;
        }

        //Attack Order
        //melee goes to critchance, 1. if crit, critchance goes to crit, 2. if not crit, then done
        public void RandomBaseMeleeDamage()
        {
            Random rand = new Random();
            GetBaseMeleeDamage = rand.Next(2, 6);
        }
        public void InitializeMeleeDamage()
        {
            meleeDamage = GetBaseMeleeDamage;
        }

        //GET AND SET METHODS FOR PLAYER STATS
        public double GetMeleeDamage { get { return meleeDamage; } set { meleeDamage += value; } }
        public int GetBaseMeleeDamage { get; private set; }
        public double GetHealth { get; set; } = 0;
        public int GetResource { get; set; } = 0;
        public double GetStamina { get { return totalStamina; } set { totalStamina += value; } }
        public int GetStrength { get { return totalStrength; } set { totalStrength += value; } }
        public int GetAgility { get { return totalAgility; } set { totalAgility += value; } }
        public int GetIntelligence { get { return totalIntelligence; } set { totalIntelligence += value; } }
        public int GetSpeed { get { return totalSpeed; } set { totalSpeed += value; } }
        public int GetAttackPower { get { return totalAttackPower; } set { totalAttackPower += value; } }
        public int GetHitChance { get { return totalHitChance; } set { totalHitChance += value; } }
        public int GetCritChance { get { return totalCritChance; } set { totalCritChance += value; } }
        public double GetDefense { get { return totalArmor; } set { totalArmor += value; } }
        public double GetTotalHealth { get; set; }


        //override
        public string ToString(CharacterCreation mob)
        {
            return "\nHealth: " + GetHealth +
            "\nResource: " + GetResource + " " + mob.GetClass +
            "\nArmor: " + totalArmor +
            "\nStamina: " + totalStamina +
            "\nStrength: " + totalStrength +
            "\nIntelligence: " + totalIntelligence +
            "\nAttack Power: " + totalAttackPower +
            "\nCrit Chance: " + totalCritChance +
            "\nHit Chance: " + totalHitChance +
            "\nSpeed: " + totalSpeed +
            "\nBase Melee Damage  is: " + GetBaseMeleeDamage +
            "\nCalculated Melee Damage: " + meleeDamage;
        }
    }
}
