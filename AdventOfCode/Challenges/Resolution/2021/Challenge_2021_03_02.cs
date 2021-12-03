using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_03_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;

        public int ChallengeDay => 3;

        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            data.Sort();

            var o2 = GetRating(data, false);
            var co2 = GetRating(data, true);

            var o2Val = Convert.ToInt64(o2, 2);
            var co2Val = Convert.ToInt64(co2, 2);

            var powerConsumption = o2Val * co2Val;

            return powerConsumption.ToString();
        }

        /// <summary>
        /// Calculate the rating
        /// </summary>
        private static string GetRating(List<string> cpData, bool opposite)
        {
            var len = cpData.First().Length;

            for (int i = 0; i < len; i++)
            {
                if (cpData.Count > 1)
                {
                    int start;
                    int end;

                    int val = cpData.Count(c => c[i] == '0');

                    var isMostCommon = val > (cpData.Count / 2m);

                    if (isMostCommon ^= opposite)
                    {
                        start = 0;
                        end = val;
                    }
                    else
                    {
                        start = val;
                        end = cpData.Count - val;
                    };

                    cpData = cpData.GetRange(start, end);
                }
            }

            return cpData.Single();
        }
    }
}