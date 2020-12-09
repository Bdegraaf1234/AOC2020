using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 6)]
    public class Day06 : BaseDay
    {
        public override string PartOne(string input)
        {
            var groupAnswers = input.Blocks();

            List<string> combinedStrings = groupAnswers.Select(x => MergeAnswers(x)).ToList();
            var lengths = combinedStrings.Select(x => x.Length).ToList();

            return lengths.Sum().ToString();
        }

		private string MergeAnswers(string input)
		{
            var concatenated = String.Concat(input.Words().ToList()).ToCharArray();
            var ordered = concatenated.OrderBy(x => x);
            return new String(ordered.Distinct().ToArray());
		}

		public override string PartTwo(string input)
        {
            var groupAnswers = input.Blocks().ToList();

            List<string> combinedStrings = groupAnswers.Select(x => MergeAnswers(x)).ToList();


            int allYesCounter = 0;

            for (int i = 0; i < combinedStrings.Count; i++)
			{
                var currentBlock = groupAnswers[i];
                var currentCharArrays = currentBlock.Words().Select(x => x.ToCharArray());
                
                var currentString = combinedStrings[i];
                
                for (int j = 0; j < currentString.Length; j++)
				{
                    var currentChar = currentString[j];
                    var yesCount = currentCharArrays.Where(x => x.Contains(currentChar)).Count();
					if (yesCount == currentCharArrays.Count())
					{
                        allYesCounter++;
					}
				}
			}

            return allYesCounter.ToString();
        }
    }
}
