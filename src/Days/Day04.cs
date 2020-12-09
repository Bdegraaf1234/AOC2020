using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 4)]
    public class Day04 : BaseDay
    {
        public override string PartOne(string input)
        {
            var passports = input.Blocks();

            var passportFields = passports.Select(x => Field.ParseFields(x));

            int validPassportCounter = 0;

			foreach (var fieldList in passportFields)
			{
                bool isComplete = CheckPassport(fieldList);
                if (isComplete)
                    validPassportCounter++;
			}

            return validPassportCounter.ToString();
        }

		private bool CheckPassport(List<Field> fieldList)
		{
			int correctFieldCount = 0;

            foreach (var curField in fieldList)
			{
				switch (curField.Name)
				{
					case Fields.Ecl:
						correctFieldCount++;
						break;
					case Fields.Pid:
						correctFieldCount++;
						break;
					case Fields.Eyr:
						correctFieldCount++;
						break;
					case Fields.Hcl:
						correctFieldCount++;
						break;
					case Fields.Byr:
						correctFieldCount++;
						break;
					case Fields.Iyr:
						correctFieldCount++;
						break;
					case Fields.Hgt:
						correctFieldCount++;
						break;
					case Fields.Cid:
						break;
					default:
						break;
				}
			}

            return correctFieldCount == 7;
		}

		public override string PartTwo(string input)
        {
			var passports = input.Blocks();

			var passportFields = passports.Select(x => Field.ParseFields(x));

			int validPassportCounter = 0;

			foreach (var fieldList in passportFields)
			{
				bool isComplete = CheckPassportPartTwo(fieldList);
				if (isComplete)
					validPassportCounter++;
			}

			return validPassportCounter.ToString();
		}

		private bool CheckPassportPartTwo(List<Field> fieldList)
		{
			int correctFieldCount = 0;

			foreach (var curField in fieldList)
			{
				switch (curField.Name)
				{
					case Fields.Ecl:
						List<string> eyeColors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
						if (eyeColors.Contains(curField.Data))
							correctFieldCount++;
						break;
					case Fields.Pid:
						if (Int32.TryParse(curField.Data, out int pid))
							if (curField.Data.Length == 9)
								correctFieldCount++;
						break;
					case Fields.Eyr:
						if (Int32.TryParse(curField.Data, out int eyr))
							if (eyr > 2019 && eyr < 2031)
								correctFieldCount++;
						break;
					case Fields.Hcl:
						var inChars = curField.Data.ToCharArray();

						if (inChars.First() == '#')
						{
							if (inChars.Length == 7)
							{
								if (Int32.TryParse(curField.Data.Substring(1, 6), System.Globalization.NumberStyles.HexNumber, null, out int ans))
								{
									correctFieldCount++;
								}
							}
						}
						break;
					case Fields.Byr:
						if (Int32.TryParse(curField.Data, out int dob))
							if (dob > 1919 && dob < 2003)
								correctFieldCount++;
						break;
					case Fields.Iyr:
						if (Int32.TryParse(curField.Data, out int iyr))
							if (iyr > 2009 && iyr < 2021)
								correctFieldCount++;
						break;
					case Fields.Hgt:
						var instring = curField.Data;
						int startIndex = instring.Length - 2 < 0 ? 0 : instring.Length - 2;
						string unit = instring.Substring(startIndex, 2);
						Int32.TryParse(instring.Substring(0, instring.Length - 2), out int hgt);
						if (unit == "in")
						{
							if (hgt > 58 && hgt < 77)
								correctFieldCount++;
						}
						else if (unit == "cm")
						{
							if (hgt > 149 && hgt < 194)
								correctFieldCount++;
						}
						break;
					case Fields.Cid:
						break;
					default:
						break;
				}
			}

			return correctFieldCount == 7;
		}
	}

    public class Field
    {
        public Fields Name;
        public string Data;

		public Field(string input)
		{
            var split = input.Split(':').ToArray();

            Name = Enum.Parse<Fields>(split[0], ignoreCase: true);
            Data = split[1];
		}

		public static List<Field> ParseFields(string passport)
		{
            var fieldStrings = passport.Words();
            return fieldStrings.Select(x => new Field(x)).ToList();
		}
	}

    public enum Fields
	{
        Ecl,
        Pid,
        Eyr,
        Hcl,
        Byr,
        Iyr,
        Hgt,
		Cid,
	}
}
