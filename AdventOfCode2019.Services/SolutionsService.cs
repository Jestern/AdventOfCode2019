﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2019.Commands;
using AdventOfCode2019.Domain;
using AdventOfCode2019.IO;

namespace AdventOfCode2019.Services
{
    public class SolutionsService : ISolutionsService
    {
        private StringBuilder outputBuilder; 
        private IRepository repository;

        public SolutionsService(IRepository inputRepository)
        {
            repository = inputRepository;
            outputBuilder = new StringBuilder();
        }

        public string SolveProblems()
        {
            SolveDayOneProblem();
            SolveDayTwoProblem();
            SolveDayThreeProblem();
            SolveDayFourProblem();
            SolveDayFiveProblem();

            return outputBuilder.ToString();
        }

        private void SolveDayOneProblem()
        {
            var masses = repository.GetDayOneInput().ToList();

            outputBuilder.AppendLine($"Result of first half of Day one's problem: {DayOneCommands.CalculateSumOfFuel(masses)}");
            outputBuilder.AppendLine($"Result of second half of Day one's problem: {DayOneCommands.CalculateSumOfFuelPlusFuel(masses)}");
        }

        private void SolveDayTwoProblem()
        {
            var programMemory = repository.GetDayTwoInput().ToList();
            
            outputBuilder.AppendLine($"Result of first half of Day two's problem: {DayTwoCommands.RunIntcode(programMemory, 12, 2)}");
            outputBuilder.AppendLine($"Result of second half of Day two's problem: {DayTwoCommands.FindNounAndVerb(programMemory, 19690720)}");
        }

        private void SolveDayThreeProblem()
        {
            var wires = repository.GetDayThreeInput();

            outputBuilder.AppendLine($"Result of first half of Day three's problem: {DayThreeCommands.CalculateDistanceWires(wires)}");
            outputBuilder.AppendLine($"Result of second half of Day three's problem: {DayThreeCommands.CalculateStepsWires(wires)}");
        }

        private void SolveDayFourProblem()
        {
            var (lowerBound, upperBound) = repository.GetDayFourInput();

            outputBuilder.AppendLine($"Result of first half of Day four's problem: {DayFourCommands.CalculatePossiblePasswords(lowerBound, upperBound)}");
            outputBuilder.AppendLine($"Result of second half of Day four's problem: {DayFourCommands.CalculatePossiblePasswordsExtended(lowerBound, upperBound)}");
        }

        private void SolveDayFiveProblem()
        {
            var programMemory = repository.GetDayFiveInput().ToList();

            outputBuilder.AppendLine($"Result of first half of Day five's problem: {DayFiveCommands.RunDiagnostics(programMemory, 1)}");
            outputBuilder.AppendLine($"Result of second half of Day five's problem: {DayFiveCommands.RunDiagnostics(programMemory, 5)}");
        }
    }
}
