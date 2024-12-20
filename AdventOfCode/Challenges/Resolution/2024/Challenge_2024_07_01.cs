using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_07_01 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 7;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var eq = data.Select(e => e.Split(':', StringSplitOptions.RemoveEmptyEntries));
            var answers = eq.Select(e => long.Parse(e[0])).ToList();
            var values = eq.Select(e => e[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();

            long sum = 0;

            for (int i = 0; i < values.Count; i++)
            {
                long expectedAnswer = answers[i];
                var vals = values[i].Select(long.Parse).ToList();
                if (CheckSolution(vals, expectedAnswer, 0, 0)) sum += expectedAnswer;
            }
            
            return sum.ToString();
        }

        private bool CheckSolution(List<long> values, long expectedAnswer, int currentIdx, long currentAggregate)
        {
            if (currentIdx > values.Count) 
                return false;
            if (currentAggregate > expectedAnswer) 
                return false;
            if (values.Count == currentIdx) 
                return expectedAnswer == currentAggregate;

            return CheckSolution(values, expectedAnswer, currentIdx + 1, currentAggregate + values[currentIdx]) || CheckSolution(values, expectedAnswer, currentIdx + 1, currentAggregate * values[currentIdx]);
        }
    }
}
