using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 12)]
    public class Day12 : BaseDay
    {
        public int xCoordinate = 0;
        public int yCoordinate = 0;
        Direction facing = Direction.Right;

        public int waypointX = 10;
        public int waypointY = 1;

        public override string PartOne(string input)
        {
            var instructions = input.Lines().Select(x => new ShipInstruction(x));
			foreach (var instr in instructions)
			{
                instr.Execute(this);
			}
            return (Math.Abs(xCoordinate) + Math.Abs(yCoordinate)).ToString();
        }

        public override string PartTwo(string input)
        {
            var instructions = input.Lines().Select(x => new ShipInstruction(x));
            foreach (var instr in instructions)
            {
                instr.ExecutePartTwo(this);
            }
            return (Math.Abs(xCoordinate) + Math.Abs(yCoordinate)).ToString();
        }

        public enum ShipInstructions
        {
            N,
            S,
            E,
            W,
            L,
            R,
            F,
        }

        public class ShipInstruction
        {
            ShipInstructions Instruction;
            int Value;

            public ShipInstruction(string input)
            {
                Instruction = Enum.Parse<ShipInstructions>(input.First().ToString(), ignoreCase: true);
                Value = Int32.Parse(input.Substring(1));
            }

            public void ExecutePartTwo(Day12 day)
            {
                var numTurns = Value / 90;
                switch (Instruction)
                {
                    case ShipInstructions.N:
                        day.waypointY += Value;
                        break;
                    case ShipInstructions.S:
                        day.waypointY -= Value;
                        break;
                    case ShipInstructions.E:
                        day.waypointX += Value;
                        break;
                    case ShipInstructions.W:
                        day.waypointX -= Value;
                        break;
                    case ShipInstructions.L:
                        for (int i = 0; i < numTurns; i++)
                        {
                            int newX = -day.waypointY;
                            int newY = day.waypointX;
                            day.waypointY = newY;
                            day.waypointX = newX;
						}
                        break;
                    case ShipInstructions.R:
                        for (int i = 0; i < numTurns; i++)
                        {
                            int newX = day.waypointY;
                            int newY = -day.waypointX;
                            day.waypointX = newX;
                            day.waypointY = newY;
                        }
                        break;
                    case ShipInstructions.F:
						for (int i = 0; i < Value; i++)
						{
                            day.xCoordinate += day.waypointX;
                            day.yCoordinate += day.waypointY;
                        }
                        break;
                    default:
                        break;
                }
            }

            public void Execute(Day12 day)
            {
                var numTurns = Value / 90;
                switch (Instruction)
                {
                    case ShipInstructions.N:
                        day.yCoordinate += Value;
                        break;
                    case ShipInstructions.S:
                        day.yCoordinate -= Value;
                        break;
                    case ShipInstructions.E:
                        day.xCoordinate += Value;
                        break;
                    case ShipInstructions.W:
                        day.xCoordinate -= Value;
                        break;
                    case ShipInstructions.L:
                        for (int i = 0; i < numTurns; i++)
                            day.facing = day.facing.TurnLeft();
                        break;
                    case ShipInstructions.R:
                        for (int i = 0; i < numTurns; i++)
                            day.facing = day.facing.TurnRight();
                        break;
                    case ShipInstructions.F:
                        switch (day.facing)
                        {
                            case Direction.Down:
                                day.yCoordinate -= Value;
                                break;
                            case Direction.Up:
                                day.yCoordinate += Value;
                                break;
                            case Direction.Right:
                                day.xCoordinate += Value;
                                break;
                            case Direction.Left:
                                day.xCoordinate -= Value;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
