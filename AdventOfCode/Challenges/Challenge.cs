using AdventOfCode.Challenges.Resolution;
using AdventOfCode.DataAccess;
using AdventOfCode.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges
{
    public class Challenge : IChallenge
    {
        readonly IDataAccess _dataSource;
        readonly IChallengeResolution _resolution;

        public Challenge(IDataAccess dataSource, IChallengeResolution resolution)
        {
            _dataSource = dataSource;
            _resolution = resolution;
        }

        public async Task<ChallengeResult> Resolve()
        {

            var result = new ChallengeResult()
            {
                ChallengeYear = _resolution.ChallengeYear,
                ChallengeDay = _resolution.ChallengeDay,
                ChallengePart = _resolution.ChallengePart
            };

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                var data = await _dataSource.GetTestFileDetails().ConfigureAwait(false);

                result.Result = _resolution.ResolveChallenge(data);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Result = ex.Message;
            }
            finally
            {
                stopWatch.Stop();
                result.ResolveTime = stopWatch.ElapsedMilliseconds;
            }

            return result;
        }
    }
}
