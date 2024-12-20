using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_06_02 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 6;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            // PASSES TESTS



            // Find count of possible obstacles where guard gets stuck in loop if we add a single obstacle
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

            // Assume ^ and UP at start with order UP, RIGHT, DOWN, LEFT
            List<(int x, int y)> guardMoveModifiers = [(-1, 0), (0, 1), (1, 0), (0, -1)];
            (int x, int y) guardPositionInit = (0, 0);

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
                        guardPositionInit = (x, y);
                    }
                }
            }

            var obstacleAddCount = 0;

            for (int x = 0; x < data.Count; x++)
            {
                for (int y = 0; y < data[x].Length; y++)
                {
                    int guardMoveIdx = 0;
                    (int x, int y) guardPosition = guardPositionInit;
                    List<((int x, int y) obstacle, (int x, int y) hitDirection)> obstacleHitDirections = [];
                    (int x, int y) nextGuardPosition = (0, 0);

                    if (data[x][y] == '.')
                    {
                        // Determine points between guard and first point in that direction
                        //  If no points in that direction, guard leaves and we calc distinct count

                        var newObstacles = obstacles.ToList();
                        newObstacles.Add((x, y));
                        // Debug.WriteLine($"Trying Location ({x},{y})");

                        while (nextGuardPosition.x >= 0
                            && nextGuardPosition.x < data.Count
                            && nextGuardPosition.y >= 0
                            && nextGuardPosition.y < data[0].Length)
                        {
                            nextGuardPosition = (guardPosition.x + guardMoveModifiers[guardMoveIdx].x, guardPosition.y + guardMoveModifiers[guardMoveIdx].y);
                            if (newObstacles.Contains(nextGuardPosition))
                            {
                                var obstacleHitDirection = (nextGuardPosition, guardMoveModifiers[guardMoveIdx]);
                                if (obstacleHitDirections.Contains(obstacleHitDirection))
                                {
                                    //Debug.WriteLine($"Found Location ({x},{y})");
                                    obstacleAddCount++;
                                    break; // We've hit this obstacle the same way
                                }

                                obstacleHitDirections.Add(obstacleHitDirection);
                                
                                // Next Guard Position is an obstacle, so turn right
                                guardMoveIdx = (guardMoveIdx + 1) % guardMoveModifiers.Count;
                                nextGuardPosition = (guardPosition.x + guardMoveModifiers[guardMoveIdx].x, guardPosition.y + guardMoveModifiers[guardMoveIdx].y);
                            }
                            guardPosition = nextGuardPosition;
                        }
                    }
                }
            }

            return obstacleAddCount.ToString();
        }
    }
}
