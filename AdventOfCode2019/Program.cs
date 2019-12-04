using System;
using AdventOfCode2019.Domain;
using AdventOfCode2019.IO;
using AdventOfCode2019.Services;

namespace AdventOfCode2019
{
    class Program
    {
        private static IRepository repository;
        private static ISolutionsService solutionsService;

        private static void SetUp()
        {
            repository = new FileRepository();
            solutionsService = new SolutionsService(repository);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2019!");
            SetUp();

            var solutionsMessage = solutionsService.SolveProblems();
            Console.WriteLine(solutionsMessage);
        }
    }
}
