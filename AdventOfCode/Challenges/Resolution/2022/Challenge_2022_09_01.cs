using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_09_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 9;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var headPos = (0, 0);
            var tailPos = (0, 0);

            var tailVisited = new HashSet<(int, int)>() { tailPos }; // Init visited (starting counts)

            foreach (var moveCommand in data)
            {
                var moveDetails = moveCommand
                    .Split(' ')
                    .ToList();

                var distanceToTravel = int.Parse(moveDetails[1]);
                for (int move = 0; move < distanceToTravel; move++)
                {
                    var priorHeadPos = (headPos.Item1, headPos.Item2);

                    switch (moveDetails[0])
                    {
                        case "R":
                            {
                                headPos.Item1++;
                                break;
                            }
                        case "L":
                            {
                                headPos.Item1--;
                                break;
                            }
                        case "U":
                            {
                                headPos.Item2++;
                                break;
                            }
                        case "D":
                            {
                                headPos.Item2--;
                                break;
                            }
                    }

                    if (Math.Abs(tailPos.Item1 - headPos.Item1) > 1 ||
                        Math.Abs(tailPos.Item2 - headPos.Item2) > 1)
                    {
                        tailPos = priorHeadPos;
                        tailVisited.Add(tailPos);
                    }
                }
            }

            return tailVisited.Count().ToString();
        }
    }
}