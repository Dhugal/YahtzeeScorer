using System;
using System.Collections.Generic;
using System.Text;

namespace Scorer
{
    public class InputParser
    {
        public RoundInfo ParseInput(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input must be provided", nameof(input));
            }

            // Remove all irrelivant chars.
            input = input.Replace("(", string.Empty)
                         .Replace(")", string.Empty)
                         .Replace(",", string.Empty);

            // Split the input.
            var splitInput = input.Split(" ");

            // Ensure we have the expected number of element 
            // (6, conisting of 5 rolls and a category).
            if(splitInput.Length != 6)
            {
                throw new ArgumentException("Input does not contain the expected 5 rolls and a category.", nameof(input));
            }

            var parsedRolls = new int[5];

            // Attempt to parse each roll entry.
            for(var i = 0; i <= 4; i++)
            {
                if(!int.TryParse(splitInput[i], out var parsedRoll))
                {
                    throw new ArgumentException($"Roll at position {i} is not numeric.", nameof(input));
                }
                else
                {
                    parsedRolls[i] = parsedRoll;
                }
            }

            return new RoundInfo(parsedRolls, splitInput[splitInput.Length - 1]);



            if (input == "(1, 3, 1, 4, 3) ones")
            {
                return new RoundInfo(new int[] { 1, 3, 1, 4, 3 }, "ones");
            }
            else if(input == "(2, 1, 2, 4, 1) fullhouse")
            {
                return new RoundInfo(new int[] { 2, 1, 2, 4, 1 }, "fullhouse");
            }
            else if (input == "(3, 3, 3, 3, 3) threes")
            {
                return new RoundInfo(new int[] { 3, 3, 3, 3, 3 }, "threes");
            }
            throw new NotImplementedException();
        }
    }
}
