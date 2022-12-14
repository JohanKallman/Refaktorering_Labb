using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring_Lab.Models
{
    public class PlayerGuess
    {
        public string OutPutResult { get; set; }
        public bool PlayerIsGuessing { get; set; }
        public string Guess { get; set; }
        public int NumberOfGuesses { get; set; }
        public bool IsValidGuess { get; set; }
    }
}
