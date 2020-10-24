using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YahtzeeInterfaces;

namespace Scorer.ScoreCalculators
{
    public class FullHouseScoreCalculator : IScoreCalculator
    {
        public int CalculateScore(int[] rolls)
        {
            // Group the rolls up and ensure we have two.
            var groupedRolls = new Dictionary<int, int>();
            for(var i = 0; i < rolls.Length; i++)
            {
                var roll = rolls[i];
                if(groupedRolls.ContainsKey(roll))
                {
                    groupedRolls[roll] += 1;
                }
                else
                {
                    groupedRolls.Add(roll, 1);
                }
            }
            // We only have a full house if we have two distinct numbers and
            // one was rolled twice and the other was rolled 3 times.
            if(groupedRolls.Count() != 2 || !groupedRolls.Any(r => r.Value == 2) || !groupedRolls.Any(r => r.Value == 3))
            {
                return 0;
            }

            return rolls.Sum();
        }
    }
}
