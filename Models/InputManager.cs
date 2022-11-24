using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refaktorering_Labb.Models
{
    public static class InputManager
    {
        public static bool ValidateInputGuess(string guess)
        {
            int numberOfAllowedCharachters = 4;
            if (guess.Length == numberOfAllowedCharachters)
            {
                return true;
            }
            return false;
        } 
    }
}
