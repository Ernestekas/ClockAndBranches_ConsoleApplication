using ClockAndBranches.Models;
using System;

namespace ClockAndBranches.Services
{
    public class ClockService
    {
        private static readonly decimal _oneHourAngle = 360 / 12;
        private static readonly decimal _oneMinuteAngle = 360 / 60;
        private readonly decimal _oneMinuteAddsToHourAngle = _oneHourAngle / 60;
        public Clock CreateRandomClock()
        {
            return new Clock()
            {
                Hours = new Random().Next(0, 12),
                Minutes = new Random().Next(0, 60)
            };
        }

        public decimal CalculateArmsAngle(Clock clock)
        {
            decimal hoursAngle = (clock.Hours * _oneHourAngle) + (clock.Minutes * _oneMinuteAddsToHourAngle);
            decimal minutesAngle = clock.Minutes * _oneMinuteAngle;
            decimal resultAngle = hoursAngle - minutesAngle;

            resultAngle = Math.Abs(resultAngle);

            if(resultAngle > 180)
            {
                resultAngle = 360 - resultAngle;
            }

            return resultAngle;
        }

        public Clock RecalculateClock(Clock clock)
        {
            clock.Hours += clock.Minutes / 60;
            clock.Hours = clock.Hours % 12;
            clock.Minutes = clock.Minutes % 60;
            return clock;
        }
    }
}
