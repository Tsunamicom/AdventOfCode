using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_02_02 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 2;
        public int ChallengePart => 2;

        enum Hand
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        public string ResolveChallenge(List<string> data)
        {
            var rounds = data.Select(x => x.Split(' '));

            var handValues = new Dictionary<string, Hand>
            {
                {"A", Hand.Rock },
                {"B", Hand.Paper },
                {"C", Hand.Scissors }
            };

            // Hand, Hand that beats it
            var winningHands = new Dictionary<Hand, Hand>
            {
                {Hand.Scissors, Hand.Rock },
                {Hand.Rock, Hand.Paper },
                {Hand.Paper, Hand.Scissors },
            };

            var totalScore = 0;

            foreach (var round in rounds)
            {
                var win = false;
                var lose = false;
                var myHandValue = int.MinValue;

                var opponentsDecision = handValues[round[0]];
                var myDecision = round[1];


                // Lose
                if (myDecision == "X")
                {
                    lose = true;
                    myHandValue = (int)winningHands.Keys.FirstOrDefault(c => winningHands[c] == opponentsDecision);
                }

                else if (myDecision == "Y")
                {
                    myHandValue = (int)opponentsDecision;
                }

                else if (myDecision == "Z")
                {
                    win = true;
                    myHandValue = (int)winningHands[opponentsDecision];
                }

                var handScore = myHandValue + (win ? 6 : lose ? 0 : 3);
                totalScore += handScore;
            }

            return totalScore.ToString();
        }
    }
}