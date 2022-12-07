namespace Refactoring_Lab.Interfaces
{
    public interface IStatistics
  {
    void SaveGameResultToFile(string playerName, int numberOfGuesses);
    void DisplayTopList();
  }
}