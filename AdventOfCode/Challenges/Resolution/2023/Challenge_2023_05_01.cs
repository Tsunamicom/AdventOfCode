using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_05_01 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 5;
        public int ChallengePart => 1;

        List<long> _seedsLoc = new();
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

            var minSeedLoc = _seedsLoc.Min(FindLocationOfSeed);

            return $"{minSeedLoc}";
        }

        private long FindMappedId(List<(long, long, long)> map, long matchId)
        {
            long mappedId = 0;
            var matchedMap = map
                .FirstOrDefault(c => (c.Item2 <= matchId) && (c.Item2 + c.Item3) >= matchId);
            mappedId = matchedMap is (0, 0, 0) ? matchId : matchedMap.Item1 + (matchId - matchedMap.Item2);

            return mappedId;
        }

        private long FindLocationOfSeed(long seedId)
        {
            var soilId = FindMappedId(_seedToSoil, seedId);
            var fertId = FindMappedId(_soilToFert, soilId);
            var waterId = FindMappedId(_fertToWater, fertId);
            var lightId = FindMappedId(_waterToLight, waterId);
            var tempId = FindMappedId(_lightToTemp, lightId);
            var humId = FindMappedId(_tempToHum, tempId);
            var locId = FindMappedId(_humToLoc, humId);

            return locId;
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
                    _seedsLoc = line
                        .Substring(6)
                        .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse)
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
