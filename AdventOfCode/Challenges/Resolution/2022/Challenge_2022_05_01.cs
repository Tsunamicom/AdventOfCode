using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_05_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 5;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var boxPositions = new List<Stack<char>>();
            var isReorganizedBoxStack = false;

            foreach (var stackInstruction in data)
            {
                if (stackInstruction.StartsWith("move"))
                {
                    if (!isReorganizedBoxStack)
                    {
                        // Stacks were loaded in reverse order, so reverse the stacks
                        boxPositions = boxPositions.Select(c => new Stack<char>(c)).ToList();
                        isReorganizedBoxStack = true;
                    }

                    // Handle Move Instruction, assume boxPositions are properly initialized.
                    var instruction = stackInstruction.Split(' ');
                    var moveCount = int.Parse(instruction[1]);
                    var moveFromPosition = int.Parse(instruction[3]) - 1;
                    var moveToPosition = int.Parse(instruction[5]) - 1;

                    for (int move = 0; move < moveCount; move++)
                    {
                        var boxToMove = boxPositions[moveFromPosition].Pop();
                        boxPositions[moveToPosition].Push(boxToMove);
                    }
                }
                else
                {
                    // Parse initial box position
                    for (int i = 0; i < stackInstruction.Length; i++)
                    {
                        if (char.IsLetter(stackInstruction[i]))
                        {
                            // This represents a box
                            var stackPosition = i / 4;  // int
                            var box = stackInstruction[i];

                            // Ensure boxPositions has the approproate number of parse locations
                            if (boxPositions.Count < stackPosition + 1)
                            {
                                // We need to add more potential positions to boxPositions.
                                var stacksToAdd = (stackPosition - boxPositions.Count);
                                for (int addPosCnt = 0; addPosCnt <= stacksToAdd; addPosCnt++)
                                {
                                    boxPositions.Add(new Stack<char>());
                                }
                            }

                            boxPositions[stackPosition].Push(box);
                        }
                    }
                }

            }

            // Get final Top Box Positions
            var boxPositionStr = string.Concat(boxPositions.Select(c => c.Peek()));

            return boxPositionStr;
        }
    }
}
