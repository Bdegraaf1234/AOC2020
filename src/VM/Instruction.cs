using AdventOfCode;
using System;
using System.Linq;

namespace AOC2020.VM
{
	public class Instruction
	{
		public InstructionCodes Operation;
		public int Arg;
		public int Address;

		/// <summary>
		/// Executes the instruction, returns the next address to execute.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int Execute(ref int value, bool debug = true)
		{
			if (debug)
				System.Diagnostics.Debug.WriteLine($@"Executing Instruction {Operation.ToString()} {Arg} at Addres {Address} for Value {value}");
			int curAddress = Address;
			switch (Operation)
			{
				case InstructionCodes.Nop:
					curAddress += 1;
					break;
				case InstructionCodes.Acc:
					value += Arg;
					curAddress += 1;
					break;
				case InstructionCodes.Jmp:
					curAddress += Arg;
					break;
				default:
					// This would be an exception
					curAddress = -1;
					break;
			}
			if (debug)
				System.Diagnostics.Debug.WriteLine($@"Succes: Addres {curAddress}; Value {value}");
			return curAddress;
		}

		public Instruction(int address, string input)
		{
			Address = address;
			Arg = Int32.Parse(input.Words().Last());
			Operation = Enum.Parse<InstructionCodes>(input.Words().First(), ignoreCase: true); 
		}
	}

	public enum InstructionCodes
	{
		Nop,
		Acc,
		Jmp,
	}
}