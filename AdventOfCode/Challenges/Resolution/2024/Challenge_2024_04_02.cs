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
                var topleft = data[coord.x - 1][coord.y - 1];
                var topright = data[coord.x - 1][coord.y + 1];
                var bottomleft = data[coord.x + 1][coord.y - 1];
                var bottomright = data[coord.x + 1][coord.y + 1];

                var surround = new List<char>() {topleft, topright, bottomleft, bottomright };

                if (surround.Count(c => c == 'S') == 2 && surround.Count(c => c == 'M') == 2)
                {
                    if(topleft != bottomright && topright != bottomleft)
                    {
                        _count++;
                    }
                }
            }
        }
    }
}
