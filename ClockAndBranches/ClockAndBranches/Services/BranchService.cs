using ClockAndBranches.Models;
using System;

namespace ClockAndBranches.Services
{
    public class BranchService
    {
        public Dream CreateRandomDream(Dream dream)
        {
            int branches = new Random().Next(1, 4);
            for(int i = 0; i < branches; i++)
            {
                int chance = new Random().Next(0, 100);
                if(chance < 50)
                {
                    Dream child = new Dream();
                    dream.Dreams.Add(CreateRandomDream(child));
                }
            }

            return dream;
        }

        public int GetDeepestDreamLevel(Dream mainDream, int currentLevel)
        {
            for(int i = 0; i < mainDream.Dreams.Count; i++)
            {
                Dream child = mainDream.Dreams[i];
                if(i == 0)
                {
                    currentLevel++;
                }
                currentLevel = GetDeepestDreamLevel(child, currentLevel);
            }

            return currentLevel;
        }
    }
}
