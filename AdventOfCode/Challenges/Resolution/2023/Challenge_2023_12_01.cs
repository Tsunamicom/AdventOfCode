using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_12_01 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 12;
        public int ChallengePart => 1;

        private readonly List<char> _possibleValidSprings = ['.', '#'];

        public string ResolveChallenge(List<string> data)
        {
            long totalScore = 0;
            foreach (var line in data)
            {
                var (springs, dmgCounts) = GetSpringsAndDamageCounts(line);

                Dictionary<(int springPos, int dmgCntPos, int brokenLen), long> foundArrangements = [];

                (int springPos, int dmgCntPos, int brokenLen) currentArrangement = (0, 0, 0);

                var lineScore = CheckSpringArrangementsPossibilities(springs, dmgCounts, ref foundArrangements, currentArrangement);

                totalScore += lineScore;
            }

            return $"{totalScore}";
        }

        private long CheckSpringArrangementsPossibilities(
            List<char> springs, 
            List<int> dmgCounts,
            ref Dictionary<(int springPos, int dmgCntPos, int brokenLen), long> foundArrangements,
            (int springPos, int dmgCntPos, int brokenLen) currentArrangement)
        {
            // Return Cached Value for this arrangement if we've seen it already
            if(foundArrangements.TryGetValue(currentArrangement, out long value)) return value;

            // Check if we're at the end of the spring positions to assess whether we can add a valid value to the dictionary
            if (currentArrangement.springPos == springs.Count)
            {
                // We're at the end of the damage counts AND we're also not within a set of broken values
                if (currentArrangement.dmgCntPos == dmgCounts.Count
                    && currentArrangement.brokenLen == 0)
                {
                    return 1; // Add to the count
                }

                // We're at the last Damage Count value, and we've found that it's last position matches the last position length
                if (currentArrangement.dmgCntPos == dmgCounts.Count - 1
                    && dmgCounts[currentArrangement.dmgCntPos] == currentArrangement.brokenLen)
                {
                    return 1; // Add to the count
                } 

                // We didn't get to the end
                return 0;
            }

            long validPossibilities = 0;
            foreach (var spring in _possibleValidSprings)
            {
                var currentSpring = springs[currentArrangement.springPos];
                
                if (currentSpring == spring || currentSpring == '?')
                {
                    if (spring == '.')
                    {
                        if (currentArrangement.brokenLen == 0)
                        {
                            // We're not within a broken segment, so keep going assuming we're attempting to add a '.'
                            validPossibilities += CheckSpringArrangementsPossibilities(
                                springs,
                                dmgCounts,
                                ref foundArrangements,
                                (currentArrangement.springPos + 1, currentArrangement.dmgCntPos, 0));
                        }
                        else if (currentArrangement.brokenLen > 0
                                && currentArrangement.dmgCntPos < dmgCounts.Count
                                && dmgCounts[currentArrangement.dmgCntPos] == currentArrangement.brokenLen)
                        {
                            // We're within a broken segment,
                            // We did find a potential match for the currently assessed damaged number
                            // So keep going assuming we're attempting to add a '.'
                            validPossibilities += CheckSpringArrangementsPossibilities(
                                springs,
                                dmgCounts,
                                ref foundArrangements,
                                (currentArrangement.springPos + 1, currentArrangement.dmgCntPos + 1, 0));
                        }
                        // else do nothing
                    }

                    if (spring == '#')
                    {
                        // We're going to attempt to add a '#' here and say that the broken length has increased,
                        // and later compare that with the currently assessed string of broken characters
                        validPossibilities += CheckSpringArrangementsPossibilities(
                            springs,
                            dmgCounts,
                            ref foundArrangements,
                            (currentArrangement.springPos + 1, currentArrangement.dmgCntPos, currentArrangement.brokenLen + 1));
                    }
                    // else do nothing
                }
            }

            // For this arrangement, store the valid possibilities
            foundArrangements[currentArrangement] = validPossibilities;
            return validPossibilities;
        }


        private (List<char> springs, List<int> dmgCounts) GetSpringsAndDamageCounts(string springLine)
        {
            var springsAndDmged = springLine
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            var springs = springsAndDmged[0]
                .ToCharArray()
                .ToList();

            var dmgCounts = springsAndDmged[1]
                .Split(',', System.StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            return (springs, dmgCounts);
        }
    }
}
