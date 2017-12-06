using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Puzzles {
    
    public sealed class Day6 : iPuzzle {

        // 4	1	15	12	0	9	9	5	5	8	7	3	14	5	12	3
        private readonly string _inputString = "0	2	7	0";
        private List<int> _aInput;

        public void Part1() {
            this.RebuildArray();
            int redistributionCycles = 0;

            Console.WriteLine("Part 1: {0}", redistributionCycles);
        }

        public void Part2() {
            this.RebuildArray();
            int redistributionCycles = 0;

            Console.WriteLine("Part 2: {0}", redistributionCycles);
        }

        private void RebuildArray() {
            _aInput = _inputString.Split('\t').Select(x => int.Parse(x.Trim())).ToList();
        }
    }
}
