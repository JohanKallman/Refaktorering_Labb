using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refaktorering_labb.Interfaces;
using Refaktorering_Labb.Models;

namespace refaktorering_labb.Models
{
  public sealed class ArcadeMachine
  {
    private readonly string Name = "The Arcade";
    public UI _uI;
    public Statistics _statistics;
    public IGame _game;

    public static bool GameIsRunning { get; set; } = false;

    private static ArcadeMachine _instance;

    // private ArcadeMachine()
    // {

    // }

    public static ArcadeMachine GetInstance()
    {
      if (_instance == null)
      {
        _instance = new ArcadeMachine(new UI(), new Statistics());
      }

      return _instance;
    }

    public ArcadeMachine(UI uI, Statistics statistics)
    {
      _uI = uI;
      _statistics = statistics;
    }


    public void Start()
    {
      _uI.PrintWelcome(Name);
      _uI.PrintChooseGameMessage();
      _game = ChooseGame(Console.ReadLine());

      RunGame();

    }

    public void RunGame()
    {
      do
      {
        RunStartup();
        RunningRounds();
        GameOver();
      }
      while (GameIsRunning);

      _uI.PrintGoodByeMessage();
    }

    public void RunStartup()
    {
      GameIsRunning = true;
      _uI.PrintWelcome(_game.GameName);
      _uI.PrintRules(_game.Rules);
      _uI.PrintEnterNameMessage();
      _game.PlayerName = Console.ReadLine();

    }

    public void RunningRounds()
    {

      _game.StartNewInstanceOfGame();
      _uI.RoundStartMessage(_game.NumberOfGuesses);

      _game.PlayerIsGuessing = true;

      RoundIsRunning();

    }

    public void RoundIsRunning()
    {
      while (_game.PlayerIsGuessing)
      {
        _uI.PrintGuessHere();
        string inputGuess = _game.PlayerGuesses();

        bool guessHasCorrectFormat = ValidateInputGuess(inputGuess);

        if (guessHasCorrectFormat)
        {

          string outputResult = _game.PrepareRoundResult(inputGuess);

          _uI.PrintResultOfPlayerGuess(_game.PlayerGuess, outputResult);
          _game.PlayerIsGuessing = _game.CheckGameWinningCondition(outputResult);
        }
        else
        {
          _uI.PrintInputErrorMessage();
          _uI.PrintRules(_game.Rules);
        }
      }

    }

    public bool ValidateInputGuess(string guess)
    {
      bool guessHasCorrectFormat = _game.CheckIfCorrectLengthFormat(guess);

      if (guessHasCorrectFormat == false)
      {
        return false;
      }

      return guessHasCorrectFormat = _game.CheckIfCorrectCharFormat(guess);

    }

    public void GameOver()
    {
      _uI.PrintResultOfInstance(_game.NumberOfGuesses);
      _uI.PrintPlayAgainQuestion();

      _uI.PrintHighScoreListMessage();
      _statistics.SaveGameResultToFile(_game.PlayerName, _game.NumberOfGuesses);
      _statistics.DisplayTopList();
      GameIsRunning = _game.CheckIfPlayAgain(Console.ReadLine());

    }

    public IGame ChooseGame(string input)
    {
      switch (input)
      {
        case "1":
          return new MooGame();


        case "2":
          return new Mastermind();


        default:
          return null;
      }


    }


  }
}