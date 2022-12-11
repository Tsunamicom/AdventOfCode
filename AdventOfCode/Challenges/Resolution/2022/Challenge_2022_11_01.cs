using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_11_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 11;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var rounds = 20;
            var monkeys = ParseStartingMonkeys(data);

            for (int round = 0; round < rounds; round++)
            {
                for (int monkey = 0; monkey < monkeys.Count; monkey++)
                {
                    var itemCountStart = monkeys[monkey].HeldItemWorryLevels.Count;
                    for (int itemCnt = 0; itemCnt < itemCountStart; itemCnt++)
                    {
                        monkeys[monkey].inspectedItemsCount++;
                        var inspectedItem = monkeys[monkey].HeldItemWorryLevels.Dequeue();

                        //   Calculate new Worry Level by Monkey Operation.
                        var operation = monkeys[monkey].Operation.Replace("old", inspectedItem.ToString());
                        long worryItem = Compute(operation);

                        //   Monkey gets bored. Worrylevel = WorryLevel / 3  (rounded down)
                        worryItem /= 3;

                        //   Run Test
                        int worryItemThrowMonkey = worryItem % monkeys[monkey].TestDivisibleVal == 0
                            ? monkeys[monkey].TestTrueThrowMonkey
                            : monkeys[monkey].TestFalseThrowMonkey;

                        monkeys[worryItemThrowMonkey].HeldItemWorryLevels.Enqueue(worryItem);
                    }
                }
            }

            var topTwoActiveMonkeyScore = monkeys
                .Select(c => c.inspectedItemsCount)
                .OrderByDescending(c => c)
                .Take(2)
                .Aggregate((a, b) => a * b);

            return topTwoActiveMonkeyScore.ToString();
        }

        private class Monkey
        {
            internal long inspectedItemsCount = 0;
            internal Queue<long> HeldItemWorryLevels { get; set; } = new Queue<long>();
            internal string Operation { get; set; }
            internal int TestDivisibleVal { get; set; }
            internal int TestTrueThrowMonkey { get; set; }
            internal int TestFalseThrowMonkey { get; set; }
        }

        private long Compute(string operation)
        {
            var operationVals = operation.Split(' ');
            if (operationVals[1] == "*")
            {
                return long.Parse(operationVals[0]) * long.Parse(operationVals[2]);
            }
            if (operationVals[1] == "+")
            {
                return long.Parse(operationVals[0]) + long.Parse(operationVals[2]);
            }
            throw new InvalidOperationException($"{operationVals[1]} is not being handled via Compute.");
        }

        private List<Monkey> ParseStartingMonkeys(List<string> data)
        {
            var itemsStr = "  Starting items: ";
            var operationStr = "  Operation: new = ";
            var testStr = "  Test: divisible by ";
            var testTrueStr = "    If true: throw to monkey ";
            var testFalseStr = "    If false: throw to monkey ";

            List<Monkey> monkeys = new();

            var currentParseMonkey = new Monkey();
            foreach (var inspection in data)
            {
                if (string.IsNullOrEmpty(inspection))
                {
                    // Make Copy of Current Monkey
                    monkeys.Add(new Monkey()
                    {
                        HeldItemWorryLevels = new Queue<long>(currentParseMonkey.HeldItemWorryLevels),
                        Operation = currentParseMonkey.Operation,
                        TestDivisibleVal = currentParseMonkey.TestDivisibleVal,
                        TestTrueThrowMonkey = currentParseMonkey.TestTrueThrowMonkey,
                        TestFalseThrowMonkey = currentParseMonkey.TestFalseThrowMonkey
                    });

                    currentParseMonkey = new Monkey();
                    continue;
                }

                if (inspection.Contains(itemsStr))
                {
                    currentParseMonkey.HeldItemWorryLevels =
                        new Queue<long>(inspection
                        .Replace(itemsStr, null)
                        .Split(',')
                        .Select(c => long.Parse(c)));
                }
                else if (inspection.Contains(operationStr))
                {
                    currentParseMonkey.Operation = inspection.Replace(operationStr, null);
                }
                else if (inspection.Contains(testStr))
                {
                    currentParseMonkey.TestDivisibleVal = int.Parse(inspection.Replace(testStr, null));
                }
                else if (inspection.Contains(testTrueStr))
                {
                    currentParseMonkey.TestTrueThrowMonkey = int.Parse(inspection.Replace(testTrueStr, null));
                }
                else if (inspection.Contains(testFalseStr))
                {
                    currentParseMonkey.TestFalseThrowMonkey = int.Parse(inspection.Replace(testFalseStr, null));
                }
            }
            monkeys.Add(currentParseMonkey); // Add last monkey

            return monkeys;
        }
    }


}