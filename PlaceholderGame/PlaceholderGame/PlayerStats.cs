using System;

namespace PlaceholderGame
{
    public class PlayerStats
    {
        private double totalHealth;
        private int resource = 0;

        //private readonly int missChance = 30;
        private int totalHitChance;

        //private readonly int dodge;

        private double totalArmor = 5;

        private double meleeDamage;

        private int totalAttackPower = 5;

        private double totalStamina = 10;

        private int totalStrength = 5;

        private int totalAgility = 5;

        private int totalIntelligence = 15;

        //private int totalSpellPower = 5;

        private int totalSpeed;

        private int totalCritChance = 5;

        public PlayerStats(CharacterCreation playerCharacter)
        {
            AddStamina(0);
            AddStrength(0, playerCharacter);
            AddAgility(0);
            AddIntelligence(0, playerCharacter);
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

        public void AddIntelligence(int amountOfIntelligence, CharacterCreation playerCharacter)
        {
            totalIntelligence = amountOfIntelligence + totalIntelligence;
            if (playerCharacter.GetClass == "Warrior")
            {
                resource = 100;
            }
            if (playerCharacter.GetClass == "Rogue")
            {
                resource = 100;
            }
            if (playerCharacter.GetClass == "Mage")
            {
                resource = totalIntelligence * 15;
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

        public void AddSpellPower(int amountOfSpellPower)
        {

        }

        public void AddStamina(double amountOfStamina)
        {
            totalStamina = amountOfStamina + totalStamina;
            GetHealth = totalStamina * 10;
            //test
            GetHealth = 2000;
            GetHealth = 20000;
        }

        public void AddStrength(int amountOfStrength, CharacterCreation playerClass)
        {
            if (playerClass.GetClass == "Rogue")
            {
                int addOneStrengthFromAgility = totalAgility / 2;
                totalStrength = addOneStrengthFromAgility + totalStrength;
                totalStrength = amountOfStrength + totalStrength;
                totalAttackPower = (totalStrength * 2) + totalAttackPower;
                meleeDamage = (totalAttackPower / 4) + meleeDamage;
            }
            else
            {
                totalStrength = amountOfStrength + totalStrength;
                totalAttackPower = (totalStrength * 2) + totalAttackPower;
                meleeDamage = (totalAttackPower / 4) + meleeDamage;
            }
        }

        //base stats - after health/resource ALPHABETICAL ORDER
        /* public void Health()
        {
            health = 0;
        }

        public void Resource()
        {
            resource = 0;
        }*/

        //NYI
        public void Defense()
        {

        }

        //NYI
        public void Dodge()
        {

        }

        //if hit > miss, it's hit, if hit < miss, it's miss
        /*public void HitChance(TestDummy testdummy, Random rand, MobStats mobstats)
        {
            Console.WriteLine(totalHitChance);
            hitChance = rand.Next(0, 101);
            //Console.WriteLine("hitChance, must be > misschance " + hitChance);
            //Console.WriteLine("miss chance: " + missChance);
            if (hitChance >= missChance)
            {
                Hit(testdummy, rand, mobstats);
            }
            else
            {
                Miss();
            }

            /* //hit method
             void Hit(TestDummy testdummy, Random rand, MobStats mobstats)
             {
                 MeleeDamage(testdummy, rand, mobstats);
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
        public int GetResource { get { return resource; } set { resource = value; } }
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
        public string ToString(CharacterCreation playerCharacter)
        {
            return "\nHealth: " + GetHealth +
            "\nResource: " + resource + " " + playerCharacter.GetClass +
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
