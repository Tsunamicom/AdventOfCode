using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_08_01 : IChallengeResolution
    {
        public int ChallengeDay => 8;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var accumulator = 0;
            var idxSeen = new HashSet<int>();
            var currentIdx = 0;

            while (!idxSeen.Contains(currentIdx))
            {
                idxSeen.Add(currentIdx);

                var commandSet = data[currentIdx].Split(' ');
                var commandVal = int.Parse(commandSet[1]);

                switch (commandSet[0])
                {
                    case "acc":
                        {
                            accumulator += commandVal;
                            currentIdx++;
                            break;
                        }
                    case "jmp":
                        {
                            currentIdx += commandVal;
                            break;
                        }
                    case "nop":
                        {
                            currentIdx++;
                            break;
                        }
                }
            }

            return accumulator.ToString();
        }


    }
}