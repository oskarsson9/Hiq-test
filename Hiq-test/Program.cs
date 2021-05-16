using System;
using System.Text.RegularExpressions;

namespace Hiq_test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Room room = new Room();
                Car car = new Car();
                Console.WriteLine("RC-Car simulator\r");
                Console.WriteLine("------------------------\n");

                Console.WriteLine("Enter room width followed by room height (seperated with a space, single digits only): \n");

                var roomInputNeeded = true;
                while(roomInputNeeded)
                {
                    var roomDimensions = Console.ReadLine().ToString();
                    var splittedRoomDimensions = roomDimensions.Split(" ");

                    if (splittedRoomDimensions.Length == 2)
                    {
                        var roomX = splittedRoomDimensions[0];
                        var roomY = splittedRoomDimensions[1];

                        var xIsInt = int.TryParse(roomX, out var parsedRoomX);
                        var yIsInt = int.TryParse(roomY, out var parsedRoomY);

                        if(xIsInt && yIsInt)
                        {
                            room = new Room(parsedRoomX, parsedRoomY);
                            roomInputNeeded = false;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid format \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid format \n");
                    }
                }

                Console.WriteLine("\n");
                Console.WriteLine("Enter the starting position and heading of the car (X Y N/S/W/E) :");

                var positionInputNeeded = true;
                while (positionInputNeeded)
                {
                    var carPosition = Console.ReadLine().ToString();
                    var splittedCarPosition = carPosition.Split(" ");

                    if (splittedCarPosition.Length == 3)
                    {
                        var carX = splittedCarPosition[0];
                        var carY = splittedCarPosition[1];

                        var carXIsInt = int.TryParse(carX, out var parsedCarX);
                        var carYIsInt = int.TryParse(carY, out var parsedCarY);

                        var carHeading = splittedCarPosition[2];
                        var headingRegex = new Regex("[NSWE]");
                        
                        if (carXIsInt && carYIsInt && headingRegex.IsMatch(carHeading) && carHeading.Length == 1)
                        {
                            car = new Car(carHeading);
                            room.SetCarPosition(parsedCarX, parsedCarY);
                            positionInputNeeded = false;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid format. Letters are case sensitive \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid format. Letters are case sensitive \n");
                    }
                }

                Console.WriteLine("\n");
                Console.WriteLine("Available commands are F, B, L or R. ");
                Console.WriteLine("Enter command: ");
                
                var commandInputNeeded = true;
                while (commandInputNeeded)
                {
                    var carCommand = Console.ReadLine().ToString();
                    var carCommadRegex = new Regex("[FBLR]");

                    if (carCommadRegex.IsMatch(carCommand))
                    {
                        try
                        {
                            car.Move(carCommand, room);
                            Console.WriteLine("Success! \n");
                            Console.WriteLine($"Current car position: {room.GetCarPosition().x} {room.GetCarPosition().y} {car.Heading}");
                            RestartProgramPrompt();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Oh no the car drove into the wall");
                            Console.WriteLine(e.Message);
                            RestartProgramPrompt();
                        }
                        commandInputNeeded = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid format. Letters are case sensitive \n");
                    }
                }
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.WriteLine("Lets try again! \n");
                Main(new string[0]);
            }
        }

        private static void RestartProgramPrompt()
        {
            Console.WriteLine("\nDo you want to run the program again? (y/n)");

            var restartInputNeeded = true;

            while (restartInputNeeded)
            {
                switch (Console.ReadKey().Key.ToString())
                {
                    case "Y":
                        restartInputNeeded = false;
                        Console.Clear();
                        Main(new string[0]);
                        break;
                    case "N":
                        restartInputNeeded = false;
                        break;
                    default:
                        Console.WriteLine("\nDo you want to run the program again? (y/n)");
                        break;
                }
            }
        }
    }
}
