using System;
using Microsoft.VisualBasic;

namespace PlaceholderGame
{
    public class CharacterCreation
    {

        //main 
        public CharacterCreation()
        {
            string creating = "creating";
            while (creating.ToLower() == "creating")
            {
                Name();
                Gender();
                ChooseClass();
                PersonalityTrait();
                while (creating.ToLower() != "done")
                {
                    Console.WriteLine(ToString());
                    Console.Write("\nIs this what you want? ");
                    creating = Console.ReadLine();
                    if (creating.ToLower() == "yes")
                    {
                        break;
                    }
                    if (creating.ToLower() == "no")
                    {
                        Console.WriteLine("\nResetting Character Creation...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid response.");
                    }
                }
                if (creating.ToLower() == "yes")
                {
                    break;
                }
                else
                {
                    creating = "creating";
                }
            }
        }

        //NAME CREATION
        public string Name()
        {
            string userInput;
            Console.WriteLine("\nName your character: ");
            userInput = Console.ReadLine();
            for (int index = 0; index < userInput.Length; index++)
            {
                while (char.IsDigit(userInput, index) == true)
                {
                    Console.WriteLine("\nOnly characters A-Z are allowed.");
                    Console.WriteLine("\nName your character: ");
                    userInput = Console.ReadLine();
                }
            }
            GetName = userInput;
            return GetName;
        }

        public string GetName { get; private set; }



        //GENDER CREATION
        public string Gender()
        {
            string userInput = "NULL";
            while (userInput != "10")
            {
                Console.WriteLine("\nChoose your gender: ");
                Console.WriteLine("\n(1) Male" + "\n(2) Female" + "\n\n(9) Quit");
                userInput = Console.ReadLine();
                if (userInput == "1" || userInput == "2")
                {
                    if (userInput == "1")
                    {
                        GetGender = "Male";
                        return GetGender;
                    }

                    if (userInput == "2")
                    {
                        GetGender = "Female";
                        return GetGender;
                    }
                }

                if (userInput == "9")
                {
                    //in game menu
                    //for now, just quit until implemented
                    Environment.Exit(0);
                    break;
                }

                else
                {
                    Console.WriteLine("\nInvalid response.");
                }
            }
            return GetGender;
        }

        public string GetGender { get; private set; }



        //CLASS CREATION
        public string ChooseClass()
        {
            Console.WriteLine("\nChoose your class: ");
            string userInput = "0";
            while (userInput != "10")
            {
                //WARRIOR CLASS DESCRIPTION
                Console.WriteLine("\n(1) WARRIOR \nA fighter who posesses immense strength " +
                "and is scared of no foe regardless their size. Uses heavy armor and " +
                "and two-handed weapons. Increased Strength.\n");

                //ROGUE CLASS DESCRIPTION
                Console.WriteLine("(2) ROGUE \nA shadow in the dark who stalks their " +
                "prey. Quick and quiet is their motto. Uses medium armor and " +
                "one-handed weapons. Increased Agility.\n");

                //MAGE CLASS DESCRIPTION
                Console.WriteLine("(3) MAGE \nA caster, otherwise known as somebody with " +
                "haphephobia, likes to keep distance from their enemies. At first glance " +
                "they seem weak and helpless, on second glance you're in the grave " +
                "with a fireball through your head. Increased Intelligence.");

                Console.WriteLine("\n(9) Quit");

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        if (userInput == "1")
                        {
                            GetClass = "Warrior";
                        }
                        return GetClass;

                    case "2":
                        if (userInput == "2")
                        {
                            GetClass = "Rogue";
                        }
                        return GetClass;

                    case "3":
                        if (userInput == "3")
                        {
                            GetClass = "Mage";
                        }
                        return GetClass;

                    case "9":
                        if (userInput == "9")
                        {
                            //in game menu
                            //for now, just quit until implemented
                        }
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nInvalid response.");
                        break;
                }
            }
            return GetClass;
        }

        //GET CLASS
        public string GetClass { get; private set; }



        //PERSONALITY TRAIT CREATION
        public string PersonalityTrait()
        {
            string userInput = "0";
            while (userInput != "9")
            {
                Console.WriteLine("\nChoose a personality trait: ");
                Console.WriteLine("\n(1) Hard-Headed: \"Hard-Headed, and literally hard-headed!\" +5 Stamina");
                Console.WriteLine("(2) Observant: Your intense focus makes it easier to find weakpoints on the target. +5 Agility");
                Console.WriteLine("(3) Quarrelsome: Your anger issues have allowed many opportunities to hone your weapon skills over the years. +5 Strength");
                Console.WriteLine("(4) Paranoid: You're always on edge, causing you to be jumpier and more aware than everybody else. +5 Speed");
                Console.WriteLine("(5) Clever: When you look in the mirror all you see is a worm because of all the studying you've done. +5 Intelligence");
                Console.WriteLine("(9) Quit");

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        GetPersonalityTrait = "Hard-Headed";
                        return GetPersonalityTrait;

                    case "2":
                        GetPersonalityTrait = "Observant";
                        return GetPersonalityTrait;

                    case "3":
                        GetPersonalityTrait = "Quarrelsome";
                        return GetPersonalityTrait;

                    case "4":
                        GetPersonalityTrait = "Paranoid";
                        return GetPersonalityTrait;

                    case "5":
                        GetPersonalityTrait = "Clever";
                        return GetPersonalityTrait;

                    case "9":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid response.");
                        break;
                }
            }
            return GetPersonalityTrait;
        }

        public string GetPersonalityTrait { get; private set; }



        public string CharacterName { get; set; }
        public string CharacterGender { get; set; }
        public string CharacterClass { get; set; }
        public string CharacterTrait { get; set; }



        override
        public string ToString()
        {
            return "\nName: " + GetName + "\nGender: " + GetGender + "\nClass: " + GetClass +
            "\nPersonality Trait: " + GetPersonalityTrait;
        }

    }
}
