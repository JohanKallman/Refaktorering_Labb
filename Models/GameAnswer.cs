using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_Lab.Interfaces;

namespace Refactoring_Lab.Models
{
  public class GameAnswer : IAnswerService
  {
    public string CorrectAnswer { get; set; } = "";
    public int HighestRandomNumber { get; set; }
    public int LowestRandomNumber { get; set; }
    public int AmountOfIntegersInAnswer { get; set; }

        public string GenerateCorrectAnswer(Game game)
        {
            Random numberGenerator = new Random();
            string correctAnswer = "";
            while (correctAnswer.Length < AmountOfIntegersInAnswer)
            {
                int newNumber = numberGenerator.Next(LowestRandomNumber, HighestRandomNumber);
                correctAnswer = game.CheckIfUniqueNumberIsRequired(correctAnswer, newNumber);
            }
            //return "3423";
            return correctAnswer;
        }

    }
}
