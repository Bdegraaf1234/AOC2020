using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 9)]
    public class Day09 : BaseDay
    {
        public override string PartOne(string input)
        {
            var inputNums = input.Longs().ToList();

            int preamble = 25;

            var idxCombos = MyHelpers.GenerateCombinations(2, 0, preamble - 1);

			for (int i = preamble; i < inputNums.Count(); i++)
			{
                long curNum = inputNums[i];
                var combos = idxCombos.Select(x => inputNums[x[0] + i - preamble] + inputNums[x[1] + i - preamble]);
				if (!combos.Contains(curNum))
				{
                    return curNum.ToString();
				}
			}

            return "";
        }

        public override string PartTwo(string input)
        {
            var inputNums = input.Longs().ToList();

            int count = inputNums.Count;

            var idxCombos = MyHelpers.GenerateCombinations(2, 0, count - 1);

            var res = new Dictionary<int[], long>();
			foreach (var idxCombo in idxCombos)
			{
				if (idxCombo[0] - idxCombo[1] < -1)
				{
					IEnumerable<int> idxs = Enumerable.Range(idxCombo[0], idxCombo[1] - idxCombo[0]);
					res.Add(idxCombo, idxs.Select(x => inputNums[x]).Sum());
				}
			}

            var ans = res.Where(x => x.Value == 177777905).First().Key;

			IEnumerable<long> ans2 = Enumerable.Range(ans[0], ans[1] - ans[0]).Select(x => inputNums[x]);
			return (ans2.Min() + ans2.Max()).ToString();
        }
    }
}
