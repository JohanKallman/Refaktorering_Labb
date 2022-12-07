using Refactoring_Lab.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Refactoring_Lab.Models
{
    public class Statistics : IStatistics
  {
    public void SaveGameResultToFile(string playerName, int numberOfGuesses)
    {
      StreamWriter output = new StreamWriter("result.txt", append: true);
      output.WriteLine(playerName + "#&#" + numberOfGuesses);
      output.Close();
    }

    public void DisplayTopList()
    {
      //string[] inputFile = File.ReadAllLines("reslut.txt");
      StreamReader input = new StreamReader("result.txt");

      List<PlayerData> results = new List<PlayerData>();
      string line;

      while ((line = input.ReadLine()) != null)
      {
        string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
        string name = nameAndScore[0];
        int guesses = Convert.ToInt32(nameAndScore[1]);
        PlayerData pd = new PlayerData(name, guesses);
        int pos = results.IndexOf(pd);

        if (pos < 0)
        {
          results.Add(pd);
        }
        else
        {
          results[pos].Update(guesses);
        }

      }
      results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
      Console.WriteLine("Player   games average");
      foreach (PlayerData p in results)
      {
        Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.PlayerName, p.NumberOfGames, p.Average()));
      }
      input.Close();
    }
  }
}