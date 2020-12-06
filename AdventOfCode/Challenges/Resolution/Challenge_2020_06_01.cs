using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_06_01 : IChallengeResolution
    {
        public int ChallengeDay => 6;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            data.Add(string.Empty);

            var answerSum = 0;
            var currentGroupAnswers = new HashSet<char>();
            
            foreach (var answers in data)
            {
                if (string.IsNullOrEmpty(answers))
                {
                    answerSum += currentGroupAnswers.Count;
                    currentGroupAnswers.Clear();
                }
                else
                {
                    foreach (var answer in answers)
                    {
                        currentGroupAnswers.Add(answer);
                    }
                }
            }

            return answerSum.ToString();
        }
    }
}
