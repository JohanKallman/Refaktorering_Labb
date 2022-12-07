using Refactoring_Lab.Interfaces;
using System;

namespace Refactoring_Lab.Models
{
    public class PlayerData : IPlayerData
  {
    public string PlayerName { get; private set; }

    public int NumberOfGames { get; private set; }

    int totalGuess;

    public PlayerData(string name, int guesses)
    {
      this.PlayerName = name;
      NumberOfGames = 1;
      totalGuess = guesses;
    }

    public PlayerData()
    {

    }

    public void Update(int guesses)
    {
      totalGuess += guesses;
      NumberOfGames++;
    }

    public double Average()
    {
      return (double)totalGuess / NumberOfGames;
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
