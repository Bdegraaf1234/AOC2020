using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 13)]
    public class Day13 : BaseDay
    {
        public override string PartOne(string input)
        {
            int departTime = Int32.Parse(input.Lines().First());
            var schedule = input.Lines().Last().Split(',').Distinct().Where(x => x != "x").Select(x => Int32.Parse(x));

            var waitPerId = schedule.Select(x => {
                int innerX = x;
				while (innerX < departTime)
				{
                    innerX += x;
				}
                return (x, innerX % departTime);
                });
            
            var selectedBus = waitPerId.OrderBy(x => x.Item2).First();

            return (selectedBus.Item2 * selectedBus.x).ToString();
        }

        public override string PartTwo(string input)
        {
            var schedule = input.Lines().Last().Split(',').ToArray();
            var remaindersThenPeriod = new List<(long, long)>(schedule.Count());
			for (int i = 0; i < schedule.Length; i++)
				if (schedule[i] != "x")
                {
                    long parsed = long.Parse(schedule[i]);
                    remaindersThenPeriod.Add((parsed - i == parsed ? 0 : parsed - i, parsed));
                }

            long N = remaindersThenPeriod.Select(x => x.Item2).Aggregate((x, y) => x * y);

            var remaindersThenPeriodThenNi = remaindersThenPeriod.Select(x => (x.Item1, x.Item2, N / x.Item2)).ToList();

            var remaindersThenPeriodThenNiThenXi = remaindersThenPeriodThenNi.Select(x => {
                long remainder = x.Item1;
                long period = x.Item2;
                long Ni = x.Item3;
                long xRem = Ni % period;
                long Xi = 1;
				while ((xRem * Xi) % period != 1)
                    Xi++;
                
                return (remainder, period, Ni, Xi);
                }).ToList();

            long ans = remaindersThenPeriodThenNiThenXi.Select(x => x.remainder * x.Ni * x.Xi).Sum() % N;

            return ans.ToString();
        }
    }
}
