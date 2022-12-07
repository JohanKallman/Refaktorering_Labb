using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactoring_labb2.Interfaces
{
  public interface IStatistics
  {
    void SaveGameResultToFile(string playerName, int numberOfGuesses);
    void DisplayTopList();
  }
}