using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_01_02 : IChallengeResolution
    {
        public int ChallengeDay => 1;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var ints = data.Select(int.Parse);

            var result =
                ints.SelectMany(i => ints, (i, j) => new { i, j })
                    .SelectMany(t => ints, (t, k) => new { t, k })
                    .Where(t => t.t.i + t.t.j + t.k == 2020)
                    .Select(t => t.t.i * t.t.j * t.k);

            if (!result.Any()) return "No Solution Found.";

            return result.First().ToString();
        }
    }
}
