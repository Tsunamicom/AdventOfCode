using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_22_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 22;
        public int ChallengePart => 1;

        readonly Dictionary<(int, int, int), int> _cuboids = new();

        public string ResolveChallenge(List<string> data)
        {
            var (xLow, xHigh, yLow, yHigh, zLow, zHigh) = (-50, 50, -50, 50, -50, 50);

            for (int i = 0; i < data.Count; i++)
            {
                var line = data[i].Replace("x=", null).Replace("y=", null).Replace("z=", null);
                var instruction = line.Split(' ');

                var toggle = instruction[0]; // on / off

                var positions = instruction[1].Split(','); // x=1..3,y=1..3,z=1..3

                var xPositions = positions[0].Split("..").Select(int.Parse).ToList();
                var yPositions = positions[1].Split("..").Select(int.Parse).ToList();
                var zPositions = positions[2].Split("..").Select(int.Parse).ToList();

                var startX = Math.Max(xPositions[0], xLow);
                var startY = Math.Max(yPositions[0], yLow);
                var startZ = Math.Max(zPositions[0], zLow);
                var endX = Math.Min(xPositions[1], xHigh);
                var endY = Math.Min(yPositions[1], yHigh);
                var endZ = Math.Min(zPositions[1], zHigh);

                int isOn = instruction[0] == "on" ? 1 : 0;

                for (int x = startX; x <= endX; x++)
                {
                    for (int y = startY; y <= endY; y++)
                    {
                        for (int z = startZ; z <= endZ; z++)
                        {
                            _cuboids[(x, y, z)] = isOn;
                        }
                    }
                }
            }

            return $"{_cuboids.Values.Sum()}";
        }
    }
}