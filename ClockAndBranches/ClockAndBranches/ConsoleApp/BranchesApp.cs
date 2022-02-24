using ClockAndBranches.Models;
using ClockAndBranches.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockAndBranches.ConsoleApp
{
    public class BranchesApp
    {
        private BranchService _branchService = new BranchService();

        public void Run()
        {
            int level;
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Branches");
                Console.WriteLine("List of objects contains same List of same objects. Get deepest branch.");
                Console.WriteLine("Create random Matrioshka and get deepest level of matrioshka. Type 'exit' to leave this app.");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "exit":
                        run = false;
                        break;
                    default:
                        Matrioshka m = new Matrioshka();
                        m = _branchService.CreateRandomMatrioshka(m);
                        //level = _branchService.GetDeepestMatrioshkaLevel(m);
                        break;
                }

                //Console.ReadKey();
            }
        }
    }
}
