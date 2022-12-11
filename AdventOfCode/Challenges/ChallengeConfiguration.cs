﻿using AdventOfCode.Challenges.Resolution;
using AdventOfCode.DataAccess;
using System.Collections.Generic;

namespace AdventOfCode.Challenges
{
    public static class ChallengeConfiguration
    {
        public readonly static Dictionary<string, IChallenge> Challenges2020 = new Dictionary<string, IChallenge>()
        {
            //{ "2020-12-1-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day01.txt"), new Challenge_2020_01_01()) },
            //{ "2020-12-1-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day01.txt"), new Challenge_2020_01_02()) },
            //{ "2020-12-2-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day02.txt"), new Challenge_2020_02_01()) },
            //{ "2020-12-2-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day02.txt"), new Challenge_2020_02_02()) },
            //{ "2020-12-3-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day03.txt"), new Challenge_2020_03_01()) },
            //{ "2020-12-3-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day03.txt"), new Challenge_2020_03_02()) },
            //{ "2020-12-4-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day04.txt"), new Challenge_2020_04_01()) },
            //{ "2020-12-4-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day04.txt"), new Challenge_2020_04_02()) },
            //{ "2020-12-5-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day05.txt"), new Challenge_2020_05_01()) },
            //{ "2020-12-5-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day05.txt"), new Challenge_2020_05_02()) },
            //{ "2020-12-6-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day06.txt"), new Challenge_2020_06_01()) },
            //{ "2020-12-6-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day06.txt"), new Challenge_2020_06_02()) },
            //{ "2020-12-7-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day07.txt"), new Challenge_2020_07_01()) },
            //{ "2020-12-7-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day07.txt"), new Challenge_2020_07_02()) },
            //{ "2020-12-8-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day08.txt"), new Challenge_2020_08_01()) },
            //{ "2020-12-8-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day08.txt"), new Challenge_2020_08_02()) },
            //{ "2020-12-9-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day09.txt"), new Challenge_2020_09_01()) },
            //{ "2020-12-9-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day09.txt"), new Challenge_2020_09_02()) },
            //{"2020-12-10-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day10.txt"), new Challenge_2020_10_01()) },
            //{"2020-12-10-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day10.txt"), new Challenge_2020_10_02()) },
            //{"2020-12-11-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day11.txt"), new Challenge_2020_11_01()) },
            //{"2020-12-11-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day11.txt"), new Challenge_2020_11_02()) },
            //{"2020-12-12-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day12.txt"), new Challenge_2020_12_01()) },
            //{"2020-12-12-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day12.txt"), new Challenge_2020_12_02()) },
            //{"2020-12-13-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day13.txt"), new Challenge_2020_13_01()) },
            //{"2020-12-13-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day13.txt"), new Challenge_2020_13_02()) },
            //{"2020-12-14-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day14.txt"), new Challenge_2020_14_01()) },
            //{"2020-12-14-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day14.txt"), new Challenge_2020_14_02()) },
            //{"2020-12-15-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day15.txt"), new Challenge_2020_15_01()) },
            //{"2020-12-15-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day15.txt"), new Challenge_2020_15_02()) },
            //{"2020-12-16-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day16.txt"), new Challenge_2020_16_01()) },
            //{"2020-12-16-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day16.txt"), new Challenge_2020_16_02()) },
            //{"2020-12-17-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day17.txt"), new Challenge_2020_17_01()) },
            //{"2020-12-17-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day17.txt"), new Challenge_2020_17_02()) },
            //{"2020-12-18-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day18.txt"), new Challenge_2020_18_01()) },
            //{"2020-12-18-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day18.txt"), new Challenge_2020_18_02()) },
            //{"2020-12-19-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day19.txt"), new Challenge_2020_19_01()) },
            //{"2020-12-19-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day19.txt"), new Challenge_2020_19_02()) },
            //{"2020-12-20-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day20.txt"), new Challenge_2020_20_01()) },
            //{"2020-12-20-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day20.txt"), new Challenge_2020_20_02()) },
            //{"2020-12-21-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day21.txt"), new Challenge_2020_21_01()) },
            //{"2020-12-21-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day21.txt"), new Challenge_2020_21_02()) },
            //{"2020-12-22-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day22.txt"), new Challenge_2020_22_01()) },
            //{"2020-12-22-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day22.txt"), new Challenge_2020_22_02()) },
            //{"2020-12-23-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day23.txt"), new Challenge_2020_23_01()) },
            //{"2020-12-23-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day23.txt"), new Challenge_2020_23_02()) },
            //{"2020-12-24-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day24.txt"), new Challenge_2020_24_01()) },
            //{"2020-12-24-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day24.txt"), new Challenge_2020_24_02()) },
            //{"2020-12-25-1", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day25.txt"), new Challenge_2020_25_01()) },
            //{"2020-12-25-2", new Challenge(new LocalFileAccess(".\\Files\\2020\\Day25.txt"), new Challenge_2020_25_02()) },
        };

