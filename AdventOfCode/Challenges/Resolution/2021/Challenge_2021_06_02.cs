using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_06_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 6;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            const int daysObserved = 256;
            const int newFishLifeSpan = 8;
            const int reproduceCycleDays = 6;

            var lanternFishData = data
                .First()
                .Split(',')
                .Select(int.Parse)
                .ToList();

            // Initialize Day 0
            var fishSpawnDict = new Dictionary<int, long>();
            for (int i = 0; i <= newFishLifeSpan; i++)
            {
                fishSpawnDict[i] = lanternFishData.Count(c => c == i);
            }

            // Begin Observing each day
            for (int currentDay = 0; currentDay < daysObserved; currentDay++)
            {
                var currentDayFishSpawnDict = fishSpawnDict.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                foreach (var kvp in fishSpawnDict)
                {
                    if (kvp.Key != 0)
                    {
                        currentDayFishSpawnDict[kvp.Key - 1] = kvp.Value;
                    }
                }
                currentDayFishSpawnDict[reproduceCycleDays] += fishSpawnDict[0];
                currentDayFishSpawnDict[newFishLifeSpan] = fishSpawnDict[0];

                fishSpawnDict = currentDayFishSpawnDict;
            }

            return fishSpawnDict.Values.Sum().ToString();
        }
    }
}