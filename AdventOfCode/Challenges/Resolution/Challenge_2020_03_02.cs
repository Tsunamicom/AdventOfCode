using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_03_02 : IChallengeResolution
    {
        public int ChallengeDay => 3;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var sectionLen = data.First().Length;

            long multipliedTrees = 1;

            // <horizontalSpeed, downHillSpeed>
            var slopes = new List<Tuple<int, int>>() {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(5, 1),
                new Tuple<int, int>(7, 1),
                new Tuple<int, int>(1, 2)
            };

            foreach (var slope in slopes)
            {
                var horizontalPos = 0;
                var treeCount = 0;

                for (int i = slope.Item2; i < data.Count; i += slope.Item2)
                {
                    horizontalPos += slope.Item1;
                    horizontalPos %= sectionLen;

                    if (data[i][horizontalPos] == '#')
                    {
                        ++treeCount;
                    }
                }

                multipliedTrees *= treeCount;
            }

            return multipliedTrees.ToString();
        }
    }
}
