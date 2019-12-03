using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IO;

namespace AdventOfCode2019.Domain
{
    public class DayOneCommands
    {
        private readonly IRepository repository;

        public DayOneCommands(IRepository repository)
        {
            this.repository = repository;
        }

        public int CalculateSumOfFuel()
        {
            var masses = repository.GetDayOneInput();

            return masses.Sum(CalculateFuelPerMass);
        }

        public int CalculateSumOfFuelPlusFuel()
        {
            var masses = repository.GetDayOneInput();

            return masses.Sum(CalculateFuelPerMassPlusFuel);
        }

        private static int CalculateFuelPerMass(int mass)
        {
            return (mass / 3 - 2);
        }

        private static int CalculateFuelPerMassPlusFuel(int mass)
        {
            var result = CalculateFuelPerMass(mass);

            if (result <= 0)
            {
                return 0;
            }

            result += CalculateFuelPerMassPlusFuel(result);

            return result;
        }
    }
}
