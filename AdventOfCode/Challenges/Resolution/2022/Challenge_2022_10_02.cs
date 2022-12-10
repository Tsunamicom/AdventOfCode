using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_10_02 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 10;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var screenWidth = 40;

            var cycles = ParseCycleDetails(data);
            var screenPopulation = PopulateScreen(cycles, screenWidth);

            // Debug output for visibility
            foreach (var line in screenPopulation)
            {
                Debug.WriteLine(line);
            }

            return string.Join(',', screenPopulation);
        }

        internal Dictionary<int, int> ParseCycleDetails(List<string> data)
        {
            var cycles = new Dictionary<int, int>();
            var register = 1;
            var cycle = 0;

            foreach (var instruction in data)
            {
                var instructions = instruction.Split(' ').ToList();

                var registerMod = 0;
                if (instructions[0] == "addx")
                {
                    cycle++;
                    cycles.Add(cycle, register);

                    registerMod = int.Parse(instructions[1]);
                }
                cycle++;
                cycles.Add(cycle, register);
                register += registerMod;
            }
            return cycles;
        }

        internal List<string> PopulateScreen(Dictionary<int, int> cycles, int screenWidth)
        {
            var screenPopulation = new List<string>();

            var screenLineSb = new StringBuilder();
            for (int i = 1; i < cycles.Count + 1; i++)
            {
                var cycleValue = cycles[i];
                var comparedIndex = (i - 1) % screenWidth;

                var pixel = new[] { cycleValue - 1, cycleValue, cycleValue + 1 }
                .Contains(comparedIndex)
                    ? '#'
                    : '.';
                screenLineSb.Append(pixel);

                if (comparedIndex == screenWidth - 1)
                {
                    screenPopulation.Add(screenLineSb.ToString());
                    screenLineSb.Clear();
                }
            }

            return screenPopulation;
        }
    }



}