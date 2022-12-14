using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refactoring_Lab.Interfaces
{
  public interface IAnswerService
  {
    string CheckIfUniqueNumberIsRequired(string correctAnswer, int newNumber);
  }
}