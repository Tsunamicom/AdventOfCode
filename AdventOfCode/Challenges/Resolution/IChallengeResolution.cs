using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution
{
    public interface IChallengeResolution
    {
        int ChallengeDay { get; }
        int ChallengePart { get; }

        Task<string> ResolveChallenge(List<string> data);
    }
}
