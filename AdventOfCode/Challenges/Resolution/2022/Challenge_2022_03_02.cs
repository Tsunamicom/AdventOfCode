using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_03_02 : IChallengeResolution
    {
        public int ChallengeYear => 2022;

        public int ChallengeDay => 3;

        public int ChallengePart => 2;

        string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string ResolveChallenge(List<string> data)
        {
            var prioritySum = 0;



            for (int i = 0; i < data.Count; i += 3)
            {
                var ruckSackOne = data[i].ToHashSet();
                var ruckSackTwo = data[i + 1].ToHashSet();
                var ruckSackThree = data[i + 2].ToHashSet();

                var similarValue = ruckSackOne
                    .Intersect(ruckSackTwo)
                    .Intersect(ruckSackThree).First();

                var priorityScore = alphabet.IndexOf(similarValue) + 1;
                prioritySum += priorityScore;
            }

            return prioritySum.ToString();
        }
    }
}