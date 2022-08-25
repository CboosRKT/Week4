namespace Rock_Paper_Scissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Make a bunch of players, random and not random
            Player paul = new Alwaysplayer("Paul", "paper");
            Player steve = new Alwaysplayer("Steve", "Sci");
            Player ryan = new Alwaysplayer("Ryan", "rok");

            Player ran1 = new RandomPlayer("Greg");
            Player ran2 = new RandomPlayer("Margo");
            Player ran3 = new RandomPlayer("Victoria");
            Player ran4 = new RandomPlayer("Arturo");
            Player ran5 = new RandomPlayer("Tiny");

            //Call Play() with a pile of them
        
            Play(paul, ran1);
            Play(steve, ran2);
            Play(ryan, ran3);
            Play(ran4, ran5);



        }



        enum Roshambo
        {
            Rock,
            Paper,
            Scissors,
            None
        }

        //player class
       public class Player
        {
            public string Name;
            public int CurrentChoice;

            public Player()
            {
                this.Name = "Void Player";
                this.CurrentChoice = 3; 
            }
          public  Player(string _Name)
            {
                this.Name = _Name;
                this.CurrentChoice = 3;
            }



           public virtual void Generate()
            {

            }

        }
        //Stores Player Name and Current Roshambo Choice
        //Member String Name
        //Member Roshambo Current Choice
        //Virual Method Generate that takes no Params and returns Void --- Have this method do nothing, just empty { }.

       public class RandomPlayer : Player
        {
            Random rnd;

            public RandomPlayer(string _rname) : base(_rname)
            {
                this.Name = _rname;
                this.rnd = new Random();
            }

            public override void Generate()
            {
              
               int rndChoice = rnd.Next(3);
               this.CurrentChoice = rndChoice;
            }
        }
        //Class RandomPlayer : Player (String _Name)
        //Generates a Random RPS choice
        //Override Generate() to create a random RPS choice.

        //Class AlwaysPlayer : Player (String _Name, Roshambo _Choice)
        //Always plays a particular RPS choice 
       public class Alwaysplayer : Player
        {
           public int alwaysPlay;
          public  Alwaysplayer(string _aname, string _alwaysPlay) : base(_aname)
            {
                this.Name = _aname;
                char aChoice = (_alwaysPlay.ToLower().Trim())[0];
                switch (aChoice)
                {
                    case 'r':
                        CurrentChoice = 0;
                        break;
                   case 'p':
                        CurrentChoice = 1;
                        break;
                    case 's':
                        CurrentChoice = 2;
                        break;

                    default:
                        CurrentChoice = 3; 
                    break;
                }
            }
        }
        //Play(Player _p1, Player _p2){

        public static void Play(Player p1, Player p2)
        {
            p1.Generate();
            p2.Generate();

            int p1Choice = p1.CurrentChoice;
            int p2Choice = p2.CurrentChoice;

            string p1Roshambo = "" + (Roshambo)p1.CurrentChoice;
            string p2Roshambo = "" + (Roshambo)p2.CurrentChoice;

           Console.WriteLine($"Match: {p1.Name} chose {p1Roshambo}, {p2.Name} chose {p2Roshambo}");
           if (p1Choice == 3 || p2Choice == 3)
            {
                Console.WriteLine("Result: No Winner - Invalid Play!");
            }
            else if(p1Choice == p2Choice){
                Console.WriteLine("Result: Draw!");

            }
            else
            {
                switch (p1Choice)
                {
                    case 0:
                        
                        switch (p2Choice)
                        {
                            case 1:
                                Console.WriteLine($"Result: {p2.Name} wins!");
                                break;
                            case 2:
                                Console.WriteLine($"Result: {p1.Name} wins!");
                                break;
                        }

                        break;
                    case 1:
                        switch (p2Choice)
                        {
                            case 2:
                                Console.WriteLine($"Result: {p2.Name} wins!");
                                break;
                            case 0:
                                Console.WriteLine($"Result: {p1.Name} wins!");
                                break;
                        }
                        break;
                    case 2:
                        switch (p2Choice)
                        {
                            case 0:
                                Console.WriteLine($"Result: {p2.Name} wins!");
                                break;
                            case 1:
                                Console.WriteLine($"Result: {p1.Name} wins!");
                                break;
                        }
                        break;

                }
            }
            
        }
        //Calls each Players Generate() function to set up plays
        //Checks their CurrentChoice against eachother to determine winner
        //Prints out both player names, and the winner.
    }   
}