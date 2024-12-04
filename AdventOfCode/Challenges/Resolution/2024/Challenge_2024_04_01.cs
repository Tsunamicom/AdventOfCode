using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_04_01 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 4;
        public int ChallengePart => 1;

        private readonly List<char> _XMAS = ['X', 'M', 'A', 'S'];
        private long _count = 0;
        private enum Direction
        {
            NEXT,
            UPLEFT,
            UP,
            UPRIGHT,
            LEFT,
            RIGHT,
            DOWNLEFT,
            DOWN,
            DOWNRIGHT
        }

        public string ResolveChallenge(List<string> data)
        {
            for (int x = 0; x < data.Count; x++)
            {
                for (int y = 0; y < data[x].Length; y++)
                {
                    FindXMAS(data,(x, y), 0, Direction.NEXT, Direction.NEXT);
                }
            }

            return $"{_count}";
        }

        private void FindXMAS(List<string> data, (int x, int y) coord, int xmasIdx, Direction direction, Direction lastDirection)
        {
            if (lastDirection != Direction.NEXT && direction != lastDirection) return;
            if (coord.x < 0 || coord.x > data.Count - 1) return;
            if (coord.y < 0 || coord.y > data[coord.x].Length - 1) return;

            var currentChar = data[coord.x][coord.y];
            if (currentChar != _XMAS[xmasIdx]) return;

            if (currentChar == 'S') { _count++; return; }

            if(direction == Direction.NEXT || direction == Direction.UPLEFT) FindXMAS(data, (coord.x - 1, coord.y - 1), xmasIdx + 1, Direction.UPLEFT, direction);
            if(direction == Direction.NEXT || direction == Direction.UP) FindXMAS(data, (coord.x - 1, coord.y), xmasIdx + 1, Direction.UP, direction);
            if(direction == Direction.NEXT || direction == Direction.UPRIGHT) FindXMAS(data, (coord.x - 1, coord.y + 1), xmasIdx + 1, Direction.UPRIGHT, direction);
            if(direction == Direction.NEXT || direction == Direction.LEFT) FindXMAS(data, (coord.x, coord.y - 1), xmasIdx + 1, Direction.LEFT, direction);
            if(direction == Direction.NEXT || direction == Direction.RIGHT) FindXMAS(data, (coord.x, coord.y + 1), xmasIdx + 1, Direction.RIGHT, direction);
            if(direction == Direction.NEXT || direction == Direction.DOWNLEFT) FindXMAS(data, (coord.x + 1, coord.y - 1), xmasIdx + 1, Direction.DOWNLEFT, direction);
            if(direction == Direction.NEXT || direction == Direction.DOWN) FindXMAS(data, (coord.x + 1, coord.y), xmasIdx + 1, Direction.DOWN, direction);
            if(direction == Direction.NEXT || direction == Direction.DOWNRIGHT) FindXMAS(data, (coord.x + 1, coord.y + 1), xmasIdx + 1, Direction.DOWNRIGHT, direction);
        }
    }
}
