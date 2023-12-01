using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_20_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 20;
        public int ChallengePart => 1;

        private class TrackableNode
        {
            internal int InitialId { get; set; }
            internal int Value { get; set; }
            //internal TrackableNode Next { get; set; }
            //internal TrackableNode Prev { get; set;}

            //internal void SetNext(TrackableNode next)
            //{
            //    Next = next;
            //    next.Prev = this;
            //}

            //internal void SetPrev(TrackableNode prev)
            //{
            //    Prev = prev;
            //    prev.Next = this;
            //}

            //internal void Unbind()
            //{
            //    Next.Prev = Prev;
            //    Prev.Next = Next;
            //}

            //internal void InsertBefore(TrackableNode beforeNode)
            //{

            //}
        }

        public string ResolveChallenge(List<string> data)
        {
            var initialFile = data.Select(int.Parse).ToList();
            var fileNodes = new List<TrackableNode>();

            // Initial arrangement:
            // 1, 2, -3, 3, -2, 0, 4
            // (..4 wraps)  <= 1 <= 2 <= -3 <= 3 <= -2 <= 0 <= 4

            // Parse as Nodes
            for (int i = 0; i < initialFile.Count; i++)
            {
                var currentNode = new TrackableNode()
                {
                    Value = initialFile[i],
                    InitialId = i
                };
                //var previousNode = fileNodes.LastOrDefault();
                //if (previousNode != null) currentNode.SetPrev(previousNode);

                //if (i == initialFile.Count - 1) currentNode.SetNext(fileNodes.First()); // Circular Node

                fileNodes.Add(currentNode);
            }

            for (int i = 0; i < fileNodes.Count; i++)
            {
                var currentNode = fileNodes.Single(c => c.InitialId == i);

                if (currentNode.Value != 0)
                {
                    var currentNodeIdx = fileNodes.IndexOf(currentNode);
                    var adjustedMoveOffset = currentNode.Value % fileNodes.Count;
                    var targetNodeIdx = currentNodeIdx + adjustedMoveOffset;

                    int multiplier = currentNodeIdx / fileNodes.Count;

                    targetNodeIdx = ((targetNodeIdx == 0 ? fileNodes.Count : targetNodeIdx) % fileNodes.Count) +
                        (adjustedMoveOffset / Math.Abs(adjustedMoveOffset));

                    if (targetNodeIdx < 0) targetNodeIdx += (fileNodes.Count);

                    if (currentNodeIdx > targetNodeIdx)
                    {
                        fileNodes.RemoveAt(currentNodeIdx);
                        fileNodes.Insert(targetNodeIdx, currentNode);
                    }
                    else
                    {
                        fileNodes.Insert(targetNodeIdx, currentNode);
                        fileNodes.RemoveAt(currentNodeIdx);
                    }
                }
            }


            var finalNodes = fileNodes.Select(c => c.Value).ToList();
            var zeroIndex = finalNodes.IndexOf(0);

            var oneThousandthVal = finalNodes[(zeroIndex + 1000) % finalNodes.Count];
            var twoThousandthVal = finalNodes[(zeroIndex + 2000) % finalNodes.Count];
            var threeThousandthVal = finalNodes[(zeroIndex + 3000) % finalNodes.Count];

            var finalSum = oneThousandthVal + twoThousandthVal + threeThousandthVal;

            return finalSum.ToString();
        }
    }
}