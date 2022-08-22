namespace Lab_4_1_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<GameCharacter> charlist = new List<GameCharacter>();
            charlist.Add(new Warrior("Longsword", "Havardi", 8, 16));
            charlist.Add(new Warrior("Hammer", "Moltar", 10, 15));
            charlist.Add(new Warrior("Holy Avenger", "Biff", 9, 18));
            charlist.Add(new Warrior("Great Axe", "Leopold", 18, 19));
            charlist.Add(new Warrior("Lance", "Sir Guiver", "Bold", 12, 14));
            charlist.Add(new Wizard(6, 5, "Griff", 9, 18));
            charlist.Add(new Wizard(60, 12, "Elminster", 9, 18));
            charlist.Add(new Wizard(5, 8, "Harry Dresden","Wizard of Chicago", 9, 18));

            foreach(GameCharacter character in charlist)
            {
                character.Play();
            }


        }
    }


    class GameCharacter
    {
        public string name;
        public int strength;
        public int intelligence;
        public string title;


        public GameCharacter(string _Name, int _strength, int _intelligence)
        {
            name = _Name;
            strength = _strength;
            intelligence = _intelligence;
            if (title == null)
            {
                title = "Commoner";
            }
        }


        public virtual void Play()
        {
            Console.WriteLine($"{name} the {title} (int {intelligence}, strength {strength})");
        }

         
    }

    class Warrior : GameCharacter
    {
       
        public string WeaponType;
        

        public Warrior(string _WeaponType, string _title, string _wName, int _wStrength, int _wIntelligence)
            :base(_wName, _wStrength, _wIntelligence )
        {
            title = _title;
            WeaponType = _WeaponType;

        }
       public Warrior(string _WeaponType, string _wName, int _wStrength, int _wIntelligence)
            :base(_wName, _wStrength, _wIntelligence)
        {
            WeaponType = _WeaponType;
            int titleRoll = new Random().Next(1,5);
            switch (titleRoll)
            {
                case 1: title = "Viking"; break;
                case 2: title = "Barbarin"; break;
                case 3: title = "Cavalier"; break;
                case 4: title = "Swashbuckler"; break;
            }
        }

        public override void Play()
        {
            Console.WriteLine($"{name} the {title} (int {intelligence}, strength {strength}) {WeaponType}");
        }
    }

    class MagicUsingCharacter : GameCharacter
    {
        public int magicalEnergy;

        public MagicUsingCharacter(int _magicalEnergy, string _mName, int _mStrength, int _mIntelligence)
                       : base(_mName, _mStrength, _mIntelligence)
        {
            magicalEnergy = _magicalEnergy;
            
        }
    }

    class Wizard : MagicUsingCharacter
    {
        public int spellNumber;
   
        public Wizard (int _spellNumber, int _magicalEnergy,  string _mName, string _title, int _mStrength, int _mIntelligence) 
        : base(_magicalEnergy,  _mName,  _mStrength, _mIntelligence)
        {
            title = _title;
            spellNumber = _spellNumber;
        }


        public Wizard(int _spellNumber, int _magicalEnergy, string _mName, int _mStrength, int _mIntelligence)
      : base(_magicalEnergy,  _mName, _mStrength, _mIntelligence)
        {
            spellNumber = _spellNumber;
            int titleRoll = new Random().Next(1, 5);
            switch (titleRoll)
            {
                case 1: title = "War Mage"; break;
                case 2: title = "Archmagi"; break;
                case 3: title = "Sorcerer"; break;
                case 4: title = "Warlock"; break;
            }
        }

        public override void Play()
        {
            Console.WriteLine($"{name} the {title} (int {intelligence}, strength {strength}, magic {magicalEnergy}) {spellNumber} Spells");
        }


    }








}