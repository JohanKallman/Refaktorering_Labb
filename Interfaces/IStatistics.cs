using Refactoring_Lab.Models;

namespace Refactoring_Lab.Interfaces
{
    public interface IStatistics
    {
        void SaveGameResultToFile(string playerName, int numberOfGuesses, string gameName);
        string CreateSortedTopList(string gameName);
        void CreateDataForTopList(string gameName);
        PlayerData CreatePlayerWithNameAndScore(string[] playerNameAndScore);
        bool CheckIfPlayerExists(int playerIndex);
        void UpdatePlayerData(int playerIndex, PlayerData player);
    }
}