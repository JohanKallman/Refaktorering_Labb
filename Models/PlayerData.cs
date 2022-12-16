using Refactoring_Lab.Interfaces;
using System;

namespace Refactoring_Lab.Models
{
    public class PlayerData : IPlayerData
    {
        public string PlayerName { get; set; }
        public int NumberOfGames { get; set; }
        public int TotalGuesses { get; set; }

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

        public double Average()
        {
            return (double)TotalGuesses / NumberOfGames;
        }

        //KVAR
        public override bool Equals(Object p)
        {
            return PlayerName.Equals(((PlayerData)p).PlayerName);
        }

        //KVAR
        public override int GetHashCode()
        {
            return PlayerName.GetHashCode();
        }


    }
}
