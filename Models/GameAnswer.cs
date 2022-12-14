using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring_Lab.Interfaces;

namespace Refactoring_Lab.Models
{
  public class GameAnswer
  {
    public string CorrectAnswer { get; set; } = "";
    public int HighestRandomNumber { get; set; }
    public int LowestRandomNumber { get; set; }
    public int AmountOfIntegersInAnswer { get; set; }

    // public string GenerateCorrectAnswer()
    // {
    //   Random numberGenerator = new Random();
    //   string correctAnswer = "";
    //   while (correctAnswer.Length < AmountOfIntegersInAnswer)
    //   {
    //     int newNumber = numberGenerator.Next(LowestRandomNumber, HighestRandomNumber);
    //     correctAnswer = CheckIfUniqueNumberIsRequired(correctAnswer, newNumber);
    //   }
    //   return "4423";
    //   return correctAnswer;
    // }

    // // public virtual string CheckIfUniqueNumberIsRequired(string correctAnswer, int newNumber);


    // public virtual string CheckIfUniqueNumberIsRequired(string correctAnswer, int newNumber)
    // {
    //   if (!correctAnswer.Contains(newNumber.ToString()))
    //   {
    //     correctAnswer += newNumber.ToString();
    //   }

    //   return correctAnswer;
    // }
  }
}
