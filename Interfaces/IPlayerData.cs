using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactoring_labb2.Interfaces
{
  public interface IPlayerData
  {
    void Update(int guesses);
    double Average();
    bool Equals(Object p);
    int GetHashCode();

  }
}