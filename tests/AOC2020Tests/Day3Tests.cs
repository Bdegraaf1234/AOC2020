using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Days;
using System.IO;

namespace AOC2020Tests
{
	[TestClass]
	public class Day3Tests
	{
		[DataTestMethod]
		public void Day3Part1Test1()
		{
			string input = File.ReadAllText(@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day3\Day3Example.txt");

			var thisDay = new Day03();
			var ans = thisDay.PartOne(input);

			Assert.AreEqual("7", ans);
		}

		[DataTestMethod]
		public void Day3Part1Test2()
		{
			string input = File.ReadAllText(@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day3\Day3Input.txt");

			var thisDay = new Day03();
			var ans = thisDay.PartOne(input);

			Assert.AreEqual("232", ans);
		}


		[DataTestMethod]
		public void Day3Part2Test1()
		{
			string input = File.ReadAllText(@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day3\Day3Example.txt");

			var thisDay = new Day03();
			var ans = thisDay.PartTwo(input);

			Assert.AreEqual("336", ans);
		}

		[DataTestMethod]
		public void Day3Part2Test2()
		{
			string input = File.ReadAllText(@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day3\Day3Input.txt");

			var thisDay = new Day03();
			var ans = thisDay.PartTwo(input);

			Assert.AreEqual("3952291680", ans);
		}
	}
}
