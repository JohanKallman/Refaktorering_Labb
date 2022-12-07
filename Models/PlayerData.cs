using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using refactoring_labb2.Interfaces;

namespace Refaktorering_Labb.Models
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
