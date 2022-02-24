using ClockAndBranches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockAndBranches.Services
{
    public class BranchService
    {
        public Matrioshka CreateRandomMatrioshka(Matrioshka matrioshka)
        {
            int branches = new Random().Next(1, 3);
            for(int i = 0; i < branches; i++)
            {
                int chance = new Random().Next(0, 100);
                if(chance < 60)
                {
                    Matrioshka child = new Matrioshka();
                    matrioshka.Matrioshkas.Add(CreateRandomMatrioshka(child));
                }
            }

            return matrioshka;
        }

        public int GetDeepestMatrioshkaLevel(Matrioshka mainMatrioshka)
        {
            int level = 1;
            for(int i = 0; i < mainMatrioshka.Matrioshkas.Count; i++)
            {
                Matrioshka child = mainMatrioshka.Matrioshkas[i];
                level += GetDeepestMatrioshkaLevel(child);
            }

            return level;
        }
    }
}
