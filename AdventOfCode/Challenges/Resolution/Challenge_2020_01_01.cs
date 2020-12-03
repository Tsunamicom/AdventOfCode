using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_01_01 : IChallengeResolution
    {
        public int ChallengeDay => 1;
        public int ChallengePart => 1;

        public async Task<string> ResolveChallenge(List<string> data)
        {
            var ints = data.Select(int.Parse);

            var result = await Task.Run(() =>
                ints.SelectMany(i => ints, (i, j) => new { i, j })
                    .Where(t => t.i + t.j == 2020)
                    .Select(t => t.i * t.j)
                ).ConfigureAwait(false);

            if (!result.Any()) return "No Solution Found.";

            return result.First().ToString();
        }
    }
}
