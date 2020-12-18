using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_10_01 : IChallengeResolution
    {
        public int ChallengeDay => 10;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var orderedAdapters = GetOrderedAdapters(data);

            var oneJolt = 0;
            var threeJolt = 0;

            for (int i = 1; i < orderedAdapters.Count(); i++)
            {
                var diff = orderedAdapters[i] - orderedAdapters[i - 1];
                if (diff == 1) oneJolt++;
                if (diff == 3) threeJolt++;
            }
            
            return (oneJolt * threeJolt).ToString();
        }

        /// <summary>
        /// Returns a list of ordered adapters with both the input and output device voltages added
        /// </summary>
        public List<int> GetOrderedAdapters(List<string> adapters)
        {
            adapters.Add("0"); // Add the input voltage

            var orderedAdapters = adapters
                .Select(int.Parse)
                .OrderBy(a => a)
                .ToList();

            orderedAdapters.Add(orderedAdapters.LastOrDefault() + 3); // Add the load device voltage

            return orderedAdapters;
        }
    }
}