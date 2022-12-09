using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_09_02 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 9;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var rope = new List<(int, int)>();

            var ropeLength = 10; // Head + 9 Tail

            for (int r = 0; r < ropeLength; r++)
            {
                rope.Add((0, 0));
            }

            var tailVisited = new HashSet<(int, int)>() { (0, 0) }; // Init visited (starting counts)

            foreach (var moveCommand in data)
            {
                var moveDetails = moveCommand
                    .Split(' ')
                    .ToList();

                var distanceToTravel = int.Parse(moveDetails[1]);

                for (int move = 0; move < distanceToTravel; move++)
                {
                    var headPos2 = rope[0];

                    switch (moveDetails[0])
                    {
                        case "R":
                            {
                                headPos2.Item1++;
                                break;
                            }
                        case "L":
                            {
                                headPos2.Item1--;
                                break;
                            }
                        case "U":
                            {
                                headPos2.Item2++;
                                break;
                            }
                        case "D":
                            {
                                headPos2.Item2--;
                                break;
                            }
                    }
                    rope[0] = headPos2;

                    for (int t = 1; t < rope.Count; t++)
                    {
                        var headPos = rope[t - 1];
                        var tailPos = rope[t];

                        if (Math.Abs(tailPos.Item1 - headPos.Item1) > 1 &&
                            Math.Abs(tailPos.Item2 - headPos.Item2) > 1)
                        {
                            tailPos.Item1 = tailPos.Item1 + (headPos.Item1 - tailPos.Item1) / 2;
                            tailPos.Item2 = tailPos.Item2 + (headPos.Item2 - tailPos.Item2) / 2;
                        }
                        else
                        {
                            if (Math.Abs(tailPos.Item1 - headPos.Item1) > 1)
                            {
                                tailPos.Item1 = tailPos.Item1 + (headPos.Item1 - tailPos.Item1) / 2;
                                tailPos.Item2 = headPos.Item2;
                            }

                            if (Math.Abs(tailPos.Item2 - headPos.Item2) > 1)
                            {
                                tailPos.Item1 = headPos.Item1;
                                tailPos.Item2 = tailPos.Item2 + (headPos.Item2 - tailPos.Item2) / 2;
                            }
                        }

                        rope[t] = tailPos;

                        if (t == rope.Count - 1)
                            tailVisited.Add(tailPos);
                    }
                }
            }

            return tailVisited.Count().ToString();
        }
    }
}