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
        public Player(CharacterCreation character, PlayerStats playerstats)
        {
            Identifiers(character);
            if (character.GetPersonalityTrait == "Hard-Headed")
            {
                playerstats.AddStrength(5, character);
            }
            Console.WriteLine(playerstats.ToString(character));
            Console.WriteLine("\nSTATS COMPLETED");
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