using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public interface IChallengeResolution
    {
        int ChallengeYear { get; }
        int ChallengeDay { get; }
        int ChallengePart { get; }

        string ResolveChallenge(List<string> data);
    }
}
