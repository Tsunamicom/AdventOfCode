using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_01_02 : IChallengeResolution
    {
        public int ChallengeDay => 1;
        public int ChallengePart => 2;

        public async Task<string> ResolveChallenge(List<string> data)
        {
            var ints = data.Select(int.Parse);

            var result = await Task.Run(() =>
                ints.SelectMany(i => ints, (i, j) => new { i, j })
                    .SelectMany(t => ints, (t, k) => new { t, k })
                    .Where(t => t.t.i + t.t.j + t.k == 2020)
                    .Select(t => t.t.i * t.t.j * t.k)
                ).ConfigureAwait(false);

            if (!result.Any()) return "No Solution Found.";

            return result.First().ToString();
        }
    }
}
