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
        readonly bool _enabled;
        readonly IDataAccess _dataSource;
        readonly IChallengeResolution _resolution;

        public Challenge(IDataAccess dataSource, IChallengeResolution resolution, bool enabled)
        {
            _dataSource = dataSource;
            _resolution = resolution;
            _enabled = enabled;
        }

        public async Task<ChallengeResult> Resolve()
        {

            var result = new ChallengeResult()
            {
                ChallengeDay = _resolution.ChallengeDay,
                ChallengePart = _resolution.ChallengePart
            };

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                if (!_enabled)
                {
                    throw new Exception("Challenge is Disabled.");
                }

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
