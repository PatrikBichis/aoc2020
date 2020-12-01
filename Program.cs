﻿using System;

namespace aoc2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting to solve puzzel..");
            Console.WriteLine("---------------------------");
            Console.WriteLine(Environment.NewLine);

            new Day1_1(InputType.Input).Run().Print();
            new Day1_2(InputType.Input).Run().Print();
            //new Day2_1(InputType.Input).Run().Print();
            //new Day2_2(InputType.Input).Run().Print();
            //new Day3_1(InputType.Input).Run().Print();
            //new Day3_2(InputType.Input).Run().Print();

            //new Day4_1(InputType.Input).Run().Print();
            //new Day4_2(InputType.Input).Run().Print();

            //new Day5_1(InputType.Input).Run().Print();
            //new Day5_2(InputType.Input).Run().Print();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("---------------------------");
            Console.ReadKey();
        }
    }
}
