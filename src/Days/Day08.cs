using AOC2020.VM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 8)]
    public class Day08 : BaseDay
    {
        public override string PartOne(string input)
        {
            var vm = new VirtualMachine(0, 0, input);

            vm.RunWithExitPredicate(vm => vm.ExecutedInstructions.Contains(vm.Address));

            return vm.Value.ToString();
        }

        public override string PartTwo(string input)
        {
			int alterIdx = -1;
			bool exitedNormally = false;

			VirtualMachine vm = new VirtualMachine(0, 0, input, false);
			while (!exitedNormally)
			{
				vm = new VirtualMachine(0, 0, input);
				alterIdx++;
				switch (vm.Memory[alterIdx].Operation)
				{
					case InstructionCodes.Nop:
						vm.Memory[alterIdx].Operation = InstructionCodes.Jmp;
						break;
					case InstructionCodes.Acc:
						continue;
						break;
					case InstructionCodes.Jmp:
						vm.Memory[alterIdx].Operation = InstructionCodes.Nop;
						break;
					default:
						break;
				}

				vm.RunWithExitPredicate(vm => vm.ExecutedInstructions.Contains(vm.Address) || vm.Address == vm.Memory.Length, vm =>
				{
					exitedNormally = vm.Address == vm.Memory.Length;
				});
			}

            return vm.Value.ToString();
        }
    }
}
