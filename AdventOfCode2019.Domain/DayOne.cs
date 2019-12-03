using System;
using System.Collections.Generic;
using AdventOfCode2019.IO;

namespace AdventOfCode2019.Domain
{
    public class DayOne
    {
        private readonly IRepository repository;

        public DayOne(IRepository repository)
        {
            this.repository = repository;
        }

        public int CalculateSumOfFuel()
        {
            var masses = repository.GetDayOneInput();
            var result = 0;
            foreach (var mass in masses)
            {
                result += CalculateFuelPerMass(mass);
            }

            return result;
        }

        private static int CalculateFuelPerMass(int mass)
        {
            return (mass / 3 - 2);
        }
    }
}
