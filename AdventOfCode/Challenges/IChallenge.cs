using AdventOfCode.Models;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges
{
    public interface IChallenge
    {
        Task<ChallengeResult> Resolve();
    }
}
