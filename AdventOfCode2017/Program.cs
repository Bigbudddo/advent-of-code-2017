using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Puzzles;

namespace AdventOfCode2017 {
    
    class Program {

        static void Main(string[] args) {
            // do something silly? I'm waiting for another day, so might aswell add some code to this..
            DateTime today = DateTime.Now;
            if (today.Month != 12) {
                Console.WriteLine("It's not December yet! Come back when it snows...");
                Console.WriteLine();
            }
            else {
                DrawHoHoHo();
                Console.WriteLine(string.Format("Looks like today is the {0}{1}.", today.Day, ProgramHelpers.GetDateEnd(today.Day)));
                Console.Write("Checking to see if we have this puzzle implemented yet... ");

                iPuzzle puzzle = GetPuzzle(today.Day);
                if (puzzle == null) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NOT FOUND!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Looks like you've not solved that puzzle yet. Get cracking!");
                    Console.WriteLine();
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("FOUND!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Executing puzzle...");
                    Console.WriteLine();

                    puzzle.Part1();
                    puzzle.Part2();

                    Console.WriteLine();
                }
            }
            
            Console.Write("Finished.. Press return to close! ");
            Console.ReadLine();
        }

        static void DrawHoHoHo(ConsoleColor baseColour = ConsoleColor.Gray) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Ho");

            Console.ForegroundColor = baseColour;
            Console.Write("-");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ho");

            Console.ForegroundColor = baseColour;
            Console.Write("-");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Ho");

            Console.ForegroundColor = baseColour;
            Console.WriteLine("...");
        }
        
        static iPuzzle GetPuzzle(int day) {
            switch (day) {
                case 1:
                    return new Day1();
                default:
                    return null;
            }
        }
    }

    public static class ProgramHelpers {

        public static string GetDateEnd(int day) {
            if (day == 1) {
                return "st";
            }
            else if (day == 2 || day == 22) {
                return "nd";
            }
            else if (day == 3) {
                return "rd";
            }
            else {
                return "th";
            }
        }
    }
}
