using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 3)]
    public class Day03 : BaseDay
    {
        public override string PartOne(string input)
        {
            var grid = input.CreateCharGrid();
            var baseLength = grid.GetRow(0).Count();

            int xPos = 0;
            var treeCount = 0;

			int deltaY = 1;
            int deltaX = 3;

			var rows = grid.GetRows().ToArray();
			for (int i = 0; i < rows.Count(); i += deltaY)
			{
				CheckForTree(baseLength, ref xPos, ref treeCount, deltaX, rows, i);
			}

			return treeCount.ToString();
        }

		private static void CheckForTree(int baseLength, ref int xPos, ref int treeCount, int deltaX, string[] rows, int i)
		{
			string currentRow = rows[i];

			int multiplier = (int)Math.Floor((double)xPos / (double)baseLength) + 1;
			string thisRowString = String.Concat(Enumerable.Repeat(currentRow, multiplier));
			var thisRow = thisRowString.ToCharArray();
			if (thisRow[xPos] == '#')
			{
				treeCount++;
				thisRow[xPos] = 'X';
			}
			else
			{
				thisRow[xPos] = 'O';
			}

			xPos += deltaX;

			System.Diagnostics.Debug.WriteLine(new String(thisRow));
		}

		public override string PartTwo(string input)
		{
			var grid = input.CreateCharGrid();
			var baseLength = grid.GetRow(0).Count();


			int[] downslopes = new int[] { 1, 1, 1, 1, 2 };
			int[] sideSlopes = new int[] { 1, 3, 5, 7, 1 };

			List<long> ans = new List<long>(downslopes.Count());

			for (int i = 0; i < downslopes.Count(); i++)
			{
				int deltaY = downslopes[i];
				int deltaX = sideSlopes[i];

				int xPos = 0;
				var treeCount = 0;

				var rows = grid.GetRows().ToArray();
				for (int j = 0; j < rows.Count(); j += deltaY)
				{
					CheckForTree(baseLength, ref xPos, ref treeCount, deltaX, rows, j);
				}

				ans.Add(treeCount);
			}

			long aggregate = ans.Aggregate((x, y) => x * y);
			return aggregate.ToString();
		}
    }
}
