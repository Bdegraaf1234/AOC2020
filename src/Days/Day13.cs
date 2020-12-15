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
            throw new NotImplementedException();
        }
    }
}
