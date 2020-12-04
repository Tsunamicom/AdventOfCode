using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_03_01 : IChallengeResolution
    {
        public int ChallengeDay => 3;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var sectionLen = data.First().Length;

            var horizontalPos = 0;
            var treeCount = 0;
            var horizontalSpeed = 3;
            var downHillSpeed = 1;

            for (int i = downHillSpeed; i < data.Count; i += downHillSpeed)
            {
                horizontalPos += horizontalSpeed;
                horizontalPos %= sectionLen;

                if (data[i][horizontalPos] == '#')
                {
                    ++treeCount;
                }
            }

            return treeCount.ToString();
        }
    }
}
