using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_06_02 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 6;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var datastream = data.Single();

            var lookBackCount = 14;

            var compareQueue = new Queue<char>();

            // Initialize Queue
            for (int i = 0; i < lookBackCount; i++)
            {
                compareQueue.Enqueue(datastream[i]);
            }

            for (int i = lookBackCount - 1; i < datastream.Length; i++)
            {
                if (compareQueue.Distinct().Count() == lookBackCount)
                    return (i + 1).ToString();

                compareQueue.Dequeue();
                compareQueue.Enqueue(datastream[i + 1]);
            }

            return "Not Found";
        }
    }
}