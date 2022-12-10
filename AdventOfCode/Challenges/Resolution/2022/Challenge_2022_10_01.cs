using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_10_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 10;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var cycles = ParseCycleDetails(data);

            var signalStrengthSum = cycles
                .Where(c => (c.Key % 40) - 20 == 0)
                .Sum(c => c.Key * c.Value);

            return signalStrengthSum.ToString();
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
    }
}