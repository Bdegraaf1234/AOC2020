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
            throw new NotImplementedException();
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
	}
}
