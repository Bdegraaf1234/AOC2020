using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 11)]
    public class Day11 : BaseDay
    {
		private static int rowLength;
		private static int colLength;

		public override string PartOne(string input)
        {
            var seatingMap = input.CreateCharGrid();

            rowLength = input.Lines().First().Length;
            colLength = input.Lines().Count();

			var seating = new Dictionary<(int, int), char>();

            var xDiffs = new int[] { -1, 0, 1 };
            var yDiffs = new int[] { -1, 0, 1 };

			var numChanged = 0;
			for (int i = 0; i < seatingMap.Length; i++)
			{
				int xNum, yNum;
				GetRowAndColNum(i, out xNum, out yNum);

				var curChar = seatingMap[xNum, yNum];

				if (curChar == '.')
				{
					continue;
				}

				//Count occupied seats
				int numOccupied = CountOccupied(seatingMap, xDiffs, yDiffs, xNum, yNum);

				if (curChar == 'L')
				{
					if (numOccupied == 0)
					{
						seating.Add((xNum, yNum), '#');
						numChanged++;
					}
					else
					{
						seating.Add((xNum, yNum), 'L');
					}
				}
				if (curChar == '#')
				{
					if (numOccupied <= 3)
					{
						seating.Add((xNum, yNum), '#');
					}
					else
					{
						seating.Add((xNum, yNum), 'L');
						numChanged++;
					}
				}
			}

			while (numChanged != 0)
			{
				foreach (var seat in seating)
					seatingMap[seat.Key.Item1, seat.Key.Item2] = seat.Value;
				numChanged = 0;

				for (int i = 0; i < seatingMap.Length; i++)
				{
					int xNum, yNum;
					GetRowAndColNum(i, out xNum, out yNum);

					var curChar = seatingMap[xNum, yNum];

					if (curChar == '.')
					{
						continue;
					}

					//Count occupied seats
					int numOccupied = CountOccupied(seatingMap, xDiffs, yDiffs, xNum, yNum);

					if (curChar == 'L')
					{
						if (numOccupied == 0)
						{
							seating[(xNum, yNum)] = '#';
							numChanged++;
						}
						else
						{
							seating[(xNum, yNum)] = 'L';
						}
					}
					if (curChar == '#')
					{
						if (numOccupied <= 3)
						{
							seating[(xNum, yNum)] = '#';
						}
						else
						{
							seating[(xNum, yNum)] = 'L';
							numChanged++;
						}
					}
				}
			}

			return seating.Where(x => x.Value == '#').Count().ToString();
		}

		private static int CountOccupied(char[,] seatingMap, int[] xDiffs, int[] yDiffs, int xNum, int yNum)
		{
			int numOccupied = 0;
			foreach (var xDiff in xDiffs)
			{
				foreach (var yDiff in yDiffs)
				{
					if (yDiff == 0 && xDiff == 0)
					{
						continue;
					}
					else
					{
						var xToCheck = xNum - xDiff;
						var yToCheck = yNum - yDiff;

						if (xToCheck < 0 || xToCheck >= rowLength)
							continue;
						if (yToCheck < 0 || yToCheck >= colLength)
							continue;

						if (seatingMap[xNum - xDiff, yNum - yDiff] == '#')
						{
							numOccupied++;
						}
					}
				}
			}

			return numOccupied;
		}

		private static void GetRowAndColNum(int i, out int rowNum, out int colNum)
		{
			rowNum = (int)Math.Floor(i / (double)colLength);
			colNum = i % colLength;
		}

		public override string PartTwo(string input)
        {
            throw new NotImplementedException();
        }
    }
}
