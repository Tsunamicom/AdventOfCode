﻿using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution.Tests
{
    public partial class Challenge_Tests
    {
        private List<string> _TestData_2023_01_01 = new()
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };

        private List<string> _TestData_2023_01_02 = new()
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };

        private List<string> _TestData_2023_02 = new()
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };

        private List<string> _TestData_2023_03 = new()
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };

        private List<string> _TestData_2023_04 = new()
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };

        private List<string> _TestData_2023_05 = new()
        {
            "seeds: 79 14 55 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
            "",
            "soil-to-fertilizer map:",
            "0 15 37",
            "37 52 2",
            "39 0 15",
            "",
            "fertilizer-to-water map:",
            "49 53 8",
            "0 11 42",
            "42 0 7",
            "57 7 4",
            "",
            "water-to-light map:",
            "88 18 7",
            "18 25 70",
            "",
            "light-to-temperature map:",
            "45 77 23",
            "81 45 19",
            "68 64 13",
            "",
            "temperature-to-humidity map:",
            "0 69 1",
            "1 0 69",
            "",
            "humidity-to-location map:",
            "60 56 37",
            "56 93 4",
        };

        private List<string> _TestData_2023_06 = new()
        {
            "Time:      7  15   30",
            "Distance:  9  40  200"
        };

        private List<string> _TestData_2023_07 = new()
        {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"
        };

        private List<string> _TestData_2023_08_01 = new()
        {
            "LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)",
        };

        private List<string> _TestData_2023_08_02 = new()
        {
            "LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)",
        };

        private List<string> _TestData_2023_09 = new()
        {
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45",
        };

        private List<string> _TestData_2023_10_01_01 = new()
        {
            ".....",
            ".S-7.",
            ".|.|.",
            ".L-J.",
            "....."
        };

        private List<string> _TestData_2023_10_01_02 = new()
        {
            "..F7.",
            ".FJ|.",
            "SJ.L7",
            "|F--J",
            "LJ..."
        };

        private List<string> _TestData_2023_11 = new()
        {
            "...#......",
            ".......#..",
            "#.........",
            "..........",
            "......#...",
            ".#........",
            ".........#",
            "..........",
            ".......#..",
            "#...#....."
        };

        private List<string> _TestData_2023_12 = new()
        {
            "???.### 1,1,3",
            ".??..??...?##. 1,1,3",
            "?#?#?#?#?#?#?#? 1,3,1,6",
            "????.#...#... 4,1,1",
            "????.######..#####. 1,6,5",
            "?###???????? 3,2,1"
        };

        private List<string> _TestData_2023_13 = new()
        {

        };

        private List<string> _TestData_2023_14 = new()
        {

        };

        private List<string> _TestData_2023_15 = new()
        {

        };

        private List<string> _TestData_2023_16 = new()
        {

        };

        private List<string> _TestData_2023_17 = new()
        {

        };

        private List<string> _TestData_2023_18 = new()
        {

        };

        private List<string> _TestData_2023_19 = new()
        {

        };

        private List<string> _TestData_2023_20 = new()
        {

        };

        private List<string> _TestData_2023_21 = new()
        {

        };

        private List<string> _TestData_2023_22 = new()
        {

        };

        private List<string> _TestData_2023_23 = new()
        {

        };

        private List<string> _TestData_2023_24 = new()
        {

        };

        private List<string> _TestData_2023_25 = new()
        {

        };
    }
}