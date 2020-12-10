using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Days;
using System.IO;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace AOC2020Tests
{
	[TestClass]
	public class Day8Tests
	{
		private const int dayNum = 8;
		private AdventOfCode.BaseDay ThisDay = new Day08();

		[DataTestMethod]
		public void Part1Test1()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Example.txt");

			var ans = ThisDay.PartOne(input);

			Assert.AreEqual("5", ans);
		}

	
		[DataTestMethod]
		public void Part1Test2()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Input.txt");

			var ans = ThisDay.PartOne(input);

			Assert.AreEqual("1744", ans);
		}

		[DataTestMethod]
		public void Part2Test1()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Example.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("8", ans);
		}


		[DataTestMethod]
		public void Part2Test3()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Input.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("1174", ans);
		}
	}
}
