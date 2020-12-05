using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public interface IChallengeResolution
    {
        int ChallengeDay { get; }
        int ChallengePart { get; }

        string ResolveChallenge(List<string> data);
    }
}
