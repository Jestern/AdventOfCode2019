using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IO;

namespace AdventOfCode2019.Domain
{
    public static class DayOneCommands
    {
        public static int CalculateSumOfFuel(IEnumerable<int> masses)
        {
            return masses.Sum(CalculateFuelPerMass);
        }

        public static int CalculateSumOfFuelPlusFuel(IEnumerable<int> masses)
        {
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
