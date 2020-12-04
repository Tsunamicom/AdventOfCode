using AdventOfCode.Challenges;
using AdventOfCode.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Repository
{
    public class ChallengeResolver
    {
        readonly List<IChallenge> _challenges;

        public ChallengeResolver(List<IChallenge> challenges)
        {
            _challenges = challenges;
        }

        public async Task<List<ChallengeResult>> GetChallengeResults()
        {
            var challengeTasks = _challenges.Select(c => c.Resolve());

            var results = await Task.WhenAll(challengeTasks).ConfigureAwait(false);

            return results.ToList();
        }
    }
}
