using ClockAndBranches.Models;
using ClockAndBranches.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace ClockAndBranchesUnitTests
{
    public class BranchServiceTests
    {
        private readonly BranchService _branchService = new BranchService();

        [Fact]
        public void GetDeepestDreamLevel_GivenObjectTree_ReturnsLevelOf4()
        {
            Dream main = new Dream()
            {
                Dreams = new List<Dream>()
                {
                    new Dream()
                    {
                        Dreams = new List<Dream>()
                        {
                            new Dream()
                            {
                                Dreams = new List<Dream>()
                                {
                                    new Dream()
                                }
                            }
                        }
                    },
                    new Dream()
                    {
                        Dreams = new List<Dream>()
                        {
                            new Dream()
                        }
                    }
                }
            };

            int level = _branchService.GetDeepestDreamLevel(main, 1);
            Assert.Equal(4, level);
        }
    }
}
