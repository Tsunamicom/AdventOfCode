using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_06_02 : IChallengeResolution
    {
        public int ChallengeDay => 6;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            data.Add(string.Empty);

            var answerSum = 0;
            var currentGroupAnswers = new Dictionary<char, int>();
            var currentGroupMembers = 0;

            foreach (var answers in data)
            {
                if (string.IsNullOrEmpty(answers))
                {
                    answerSum += currentGroupAnswers.Count(a => a.Value == currentGroupMembers);

                    currentGroupMembers = 0;
                    currentGroupAnswers.Clear();
                }
                else
                {
                    currentGroupMembers++;

                    foreach (var answer in answers)
                    {
                        if (currentGroupAnswers.ContainsKey(answer)) currentGroupAnswers[answer]++;
                        else currentGroupAnswers[answer] = 1;
                    }
                }
            }

            return answerSum.ToString();
        }
    }
}