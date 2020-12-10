using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Days
{
    [Day(2020, 7)]
    public class Day07 : BaseDay
    {
        private Dictionary<string, BagRule> ParsedRules;

        public override string PartOne(string input)
        {
            var rules = input.Lines();
			IEnumerable<BagRule> bagRules = rules.Select(x => new BagRule(x));
			ParsedRules = bagRules.ToDictionary(x => x.Color, x => x);
            List<bool> containsRequested = ParsedRules.Select(x => BagContains(x.Key, "shiny gold")).ToList();

            return containsRequested.Where(x => x).Count().ToString();
        }

		private bool BagContains(string key, string color)
		{
			if (key == "no other")
				return false;
			
			
            if (ParsedRules[key].ContainedColors.Contains(color))
                return true;
			
            else
				foreach (var containedColor in ParsedRules[key].ContainedColors)
					if (BagContains(containedColor, color))
						return true;
			
            
            return false;
		}

		public override string PartTwo(string input)
        {
			var rules = input.Lines();
			IEnumerable<BagRule> bagRules = rules.Select(x => new BagRule(x));
			ParsedRules = bagRules.ToDictionary(x => x.Color, x => x);

			return CountBagsInside("shiny gold").ToString();
		}

		private int CountBagsInside(string key)
		{
			int count = 0;
			if (key == "no other")
				return count;

			foreach (string color in ParsedRules[key].ContainedColors)
			{
				int numForColor = ParsedRules[key].CountPerColor[color];

				// 
				if (color == "no other")
					return count;

				// add the number of bags itself
				count += numForColor;

				// add the bags in the bags
				count += numForColor * CountBagsInside(color);
			}

			return count;
		}
	}

    public class BagRule
	{
        public string Color;
        public List<string> ContainedColors = new List<string>();
        public Dictionary<string, int> CountPerColor = new Dictionary<string, int>();

		public BagRule(string input)
		{
            Color = String.Join(' ', input.Words().Take(2));
            var content = input.Split("contain ")[1].Trim('.');
            var splitContent = content.Split(',');
			foreach (var bagColor in splitContent)
			{
                var bagWords = bagColor.Words();
                var parsedColor = new StringBuilder();
                int count = 0;
				foreach (var word in bagWords)
				{
					bool isCount = Int32.TryParse(word, out int innerCount);
					if (!isCount)
					{
						if (word.Contains("bag"))
						{
                            continue;
						}
                        parsedColor.Append(" ");
                        parsedColor.Append(word);
                    }
					else
					{
						count = innerCount;
					}
                }

				string parsedColorString = parsedColor.ToString().Trim(' ');
				ContainedColors.Add(parsedColorString);
                CountPerColor.Add(parsedColorString, count);
            }
		}
	}
}
