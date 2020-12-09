using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 5)]
    public class Day05 : BaseDay
    {
        public override string PartOne(string input)
        {
            var boardingPasses = input.Lines();

            List<int> ids = boardingPasses.Select(x => GetId(x)).ToList();

			return ids.Max().ToString();
        }

		public int GetId(string input)
		{
            int row = GetRow(input);
            int column = GetColumn(input);

            return (row * 8) + column;
        }

		private int GetRow(string input)
		{
            var idxs = Enumerable.Range(0, 128);

            var relevantChars = input.ToCharArray().Take(7).ToArray();
			for (int i = 0; i < relevantChars.Count(); i++)
			{
				if (relevantChars[i] == 'F')
					idxs = TakeBottomHalf(idxs);
				else
					idxs = TakeTopHalf(idxs);
			}

			if (idxs.Count() != 1)
				throw new Exception("Too many values");

			return idxs.First();
		}

		private IEnumerable<int> TakeTopHalf(IEnumerable<int> idxs)
		{
			int numToTake= idxs.Count() / 2;
			return idxs.Skip(numToTake).Take(numToTake).ToArray();
		}

		private IEnumerable<int> TakeBottomHalf(IEnumerable<int> idxs)
		{
			int numToTake = idxs.Count() / 2;
			return idxs.Take(numToTake).ToArray();
		}

		private int GetColumn(string input)
		{
			var idxs = Enumerable.Range(0, 8);

			var relevantChars = input.ToCharArray().Skip(7).Take(3).ToArray();
			for (int i = 0; i < relevantChars.Count(); i++)
			{
				if (relevantChars[i] == 'L')
					idxs = TakeBottomHalf(idxs);
				else
					idxs = TakeTopHalf(idxs);
			}

			if (idxs.Count() != 1)
				throw new Exception("Too many values");

			return idxs.First();
		}

		public override string PartTwo(string input)
        {
			var boardingPasses = input.Lines();

			List<int> ids = boardingPasses.Select(x => GetId(x)).ToList();

			ids.Sort();
			int prevId = 0;
			for (int i = 0; i < ids.Count; i++)
			{
				if (prevId == ids[i] - 2)
				{
					return (ids[i] - 1).ToString();
				}
				prevId = ids[i];
			}
			
			throw new Exception("No suitable solution found");
		}
    }
}
