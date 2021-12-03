using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_03_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;

        public int ChallengeDay => 3;

        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var gammaStr = new StringBuilder();

            var len = data.First().Length;

            for (int i = 0; i < len; i++)
            {
                var val = data.Count(c => c[i] == '0');
                gammaStr.Append(val > (data.Count / 2m) ? "0" : "1");
            }
            var gamma = Convert.ToInt64(gammaStr.ToString(), 2);

            var epsilonStr = gammaStr.ToString().Select(c => c == '0' ? '1' : '0');
            var epsilon = Convert.ToInt64(string.Concat(epsilonStr), 2);

            var powerConsumption = gamma * epsilon;

            return powerConsumption.ToString();
        }
    }
}