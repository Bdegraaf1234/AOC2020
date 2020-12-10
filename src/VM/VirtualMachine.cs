using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2020.VM
{
	public class VirtualMachine
	{
		public int Address;
		public int Value;
		public Instruction[] Memory;
		public List<int> ExecutedInstructions = new List<int>();
		public bool Debug = true;

		public VirtualMachine(int address, int value, string program, bool debug = true)
		{
			Address = address;
			Value = value;
			var instructions = program.Lines().ToList();
			Memory = new Instruction[instructions.Count()];
			for (int i = 0; i < instructions.Count(); i++)
			{
				Memory[i] = new Instruction(i, instructions[i]);
			}
			Debug = debug;
		}

		public int Run()
		{
			while (Address >= 0)
			{
				ExecutedInstructions.Add(Address);
				Execute();
			}

			return Value;
		}

		public int RunWithExitValue<T>(int exitValue)
		{
			while (Value != exitValue)
			{
				ExecutedInstructions.Add(Address);
				Execute();
			}

			return Value;
		}

		public int RunWithExitPredicate(Func<VirtualMachine, bool> exitCondition, Action<VirtualMachine> inject = null)
		{
			inject = inject ?? fakeInject;

			while (true)
			{
				inject(this);
				if (exitCondition(this))
				{
					return 1;
				};
				ExecutedInstructions.Add(Address);
				Execute();
			}

			return -1;

			void fakeInject(VirtualMachine vm)
			{
			}
		}

		private void Execute()
		{
			Address = Memory[Address].Execute(ref Value, Debug);
		}
	}
}
