using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_12_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 12;
        public int ChallengePart => 1;

        //private string _alphaValWeights = "SabcdefghijklmnopqrstuvwxyzE";
        //long _minSteps = long.MaxValue;

        public string ResolveChallenge(List<string> data)
        {

            //var visited = new Dictionary<int, HashSet<int>>();

            //var distances = new Dictionary<(int, int), long>();

            //// Convert to integers
            //var elevations = data.Select(c => c.Select(r => _alphaValWeights.IndexOf(r)).ToList()).ToList();

            //var start = (0, 0);
            //var end = (2, 5);

            //var traversalQueue = new Queue<(int, int)>();
            //traversalQueue.Enqueue(start);

            //while (traversalQueue.Any())
            //{
            //    var currentPosition = traversalQueue.Dequeue();

            //    var currentValue = elevations[currentPosition.Item1][currentPosition.Item2];

            //    if (distances.ContainsKey(currentPosition) && distances[currentPosition] <= traversalQueue.Count()) continue;

            //    distances[currentPosition] = traversalQueue.Count();

            //    var upModifier = Math.Max(0, currentPosition.Item1 - 1);
            //    var downModifier = Math.Min(elevations.Count - 1, currentPosition.Item1 + 1);
            //    var leftModifier = Math.Max(0, currentPosition.Item2 - 1);
            //    var rightModifier = Math.Min(elevations[currentPosition.Item1].Count - 1, currentPosition.Item2 + 1);

            //    var nextPositions = new Queue<(int, int)>();

            //    if (currentValue <= elevations[currentPosition.Item1][rightModifier])
            //    {
            //        nextPositions.Enqueue((currentPosition.Item1, rightModifier));
            //    }

            //    if (currentValue <= elevations[downModifier][currentPosition.Item2])
            //    {
            //        nextPositions.Enqueue((downModifier, currentPosition.Item2));
            //    }

            //    if (currentValue <= elevations[upModifier][currentPosition.Item2])
            //    {
            //        nextPositions.Enqueue((upModifier, currentPosition.Item2));
            //    }

            //    if (currentValue <= elevations[currentPosition.Item1][leftModifier])
            //    {
            //        nextPositions.Enqueue((currentPosition.Item1, leftModifier));
            //    }

            //    if (nextPositions.Contains(end)) _minSteps = Math.Min(_minSteps, traversalQueue.Count);

            //    foreach (var position in nextPositions)
            //    {
            //        var currentPath = new Queue<(int, int)>(traversalQueue);
            //        currentPath.Enqueue(position);
            //        var x = new Dequeue
            //    }


            //}

            //WalkElevation(elevations, visited, (i, j), (i, j), 0);


            return "Not Implemented Yet";
        }

        //private long WalkElevation(List<List<int>> elevations, Dictionary<int, HashSet<int>> visited, (int, int) current, (int, int) last, long distance)
        //{

        //    if (current.Item1 != last.Item1 && current.Item2 != last.Item2)
        //    {
        //        if (elevations[current.Item1][current.Item2] - elevations[last.Item1][last.Item2] <= 1) return distance;
        //    }


        //    if (visited.TryGetValue(current.Item1, out var jHash))
        //    {
        //        if (jHash.Contains(current.Item2)) return distance;

        //        jHash.Add(current.Item2);
        //    }
        //    else
        //    {
        //        visited.Add(current.Item1, new HashSet<int>());
        //        visited[current.Item1].Add(current.Item2);
        //    }



        //    if (distance >= _minSteps)
        //        return distance;

        //    distance++;

        //    var currentElevation = elevations[current.Item1][current.Item2];
        //    Debug.WriteLine($"Current: {currentElevation}");
        //    if (currentElevation == 27)
        //    {
        //        _minSteps = Math.Min(_minSteps, distance);

        //        return _minSteps; // Found End (E)
        //    }

        //    var upModifier = Math.Max(0, current.Item1 - 1);
        //    var downModifier = Math.Min(elevations.Count - 1, current.Item1 + 1);
        //    var leftModifier = Math.Max(0, current.Item2 - 1);
        //    var rightModifier = Math.Min(elevations[current.Item1].Count - 1, current.Item2 + 1);

        //    WalkElevation(elevations, visited, (upModifier, current.Item2), (current.Item1, current.Item2), distance);
        //    WalkElevation(elevations, visited, (downModifier, current.Item2), (current.Item1, current.Item2), distance);
        //    WalkElevation(elevations, visited, (current.Item1, leftModifier), (current.Item1, current.Item2), distance);
        //    WalkElevation(elevations, visited, (current.Item1, rightModifier), (current.Item1, current.Item2), distance);

        //    return distance;
        //}
    }
}