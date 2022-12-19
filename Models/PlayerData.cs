using Refactoring_Lab.Interfaces;
using System;

namespace Refactoring_Lab.Models
{
    public class PlayerData : IPlayerData
    {
        public string PlayerName { get; set; }
        public int NumberOfGames { get; set; }
        public int TotalGuesses { get; set; }
        public PlayerData()
        {
        }
        public PlayerData(string name, int guesses)
        {
            PlayerName = name;
            NumberOfGames = 1;
            TotalGuesses = guesses;
        }

        public void SetPlayerName()
        {
            string inputName = Console.ReadLine();
            if (string.IsNullOrEmpty(inputName))
            {
                PlayerName = "No Name";
            }
            else PlayerName = inputName;
        }

        public void UpdateNumberOfGames()
        {
            NumberOfGames++;
        }

        public void UpdateTotalGuesses(int guesses)
        {
            TotalGuesses += guesses;
        }

        public double CalculateAverageScore()
        {
            return (double)TotalGuesses / NumberOfGames;
        }

        //=============================================
        // Since we create a new PlayerData to create data for the TopList,
        // we check if a player with that name already exist in the TopList.
        //-----------------------------------------
        public override bool Equals(Object obj)
        {
            return PlayerName.Equals(((PlayerData)obj).PlayerName);
        }

        public override int GetHashCode()
        {
            return PlayerName.GetHashCode();
        }
    }
}
