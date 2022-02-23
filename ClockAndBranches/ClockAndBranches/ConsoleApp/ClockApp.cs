using ClockAndBranches.Models;
using ClockAndBranches.Services;
using System;

namespace ClockAndBranches.ConsoleApp
{
    public class ClockApp
    {
        private Clock _clock = new Clock();
        private readonly ClockService _clockService = new ClockService();
        private AddTimeForm _addTimeForm = new AddTimeForm();

        public void Run()
        {
            _clock = _clockService.CreateRandomClock();

            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine($"Current time {_clock.Hours} : {_clock.Minutes}. Angle: {_clockService.CalculateArmsAngle(_clock)}°");
                Console.WriteLine();

                Console.WriteLine("Select command by entering command number:");
                Console.WriteLine("1 - Add time to current date and get new time and angle.");
                Console.WriteLine("2 - Exit to main menu.");

                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        _addTimeForm.Run(_clock);
                        break;
                    case "2":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
