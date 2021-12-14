﻿using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution.Tests
{
    public partial class Challenge_Tests
    {
        private List<string> _TestData_2021_01 = new()
        {
            "199",
            "200",
            "208",
            "210",
            "200",
            "207",
            "240",
            "269",
            "260",
            "263"
        };

        private List<string> _TestData_2021_02 = new()
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };

        private List<string> _TestData_2021_03 = new()
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        private List<string> _TestData_2021_04 = new()
        {
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "",
            "22 13 17 11  0",
            " 8  2 23  4 24",
            "21  9 14 16  7",
            " 6 10  3 18  5",
            " 1 12 20 15 19",
            "",
            " 3 15  0  2 22",
            " 9 18 13 17  5",
            "19  8  7 25 23",
            "20 11 10 24  4",
            "14 21 16 12  6",
            "",
            "14 21 17 24  4",
            "10 16 15  9 19",
            "18  8 23 26 20",
            "22 11 13  6  5",
            " 2  0 12  3  7",
        };

        private List<string> _TestData_2021_05 = new()
        {
            "0,9  ->  5,9",
            "8,0  ->  0,8",
            "9,4  ->  3,4",
            "2,2  ->  2,1",
            "7,0  ->  7,4",
            "6,4  ->  2,0",
            "0,9  ->  2,9",
            "3,4  ->  1,4",
            "0,0  ->  8,8",
            "5,5  ->  8,2"
        };

        private List<string> _TestData_2021_06 = new()
        {
            "3,4,3,1,2"
        };

        private List<string> _TestData_2021_07 = new()
        {
            "16,1,2,0,4,2,7,1,2,14"
        };

        private List<string> _TestData_2021_08 = new()
        {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
        };

        private List<string> _TestData_2021_09 = new()
        {
            "2199943210",
            "3987894921",
            "9856789892",
            "8767896789",
            "9899965678"
        };

        private List<string> _TestData_2021_10 = new()
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]"
        };

        private List<string> _TestData_2021_11 = new()
        {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526"
        };

        private List<string> _TestData_2021_12_Mod1 = new()
        {
            "start-A",
            "start-b",
            "A-c",
            "A-b",
            "b-d",
            "A-end",
            "b-end",
        };

        private List<string> _TestData_2021_12_Mod2 = new()
        {
            "dc-end",
            "HN-start",
            "start-kj",
            "dc-start",
            "dc-HN",
            "LN-dc",
            "HN-end",
            "kj-sa",
            "kj-HN",
            "kj-dc"
        };

        private List<string> _TestData_2021_13 = new()
        {
            "6,10",
            "0,14",
            "9,10",
            "0,3",
            "10,4",
            "4,11",
            "6,0",
            "6,12",
            "4,1",
            "0,13",
            "10,12",
            "3,4",
            "3,0",
            "8,4",
            "1,10",
            "2,14",
            "8,10",
            "9,0",
            "",
            "fold along y=7",
            "fold along x=5"
        };

        private List<string> _TestData_2021_14 = new()
        {
            "NNCB",
            "",
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C",
        };

        private List<string> _TestData_2021_15 = new()
        {

        };

        private List<string> _TestData_2021_16 = new()
        {

        };

        private List<string> _TestData_2021_17 = new()
        {

        };

        private List<string> _TestData_2021_18 = new()
        {

        };

        private List<string> _TestData_2021_19 = new()
        {

        };

        private List<string> _TestData_2021_20 = new()
        {

        };

        private List<string> _TestData_2021_21 = new()
        {

        };

        private List<string> _TestData_2021_22 = new()
        {

        };

        private List<string> _TestData_2021_23 = new()
        {

        };

        private List<string> _TestData_2021_24 = new()
        {

        };

        private List<string> _TestData_2021_25 = new()
        {

        };
    }
}