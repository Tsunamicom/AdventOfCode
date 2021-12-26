using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_25_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 25;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var initialState = data.Select(c => c.Select(c => c).ToList()).ToList();

            var step = 0;

            var currentState = MakeCopy(initialState); // make copy
            var height = currentState.Count;
            var length = currentState[0].Count;

            while (true)
            {

                var workingState = MakeCopy(currentState);

                step++;
                var totalStepMovement = 0;
                totalStepMovement += MoveRight(currentState, workingState, height, length);

                var newCurrentState = MakeCopy(workingState);
                totalStepMovement += MoveDown(newCurrentState, workingState, height, length);

                currentState = workingState;

                if (totalStepMovement == 0) break;
            }

            Debug.WriteLine($"Step: {step}");
            foreach (var line in currentState)
            {
                Debug.WriteLine(string.Concat(line));
            }

            return $"{step}";
        }

        private static int MoveRight(List<List<char>> currentState, List<List<char>> workingState, int height, int length)
        {
            var moveRightCount = 0;
            for (var x = 0; x < height; x++)
            {
                for (var y = 0; y < length; y++)
                {
                    if (currentState[x][y] != '>') continue;

                    var nextY = (y + 1) % length; // Go to next, but wrap to beginning
                    if (currentState[x][nextY] == '.')
                    {
                        // Can Move
                        moveRightCount++;
                        workingState[x][nextY] = '>';
                        workingState[x][y] = '.';
                    }
                }
            }

            return moveRightCount;
        }

        private static int MoveDown(List<List<char>> currentState, List<List<char>> workingState, int height, int length)
        {
            var moveDownCount = 0;
            for (var x = 0; x < height; x++)
            {
                for (var y = 0; y < length; y++)
                {
                    if (currentState[x][y] != 'v') continue;

                    var nextX = (x + 1) % height; // Go to next, but wrap to beginning
                    if (currentState[nextX][y] == '.')
                    {
                        // Can Move
                        moveDownCount++;
                        workingState[nextX][y] = 'v';
                        workingState[x][y] = '.';
                    }
                }
            }

            return moveDownCount;
        }

        private static List<List<char>> MakeCopy(List<List<char>> currentList)
        {
            var ret = new List<List<char>>();
            foreach (var item in currentList)
            {
                var row = new char[item.Count];
                item.CopyTo(row);
                ret.Add(row.ToList());
            }

            return ret;
        }

    }


}