using Refactoring_Lab.Interfaces;
using System;

namespace Refactoring_Lab.Models
{
    public class PlayerData : IPlayerData
    {
        public string PlayerName { get; set; }

        public int NumberOfGames { get; set; }
        public int TotalGuesses { get; set; }

        //int totalGuess;

        public PlayerData(string name, int guesses)
        {
            PlayerName = name;
            NumberOfGames = 1;
            TotalGuesses = guesses;
        }

        public PlayerData()
        {

        }

        public void SetPlayerName()
        {
            PlayerName = Console.ReadLine();

        }

        public void Update(int guesses)
        {
            TotalGuesses += guesses;
            NumberOfGames++;
        }

        public double Average()
        {
            return (double)TotalGuesses / NumberOfGames;
        }

        public override bool Equals(Object p)
        {
            return PlayerName.Equals(((PlayerData)p).PlayerName);
        }

        public override int GetHashCode()
        {
            return PlayerName.GetHashCode();
        }

    }
}
