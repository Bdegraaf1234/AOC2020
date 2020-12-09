using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 2)]
    public class Day02 : BaseDay
    {
        public override string PartOne(string input)
        {
            // Parse input
            var inputLines = input.Lines();

            // Count the number of valid passwords
            int validCounter = 0;
			foreach (var line in inputLines)
			{
                bool ans = CheckPasswordValidity(line);
                if (ans)
                    validCounter++;
			}

            return validCounter.ToString();
        }

		private bool CheckPasswordValidity(string line)
		{
			int min, max;
			char letter;
			string password;
			ParsePasswordLine(line, out min, out max, out letter, out password);

			// count occurence of the specified letter
			var specifiedLetterOccurrence = password.ToCharArray().Where(x => x == letter).Count();

			return specifiedLetterOccurrence >= min && specifiedLetterOccurrence <= max;
		}

		public override string PartTwo(string input)
		{
			// Parse input
			var inputLines = input.Lines();

			// Count the number of valid passwords
			int validCounter = 0;
			foreach (var line in inputLines)
			{
				bool ans = CheckPasswordValidityPartTwo(line);
				if (ans)
					validCounter++;
			}

			return validCounter.ToString();
		}

        private bool CheckPasswordValidityPartTwo(string line)
		{
			int firstPosition, secondPosition;
			char letter;
			string password;
			ParsePasswordLine(line, out firstPosition, out secondPosition, out letter, out password);

			// count occurence of the specified letter
			var passwordCharArray = password.ToCharArray();

            return passwordCharArray[firstPosition - 1] == letter ^ passwordCharArray[secondPosition - 1] == letter;
        }


		private static void ParsePasswordLine(string line, out int min, out int max, out char letter, out string password)
		{
			// Parse the input line
			var split = line.Words().ToList();

			// Parse the min and max occurrences
			var minMax = split[0].Split('-');
			min = Int32.Parse(minMax.First());
			max = Int32.Parse(minMax.Last());

			// Parse the letter and password
			letter = split[1].ToCharArray().First();
			password = split[2];
		}
	}
}
