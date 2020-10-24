using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YahtzeeInterfaces;

namespace Scorer.ScoreCalculators
{
    public class NumberMatchScoreCalculator : IScoreCalculator
    {
        private readonly int _target;

        public NumberMatchScoreCalculator(int target)
        {
            _target = target;
        }

        public int CalculateScore(int[] rolls)
        {
            return rolls.Where(r => r == _target).Sum();
        }
    }
}
