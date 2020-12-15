using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 14)]
    public class Day14 : BaseDay
    {
        public override string PartOne(string input)
        {
            BitMask currentMask = null;
            long[] memory = new long[1000000];

			foreach (var line in input.Lines())
			{
                var words = line.Words();
                if (words.First() == "mask")
				{
                    currentMask = new BitMask(line);
				}
				else
				{
                    int address = Int32.Parse(words.First().Split("[").Last().Trim(']'));
                    memory[address] = currentMask.Apply(int.Parse(words.Last()));
				}
			}


            return memory.Sum().ToString();
        }

        public override string PartTwo(string input)
        {
            BitMask currentMask = null;

            Dictionary<long, long> memory = new Dictionary<long, long>();

            foreach (var line in input.Lines())
            {
                var words = line.Words();
                if (words.First() == "mask")
                {
                    currentMask = new BitMask(line);
                }
                else
                {
                    int address = Int32.Parse(words.First().Split("[").Last().Trim(']'));
                    long[] addresses = currentMask.ApplyPartTwo(address);
					foreach (var addr in addresses)
                    {
						if (memory.TryGetValue(addr, out long _))
						{
                            memory[addr] = int.Parse(words.Last());
                        }
						else
						{
                            memory.Add(addr, int.Parse(words.Last()));
						}
                    }
                }
            }


            return memory.Select(x => x.Value).Sum().ToString();
        }
    }

    public enum BitOps
    {
        Off,
        On,
        X
	}

    public class BitMask
	{
        BitOps[] Mask = new BitOps[36];

		public BitMask(string input)
		{
            var chars = input.Words().Last().ToCharArray();
            Mask = chars.Select(x => Enum.Parse<BitOps>(x.ToString())).ToArray();
        }

        public long Apply(int input)
        {
            char[] binary = Convert.ToString(input, 2).ToCharArray();
            char[] binary36 = Enumerable.Repeat('0', 36).ToArray();

            int offset = binary36.Length - binary.Length;
            for (int i = 0; i < binary.Length; i++)
            {
                binary36[i + offset] = binary[i];
            }

            for (int i = 0; i < 36; i++)
            {
                switch (Mask[i])
                {
                    case BitOps.Off:
                        binary36[i] = '0';
                        break;
                    case BitOps.On:
                        binary36[i] = '1';
                        break;
                    case BitOps.X:
                        break;
                    default:
                        break;
                }
            }

            return Convert.ToInt64(new string(binary36), 2);
        }


        public long[] ApplyPartTwo(int input)
        {
            char[] binary = Convert.ToString(input, 2).ToCharArray();
            char[] binary36 = Enumerable.Repeat('0', 36).ToArray();

            int offset = binary36.Length - binary.Length;
            for (int i = 0; i < binary.Length; i++)
            {
                binary36[i + offset] = binary[i];
            }

            int numFloats = Mask.Where(x => x == BitOps.X).Count();
            List<long> output = new List<long>();

            for (int i = 0; i < 36; i++)
            {
                switch (Mask[i])
                {
                    case BitOps.Off:
                        break;
                    case BitOps.On:
                        binary36[i] = '1';
                        break;
                    case BitOps.X:
                        binary36[i] = 'x';
                        break;
                    default:
                        break;
                }
            }

            var idxCombos = MyHelpers.GenerateCombinations(numFloats, 0, 1);

			foreach (var combo in idxCombos)
			{
                var curBinary = new char[36];
                binary36.CopyTo(curBinary, 0);
				foreach (var bit in combo)
				{
                    curBinary[curBinary.IndexOf('x')] = bit.ToString()[0];
				}
                output.Add(Convert.ToInt64(new string(curBinary), 2));
            }

            return output.ToArray();
        }
    }
}
