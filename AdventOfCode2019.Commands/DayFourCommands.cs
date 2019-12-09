using System;
using System.Linq;

namespace AdventOfCode2019.Commands
{
    public static class DayFourCommands
    {
        public static int CalculatePossiblePasswords(int lowerBound, int upperBound)
        {
            return CalculateNumberOfPasswords(lowerBound, upperBound, CheckIfPossiblePassword);
        }

        public static int CalculatePossiblePasswordsExtended(int lowerBound, int upperBound)
        {
            return CalculateNumberOfPasswords(lowerBound, upperBound, CheckIfPossiblePasswordExtended);
        }

        private static int CalculateNumberOfPasswords(int lowerBound, int upperBound, Func<string, bool> passwordCheck)
        {
            var possibleCombinations = 0;

            for (var possibleCombination = lowerBound; possibleCombination <= upperBound; possibleCombination++)
            {
                if (!passwordCheck(possibleCombination.ToString()))
                {
                    continue;
                }

                ++possibleCombinations;
            }

            return possibleCombinations;
        }

        private static bool CheckIfPossiblePassword(string password)
        {
            var hasDouble = false;

            var previousDigit = int.MinValue;

            foreach (var digit in password.AsEnumerable())
            {
                var parsedDigit = int.Parse(digit.ToString());

                if (previousDigit > parsedDigit)
                {
                    return false;
                }

                if (previousDigit == parsedDigit)
                {
                    hasDouble = true;
                }

                previousDigit = parsedDigit;
            }

            return hasDouble;
        }

        private static bool CheckIfPossiblePasswordExtended(string password)
        {
            var hasDouble = false;

            var previousDigit = int.MinValue;
            var numberOfDigits = 1;

            foreach (var digit in password.AsEnumerable())
            {
                var parsedDigit = int.Parse(digit.ToString());

                if (previousDigit > parsedDigit)
                {
                    return false;
                }

                if (previousDigit == parsedDigit)
                {
                    ++numberOfDigits;
                } 
                else if (numberOfDigits == 2)
                {
                    hasDouble = true;
                }
                else
                {
                    numberOfDigits = 1;
                }

                previousDigit = parsedDigit;
            }

            if (numberOfDigits == 2)
            {
                hasDouble = true;
            }

            return hasDouble;
        }
    }
}