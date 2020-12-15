using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 15)]
    public class Day15 : BaseDay
    {
        public override string PartOne(string input)
        {
            int turnNum = 1;
            var nums = input.Split(',').Select(x => int.Parse(x)).ToList();
            var spoken = new List<int>(2020);
			foreach (var num in nums)
			{
                spoken.Add(num);
                turnNum++;
			}

			while (turnNum != 2021)
			{
                var allBefore = spoken.Take(spoken.Count - 1).ToList();

                if (allBefore.Contains(spoken.Last()))
				{
                    spoken.Add(turnNum - allBefore.LastIndexOf(spoken.Last()) - 2);
				}
				else
				{
                    spoken.Add(0);
				}

                turnNum++;
			}

            return spoken.Last().ToString();
        }

        public override string PartTwo(string input)
        {
            int turnNum = 1;
            var nums = input.Split(',').Select(x => int.Parse(x)).ToList();
            var spoken = new Dictionary<int, int>();
            int lastNum = 0;

            var queue = new FixedSizedQueue<int>(10);

            foreach (var num in nums)
            {
                queue.Enqueue(num);
				if (num != nums.Last())
                    spoken.Add(num, turnNum);
                
                turnNum++;
            }

            while (turnNum != 30000001)
            {
                if (spoken.TryGetValue(queue.Last(), out int lastIdx))
                {
                    spoken[queue.Last()] = turnNum - 1;
                    queue.Enqueue(turnNum - lastIdx - 1);
                }
                else
                {
                    spoken[queue.Last()] = turnNum - 1;
                    queue.Enqueue(0);
                }

                turnNum++;
            }

            return queue.Last().ToString();
        }
    }

    public class FixedSizedQueue<T> : ConcurrentQueue<T>
    {
        private readonly object syncObject = new object();

        public int Size { get; private set; }

        public FixedSizedQueue(int size)
        {
            Size = size;
        }

        public new void Enqueue(T obj)
        {
            base.Enqueue(obj);
            lock (syncObject)
            {
                while (base.Count > Size)
                {
                    T outObj;
                    base.TryDequeue(out outObj);
                }
            }
        }
    }
}
