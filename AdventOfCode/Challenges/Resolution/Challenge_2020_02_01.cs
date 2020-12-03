using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_02_01 : IChallengeResolution
    {
        public int ChallengeDay => 2;
        public int ChallengePart => 1;

        public async Task<string> ResolveChallenge(List<string> data)
        {
            var count = 0;

            await Task.Run(() => {
                foreach (var password in data)
                {
                    var splitPass = password.Replace(":", null).Split(' ');

                    var minMax = splitPass[0].Split('-');
                    var min = int.Parse(minMax[0]);
                    var max = int.Parse(minMax[1]);

                    var targetChar = char.Parse(splitPass[1]);

                    var actual = splitPass[2]
                        .ToList()
                        .Count(c => c == targetChar);

                    if (actual >= min && actual <= max) count++;
                }
            }).ConfigureAwait(false);

            return count.ToString();
        }

        
    }
}
