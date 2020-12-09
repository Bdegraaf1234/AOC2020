using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 1)]
    public class Day01 : BaseDay
    {
        public override string PartOne(string input)
        {
            var inputIntegers = input.Integers().ToList();
            var idxCombos = MyHelpers.GenerateCombinations(2, 0, inputIntegers.Count() -1);

            var inputCombos = idxCombos.Select(x => x.Select(y => inputIntegers[y]));
            var combosWithSum2020 = inputCombos.Where(x => x.Sum() == 2020);
			if (combosWithSum2020.Count() < 2)
			{
                System.Diagnostics.Debug.WriteLine($"More/less than one 2020 combo found: {combosWithSum2020.Count()}");
                return $"More/less than one 2020 combo found: {combosWithSum2020.Count()}";

            }
			else
			{
                return combosWithSum2020.First().Aggregate((x, y) => x * y).ToString();
			}
        }

        public override string PartTwo(string input)
        {
            var inputIntegers = input.Integers().ToList();
            var idxCombos = MyHelpers.GenerateCombinations(3, 0, inputIntegers.Count() - 1);

            var inputCombos = idxCombos.Select(x => x.Select(y => inputIntegers[y]));
            var combosWithSum2020 = inputCombos.Where(x => x.Sum() == 2020);
            if (combosWithSum2020.Count() < 2)
            {
                System.Diagnostics.Debug.WriteLine($"More/less than one 2020 combo found: {combosWithSum2020.Count()}");
                return $"More/less than one 2020 combo found: {combosWithSum2020.Count()}";
            }
            else
            {
                return combosWithSum2020.First().Aggregate((x, y) => x * y).ToString();
            }
        }
    }
}
