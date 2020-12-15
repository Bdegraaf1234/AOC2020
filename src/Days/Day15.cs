using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 15)]
    public class Day15 : BaseDay
    {
        public override string PartOne(string input)
        {
            int turnNum = 1;
            var nums = input.Split(',').Select(x => int.Parse(x)).ToList();
            var spoken = new List<int>(2020);
			foreach (var num in nums)
			{
                spoken.Add(num);
                turnNum++;
			}

			while (turnNum != 2021)
			{
                var allBefore = spoken.Take(spoken.Count - 1).ToList();

                if (allBefore.Contains(spoken.Last()))
				{
                    spoken.Add(turnNum - allBefore.LastIndexOf(spoken.Last()) - 2);
				}
				else
				{
                    spoken.Add(0);
				}

                turnNum++;
			}

            return spoken.Last().ToString();
        }

        public override string PartTwo(string input)
        {
            throw new NotImplementedException();
        }
    }
}
