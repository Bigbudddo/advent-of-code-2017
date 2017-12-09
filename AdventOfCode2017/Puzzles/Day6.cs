using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Puzzles {
    
    public sealed class Day6 : iPuzzle {

        // 4,1,15,12,0,9,9,5,5,8,7,3,14,5,12,3
        // 0,2,7,0
        private readonly string _inputString = "4,1,15,12,0,9,9,5,5,8,7,3,14,5,12,3";

        public void Part1() {
            int redistributionCycles = 0;
            List<int> input = this.BuildArray();
            List<string> previousStates = new List<string>();
            
            string memoryBankState = string.Empty;
            do {
                // append the previously built state to our array
                // we do this before we rebuild the string input
                if (!String.IsNullOrWhiteSpace(memoryBankState)) {
                    previousStates.Add(memoryBankState);
                }

                // fetch the location in the array with the highest bit count
                int highestLocation = this.FetchHighestMemoryLocation(input);
                // remove the bits to distribute from array
                int bitsToDistribute = input[highestLocation];
                input[highestLocation] = 0;

                // rebuild the memory bank state
                memoryBankState = this.BuildMemoryBank(ref input, highestLocation, bitsToDistribute);
                redistributionCycles++; // increment the cycles
            } while (!previousStates.Contains(memoryBankState));

            Console.WriteLine("Part 1: {0}", redistributionCycles);
        }

        public void Part2() {
            Console.WriteLine("--");
            WorkingPart2();
            Console.WriteLine("--");
            int redistributionCycles = 0;
            List<int> input = this.BuildArray();
            List<string> previousStates = new List<string>();

            string memoryBankState = string.Empty;
            do {
                // append the previously built state to our array
                // we do this before we rebuild the string input
                if (!String.IsNullOrWhiteSpace(memoryBankState)) {
                    previousStates.Add(memoryBankState);
                }

                // fetch the location in the array with the highest bit count
                int highestLocation = this.FetchHighestMemoryLocation(input);
                // remove the bits to distribute from array
                int bitsToDistribute = input[highestLocation];
                input[highestLocation] = 0;

                // rebuild the memory bank state
                memoryBankState = this.BuildMemoryBank(ref input, highestLocation, bitsToDistribute);
                redistributionCycles++;
            } while (this.CountOccurances(previousStates, memoryBankState) != 2);

            //int difference = redistributionCyclesToSecond - redistributionCyclesToFirst;
            int difference = input.Count() - redistributionCycles;
            Console.WriteLine("Part 2: {0} : {1}", redistributionCycles - 1, difference);
        }

        private void WorkingPart2() {
            var words = _inputString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var banks = words.Select(x => int.Parse(x)).ToArray();
            var configs = new List<int[]>();

            while (!configs.Any(x => x.SequenceEqual(banks))) {
                configs.Add((int[])banks.Clone());
                RedistributeBlocks(banks);
            }

            var seenIndex = configs.IndexOf(configs.First(x => x.SequenceEqual(banks)));
            var steps = configs.Count() - seenIndex;

            Console.WriteLine("Answer: {0}", steps.ToString());
        }

        private static void RedistributeBlocks(int[] banks) {
            var idx = banks.ToList().IndexOf(banks.Max());
            var blocks = banks[idx];

            banks[idx++] = 0;

            while (blocks > 0) {
                if (idx >= banks.Length) {
                    idx = 0;
                }

                banks[idx++]++;
                blocks--;
            }
        }

        private int FetchHighestMemoryLocation(List<int> input) {
            int location = -1;
            int locationScore = -1;

            for (int i = 0; i < input.Count; i++) {
                if (input[i] > locationScore) {
                    location = i;
                    locationScore = input[i];
                }    
            }

            return location;
        }

        private int CountOccurances(List<string> previousStates, string compareMemoryBank) {
            //int count = previousStates.Select(x => x == compareMemoryBank).Count();
            int count = 0;
            for (int i = 0; i < previousStates.Count; i++) {
                if (previousStates[i].Equals(compareMemoryBank)) {
                    count++;
                }
            }

            return count + 1; // because we include the one we already have found?
        }

        private string BuildMemoryBank(ref List<int> input, int startLocation, int bitsToDistribute) {
            for (int i = 0; i < bitsToDistribute; i++) {
                startLocation++;
                if (startLocation >= input.Count) {
                    startLocation = 0;
                }

                input[startLocation]++;
            }
            return String.Join("", input.ConvertAll(i => i.ToString()).ToArray());
        }

        private List<int> BuildArray() {
            return _inputString.Split(',').Select(x => int.Parse(x.Trim())).ToList();
        }
    }
}
