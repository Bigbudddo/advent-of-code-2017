using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Puzzles {

    public sealed class Day3 : iPuzzle {

        // dirty and hacky way of doing it
        // but after a long day of travelling, math was not on my mind. =[
        // this works though!

        // thanks to David M. for giving me some tips at the start whilst trying to figure out the math
        // we go the math for working out the bottom corner, but had to stop
        // check out his github: https://github.com/David-Mimnagh

        // thanks to the reddit/r/adventofcode community for the help & tips..
        // https://www.reddit.com/r/adventofcode

        private enum Direction {
            Right,
            Up,
            Left,
            Down
        }

        private readonly int _input = 265149;

        public void Part1() {
            int result = 0;
            // handle the event we have a 1 input?? That way we take 0 steps!
            if (_input > 1) {
                int x = 0, y = 0;
                int stepCounter = 1;
                int whileCounter = 1;
                bool stop = false;
                bool changeDirection = true;

                Direction direction = Direction.Right; // default-start
                Dictionary<string, int> coordValues = new Dictionary<string, int>();
                
                do {
                    for (int i = 0; i < stepCounter; i++) {
                        switch (direction) {
                            case Direction.Right:
                                x += 1;
                                break;
                            case Direction.Up:
                                y += 1;
                                break;
                            case Direction.Left:
                                x -= 1;
                                break;
                            case Direction.Down:
                                y -= 1;
                                break;
                        }

                        coordValues[this.GenerateCoordKey(x, y)] = whileCounter;
                        whileCounter++;

                        if (whileCounter == _input) {
                            stop = true;
                            break;
                        }
                    }

                    direction = this.GetDirection(direction);
                    changeDirection = !changeDirection;

                    if (changeDirection) {
                        stepCounter++;
                    }
                } while (!stop);

                result = Math.Abs(x) + Math.Abs(y);
            }

            Console.WriteLine("Part 1: {0}", result);
        }

        public void Part2() {
            int result = 1; // since the first store will be 1!
            if(_input > 1) {
                int x = 0, y = 0;
                int stepCounter = 1;
                bool stop = false;
                bool changeDirection = true;
                Direction direction = Direction.Right;

                var sumCollection = new Dictionary<string, int>() {
                    { "0,0", 1 }
                };

                do {
                    for (var i = 0; i < stepCounter; i++) {
                        switch (direction) {
                            case Direction.Right:
                                x += 1;
                                break;
                            case Direction.Up:
                                y += 1;
                                break;
                            case Direction.Left:
                                x -= 1;
                                break;
                            case Direction.Down:
                                y -= 1;
                                break;
                        }

                        // sum the neighbours?
                        int sum = 0;
                        int neighbourValue = 0;

                        // right
                        if (sumCollection.TryGetValue(GenerateCoordKey(x + 1, y), out neighbourValue)) {
                            sum += neighbourValue;
                        }
                        // right up
                        if (sumCollection.TryGetValue(GenerateCoordKey(x + 1, y + 1), out neighbourValue)) {
                            sum += neighbourValue;
                        }
                        // up
                        if (sumCollection.TryGetValue(GenerateCoordKey(x, y + 1), out neighbourValue)) {
                            sum += neighbourValue;
                        }
                        // up left
                        if (sumCollection.TryGetValue(GenerateCoordKey(x - 1, y + 1), out neighbourValue)) {
                            sum += neighbourValue;
                        }
                        // left
                        if (sumCollection.TryGetValue(GenerateCoordKey(x - 1, y), out neighbourValue)) {
                            sum += neighbourValue;
                        }
                        // left down
                        if (sumCollection.TryGetValue(GenerateCoordKey(x - 1, y - 1), out neighbourValue)) {
                            sum += neighbourValue;
                        }
                        // down
                        if (sumCollection.TryGetValue(GenerateCoordKey(x, y - 1), out neighbourValue)) {
                            sum += neighbourValue;
                        }
                        // down right
                        if (sumCollection.TryGetValue(GenerateCoordKey(x + 1, y - 1), out neighbourValue)) {
                            sum += neighbourValue;
                        }
                        
                        sumCollection[GenerateCoordKey(x, y)] = sum;
                        if (sum > _input) {
                            result = sum;

                            stop = true;
                            break;
                        }
                    }

                    direction = this.GetDirection(direction);
                    changeDirection = !changeDirection;

                    if (changeDirection) {
                        stepCounter++;
                    }
                } while (!stop);
            }

            Console.WriteLine("Part 2: {0}", result);
        }

        private Direction GetDirection(Direction currentDirection) {
            int currentDirectionInt = this.GetDirectionInt(currentDirection);
            currentDirectionInt = (currentDirectionInt + 1) % 4;

            switch (currentDirectionInt) {
                case 0:
                    return Direction.Right;
                case 1:
                    return Direction.Up;
                case 2:
                    return Direction.Left;
                case 3:
                    return Direction.Down;
                default:
                    return Direction.Right;
            }
        }

        private int GetDirectionInt(Direction direction) {
            switch (direction) {
                case Direction.Right:
                    return 0;
                case Direction.Up:
                    return 1;
                case Direction.Left:
                    return 2;
                case Direction.Down:
                    return 3;
                default:
                    return 0;
            }
        }

        private string GenerateCoordKey(int x, int y) {
            return string.Format("{0},{1}", x, y);
        }
    }
}
