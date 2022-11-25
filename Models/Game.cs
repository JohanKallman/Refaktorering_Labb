using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Refaktorering_Labb.Models
{
    public class Game
    {
        public bool IsRunning { get; set; } = true;

        public void RunGame()
        {
            string name = Console.ReadLine();

            while (IsRunning)
            {
                //Parameter number cannot be greater than 10 since all numbers in the correct answer are unique
                string correctAnswer = GenerateCorrectAnswer(4);
                int numberOfGuesses = 0;
                bool playerGuessedCorrect = false;
                Console.WriteLine("New game:\n");
                Console.WriteLine("For practice, number is: " + correctAnswer + "\n");

                while (playerGuessedCorrect == false)
                {
                    string inputGuess = Console.ReadLine().Trim();
                    bool guessHasCorrectFormat = InputManager.ValidateInputGuess(inputGuess);
                    numberOfGuesses++;
                    if (guessHasCorrectFormat)
                    {
                        Console.WriteLine($"You guessed: { inputGuess} \n");
                        string outputResult = ReturnOutputAfterGuess(correctAnswer, inputGuess);
                        Console.WriteLine($"Result: {outputResult} \n");
                        playerGuessedCorrect = CheckGameWinningCondition(outputResult);
                    }
                    else
                    {
                        Console.WriteLine("Guess must contain 4 characters! Try again: ");
                    }
                }

                SaveResultToFile(name, numberOfGuesses);
                DisplayTopList();
                
                Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    IsRunning = false;
                }
            }

        }

        static void SaveResultToFile(string name, int numberOfGuesses)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(name + "#&#" + numberOfGuesses);
            output.Close();
        }

        static void DisplayTopList()
        {
            StreamReader input = new StreamReader("result.txt");
            List<PlayerData> results = new List<PlayerData>();
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }


            }
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }

        static string GenerateCorrectAnswer(int amountOfIntegers)
        {
            Random numberGenerator = new Random();
            string uniqueNumberToReturn = "";
            while (uniqueNumberToReturn.Length < amountOfIntegers)
            {
                int newNumber = numberGenerator.Next(10);
                if (!uniqueNumberToReturn.Contains(newNumber.ToString()))
                {
                    uniqueNumberToReturn += newNumber.ToString();
                }
            }
            return uniqueNumberToReturn;
        }
        static string ReturnOutputAfterGuess(string hiddenAnswer, string guess)
        {
            int numberExistsWrongPositionCounter = 0;
            int correctPositionCounter = 0;
           /* guess += "    "; */    // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (hiddenAnswer[i] == guess[j])
                    {
                        if (i == j)
                        {
                            correctPositionCounter++;
                        }
                        else
                        {
                            numberExistsWrongPositionCounter++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, correctPositionCounter) + "," + "CCCC".Substring(0, numberExistsWrongPositionCounter);
        }

        static bool CheckGameWinningCondition(string resultAfterGuess)
        {
            if (resultAfterGuess == "BBBB,")
            {
                return true;
            }
            return false;
        }

    }
}
