using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_08_02 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 8;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var maxScenicScore = 0;

            var height = data.Count(); // up and down
            var length = data.First().Length; // left and right


            for (int h = 1; h < height - 1; h++)
            {
                for (int l = 1; l < length - 1; l++)
                {
                    var targetTree = data[h][l];

                    // Check Above
                    var up = data.Select(c => c.ElementAt(l)).Take(h).ToList();
                    up.Reverse();
                    var upScore = CalculateScenicScore(up, targetTree);

                    // Check Left
                    var left = data[h].Take(l).ToList();
                    left.Reverse();
                    var leftScore = CalculateScenicScore(left, targetTree);

                    // Check Right
                    var right = data[h].Skip(l + 1).Take(length - l).ToList();
                    var rightScore = CalculateScenicScore(right, targetTree);

                    // Check Down
                    var down = data.Select(c => c.ElementAt(l)).Skip(h + 1).Take(height - h).ToList();
                    var downScore = CalculateScenicScore(down, targetTree);

                    var targetTreeScenicScore = upScore * downScore * leftScore * rightScore;

                    maxScenicScore = Math.Max(maxScenicScore, targetTreeScenicScore);
                }
            }

            return maxScenicScore.ToString();
        }

        private int CalculateScenicScore(List<char> trees, char targetTree)
        {
            int scenicScore = 0;
            for (int i = 0; i < trees.Count; i++)
            {
                var compared = trees[i];
                scenicScore++;
                if (compared >= targetTree)
                {
                    break;
                }
            }
            return scenicScore;
        }
    }
}