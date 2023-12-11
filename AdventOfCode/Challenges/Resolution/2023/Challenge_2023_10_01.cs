using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_10_01 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 10;
        public int ChallengePart => 1;

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            Start,
            End
        }

        private enum PipeType
        {
            /// <summary>|</summary>
            NS,

            /// <summary>-</summary>
            EW,

            /// <summary>L</summary>
            NE,

            /// <summary>J</summary>
            NW,

            /// <summary>7</summary>
            SW,

            /// <summary>F</summary>
            SE,

            /// <summary>.</summary>
            G,

            /// <summary>S</summary>
            S
        }

        private readonly Dictionary<Direction, List<PipeType>> AccessiblePipeTypes = new()
        {
            {Direction.Start, [PipeType.NS, PipeType.EW, PipeType.NE, PipeType.NW, PipeType.SW, PipeType.SE] },
            {Direction.Left, [PipeType.NE, PipeType.SE, PipeType.EW, PipeType.S] },
            {Direction.Right, [PipeType.NW, PipeType.SW, PipeType.EW, PipeType.S] },
            {Direction.Up, [PipeType.SW, PipeType.SE, PipeType.NS, PipeType.S]  },
            {Direction.Down, [PipeType.NE, PipeType.NW, PipeType.NS, PipeType.S]  }
        };

        private readonly Dictionary<Direction, (int i, int j)> DirectionCoordOffset = new()
        {
            {Direction.Up, (-1, 0)},
            {Direction.Down, (1, 0)},
            {Direction.Left, (0, -1)},
            {Direction.Right, (0, 1)},
        };

        private readonly Dictionary<PipeType, List<Direction>> PipeDirections = new()
        {
            /* S */  {PipeType.S, [Direction.Up, Direction.Down, Direction.Left, Direction.Right] },
            /* | */  {PipeType.NS, [Direction.Up, Direction.Down] },
            /* - */  {PipeType.EW, [Direction.Left, Direction.Right] },
            /* L */  {PipeType.NE, [Direction.Up, Direction.Right] },
            /* J */  {PipeType.NW, [Direction.Up, Direction.Left] },
            /* 7 */  {PipeType.SW, [Direction.Down, Direction.Left] },
            /* F */  {PipeType.SE, [Direction.Down, Direction.Right] },
            /* . */  {PipeType.G, [] },
        };

        private readonly Dictionary<Direction, Direction> BackFlowDirection = new()
        {
            { Direction.Up, Direction.Down },
            { Direction.Down, Direction.Up },
            { Direction.Left, Direction.Right },
            { Direction.Right, Direction.Left },
            { Direction.Start, Direction.End },
        };

        private readonly Dictionary<char, PipeType> PipeTranslate = new()
        {
            {'|', PipeType.NS},
            {'-', PipeType.EW},
            {'L', PipeType.NE},
            {'J', PipeType.NW},
            {'7', PipeType.SW},
            {'F', PipeType.SE},
            {'.', PipeType.G},
            {'S', PipeType.S},
        };

        private List<List<PipeType>> PipeMapping = new();

        private (Direction d, (int i, int j) coords) Start = (Direction.Start, (0, 0));

        List<List<(int i, int j)>> AllLoops = [[]];

        public string ResolveChallenge(List<string> data)
        {
            // NOTES:  Getting Stack Overflow on main input.  Refactor MoveDirection to be a while loop and maybe a Queue.
            Start = (Direction.Start, (0, 0));
            PipeMapping = [[]];
            AllLoops = [[]];

            PipeMapping = data.Select(c => c.Select(c => PipeTranslate[c]).ToList()).ToList();

            Start = FindStartCoords();
            Debug.WriteLine(Start.ToString());
            Debug.WriteLine(PipeMapping[Start.coords.i][Start.coords.j]);

            var totalCycles = MoveDirection([Start.coords], Start);

            var maxDistance = totalCycles.Count / 2;

            return $"{maxDistance}";
        }


        private List<(int i, int j)> MoveDirection(List<(int i, int j)> visited, (Direction d, (int i, int j) coords) current)
        {
            var lastVisited = visited.ToList();
            var availableMoves = FindAvailableMoves(visited, current);
            if (availableMoves.Any(c => c.coords == Start.coords))
            {
                lastVisited.Add(Start.coords);
                AllLoops.Add(lastVisited);
                return lastVisited;
            }

            foreach(var move in availableMoves) 
            {
                lastVisited.Add(move.coords);
                var nextVisited = MoveDirection(lastVisited, move);
                if (nextVisited.Count > visited.Count) visited = nextVisited;
            }

            return visited;
        }

        private List<(Direction d, (int i, int j) coords)> FindAvailableMoves(List<(int i, int j)> visited, (Direction d, (int i, int j) coords) current)
        {
            List<(Direction d, (int i, int j) coords)> availableMoves = [];

            var currentPipe = PipeMapping[current.coords.i][current.coords.j];
            var availablePipeDirections = PipeDirections[currentPipe];

            foreach(var direction in availablePipeDirections) 
            {
                if (direction != BackFlowDirection[current.d])
                {
                    var accessiblePipeTypes = AccessiblePipeTypes[direction];
                    var coordOffset = DirectionCoordOffset[direction];
                    (Direction d, (int i, int j) coords) nextCoord = (direction, (current.coords.i + coordOffset.i, current.coords.j + coordOffset.j));
                    if (IsWithinBounds(nextCoord.coords) && (!visited.Contains((nextCoord.coords.i, nextCoord.coords.j)) || (nextCoord.coords == Start.coords)))
                    {
                        var nextPipe = PipeMapping[nextCoord.coords.i][nextCoord.coords.j];
                        if (accessiblePipeTypes.Contains(nextPipe))
                        {
                            availableMoves.Add(nextCoord);
                        }
                    }
                }
            }
            return availableMoves;
        }

        //private List<(int i, int j)> MoveDirection(List<(int i, int j)> visited, (Direction d, int i, int j) current)
        //{
        //    // TODO:  This traversal should complete a circuit from start back to start without jumps.
        //    // Need to backtrack dead ends until we find a good circuit back to start
        //    //if (visited.Contains((current.i, current.j)))
        //    //    return visited;
        //    var currentPipe = PipeMapping[current.i][current.j];
        //    var availablePipeDirections = PipeDirections[currentPipe];
        //    visited.Add((current.i, current.j));

        //    var maxCycle = visited.ToList();
        //    var hasAccessiblePipes = false;
        //    foreach (var direction in availablePipeDirections)
        //    {
        //        var coordOffset = DirectionCoordOffset[direction];
        //        (Direction d, int i, int j) nextCoord = (direction, current.i + coordOffset.i, current.j + coordOffset.j);
        //        if (IsWithinBounds(nextCoord))
        //        {
        //            var nextPipeType = PipeMapping[nextCoord.i][nextCoord.j];
        //            var accessiblePipes = AccessiblePipeTypes[direction];
        //            hasAccessiblePipes = accessiblePipes.Contains(nextPipeType) &&
        //                (!visited.Contains((nextCoord.i, nextCoord.j))
        //                    || (nextPipeType == PipeType.S && visited.Count > 4));

        //            if (hasAccessiblePipes)
        //            {
        //                if (nextPipeType == PipeType.S)
        //                {
        //                    visited.Add((Start.i, Start.j));
        //                    break;
        //                };
        //                if (!visited.Contains((nextCoord.i, nextCoord.j)))
        //                {
        //                    var nextMoves = MoveDirection(visited, nextCoord);
        //                    maxCycle = maxCycle.Count > nextMoves.Count ? maxCycle : nextMoves;
        //                }

        //                //visited = maxCycle;
        //            }

        //        }
        //    }


        //    return maxCycle; //visited;
        //}

        private bool IsWithinBounds((int i, int j) coord)
        {
            return coord.i >= 0
                    && coord.j >= 0
                    && PipeMapping.Count - 1 >= coord.i
                    && PipeMapping[coord.i].Count - 1 >= coord.j;
        }

        private (Direction d, (int i, int j) coords) FindStartCoords()
        {
            var startRow = PipeMapping.First(c => c.Contains(PipeType.S));
            return (Direction.Start, (PipeMapping.IndexOf(startRow), startRow.IndexOf(PipeType.S)));
        }


    }
}
