using System;
using System.Collections.Generic;
using System.Text;

namespace Scorer
{
    public class RoundInfo
    {
        public RoundInfo(int[] rolls, string category)
        {
            Rolls = rolls;
            Category = category;
        }

        public int[] Rolls { get; set; }
        public string Category { get; set; }
    }
}
