using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_04_02 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 4;
        public int ChallengePart => 2;

        private long _count = 0;
        private readonly List<(int x, int y)> _directions = [(-1, -1), (-1, 1), (1, -1), (1, 1)];

        public string ResolveChallenge(List<string> data)
        {
            for (int x = 1; x < data.Count-1; x++)
            {
                for (int y = 1; y < data[x].Length-1; y++)
                {
                    FindMAS(data, (x, y));
                }
            }

            return $"{_count}";
        }

        private void FindMAS(List<string> data, (int x, int y) coord)
        {
            var currentChar = data[coord.x][coord.y];
            if (currentChar == 'A')
            {
                // Check Surrounding
                var surround = _directions.Select(dir => data[coord.x + dir.x][coord.y + dir.y]).ToList();
                if (surround.Count(c => c == 'S') == 2 && surround.Count(c => c == 'M') == 2)
                {
                    if(surround[0] != surround[3] && surround[1] != surround[2])
                    {
                        _count++;
                    }
                }
            }
        }
    }
}
