using Scorer;
using System;
using YahtzeeInterfaces;

namespace ExampleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Probably want to introduce some DI here.
            IGameScorer scorer = new GameScorer();
            var input1 = "(1, 3, 1, 4, 3) ones";
            var input2 = "(2, 1, 2, 4, 1) fullhouse";
            var input3 = "(3, 3, 3, 3, 3) threes";

            
            var lastRoundScore = scorer.CalculateScore(input1);
            Console.WriteLine($"Round 1: {input1} = {lastRoundScore}. Current Score = {scorer.CurrentScore}");

            lastRoundScore = scorer.CalculateScore(input2);
            Console.WriteLine($"Round 2: {input2} = {lastRoundScore}. Current Score = {scorer.CurrentScore}");

            lastRoundScore = scorer.CalculateScore(input3);
            Console.WriteLine($"Round 3: {input3} = {lastRoundScore}. Current Score = {scorer.CurrentScore}");

            Console.ReadLine();
        }
    }
}
