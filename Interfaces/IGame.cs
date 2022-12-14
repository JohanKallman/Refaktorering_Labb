namespace Refactoring_Lab.Interfaces
{
    //Används ej för tillfället
    public interface IGame
    {
        string GameName { get; set; }
        string Rules { get; set; }
        int HighestRandomNumber { get; set; }
        int AmountOfIntegersInAnswer { get; set; }
        bool PlayerIsGuessing { get; set; }
        string CorrectAnswer { get; set; }
        int NumberOfGuesses { get; set; }
        string PlayerGuess { get; set; }
        string PlayerName { get; set; }


        void StartNewInstanceOfGame();
        string ReturnOutputAfterGuess(string inputGuess);
        bool CheckGameWinningCondition(string outputResult);
        bool CheckIfPlayAgain(string answer);
        bool CheckIfCorrectLengthFormat(string guess);
        bool CheckIfCorrectCharFormat(string guess);
        string PlayerGuesses();
        string PrepareRoundResult(string inputGuess);
        void ResetInstance();
    }
}