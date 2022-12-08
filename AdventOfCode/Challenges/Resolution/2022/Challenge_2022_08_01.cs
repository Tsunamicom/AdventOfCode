using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_08_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 8;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var totalVisible = 0;

            var height = data.Count(); // up and down
            var length = data.First().Length; // left and right

            var outerTrees = length * 2 + (height - 2) * 2;
            totalVisible += outerTrees;

            for (int h = 1; h < height - 1; h++)
            {
                for (int l = 1; l < length - 1; l++)
                {
                    var targetTree = data[h][l];
                    // Check Above
                    var up = data.Select(c => c.ElementAt(l)).Take(h);
                    var isVisibleUp = up.All(n => n < targetTree);
                    if (isVisibleUp)
                    {
                        totalVisible++; continue;
                    }

                    // Check Left
                    var left = data[h].Take(l);
                    var isVisibleLeft = left.All(n => n < targetTree);
                    if (isVisibleLeft)
                    {
                        totalVisible++; continue;
                    }

                    // Check Right
                    var right = data[h].Skip(l + 1).Take(length - l);
                    var isVisibleRight = right.All(n => n < targetTree);
                    if (isVisibleRight)
                    {
                        totalVisible++; continue;
                    }

                    // Check Down
                    var down = data.Select(c => c.ElementAt(l)).Skip(h + 1).Take(height - h);
                    var isVisibleDown = down.All(n => n < targetTree);
                    if (isVisibleDown)
                    {
                        totalVisible++; continue;
                    }
                }
            }

            return totalVisible.ToString();
        }
    }
}