using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_05_02 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 5;
        public int ChallengePart => 2;

        List<(long seedStart, long seedEnd)> _seedRanges = new();
        List<(long soilId, long seedId, long range)> _seedToSoil = new();
        List<(long fertId, long soilId, long range)> _soilToFert = new();
        List<(long waterId, long fertId, long range)> _fertToWater = new();
        List<(long lightId, long waterId, long range)> _waterToLight = new();
        List<(long tempId, long lightId, long range)> _lightToTemp = new();
        List<(long humId, long tempId, long range)> _tempToHum = new();
        List<(long locId, long humId, long range)> _humToLoc = new();

        public string ResolveChallenge(List<string> data)
        {
            ParseMapping(data);
            //var seedLocations = FindLocationsOfSeeds(_seedRanges);
            long minSeedLoc = 0; //seedLocations.Min().Item1;
            List<Task<long>> minSeedTasks = new();

            foreach (var seedRange in _seedRanges)
            {
                var t = Task.Run(() => FindLocationsOfSeeds(seedRange));
                minSeedTasks.Add(t);
            }

            Task.WhenAll(minSeedTasks).ConfigureAwait(false).GetAwaiter().GetResult();

            minSeedLoc = minSeedTasks.Select(c => c.Result).Min();


            return $"{minSeedLoc}";
        }



        private long FindMappedId(List<(long, long, long)> map, long matchId)
        {
            if (matchId == 0)
            {
                //throw new ArgumentException("matchId not expected to be zero.");
            }
            long mappedId = 0;
            var matchedMap = map
                .FirstOrDefault(c => (c.Item2 <= matchId) && (c.Item2 + c.Item3) >= matchId);
            mappedId = matchedMap is (0, 0, 0) ? matchId : matchedMap.Item1 + (matchId - matchedMap.Item2);

            return mappedId;
        }

        //private List<(long, long)> FindMappedIdOverlaps(List<(long dest, long source, long range)> mapVal, List<(long subMin, long subMax)> subjectRange)
        //{
        //    var mappedOverlaps = new List<(long, long)>();
        //    foreach(var range in subjectRange) 
        //    {
        //        var min = FindMappedId(mapVal, range.subMin);
        //        var max = FindMappedId(mapVal, range.subMax);

        //        mappedOverlaps.Add((min, max));
        //    }

        //    return mappedOverlaps;

        //    //var soilIds = FindMappedIdOverlaps(_seedToSoil, seeds);
        //    //var fertIds = FindMappedIdOverlaps(_soilToFert, soilIds);
        //    //var waterIds = FindMappedIdOverlaps(_fertToWater, fertIds);
        //    //var lightIds = FindMappedIdOverlaps(_waterToLight, waterIds);
        //    //var tempIds = FindMappedIdOverlaps(_lightToTemp, lightIds);
        //    //var humIds = FindMappedIdOverlaps(_tempToHum, tempIds);
        //    //var locIds = FindMappedIdOverlaps(_humToLoc, humIds);
        //}

        private long FindLocationsOfSeeds((long, long) seeds)
        {

            long minLoc = long.MaxValue;

            for (var seedId = seeds.Item1; seedId <= seeds.Item2; seedId++)
            {
                if (seedId % 10000000 == 0) Debug.WriteLine($"{seedId}: ({seeds.Item1},{seeds.Item2})");

                var soilId = FindMappedId(_seedToSoil, seedId);
                var fertId = FindMappedId(_soilToFert, soilId);
                var waterId = FindMappedId(_fertToWater, fertId);
                var lightId = FindMappedId(_waterToLight, waterId);
                var tempId = FindMappedId(_lightToTemp, lightId);
                var humId = FindMappedId(_tempToHum, tempId);
                var locId = FindMappedId(_humToLoc, humId);

                if (locId < minLoc)
                {
                    minLoc = locId;
                }
            }

            return minLoc;

        }

        private void ParseMapping(List<string> data)
        {
            var isParsingSeedToSoil = false;
            var isParsingSoilToFert = false;
            var isParsingFertToWater = false;
            var isParsingWaterToLight = false;
            var isParsingLightToTemp = false;
            var isParsingTempToHum = false;
            var isParsingHumToLoc = false;
            foreach (var line in data)
            {
                if (string.IsNullOrEmpty(line))
                {
                    // Reset Parse
                    isParsingSeedToSoil = false;
                    isParsingSoilToFert = false;
                    isParsingFertToWater = false;
                    isParsingWaterToLight = false;
                    isParsingLightToTemp = false;
                    isParsingTempToHum = false;
                    isParsingHumToLoc = false;
                    continue;
                };

                if (line.StartsWith("seeds:"))
                {
                    var seedsLoc = line
                        .Substring(6)
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse)
                        .ToList();

                    _seedRanges = seedsLoc
                        .Where((s, idx) => idx % 2 == 0)
                        .Select(c => (c, c + seedsLoc[seedsLoc.IndexOf(c) + 1]))
                        .OrderBy(s => s)
                        .ToList();

                    continue;
                }

                if (line.StartsWith("seed-")) { isParsingSeedToSoil = true; continue; }
                if (line.StartsWith("soil")) { isParsingSoilToFert = true; continue; }
                if (line.StartsWith("fert")) { isParsingFertToWater = true; continue; }
                if (line.StartsWith("water")) { isParsingWaterToLight = true; continue; }
                if (line.StartsWith("light")) { isParsingLightToTemp = true; continue; }
                if (line.StartsWith("temp")) { isParsingTempToHum = true; continue; }
                if (line.StartsWith("hum")) { isParsingHumToLoc = true; continue; }

                var splitLine = line.Split(' ').Select(long.Parse).ToList();

                if (isParsingSeedToSoil) { _seedToSoil.Add((splitLine[0], splitLine[1], splitLine[2])); continue; }
                if (isParsingSoilToFert) { _soilToFert.Add((splitLine[0], splitLine[1], splitLine[2])); continue; }
                if (isParsingFertToWater) { _fertToWater.Add((splitLine[0], splitLine[1], splitLine[2])); continue; }
                if (isParsingWaterToLight) { _waterToLight.Add((splitLine[0], splitLine[1], splitLine[2])); continue; }
                if (isParsingLightToTemp) { _lightToTemp.Add((splitLine[0], splitLine[1], splitLine[2])); continue; }
                if (isParsingTempToHum) { _tempToHum.Add((splitLine[0], splitLine[1], splitLine[2])); continue; }
                if (isParsingHumToLoc) { _humToLoc.Add((splitLine[0], splitLine[1], splitLine[2])); continue; }
            }
        }
    }
}
