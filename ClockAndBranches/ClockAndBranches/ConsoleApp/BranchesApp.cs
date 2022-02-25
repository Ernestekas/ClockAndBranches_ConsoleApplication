using ClockAndBranches.Models;
using ClockAndBranches.Services;
using System;

namespace ClockAndBranches.ConsoleApp
{
    public class BranchesApp
    {
        private BranchService _branchService = new BranchService();

        public void Run()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Branches");
                Console.WriteLine("List of objects contains same List of same objects. Get deepest branch.");
                Console.WriteLine();
                Console.WriteLine("Yo dawg. I heard you like to dream, so I put a dream in a dream so you can dream while dreaming.");
                Console.WriteLine();
                Console.WriteLine("Create random Dream and get deepest level of created Dream. Select command:");
                Console.WriteLine("1 - Create random dream and get deepest level of it.");
                Console.WriteLine("2 - Exit an app.");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "2":
                        run = false;
                        break;
                    case "1":
                        int level = 0;
                        Dream m = new Dream();
                        m = _branchService.CreateRandomDream(m);
                        level = _branchService.GetDeepestDreamLevelNumber(m, level);
                        Console.WriteLine($"Deepest level of a main Dream {level}.");
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
