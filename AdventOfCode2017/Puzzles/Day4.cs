using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Puzzles {

    public sealed class Day4 : iPuzzle {

        // test input = aa,bb,cc,dd,ee|aa,bb,cc,dd,aa|aa,bb,cc,dd,aaa
        private readonly string _input = @"aa,bb,cc,dd,ee|aa,bb,cc,dd,aa|aa,bb,cc,dd,aaa";
        private List<string[]> _rows;

        public Day4() {
            _rows = new List<string[]>();
            foreach(string row in _input.Split('|')) {
                _rows.Add(row.Split(','));
            }
        }

        public void Part1() {
            int result = 0;

            foreach (var row in _rows) {
                // iterate the row strings
                bool isValid = false;
                for (var i = 0; i < row.Length; i++) {
                    string checkValue = row[i];

                    List<string> tmp = row.Skip(i + 1).ToList();
                    for (int j = 0; j < i; j++) {
                        tmp.Add(row[j]);
                    }

                    foreach (var t in tmp) {
                        if (t.Equals(checkValue)) {
                            isValid = false;
                            break;
                        }
                    }

                    if (!isValid) {
                        break;
                    }
                }

                if (isValid) {
                    result++;
                }
            }

            Console.WriteLine("Part 1: {0}", result);
        }

        public void Part2() {

        }
    }
}
