namespace Refactoring_Lab.Interfaces
{
    public interface IStatistics
  {
    void SaveGameResultToFile(string playerName, int numberOfGuesses, string topListData);
    string CreateSortedTopList();
  }
}