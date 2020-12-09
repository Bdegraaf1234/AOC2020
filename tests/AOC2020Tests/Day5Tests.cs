using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Days;
using System.IO;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace AOC2020Tests
{
	[TestClass]
	public class Day5Tests
	{
		private const int dayNum = 5;
		private AdventOfCode.BaseDay ThisDay = new Day05();

		[DataTestMethod]
		public void Part1Test1()
		{
			string input = "BFFFBBFRRR";
			var ans = ThisDay.PartOne(input);

			Assert.AreEqual("567", ans);
		}

		[DataTestMethod]
		public void Part1Test2()
		{
			string input = "FFFBBBFRRR";
			var ans = ThisDay.PartOne(input);

			Assert.AreEqual("119", ans);
		}

		[DataTestMethod]
		public void Part1Test3()
		{
			string input = "BBFFBBFRLL";
			var ans = ThisDay.PartOne(input);

			Assert.AreEqual("820", ans);
		}

		[DataTestMethod]
		public void Part1Test4()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Input.txt");

			var ans = ThisDay.PartOne(input);

			Assert.AreEqual("987", ans);
		}

		[DataTestMethod]
		public void Part2Test2()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Input.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("603", ans);
		}
	}
}
