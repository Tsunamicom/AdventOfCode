using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_24_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 24;
        public int ChallengePart => 1;

        private class Instruction
        {
            public string Action { get; set; }
            public char Variable { get; set; }
            public char? ActionVariable { get; set; }
            public long? ActionIntValue { get; set; }

            public Instruction(string instructionLine)
            {
                var ins = instructionLine.Split(' ');
                Action = ins[0];
                Variable = ins[1][0]; // Expected to be char

                if (ins.Length > 2) // Get non INP
                {
                    // Could be variable or int
                    if (int.TryParse(ins[2], out var val))
                    {
                        ActionIntValue = val;
                    }
                    else
                    {
                        ActionVariable = ins[2][0];
                    }
                }
            }

            public Instruction(Instruction instruction)
            {
                Action = instruction.Action;
                Variable = instruction.Variable;
                ActionVariable = instruction.ActionVariable;
                ActionIntValue = instruction.ActionIntValue;
            }
        }

        private IEnumerator<string> NumberGenerator(bool descending)
        {
            var validValues = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (descending) validValues = validValues.OrderByDescending(x => x).ToHashSet();

            while (true)
            {
                foreach (var v1 in validValues)
                    foreach (var v2 in validValues)
                        foreach (var v3 in validValues)
                            foreach (var v4 in validValues)
                                foreach (var v5 in validValues)
                                    foreach (var v6 in validValues)
                                        foreach (var v7 in validValues)
                                            foreach (var v8 in validValues)
                                                foreach (var v9 in validValues)
                                                    foreach (var v10 in validValues)
                                                        foreach (var v11 in validValues)
                                                            foreach (var v12 in validValues)
                                                                foreach (var v13 in validValues)
                                                                    foreach (var v14 in validValues)
                                                                        yield return $"{v1}{v2}{v3}{v4}{v5}{v6}{v7}{v8}{v9}{v10}{v11}{v12}{v13}{v14}";
            }
        }

        public string ResolveChallenge(List<string> data)
        {
            var instructionsAll = data.Select(c => new Instruction(c)).ToList();

            

            var numGen = NumberGenerator(descending: true);

            //while (true)
            //{
            //    numGen.MoveNext();
            //    if (numGen.Current == "11111111111111") break;
            //}

            var hasBeenFound = false;
            while (!hasBeenFound)
            {
                numGen.MoveNext();

                var newInstructions = GetModifiedInstructions(instructionsAll, numGen.Current);
                var instructionModifiedZValue = GetInstructionModifiedValue(newInstructions);

                hasBeenFound = instructionModifiedZValue == 0;

                if (long.Parse(numGen.Current) % 9999 == 0) Console.WriteLine($"{numGen.Current}: {instructionModifiedZValue}");
            }

            var modelNumber = numGen.Current;

            return $"{modelNumber}";
        }

        private List<Instruction> GetModifiedInstructions(List<Instruction> instructions, string generatedNumber)
        {
            var workingInstructions = instructions.Select(c => new Instruction(c)).ToList();

            var inpInstructions = workingInstructions.Where(c => c.Action == "inp");
            for (int i = 0; i < inpInstructions.Count(); i++)
            {
                inpInstructions.ElementAt(i).ActionIntValue = int.Parse(generatedNumber[i].ToString());
            }

            return workingInstructions.ToList();
        }

        private long GetInstructionModifiedValue(List<Instruction> instructions)
        {
            var variableValueDictionary = new Dictionary<char, long>()
            {
                { 'w', 0 },
                { 'x', 0 },
                { 'y', 0 },
                { 'z', 0 }
            };

            foreach (var instruction in instructions)
            {
                var instructionActionValue = GetInstructionActionValue(variableValueDictionary, instruction);

                switch (instruction.Action)
                {
                    case "inp":
                        {
                            variableValueDictionary[instruction.Variable] = instructionActionValue;
                            break;
                        }
                    case "add":
                        {
                            variableValueDictionary[instruction.Variable] += instructionActionValue;
                            break;
                        }
                    case "mod":
                        {
                            if (variableValueDictionary[instruction.Variable] > 0 || instructionActionValue <= 0) return -1;
                            variableValueDictionary[instruction.Variable] %= instructionActionValue;
                            break;
                        }
                    case "div":
                        {
                            if(instructionActionValue == 0) return -1;
                            variableValueDictionary[instruction.Variable] /= instructionActionValue;
                            break;
                        }
                    case "mul":
                        {
                            variableValueDictionary[instruction.Variable] *= instructionActionValue;
                            break;
                        }
                    case "eql":
                        {
                            variableValueDictionary[instruction.Variable] =
                                instructionActionValue == variableValueDictionary[instruction.Variable] ? 1 : 0;
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException($"Unhandled Instruction Action: {instruction.Action}");
                        }

                        
                }
                if (variableValueDictionary['z'] > 10000) return -1;
            }
            return variableValueDictionary['z'];
        }

        private long GetInstructionActionValue(Dictionary<char, long> variableValueDictionary, Instruction currentInstruction)
        {
            if (currentInstruction.ActionVariable != null)
            {
                var actionVar = (char)currentInstruction.ActionVariable;
                if (variableValueDictionary.ContainsKey(actionVar))
                {
                    return variableValueDictionary[actionVar];
                }
                throw new InvalidOperationException($"VariableValueDictionary is expecting to have a value for the ActionVariable: {actionVar}.");
            }
            else
            {
                if (currentInstruction.ActionIntValue.HasValue)
                {
                    return (int)currentInstruction.ActionIntValue;
                }
                throw new InvalidOperationException("Instruction must have an ActionIntValue.");
            }
        }

        private static List<Instruction> GetInstructions(List<string> data)
        {
            return data.Select(c => new Instruction(c)).ToList();
        }

        //private static List<List<Instruction>> GetInstructions(List<string> data)
        //{
        //    var instructions = new List<List<Instruction>>();

        //    var currentInstructionList = new List<Instruction>();
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        var currentInstruction = new Instruction(data[i]);
        //        if (currentInstructionList.Any() && currentInstruction.Action == "inp")
        //        {
        //            // Add the current instruction set to the list and start a new instruction set.
        //            var listToAdd = new Instruction[currentInstructionList.Count];
        //            currentInstructionList.CopyTo(listToAdd);
        //            instructions.Add(listToAdd.ToList());
        //            currentInstructionList.Clear();
        //        }
        //        currentInstructionList.Add(currentInstruction);
        //    }

        //    instructions.Add(currentInstructionList); // Get the last one

        //    return instructions;
        //}


    }
}