        public readonly static Dictionary<string, IChallenge> Challenges2021 = new Dictionary<string, IChallenge>()
        {
            //{ "2021-12-1-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day01.txt"), new Challenge_2021_01_01()) },
            //{ "2021-12-1-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day01.txt"), new Challenge_2021_01_02()) },
            //{ "2021-12-2-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day02.txt"), new Challenge_2021_02_01()) },
            //{ "2021-12-2-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day02.txt"), new Challenge_2021_02_02()) },
            //{ "2021-12-3-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day03.txt"), new Challenge_2021_03_01()) },
            //{ "2021-12-3-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day03.txt"), new Challenge_2021_03_02()) },
            //{ "2021-12-4-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day04.txt"), new Challenge_2021_04_01()) },
            //{ "2021-12-4-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day04.txt"), new Challenge_2021_04_02()) },
            //{ "2021-12-5-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day05.txt"), new Challenge_2021_05_01()) },
            //{ "2021-12-5-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day05.txt"), new Challenge_2021_05_02()) },
            //{ "2021-12-6-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day06.txt"), new Challenge_2021_06_01()) },
            //{ "2021-12-6-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day06.txt"), new Challenge_2021_06_02()) },
            //{ "2021-12-7-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day07.txt"), new Challenge_2021_07_01()) },
            //{ "2021-12-7-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day07.txt"), new Challenge_2021_07_02()) },
            //{ "2021-12-8-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day08.txt"), new Challenge_2021_08_01()) },
            //{ "2021-12-8-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day08.txt"), new Challenge_2021_08_02()) },
            //{ "2021-12-9-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day09.txt"), new Challenge_2021_09_01()) },
            //{ "2021-12-9-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day09.txt"), new Challenge_2021_09_02()) },
            //{"2021-12-10-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day10.txt"), new Challenge_2021_10_01()) },
            //{"2021-12-10-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day10.txt"), new Challenge_2021_10_02()) },
            //{"2021-12-11-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day11.txt"), new Challenge_2021_11_01()) },
            //{"2021-12-11-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day11.txt"), new Challenge_2021_11_02()) },
            //{"2021-12-12-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day12.txt"), new Challenge_2021_12_01()) },
            //{"2021-12-12-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day12.txt"), new Challenge_2021_12_02()) },
            //{"2021-12-13-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day13.txt"), new Challenge_2021_13_01()) },
            //{"2021-12-13-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day13.txt"), new Challenge_2021_13_02()) },
            //{"2021-12-14-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day14.txt"), new Challenge_2021_14_01()) },
            //{"2021-12-14-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day14.txt"), new Challenge_2021_14_02()) },
            //{"2021-12-15-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day15.txt"), new Challenge_2021_15_01()) },
            //{"2021-12-15-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day15.txt"), new Challenge_2021_15_02()) },
            //{"2021-12-16-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day16.txt"), new Challenge_2021_16_01()) },
            //{"2021-12-16-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day16.txt"), new Challenge_2021_16_02()) },
            //{"2021-12-17-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day17.txt"), new Challenge_2021_17_01()) },
            //{"2021-12-17-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day17.txt"), new Challenge_2021_17_02()) },
            //{"2021-12-18-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day18.txt"), new Challenge_2021_18_01()) },
            //{"2021-12-18-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day18.txt"), new Challenge_2021_18_02()) },
            //{"2021-12-19-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day19.txt"), new Challenge_2021_19_01()) },
            //{"2021-12-19-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day19.txt"), new Challenge_2021_19_02()) },
            //{"2021-12-20-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day20.txt"), new Challenge_2021_20_01()) },
            //{"2021-12-20-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day20.txt"), new Challenge_2021_20_02()) },
            //{"2021-12-21-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day21.txt"), new Challenge_2021_21_01()) },
            //{"2021-12-21-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day21.txt"), new Challenge_2021_21_02()) },
            //{"2021-12-22-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day22.txt"), new Challenge_2021_22_01()) },
            //{"2021-12-22-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day22.txt"), new Challenge_2021_22_02()) },
            //{"2021-12-23-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day23.txt"), new Challenge_2021_23_01()) },
            //{"2021-12-23-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day23.txt"), new Challenge_2021_23_02()) },
            //{"2021-12-24-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day24.txt"), new Challenge_2021_24_01()) },
            //{"2021-12-24-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day24.txt"), new Challenge_2021_24_02()) },
            //{"2021-12-25-1", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day25.txt"), new Challenge_2021_25_01()) },
            //{"2021-12-25-2", new Challenge(new LocalFileAccess(".\\Files\\2021\\Day25.txt"), new Challenge_2021_25_02()) },
        };

