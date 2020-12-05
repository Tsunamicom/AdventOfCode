using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_02_02 : IChallengeResolution
    {
        public int ChallengeDay => 2;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var count = 0;

            foreach (var password in data)
            {
                var splitPass = password.Replace(":", null).Split(' ');

                var positions = splitPass[0].Split('-').Select(int.Parse);
                var firstPosIdx = positions.First() - 1;
                var secondPosIdx = positions.Last() - 1;

                var targetChar = char.Parse(splitPass[1]);

                var focusCount = new List<char>() { splitPass[2][firstPosIdx], splitPass[2][secondPosIdx] }
                    .Count(c => c == targetChar) == 1;

                if (focusCount) count++;
            }

            return count.ToString();
        }
    }
}
