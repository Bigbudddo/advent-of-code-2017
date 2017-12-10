using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Puzzles {

    public sealed class Day10 : iPuzzle {

        // flatmate is drunk and came in wrecking the joint!
        // so doing this puzzle earlier than usual...

        // sorry if it's a little rough, not had much sleep.. nobody is perfect right?

        // thanks Craig...

        private readonly bool _useTestInput = false;
        private readonly string _testInput = @"3,4,1,5";
        private readonly string _input = @"106,16,254,226,55,2,1,166,177,247,93,0,255,228,60,36";

        public void Part1() {
            List<int> stream = this.BuildList();
            List<int> input = this.BuildInput();
            int currentPosition = 0, skipSize = 0;

            for (int i = 0; i < input.Count; i++) {
                int skipAmount = input[i];
                int[] subSection = new int[skipAmount];
                
                // reversing 1 will have no effect
                if (skipAmount > 1) {
                    int counter = 0;
                    int jPosition = currentPosition;
                    for (int j = 0; j < subSection.Length; j++) {
                        if ((jPosition + j) >= stream.Count) {
                            counter = 0;
                            jPosition = 0;
                        }

                        subSection[j] = stream[jPosition + counter];
                        counter++;
                    }
                    // reverse it
                    subSection = subSection.Reverse().ToArray();
                    // feed it back into the stream
                    counter = 0;
                    jPosition = currentPosition; // reset these values first!
                    for (int j = 0; j < subSection.Length; j++) {
                        if ((jPosition + j) >= stream.Count) {
                            counter = 0;
                            jPosition = 0;
                        }

                        stream[jPosition + counter] = subSection[j];
                        counter++;
                    }
                }

                // workout the current position
                for (int j = 0; j < (skipAmount + skipSize); j++) {
                    currentPosition++;
                    if (currentPosition >= stream.Count) {
                        currentPosition = 0;
                    }
                }
                // increment the skip size
                skipSize++;
            }

            int result = stream[0] * stream[1];
            Console.WriteLine("Part 1: {0}", result);
        }

        public void Part2() {

        }

        private List<int> BuildList() {
            if (_useTestInput) {
                return new List<int>() { 0, 1, 2, 3, 4 };
            }
            else {
                List<int> retval = new List<int>();
                for (int i = 0; i <= 255; i++) {
                    retval.Add(i);
                }
                return retval;
            }
        }

        private List<int> BuildInput() {
            return (_useTestInput)
                ? _testInput.Split(',').Select(x => int.Parse(x.Trim())).ToList()
                : _input.Split(',').Select(x => int.Parse(x.Trim())).ToList();
        }
    }
}
