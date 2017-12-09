using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AdventOfCode
{
    public class Register
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class Instruction
    {
        public Register Register { get; set; }
        public Register RegisterOperand { get; set; }
        public int IncAmount { get; set; }
        public string OperatorStr { get; set; }
        public int Operand { get; set; }
    }

    public class Problem08Part1
    {
        public static void Run()
        {
            var input = File.ReadAllLines("Problem08.txt");
            var registers = input.Select(row => new Register { Name = row.Split(" ")[0] }).ToList();
            var instructions = input.Select(row =>
            {
                var register = row.Split(" ")[0];
                var registerOperand = row.Split(" ")[4];

                var incAmount = row.Split(" ")[1] == "inc"
                    ? int.Parse(row.Split(" ")[2])
                    : int.Parse(row.Split(" ")[2]) * -1;

                var operatorStr = row.Split(" ")[5];
                var operand = int.Parse(row.Split(" ")[6]);

                return new Instruction
                {
                    Register = registers.First(r => r.Name == register),
                    RegisterOperand = registers.First(r => r.Name == registerOperand),
                    IncAmount = incAmount,
                    OperatorStr = operatorStr,
                    Operand = operand
                };
            });

            var superMax = 0;
            foreach (var instruction in instructions)
            {
                bool operate = IsExpressionTrue(
                    instruction.OperatorStr,
                    instruction.RegisterOperand.Value,
                    instruction.Operand);

                if (operate)
                {
                    instruction.Register.Value += instruction.IncAmount;
                    if (instruction.Register.Value > superMax)
                        superMax = instruction.Register.Value;
                }
            }

            var max = registers.Max(r => r.Value);
        }

        private static bool IsExpressionTrue(string operationStr, int value1, int value2)
        {
            switch (operationStr)
            {
                case ">":
                    return value1 > value2;
                case ">=":
                    return value1 >= value2;
                case "<":
                    return value1 < value2;
                case "<=":
                    return value1 <= value2;
                case "==":
                    return value1 == value2;
                case "!=":
                    return value1 != value2;
                default:
                    throw new Exception();
            }
        }
    }


    public class Problem08Part2
    {
        public static void Run()
        {
            // See above (superMax)
            Problem08Part1.Run();
        }
    }
}
