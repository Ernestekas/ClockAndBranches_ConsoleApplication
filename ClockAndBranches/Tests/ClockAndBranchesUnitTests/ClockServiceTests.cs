using ClockAndBranches.Models;
using ClockAndBranches.Services;
using Xunit;

namespace ClockAndBranchesUnitTests
{
    public class ClockServiceTests
    {
        private readonly ClockService _clockService = new ClockService();

        [Fact]
        public void RecalculateClock_GivenBadClockFormat_ReturnsValidClockFormat()
        {
            Clock clock = new Clock()
            {
                Hours = 15,
                Minutes = 69
            };
            
            Clock result = _clockService.RecalculateClock(clock);

            Assert.InRange(result.Hours, 0, 11);
            Assert.InRange(result.Minutes, 0, 59);
        }

        [Fact]
        public void RecalculateClock_GivenInvalidBoundaryValues_ReturnsValidClockFormat()
        {
            Clock clock = new Clock()
            {
                Hours = 12,
                Minutes = 60
            };

            Clock result = _clockService.RecalculateClock(clock);

            Assert.InRange(result.Hours, 0, 11);
            Assert.InRange(result.Minutes, 0, 59);
        }

        [Fact]
        public void RecalculateClock_GivenInvalidNegativeValues_ReturnsValidClock()
        {
            Clock clock = new Clock()
            {
                Hours = -1,
                Minutes = -10
            };

            Clock result = _clockService.RecalculateClock(clock);

            Assert.InRange(result.Hours, 0, 11);
            Assert.InRange(result.Minutes, 0, 59);
        }

        [Fact]
        public void CalculateArmsAngle_GivenClockWithLessThanOrEqual180AngleArms_ReturnsAngleLessThanOrEqual180Angle()
        {
            Clock clock = new Clock()
            {
                Hours = 0,
                Minutes = 10
            };

            decimal result = _clockService.CalculateArmsAngle(clock);

            Assert.InRange(result, 0, 180);
        }

        [Fact]
        public void CalculateArmsAngle_GivenClockWith180AngleArms_Returns180Angle()
        {
            Clock clock = new Clock()
            {
                Hours = 6,
                Minutes = 0
            };

            decimal resultAngle = _clockService.CalculateArmsAngle(clock);
            Assert.Equal(180, resultAngle);
        }

        [Fact]
        public void CalculateArmsAngle_GivenClockWithMoreThan180AngleArma_ReturnsLessThanOr180Angle()
        {
            Clock clock = new Clock()
            {
                Hours = 0,
                Minutes = 50
            };

            decimal resultAngle = _clockService.CalculateArmsAngle(clock);
            Assert.InRange(resultAngle, 0, 180);
        }

        [Fact]
        public void CalculateArmsAngle_GivenClockWith0AngleArms_Returns0Angle()
        {
            Clock clock = new Clock()
            {
                Hours = 0,
                Minutes = 0
            };

            decimal resultAngle = _clockService.CalculateArmsAngle(clock);
            Assert.Equal(0, resultAngle);
        }
    }
}
