using Refactoring_Lab.Models;
using System.Runtime.InteropServices.ComTypes;

namespace Refactoring_Lab.Interfaces
{
    public interface IStatistics
    {
        void SaveGameResultToFile(string playerName, int numberOfGuesses, string gameName, string fileName);
        string CreateTopList(string gameName, string fileName);
        string SortTopListData();
        void CreateDataForTopList(string gameName, string fileName);
        PlayerData CreatePlayerWithNameAndScore(string[] playerData);
        bool CheckIfPlayerExists(int playerIndex);
        void UpdatePlayerData(int playerIndex, PlayerData player);
    }
}