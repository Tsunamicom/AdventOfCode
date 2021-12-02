using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_01_01 : IChallengeResolution
    {
        public int ChallengeYear => 2020;
        public int ChallengeDay => 1;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var ints = data.Select(int.Parse);

            var result =
                ints.SelectMany(i => ints, (i, j) => new { i, j })
                    .Where(t => t.i + t.j == 2020)
                    .Select(t => t.i * t.j);

            if (!result.Any()) return "No Solution Found.";

            return result.First().ToString();
        }
    }
}
