using ClockAndBranches.Models;
using ClockAndBranches.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClockAndBranches.ConsoleApp
{
    public class AddTimeForm
    {
        private readonly ClockService _clockService = new ClockService();

        public Clock Run(Clock currentTime)
        {
            Clock resultClock = currentTime;
            Console.WriteLine();
            Console.WriteLine("Type time you want to add. Correct format hh:mm. You can add whatever integer numbers you want. To go back type 'exit'.");
            string action = Console.ReadLine();

            switch (action)
            {
                case "exit":
                    break;
                default:
                    Clock newTime = TryParseToTime(action, currentTime);
                    resultClock = _clockService.RecalculateClock(newTime);
                    break;
            }
            return resultClock;
        }

        private Clock TryParseToTime(string action, Clock currentTime)
        {
            Clock resultClock = currentTime;
            List<string> hoursAndMinutes = action.Split(':').ToList();

            switch(hoursAndMinutes.Count == 2)
            {
                case true:
                    switch(int.TryParse(hoursAndMinutes[0], out int h) & int.TryParse(hoursAndMinutes[1], out int m))
                    {
                        case true:
                            resultClock.Hours += h;
                            resultClock.Minutes += m;
                            break;
                        case false:
                            Console.WriteLine("Wrong time format.");
                            break;
                    }
                    break;
                case false:
                    Console.WriteLine("Wrong time format.");
                    break;
            }

            return resultClock;
        }
    }
}
