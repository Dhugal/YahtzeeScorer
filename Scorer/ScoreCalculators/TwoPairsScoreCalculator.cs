using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YahtzeeInterfaces;

namespace Scorer.ScoreCalculators
{
    public class TwoPairsScoreCalculator : IScoreCalculator
    {
        public int CalculateScore(int[] rolls)
        {
            // Group up the rolls.
            // Group the rolls up and ensure we have two.
            var groupedRolls = new Dictionary<int, int>();
            for (var i = 0; i < rolls.Length; i++)
            {
                var roll = rolls[i];
                if (groupedRolls.ContainsKey(roll))
                {
                    groupedRolls[roll] += 1;
                }
                else
                {
                    groupedRolls.Add(roll, 1);
                }
            }

            // Do we have two pairs?
            var pairs = groupedRolls.Where(r => r.Value >= 2);
            if(pairs.Count() < 2)
            {
                return 0;
            }
            // What's the value of these pairs.
            return pairs.Sum(r => r.Key * 2);
        }
    }
}
