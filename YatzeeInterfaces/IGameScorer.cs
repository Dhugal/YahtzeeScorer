using System;

namespace YahtzeeInterfaces
{
    public interface IGameScorer
    {
        int CurrentScore { get; }
        int CalculateScore(string input);
    }
}
