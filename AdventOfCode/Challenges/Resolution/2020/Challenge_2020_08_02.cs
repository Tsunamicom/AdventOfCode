using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_08_02 : IChallengeResolution
    {
        public int ChallengeYear => 2020;
        public int ChallengeDay => 8;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var idxFlipped = new HashSet<int>();

            while (true)
            {
                var accumulator = 0;
                var idxSeen = new HashSet<int>();
                var currentIdx = 0;
                var isFlipped = false;

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
                                if (!isFlipped && !idxFlipped.Contains(currentIdx))
                                {
                                    idxFlipped.Add(currentIdx);
                                    isFlipped = true;

                                    currentIdx++;
                                }
                                else
                                {
                                    currentIdx += commandVal;
                                }
                                break;
                            }
                        case "nop":
                            {
                                if (!isFlipped && !idxFlipped.Contains(currentIdx))
                                {
                                    idxFlipped.Add(currentIdx);
                                    isFlipped = true;

                                    currentIdx += commandVal;
                                }
                                else
                                {
                                    currentIdx++;
                                }
                                break;
                            }
                    }
                    if (currentIdx >= data.Count) return accumulator.ToString();
                }
            }
        }
    }
}