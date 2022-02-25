using ClockAndBranches.Models;
using System;

namespace ClockAndBranches.Services
{
    public class BranchService
    {
        private int _deepestLevel = 0;

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

        public int BeginDeepestLevelCalculations(Dream parent, int deepestFound)
        {
            _deepestLevel = 0;
            return GetDeepestDreamLevelNumber(parent, deepestFound);
        }

        private int GetDeepestDreamLevelNumber(Dream parent, int deepestFound)
        {
            int currentLevel = deepestFound + 1;
            if(currentLevel > _deepestLevel)
            {
                _deepestLevel = currentLevel;
            }
            if(parent.Dreams != null)
            {
                foreach(Dream child in parent.Dreams)
                {
                    GetDeepestDreamLevelNumber(child, currentLevel);
                }
            }

            if(currentLevel == 1)
            {
                return _deepestLevel;
            }
            return 0;
        }
    }
}
