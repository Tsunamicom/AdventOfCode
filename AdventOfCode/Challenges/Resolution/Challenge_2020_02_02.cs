using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_02_02 : IChallengeResolution
    {
        public int ChallengeDay => 2;
        public int ChallengePart => 2;

        public async Task<string> ResolveChallenge(List<string> data)
        {
            var count = 0;

            await Task.Run(() => {
                foreach (var password in data)
                {
                    var splitPass = password.Replace(":", null).Split(' ');

                    var positions = splitPass[0].Split('-');
                    var firstPosIdx = int.Parse(positions[0]) - 1;
                    var secondPosIdx = int.Parse(positions[1]) - 1;

                    var targetChar = char.Parse(splitPass[1]);

                    var focusCount = $"{splitPass[2][firstPosIdx]}{splitPass[2][secondPosIdx]}"
                        .ToList()
                        .Count(c => c == targetChar) == 1;

                    if (focusCount) count++;
                }
            }).ConfigureAwait(false);

            

            return count.ToString();
        }

        
    }
}
