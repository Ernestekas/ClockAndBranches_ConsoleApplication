﻿using ClockAndBranches.Models;
using System;

namespace ClockAndBranches.Services
{
    public class BranchService
    {
        private int _deepest = 0;

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

        public int GetDeepestDreamLevelNumber(Dream parent, int deepestFound)
        {
            int currentLevel = deepestFound + 1;
            if(currentLevel > _deepest)
            {
                _deepest = currentLevel;
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
                return _deepest;
            }
            return 0;
        }
    }
}
