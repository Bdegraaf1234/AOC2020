using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Days;
using System.IO;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace AOC2020Tests
{
	[TestClass]
	public class Day13Tests
	{
		private const int dayNum = 13;
		private AdventOfCode.BaseDay ThisDay = new Day13();

		[DataTestMethod]
		public void Part1Test1()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Example.txt");

			var ans = ThisDay.PartOne(input);

			Assert.AreEqual("295", ans);
		}

	
		[DataTestMethod]
		public void Part1Test2()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Input.txt");

			var ans = ThisDay.PartOne(input);

			Assert.AreEqual("3246", ans);
		}

		[DataTestMethod]
		public void Part2Test1()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Example.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("1068781", ans);
		}

		[DataTestMethod]
		public void Part2Test2()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Example2.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("3417", ans);
		}

		[DataTestMethod]
		public void Part2Test3()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Example3.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("754018", ans);
		}

		[DataTestMethod]
		public void Part2Test4()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Example4.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("779210", ans);
		}

		[DataTestMethod]
		public void Part2Test5()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Example5.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("1261476", ans);
		}

		[DataTestMethod]
		public void Part2Test6()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Example6.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("1202161486", ans);
		}

		[DataTestMethod]
		public void Part2Test7()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Example7.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("202", ans);
		}


		[DataTestMethod]
		public void Part2Test8()
		{
			string input = File.ReadAllText($@"C:\Users\3765563\source\repos\AOC2020\tests\AOC2020Tests\input\day{dayNum}\Day{dayNum}Input.txt");

			var ans = ThisDay.PartTwo(input);

			Assert.AreEqual("1010182346291467", ans);
		}
	}
}
