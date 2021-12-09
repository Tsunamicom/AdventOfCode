using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_08_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 8;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var result = data
                .Select(c => c.Split('|', System.StringSplitOptions.RemoveEmptyEntries).Last())
                .SelectMany(c => c.Split(' ', System.StringSplitOptions.RemoveEmptyEntries))
                .Count(c => new int[] { 2, 3, 4, 7 }.Contains(c.Length));

            return result.ToString();
        }
    }
}