using Refactoring_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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