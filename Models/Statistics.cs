using Refactoring_Lab.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Refactoring_Lab.Models
{
  public class Statistics : IStatistics
  {
    //PlayerData _playerData = new PlayerData();

    public void SaveGameResultToFile(string playerName, int numberOfGuesses)
    {
      StreamWriter resultOutput = new StreamWriter("result.txt", append: true);
      resultOutput.WriteLine(playerName + "#&#" + numberOfGuesses);
      resultOutput.Close();
    }


    public void DisplayTopList()
    {
      //Read game result from file
      StreamReader resultInput = new StreamReader("result.txt");

      List<PlayerData> playerResults = new List<PlayerData>();
      string line;

      while ((line = resultInput.ReadLine()) != null)
      {
        string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
        string name = nameAndScore[0];
        int guesses = Convert.ToInt32(nameAndScore[1]);
        PlayerData pd = new PlayerData(name, guesses);
        int pos = playerResults.IndexOf(pd);

        if (pos < 0)
        {
          playerResults.Add(pd);
        }
        else
        {
          playerResults[pos].UpdateTotalGuesses(guesses);
          playerResults[pos].UpdateNumberOfGames();
        }

      }
      playerResults.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
      Console.WriteLine("Player   games average");
      foreach (PlayerData p in playerResults)
      {
        Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.PlayerName, p.NumberOfGames, p.Average()));
      }
      Console.WriteLine();
      resultInput.Close();
    }

    // public void UpdatePlayerData(int guesses)
    // {
    //   results[pos].UpdateTotalGuesses(guesses);
    //   results[pos].UpdateNumberOfGames();
    // }
  }
}