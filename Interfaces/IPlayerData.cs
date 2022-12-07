using System;

namespace Refactoring_Lab.Interfaces
{
    public interface IPlayerData
  {
    void Update(int guesses);
    double Average();
    bool Equals(Object p);
    int GetHashCode();

  }
}