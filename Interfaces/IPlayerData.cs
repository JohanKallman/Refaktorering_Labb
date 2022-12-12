using System;

namespace Refactoring_Lab.Interfaces
{
  public interface IPlayerData
  {
    string PlayerName { get; set; }
    int NumberOfGames { get; set; }
    int TotalGuesses { get; set; }
    void SetPlayerName();
    void UpdateTotalGuesses(int guesses);
    void UpdateNumberOfGames();
    double Average();
    bool Equals(Object p);
    int GetHashCode();

  }
}