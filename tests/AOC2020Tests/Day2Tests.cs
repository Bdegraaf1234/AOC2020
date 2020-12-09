using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Days;
using System.IO;

namespace AOC2020Tests
{
	[TestClass]
	public class Day2Tests
	{
		[DataTestMethod]
		[DataRow("1-3 a: abcde", "1")]
		[DataRow("1-3 b: cdefg", "0")]
		public void Day2Part1Test1(string input, string expectedOutput)
		{
			var thisDay = new Day02();
			var ans = thisDay.PartOne(input);

			Assert.AreEqual(expectedOutput, ans);
		}

		[DataTestMethod]
		public void Day2Part1Test2()
		{
			string input = File.ReadAllText(@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day2\Day2Input.txt");

			var thisDay = new Day02();
			var ans = thisDay.PartOne(input);

			Assert.AreEqual("546", ans);
		}


		[DataTestMethod]
		[DataRow("1-3 a: abcde", "1")]
		[DataRow("1-3 b: cdefg", "0")]
		public void Day2Part2Test1(string input, string expectedOutput)
		{
			var thisDay = new Day02();
			var ans = thisDay.PartTwo(input);

			Assert.AreEqual(expectedOutput, ans);
		}

		[DataTestMethod]
		public void Day2Part2Test2()
		{
			string input = File.ReadAllText(@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day2\Day2Input.txt");

			var thisDay = new Day02();
			var ans = thisDay.PartTwo(input);

			Assert.AreEqual("275", ans);
		}
	}
}
