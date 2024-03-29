using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_07_02 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 7;
        public int ChallengePart => 2;

        private readonly Dictionary<char, int> _cardValues = new()
            {
                {'J', 1 },
                {'2', 2 },
                {'3', 3 },
                {'4', 4 },
                {'5', 5 },
                {'6', 6 },
                {'7', 7 },
                {'8', 8 },
                {'9', 9 },
                {'T', 10 },
                {'Q', 13 },
                {'K', 14 },
                {'A', 15 }
            };

        public string ResolveChallenge(List<string> data)
        {
            var camelCardHands = ParseCamelCardHands(data);

            var comparer = new CompareLikeHands(_cardValues);

            camelCardHands = camelCardHands
                .OrderBy(c => c.HandTypes.HandTypeRank)
                .ThenBy(c => c.Cards, comparer)
                .ThenBy(c => c.HandTypes.Value)
                .ThenBy(c => c.RawCardTotalValue - c.HandTypes.Value)
                .ToList();

            var totalWinnings = 0;
            for (int i = 0; i < camelCardHands.Count; i++)
            {
                totalWinnings += camelCardHands[i].Bid * (i + 1);
            }

            return $"{totalWinnings}";
        }

        private class CompareLikeHands : IComparer<List<char>>
        {
            private readonly Dictionary<char, int> _cardValues;
            public CompareLikeHands(Dictionary<char, int> cardValues)
            {
                _cardValues = cardValues;
            }
            public int Compare(List<char> x, List<char> y)
            {
                if (x.Count < y.Count) return -1;
                if (x.Count > y.Count) return 1;

                for (int i = 0; i < x.Count; i++)
                {
                    if (_cardValues[x[i]] == _cardValues[y[i]]) continue;
                    if (_cardValues[x[i]] < _cardValues[y[i]]) return -1;
                    if (_cardValues[x[i]] > _cardValues[y[i]]) return 1;
                }

                return 0;
            }
        }

        private List<Hand> ParseCamelCardHands(List<string> data)
        {
            var camelCards = new List<Hand>();
            foreach (var line in data)
            {
                var lineSplit = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                var hand = new Hand()
                {
                    Bid = int.Parse(lineSplit[1]),
                    Cards = lineSplit[0].Select(c => c).ToList()
                };
                hand.RawCardTotalValue = hand.Cards.Sum(c => _cardValues[c]);
                hand.HandTypes = FindHandTypes(hand);
                camelCards.Add(hand);
            }
            return camelCards;
        }

        private HandType FindHandTypes(Hand hand)
        {
            var one = hand.Cards.Distinct().Where(c => hand.Cards.Count(h => h == c && h != 'J') == 1).ToList();
            var two = hand.Cards.Distinct().Where(c => hand.Cards.Count(h => h == c && h != 'J') == 2).ToList();
            var three = hand.Cards.Distinct().Where(c => hand.Cards.Count(h => h == c && h != 'J') == 3).ToList();
            var four = hand.Cards.Distinct().Where(c => hand.Cards.Count(h => h == c && h != 'J') == 4).ToList();
            var five = hand.Cards.Distinct().Where(c => hand.Cards.Count(h => h == c) == 5).ToList();

            var Js = hand.Cards.Count(h => h == 'J');

            var handType = new HandType();

            if (five.Count > 0)
            {
                handType.HandTypeRank = HandTypeRank.FiveOfAKind;
                handType.Value = hand.Cards.Sum(c => _cardValues[c]);
                handType.Cards = hand.Cards.ToList();
                return handType;
            }

            if (four.Count == 1)
            {
                if (Js == 1)
                {
                    // Uprank due to Js
                    handType.HandTypeRank = HandTypeRank.FiveOfAKind;
                    handType.Value = _cardValues[four.First()] * 4 + _cardValues['J'];
                    handType.Cards = hand.Cards.Where(c => c == four.First() || c == 'J').ToList();
                    return handType;
                }

                handType.HandTypeRank = HandTypeRank.FourOfAKind;
                handType.Value = _cardValues[four.First()] * 4;
                handType.Cards = hand.Cards.Where(c => c == four.First()).ToList();
                return handType;

            }

            if (three.Count == 1 && two.Count == 0)
            {
                if (Js == 2)
                {
                    handType.HandTypeRank = HandTypeRank.FiveOfAKind; // Full House also an option, but J's count as base card and this is better
                    handType.Value = (_cardValues[three.First()] * 3) + (_cardValues['J'] * 2);
                    handType.Cards = hand.Cards.Where(c => c == three.First() || c == 'J').ToList();
                    return handType;
                }

                if (Js == 1)
                {
                    handType.HandTypeRank = HandTypeRank.FourOfAKind;
                    handType.Value = (_cardValues[three.First()] * 3) + _cardValues['J'];
                    handType.Cards = hand.Cards.Where(c => c == three.First() || c == 'J').ToList();
                    return handType;
                }


                handType.HandTypeRank = HandTypeRank.ThreeOfAKind;
                handType.Value = _cardValues[three.First()] * 3;
                handType.Cards = hand.Cards.Where(c => c == three.First()).ToList();
                return handType;

            }

            if (three.Count == 1 && two.Count == 1)
            {
                handType.HandTypeRank = HandTypeRank.FullHouse;
                handType.Value = (_cardValues[three.First()] * 3) + (_cardValues[two.First()] * 2);
                handType.Cards = hand.Cards.Where(c => c == three.First() || c == two.First()).ToList();
                return handType;
            }

            if (three.Count == 0 && two.Count == 1)
            {
                if (Js == 3)
                {
                    handType.HandTypeRank = HandTypeRank.FiveOfAKind;
                    handType.Value = (_cardValues[two.First()] * 2) + (_cardValues['J'] * 3);
                    handType.Cards = hand.Cards.Where(c => c == two.First() || c == 'J').ToList();
                    return handType;
                }

                if (Js == 2)
                {
                    handType.HandTypeRank = HandTypeRank.FourOfAKind;
                    handType.Value = (_cardValues[two.First()] * 2) + (_cardValues['J'] * 2);
                    handType.Cards = hand.Cards.Where(c => c == two.First() || c == 'J').ToList();
                    return handType;
                }

                if (Js == 1)
                {
                    handType.HandTypeRank = HandTypeRank.ThreeOfAKind;
                    handType.Value = (_cardValues[two.First()] * 2) + _cardValues['J'];
                    handType.Cards = hand.Cards.Where(c => c == two.First() || c == 'J').ToList();
                    return handType;
                }

                handType.HandTypeRank = HandTypeRank.OnePair;
                handType.Value = _cardValues[two.First()] * 2;
                handType.Cards = hand.Cards.Where(c => c == two.First()).ToList();
                return handType;
            }

            if (two.Count == 2)
            {
                if (Js == 1)
                {
                    handType.HandTypeRank = HandTypeRank.FullHouse;
                    handType.Value = (_cardValues[two.First()] * 2) + (_cardValues[two.Last()] * 2) + _cardValues['J'];
                    handType.Cards = [.. hand.Cards.Where(two.Contains).OrderBy(c => c)];
                    return handType;
                }

                handType.HandTypeRank = HandTypeRank.TwoPair;
                handType.Value = (_cardValues[two.First()] * 2) + (_cardValues[two.Last()] * 2);
                handType.Cards = [.. hand.Cards.Where(two.Contains).OrderBy(c => c)];
                return handType;
            }

            if (one.Count == 5 - Js)
            {
                if (Js == 4)
                {
                    handType.HandTypeRank = HandTypeRank.FiveOfAKind;
                    handType.Value = one.Max(c => _cardValues[c]);
                    handType.Cards = [_cardValues.Single(c => c.Value == handType.Value).Key];
                    handType.Cards.AddRange(Enumerable.Range(0, Js).Select(c => 'J'));
                    handType.Value += _cardValues['J'] * Js;
                    return handType;
                }

                if (Js == 3)
                {
                    handType.HandTypeRank = HandTypeRank.FourOfAKind;
                    handType.Value = one.Max(c => _cardValues[c]);
                    handType.Cards = [_cardValues.Single(c => c.Value == handType.Value).Key];
                    handType.Cards.AddRange(Enumerable.Range(0, Js).Select(c => 'J'));
                    handType.Value += _cardValues['J'] * Js;
                    return handType;
                }

                if (Js == 2)
                {
                    handType.HandTypeRank = HandTypeRank.ThreeOfAKind;
                    handType.Value = one.Max(c => _cardValues[c]);
                    handType.Cards = [_cardValues.Single(c => c.Value == handType.Value).Key];
                    handType.Cards.AddRange(Enumerable.Range(0, Js).Select(c => 'J'));
                    handType.Value += _cardValues['J'] * Js;
                    return handType;
                }

                if (Js == 1)
                {
                    handType.HandTypeRank = HandTypeRank.OnePair;
                    handType.Value = one.Max(c => _cardValues[c]);
                    handType.Cards = [_cardValues.Single(c => c.Value == handType.Value).Key];
                    handType.Cards.AddRange(Enumerable.Range(0, Js).Select(c => 'J'));
                    handType.Value += _cardValues['J'] * Js;
                    return handType;
                }

                handType.HandTypeRank = HandTypeRank.HighCard;
                handType.Value = one.Max(c => _cardValues[c]);
                handType.Cards = [_cardValues.Single(c => c.Value == handType.Value).Key];
                return handType;
            }
            throw new ArgumentException($"Unable to Parse HandType for Hand {string.Join(null, hand.Cards)}");
        }


        private class Hand
        {
            public int Bid { get; set; }

            public List<char> Cards { get; set; }

            public int RawCardTotalValue { get; set; }

            public HandType HandTypes { get; set; }

        }

        private class HandType
        {
            public List<char> Cards { get; set; }
            public HandTypeRank HandTypeRank { get; set; }
            public int Value { get; set; }
        }

        private enum HandTypeRank
        {
            HighCard = 1,
            OnePair = 2,
            TwoPair = 3,
            ThreeOfAKind = 4,
            FullHouse = 5,
            FourOfAKind = 6,
            FiveOfAKind = 7
        }
    }
}
