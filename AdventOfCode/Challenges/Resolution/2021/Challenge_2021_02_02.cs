using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_02_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;

        public int ChallengeDay => 2;

        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var depthPos = 0;
            var horizontalPos = 0;
            var aim = 0;

            foreach (var command in data)
            {
                var commandSet = command.Split(' ');
                _ = int.TryParse(commandSet[1], out var adjustmentVal);

                switch (commandSet[0])
                {
                    case "forward":
                        horizontalPos += adjustmentVal;
                        depthPos += adjustmentVal * aim;
                        break;

                    case "up":
                        aim -= adjustmentVal;
                        break;

                    case "down":
                        aim += adjustmentVal;
                        break;

                    default:
                        break;
                }
            }

            var result = depthPos * horizontalPos;

            return result.ToString();
        }
    }
}