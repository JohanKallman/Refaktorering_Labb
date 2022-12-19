using Refactoring_Lab.Models;

namespace Refactoring_Lab.Interfaces
{
    public interface IAnswerService
    {
        string CorrectAnswer { get; set; }
        int HighestRandomNumber { get; set; }
        int LowestRandomNumber { get; set; }
        int AmountOfIntegersInAnswer { get; set; }
        string GenerateCorrectAnswer(Game game);
    }
}