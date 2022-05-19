using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarsRoverProject
{
    
    class Program
    {
        static Rover firstRover;
        static Rover secondRover;
        static Regex pattern = new Regex("[^RLM]");
        static void Main(string[] args)
        {
            Run();
        
        }

        public static void Run()
        {

            ReadDimension();
            ReadRover(out firstRover);
            ReadRover(out secondRover);

            FindRoute(firstRover);
            FindRoute(secondRover);

            ShowResult(firstRover);
            ShowResult(secondRover);

            Console.Read();
        }
        public static void ReadDimension()
        {
            string dimensions="";
            var dimensionList = new List<string>();

            do
            {
                Console.Write("Please enter dimensions :");
                dimensions = Console.ReadLine();
                dimensionList = dimensions.Trim().Split(' ').ToList();



            } while (dimensionList.Count() != 2 || !IsNumeric(dimensionList[0]) || !IsNumeric(dimensionList[1]));

            Dimension.Instance.X = Convert.ToInt32(dimensionList[0]);
            Dimension.Instance.Y = Convert.ToInt32(dimensionList[1]);

        }

        public static void ReadRover(out Rover rover)
        {
            var roverPosition = "";
            var roverPositionList = new List<string>();
           

            do
            {
                readRover:
                Console.Write("Please enter rover position :");
                roverPosition = Console.ReadLine().ToUpper();
                roverPositionList = roverPosition.Trim().Split(' ').ToList();


                if (!IsNumeric(roverPositionList[0]) || !IsNumeric(roverPositionList[1]) || roverPositionList[2].IndexOfAny(new char[] { 'W', 'S', 'E', 'N' }) == -1)
                    goto readRover;


            } while ((roverPositionList.Count() != 3) || !CheckPosition(Convert.ToInt32(roverPositionList[0]),Convert.ToInt32(roverPositionList[1])));


            rover = new Rover(Convert.ToInt32(roverPositionList[0]), Convert.ToInt32(roverPositionList[1]), Convert.ToChar(roverPositionList[2]));

            Console.Write("Please enter rover route :");
            var roverRoute = Console.ReadLine().ToUpper();
    

            while (pattern.IsMatch(roverRoute))
            {
                Console.Write("Please enter rover route :");
                roverRoute = Console.ReadLine().ToUpper();
            }

            rover.Route = roverRoute;
         

        }

        public static void FindRoute(Rover rover)
        {
            try
            {
                foreach (char process in rover.Route)
                {
                    switch (process)
                    {
                        case 'M':
                            Move(rover);
                            break;
                        case 'R':
                            rover.Direction = TurnRigt(rover.Direction);
                            break;
                        case 'L':
                            rover.Direction = TurnLeft(rover.Direction);
                            break;
                        default:
                            throw new Exception("Wrong route value");
                    }

                    if (!CheckPosition(rover.X,rover.Y))
                    {
                        Console.WriteLine("Route value is not valid");
                        Run();
                    }
                         
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        public static char TurnRigt(char direction)
        {
            switch (direction)
            {
                case 'N':
                    return 'E';
                
                case 'S':
                    return 'W';
                
                case 'E':
                    return 'S';
                
                case 'W':
                    return 'N';
                default:
                    throw new Exception("Wrong direction value");
                   
            }
        }

        public static char TurnLeft(char direction)
        {
            switch (direction)
            {
                case 'N':
                    return 'W';

                case 'S':
                    return 'E';

                case 'E':
                    return 'N';

                case 'W':
                    return 'S';
                default:
                     throw new Exception("Wrong direction value");

            }
        }

        public static void Move(Rover rover)
        {
            switch (rover.Direction)
            {
                case 'N':
                    rover.Y = rover.Y + 1;
                    break;
                case 'S':
                    rover.Y = rover.Y - 1;
                    break;
                case 'E':
                    rover.X = rover.X + 1;
                    break;
                case 'W':
                    rover.X = rover.X - 1;
                    break;
                default:
                    throw new Exception("Wrong direction value");

            }
        }

        public static void ShowResult(Rover rover)
        {
            Console.WriteLine(rover.X.ToString() + ' ' + rover.Y.ToString() + ' ' + rover.Direction);
        }

        public static bool CheckPosition(int x,int y)
        {
            if ( x > Dimension.Instance.X || y > Dimension.Instance.Y || x < 0 || y < 0)
                return false;
            else
                return true;
            
        }

        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}
