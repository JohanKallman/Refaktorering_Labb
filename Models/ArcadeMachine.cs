using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refactoring_labb2.Interfaces;
using refaktorering_labb.Interfaces;
using Refaktorering_Labb.Models;

namespace refaktorering_labb.Models
{
  public sealed class ArcadeMachine
  {
    private readonly string Name = "The Arcade";
    public UI _uI;
    //public Statistics _statistics;

    public Game _game;
    //public PlayerData _playerData;

    IStatistics _statistics;
    IPlayerData _playerData;

    public static bool GameIsRunning { get; set; } = false;
    // public UI _uI { get; set; }
    // public Statistics _statistics { get; set; }
    // public Game _game { get; set; }

    private static ArcadeMachine _instance;


    public static ArcadeMachine GetInstance()
    {
      if (_instance == null)
      {
        IStatistics statistics = new Statistics();
        UI uI = new UI();
        IPlayerData playerData = new PlayerData();

        _instance = new ArcadeMachine(uI, statistics, playerData);
      }

      return _instance;
    }

    public ArcadeMachine(UI uI, IStatistics statistics, IPlayerData playerData)
    {
      _uI = uI;
      _statistics = statistics;
      _playerData = playerData;


    }


    public void Start()
    {
      _uI.PrintWelcomeMessage(Name);

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
      _game.ResetGuessingCounter();
      _uI.PrintWelcomeMessage(_game.GameName);
      _uI.PrintEnterNameMessage();
      _game.PlayerName = Console.ReadLine();
      _uI.PrintRulesMessage(_game.Rules);

    }

    public void RunningRounds()
    {

      _game.StartNewInstanceOfGame();


      _game.PlayerIsGuessing = true;

      RoundIsRunning();

    }

    public void RoundIsRunning()
    {
      while (_game.PlayerIsGuessing)
      {
        _uI.PrintRoundStartMessage(_game.NumberOfGuesses);
        _uI.PrintGuessHereMessage();
        _game.PlayerGuess = _game.PlayerGuesses();

        bool guessHasCorrectFormat = ValidateInputGuess();

        if (guessHasCorrectFormat)
        {

          _game.PrepareRoundResult();

          _uI.PrintResultOfPlayerGuessMessage(_game.PlayerGuess, _game.OutPutResult);
          _game.PlayerIsGuessing = _game.CheckGameWinningCondition();
        }
        else
        {
          _uI.PrintInputErrorMessage();
          _uI.PrintRulesMessage(_game.Rules);
        }
      }

    }

    public bool ValidateInputGuess()
    {
      bool guessHasCorrectFormat = _game.CheckIfCorrectLengthFormat();

      if (guessHasCorrectFormat == false)
      {
        return false;
      }

      return guessHasCorrectFormat = _game.CheckIfCorrectCharFormat();

    }

    public void GameOver()
    {
      _uI.PrintResultOfInstanceMessage(_game.NumberOfGuesses);
      _uI.PrintAskToPlayAgainMessage();

      _uI.PrintHighScoreListMessage();
      _statistics.SaveGameResultToFile(_game.PlayerName, _game.NumberOfGuesses);
      _statistics.DisplayTopList();
      GameIsRunning = _game.CheckIfPlayAgain(Console.ReadLine());

    }

    public Game ChooseGame(string input)
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