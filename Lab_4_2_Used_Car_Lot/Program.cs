namespace Lab_4_2_Used_Car_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Make a List of Six Cars
            List<Car> cars = new List<Car>();
            cars.Add(new Car("Forb","Rhombus", 2022, 25000.59m));
            cars.Add(new Car("Forb", "Stallion", 2023, 52000.00m));
            cars.Add(new Car("Porch", "Seven-Eleven", 2022, 71107.11m));
            cars.Add(new Car("Beuwick", "Rancor", 2021, 25999.99m ));
            cars.Add(new Used("Beuwick", "Rancor", 2018, 39859.22m, 98991.25 ));
            cars.Add(new Used("Forb", "Prefect", 1979, 4242.42m, 694216));

            bool GoAgain = true;
            //Begin GoAgain loop
            while (GoAgain)
            {
                int carDex = 0;
                Console.Clear();
                PrintHead();

                //run a foreach ToString() on each Car (number them)
                foreach(Car curCar in cars)
                {
                    carDex++;
                    Console.WriteLine($"[{carDex}] " + curCar.ToString());
                }
                Console.WriteLine("[a] Add Car");
                Console.WriteLine("[x] Exit Program");
                Console.WriteLine("Which Car would you like to select?");

              string uEntry =  Console.ReadLine().Trim().ToLower();


                if (uEntry[0] == 'x' || uEntry[0] == 'a')
                {
                    if (uEntry[0]=='x')
                    {
                        GoAgain = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Car make: ");
                        string cmake = Console.ReadLine();
                        Console.WriteLine("Model: ");
                        string cmodel = Console.ReadLine();
                        Console.WriteLine("Year: ");
                        int cyear = int.Parse(Console.ReadLine());
                        Console.WriteLine("Price: ");
                        decimal cprice = decimal.Parse(Console.ReadLine());
              
                        while (true)
                        {
                            Console.WriteLine("Please enter [n] if this a New Car and [u] if this is a Used car: ");
                            char uUsed = (Console.ReadLine())[0];
                            if (uUsed == 'n')
                            {
                                cars.Add(new Car(cmake, cmodel, cyear, cprice));
                                Console.WriteLine("Car Added!");
                                Thread.Sleep(1250);
                                break;
                            }
                            else if(uUsed == 'u')
                            {

                                Console.WriteLine("Current Miles: ");
                                double cmiles = double.Parse(Console.ReadLine());
                                cars.Add(new Used(cmake, cmodel, cyear, cprice, cmiles));
                                Console.WriteLine("Car Added!");
                                Thread.Sleep(1250);
                                break;
                            }
                            else { Console.WriteLine("Incorrect Entry, try again."); }

                        }

                    }
                }
                else if(int.TryParse(uEntry, out int uChoice) && uChoice > 0 && uChoice <= carDex)
                {
                    uChoice = uChoice - 1;
                    while (true) {
                        Console.WriteLine("Would you like to purchase this car? [y] or [n]");
                        char uBuy = (Console.ReadLine())[0];
                        if(uBuy == 'y' || uBuy == 'n')
                        {
                            if (uBuy == 'y')
                            {
                                Console.WriteLine("Fantastic! Our Finance Manager has been dispatched to collect you. \n For your safety, please assume the 'buyer position' and make no attempt to escape.");
                                cars.RemoveAt(uChoice);
                                Thread.Sleep(2000);
                            }
                            break;
                        }
                            }
                }
                //ask for a car number (validate loop) (or Type A to Add) (or Type q to quit ) 

                //if a or q entered
                //ask for car details, then slap into string - then repeat loop


                //else if check if number is valid to collection
                //  ask if wish to purchase (if so remove from list) - otherwise repeat loop
                //prompt to try another entry




            }
            //End Go Again Loop

            //Exit Program
         







        }


        //Car class
        public class Car
        {
           public string make;
           public   string model;
           public int year;
           public decimal price;

            //No Argument Constructor
            public  Car()
            {
                make = "NoMake";
                model = "NoModel"; 
                year = 1886;
                price = 29.00M;

            }
            //Full Constructor
            public  Car(string _make, string _model, int _year, decimal _price)
            {
                make = _make;
                model = _model;
                year = _year;
                price = _price;

            }
            //to String overide (virtual)
            //

             public  override  string ToString()
            {
                string outCar = make + "\t\t   " + model + "\t\t      " + year + "\t\t" + "$" + price;
                return outCar;
            }

            
        }

        //Used subclass
        //initializer
        //to String overide adding the (Used) tag and mileage
        public class Used : Car
        {
          public  double miles;

          public Used() : base()
            {
                miles = 0;
            }
            public Used(string _make, string _model, int _year, decimal _price, double _miles) : base(_make,  _model,  _year,  _price)
            {
                miles = _miles;
            }

            public override string ToString()
            {
                string outCar = make + "\t\t   " + model + "\t\t      " + year + "\t\t" + "$" + price + "\t" + miles + "miles \t[USED]";
                return outCar;
            }

        }

        static void PrintCar()
        {
            

            string cartop = ".-'--`-._";
            string carbot = "'-O---O--'";

            for (int i = 0; i < 40; i++)
            {
                Console.Clear();
                Console.WriteLine(cartop);
                Console.WriteLine(carbot);
                cartop = " " + cartop;
                carbot = " " + carbot;
                Thread.Sleep(5);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                int ctL = cartop.Length;
                int ctB = carbot.Length;
                cartop = cartop.Substring(0, (ctL -1));
                carbot = carbot.Substring(0, (ctL - 1));
                cartop = " " + cartop;
                carbot = " " + carbot;

                Console.WriteLine(cartop);
                Console.WriteLine(carbot);
                Thread.Sleep(5);

            }


        }

        static void PrintHead()
        {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("******************| DevBuild 8  Car Lot Manager |**********************");
            Console.WriteLine("***********************************************************************");
                        
        }
      










    }

}