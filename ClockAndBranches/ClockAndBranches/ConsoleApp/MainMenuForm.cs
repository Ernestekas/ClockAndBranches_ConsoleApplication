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
                Console.WriteLine("To select program enter program number, type 'exit' to exit application:");
                Console.WriteLine();
                Console.WriteLine("1 - Clock arms ange calculator application.");
                Console.WriteLine("2 - Branch depth level calculator application.");

                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        clockApp.Run();
                        break;
                    case "2":
                        branchesApp.Run();
                        break;
                    case "exit":
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
