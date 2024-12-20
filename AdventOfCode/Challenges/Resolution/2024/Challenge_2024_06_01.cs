using System;
using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_06_01 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 6;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            // "....#.....", | 
            // ".........#", |
            // "..........", |
            // "..#.......", |
            // ".......#..", |
            // "..........", x
            // ".#..^.....", |
            // "........#.", |
            // "#.........", |
            // "......#...", |
            // ----- y ----> V

            List<(int x, int y)> obstacles = [];
            HashSet<(int x, int y)> visited = []; // First will be current guard position

            // Assume ^ and UP at start with order UP, RIGHT, DOWN, LEFT
            List<(int x, int y)> guardMoveModifiers = [(-1, 0),(0, 1), (1, 0), (0, -1)];
            int guardMoveIdx = 0;
            (int x, int y) guardPosition = (0, 0);

            // Initial Parse
            for (int x = 0; x < data.Count; x++)
            {
                for (int y = 0; y < data[x].Length; y++)
                {
                    if (data[x][y] == '#')
                    { 
                        obstacles.Add((x, y)); 
                    }
                    if (data[x][y] == '^') 
                    { 
                        guardPosition = (x, y);
                    }
                }
            }

            (int x, int y) nextGuardPosition = (0, 0);
            // Determine points between guard and first point in that direction
            //  If no points in that direction, guard leaves and we calc distinct count
            while (nextGuardPosition.x >= 0
                && nextGuardPosition.x < data.Count
                && nextGuardPosition.y >= 0
                && nextGuardPosition.y < data[0].Length)
            {
                visited.Add(guardPosition);
                nextGuardPosition = (guardPosition.x + guardMoveModifiers[guardMoveIdx].x, guardPosition.y + guardMoveModifiers[guardMoveIdx].y);
                if (obstacles.Contains(nextGuardPosition)) 
                {
                    // Next Guard Position is an obstacle, so turn right
                    guardMoveIdx = (guardMoveIdx + 1) % guardMoveModifiers.Count;
                    nextGuardPosition = (guardPosition.x + guardMoveModifiers[guardMoveIdx].x, guardPosition.y + guardMoveModifiers[guardMoveIdx].y);
                }
                guardPosition = nextGuardPosition;
            }

            return visited.Count.ToString();
        }
    }
}