        public readonly static Dictionary<string, IChallenge> Challenges2022 = new Dictionary<string, IChallenge>()
        {
            //{ "2022-12-1-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day01.txt"), new Challenge_2022_01_01()) },
            //{ "2022-12-1-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day01.txt"), new Challenge_2022_01_02()) },
            //{ "2022-12-2-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day02.txt"), new Challenge_2022_02_01()) },
            //{ "2022-12-2-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day02.txt"), new Challenge_2022_02_02()) },
            //{ "2022-12-3-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day03.txt"), new Challenge_2022_03_01()) },
            //{ "2022-12-3-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day03.txt"), new Challenge_2022_03_02()) },
            //{ "2022-12-4-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day04.txt"), new Challenge_2022_04_01()) },
            //{ "2022-12-4-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day04.txt"), new Challenge_2022_04_02()) },
            //{ "2022-12-5-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day05.txt"), new Challenge_2022_05_01()) },
            //{ "2022-12-5-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day05.txt"), new Challenge_2022_05_02()) },
            //{ "2022-12-6-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day06.txt"), new Challenge_2022_06_01()) },
            //{ "2022-12-6-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day06.txt"), new Challenge_2022_06_02()) },
            //{ "2022-12-7-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day07.txt"), new Challenge_2022_07_01()) },
            //{ "2022-12-7-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day07.txt"), new Challenge_2022_07_02()) },
            //{ "2022-12-8-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day08.txt"), new Challenge_2022_08_01()) },
            //{ "2022-12-8-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day08.txt"), new Challenge_2022_08_02()) },
            //{ "2022-12-9-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day09.txt"), new Challenge_2022_09_01()) },
            //{ "2022-12-9-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day09.txt"), new Challenge_2022_09_02()) },
            //{"2022-12-10-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day10.txt"), new Challenge_2022_10_01()) },
            //{"2022-12-10-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day10.txt"), new Challenge_2022_10_02()) },
            {"2022-12-11-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day11.txt"), new Challenge_2022_11_01()) },
            {"2022-12-11-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day11.txt"), new Challenge_2022_11_02()) },
            //{"2022-12-12-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day12.txt"), new Challenge_2022_12_01()) },
            //{"2022-12-12-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day12.txt"), new Challenge_2022_12_02()) },
            //{"2022-12-13-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day13.txt"), new Challenge_2022_13_01()) },
            //{"2022-12-13-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day13.txt"), new Challenge_2022_13_02()) },
            //{"2022-12-14-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day14.txt"), new Challenge_2022_14_01()) },
            //{"2022-12-14-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day14.txt"), new Challenge_2022_14_02()) },
            //{"2022-12-15-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day15.txt"), new Challenge_2022_15_01()) },
            //{"2022-12-15-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day15.txt"), new Challenge_2022_15_02()) },
            //{"2022-12-16-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day16.txt"), new Challenge_2022_16_01()) },
            //{"2022-12-16-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day16.txt"), new Challenge_2022_16_02()) },
            //{"2022-12-17-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day17.txt"), new Challenge_2022_17_01()) },
            //{"2022-12-17-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day17.txt"), new Challenge_2022_17_02()) },
            //{"2022-12-18-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day18.txt"), new Challenge_2022_18_01()) },
            //{"2022-12-18-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day18.txt"), new Challenge_2022_18_02()) },
            //{"2022-12-19-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day19.txt"), new Challenge_2022_19_01()) },
            //{"2022-12-19-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day19.txt"), new Challenge_2022_19_02()) },
            //{"2022-12-20-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day20.txt"), new Challenge_2022_20_01()) },
            //{"2022-12-20-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day20.txt"), new Challenge_2022_20_02()) },
            //{"2022-12-21-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day21.txt"), new Challenge_2022_21_01()) },
            //{"2022-12-21-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day21.txt"), new Challenge_2022_21_02()) },
            //{"2022-12-22-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day22.txt"), new Challenge_2022_22_01()) },
            //{"2022-12-22-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day22.txt"), new Challenge_2022_22_02()) },
            //{"2022-12-23-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day23.txt"), new Challenge_2022_23_01()) },
            //{"2022-12-23-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day23.txt"), new Challenge_2022_23_02()) },
            //{"2022-12-24-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day24.txt"), new Challenge_2022_24_01()) },
            //{"2022-12-24-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day24.txt"), new Challenge_2022_24_02()) },
            //{"2022-12-25-1", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day25.txt"), new Challenge_2022_25_01()) },
            //{"2022-12-25-2", new Challenge(new LocalFileAccess(".\\Files\\2022\\Day25.txt"), new Challenge_2022_25_02()) },
        };
    }
}
