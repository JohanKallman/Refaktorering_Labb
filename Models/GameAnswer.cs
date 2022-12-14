using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring_Lab.Models
{
    public class GameAnswer
    {
        public string CorrectAnswer { get; set; } = "";
        public int HighestRandomNumber { get; set; }
        public int LowestRandomNumber { get; set; }
        public int AmountOfIntegersInAnswer { get; set; }
    }
}
