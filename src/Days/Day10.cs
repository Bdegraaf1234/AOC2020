using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 10)]
    public class Day10 : BaseDay
    {
        public override string PartOne(string input)
        {
            var nums = input.Integers().ToList();
            nums = nums.OrderByDescending(x => x).ToList();
            nums.Add(0);

            List<int> diffs = new List<int>() { 3 };

            for (int i = 0; i < nums.Count() - 1; i++)
			{
                int curNum = nums[nums.Count() - i - 1];
                int nextNum = nums[nums.Count() - i - 2];
                diffs.Add(nextNum - curNum);
            }

            return (diffs.Where(x => x == 1).Count() * diffs.Where(x => x == 3).Count()).ToString();
        }

        public override string PartTwo(string input)
        {
            var nums = input.Integers().ToList();
            nums.Add(0);
            nums.Add(nums.Max() + 3);
            nums = nums.OrderByDescending(x => x).ToList();

            List<int> stretches = new List<int>();
            int stretch = -1;
            for (int i = 0; i < nums.Count() - 1; i++)
            {
                int curNum = nums[nums.Count() - i - 1];
                int nextNum = nums[nums.Count() - i - 2];
				if (nextNum - curNum == 3)
				{
					if (stretch > 0)
					{
                        stretches.Add(stretch);
					}
                    stretch = -1;
                }
                else
				{
                    stretch++;
				}
            }
            long acc = 1;
			foreach (var innerStretch in stretches)
            {
                if (innerStretch == 1)
                {
                    acc = acc * 2;
                }
                if (innerStretch == 2)
                {
                    acc = acc * 4;
                }
                if (innerStretch == 3)
                {
                    acc = acc * 7;
                }
            }

            return acc.ToString();
        }
    }
}
