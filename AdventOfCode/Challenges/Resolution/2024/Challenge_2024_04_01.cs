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
        private readonly List<(int x, int y)> _directions = [(-1, -1),(-1, 0),(-1, 1),(0, -1),(0, 1),(1, -1),(1, 0),(1, 1)];

        public string ResolveChallenge(List<string> data)
        {
            for (int x = 0; x < data.Count; x++)
            {
                for (int y = 0; y < data[x].Length; y++)
                {
                    FindXMAS(data,(x, y), (0, 0), 0);
                }
            }

            return $"{_count}";
        }

        private void FindXMAS(List<string> data, (int x, int y) coord, (int x, int y) direction, int xmasIdx)
        {
            if (coord.x < 0 || coord.x > data.Count - 1) return;
            if (coord.y < 0 || coord.y > data[coord.x].Length - 1) return;
            var currentChar = data[coord.x][coord.y];
            if (currentChar != _XMAS[xmasIdx]) return;
            if (currentChar == 'S') { _count++; return; }

            if (direction == (0, 0))
            {
                // If we're starting on a new X, look around in all directions.
                _directions.ForEach(dir => FindXMAS(data, (coord.x + dir.x, coord.y + dir.y), dir, xmasIdx + 1));
            }
            else
            {
                // If we already have a direction, keep following it.
                FindXMAS(data, (coord.x + direction.x, coord.y + direction.y), direction, xmasIdx + 1);
            }
        }
    }
}
