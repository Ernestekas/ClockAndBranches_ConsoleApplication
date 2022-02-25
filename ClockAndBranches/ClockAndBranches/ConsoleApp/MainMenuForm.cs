using System;

namespace ClockAndBranches.ConsoleApp
{
    public class MainMenuForm
    {
        private ClockApp clockApp = new ClockApp();
        private BranchesApp branchesApp = new BranchesApp();

        public void Run()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Select program you want to run.");
                Console.WriteLine("Select command:");
                Console.WriteLine();
                Console.WriteLine("1 - Clock arms ange calculator application.");
                Console.WriteLine("2 - Branch depth level calculator application.");
                Console.WriteLine("3 - Exit.");
                Console.WriteLine();

                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        clockApp.Run();
                        break;
                    case "2":
                        branchesApp.Run();
                        break;
                    case "3":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
