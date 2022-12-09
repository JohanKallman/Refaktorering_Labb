using Refactoring_Lab.Interfaces;
using System;

namespace Refactoring_Lab.Models
{
  public sealed class ArcadeMachine
  {
    private readonly string ArcadeName = "The Arcade";

    public UI _uI;
    public Game _game;


    private readonly IStatistics _statistics;
    private readonly IPlayerData _playerData;

    public static bool GameIsRunning { get; set; } = false;
    public static bool ArcadeIsRunning { get; set; }


    private static ArcadeMachine _instance;


    public static ArcadeMachine GetInstance()
    {
      if (_instance == null)
      {
        UI uI = new UI();
        IStatistics statistics = new Statistics();
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
      do
      {
        ArcadeIsRunning = true;
        _uI.PrintWelcomeMessage(ArcadeName);
        _uI.PrintChooseGameMessage();
        _game = GameMenu(Console.ReadLine().ToUpper());

        if (_game is not null)
        {
          RunGame();
        }

      }
      while (ArcadeIsRunning);

      _uI.PrintGoodByeMessage();
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
      _playerData.SetPlayerName();
      _uI.PrintRulesMessage(_game.Rules);

    }

    public void RunningRounds()
    {
      _game.StartNewInstanceOfGame();
      RoundIsRunning();
    }

    public void RoundIsRunning()
    {
      do
      {
        _game.ActiveGame = true;
        _uI.PrintRoundStartMessage(_game.NumberOfGuesses);
        _uI.PrintGuessHereMessage();
        _game.PlayerGuesses();

        _game.ValidateInputGuess();

        if (_game.ValidGuess == false)
        {
          _uI.PrintInputErrorMessage();
          _uI.PrintRulesMessage(_game.Rules);
        }

        else
        {
          _game.PrepareRoundResult();
          _game.CheckIfGameIsOver();
          _uI.PrintResultOfPlayerGuessMessage(_game.PlayerGuess, _game.OutPutResult);
        }
      }

      while (_game.ActiveGame);



    }


    public void GameOver()
    {
      _uI.PrintResultOfInstanceMessage(_game.NumberOfGuesses);
      _uI.PrintHighScoreListMessage();

      _statistics.SaveGameResultToFile(_playerData.PlayerName, _game.NumberOfGuesses);
      _statistics.DisplayTopList();
      _uI.PrintAskToPlayAgainMessage();
      GameIsRunning = _game.CheckIfPlayAgain(Console.ReadLine());

    }

    // public void GameMenu(string input)
    // {
    //   switch (input)
    //   {
    //     case "1":
    //       _game = new MooGame();
    //       break;

    //     case "2":
    //       _game = new Mastermind();
    //       break;

    //     case "3":
    //       ArcadeIsRunning = false;
    //       break;

    //     default:
    //       break;
    //   }


    // }


    public Game GameMenu(string input)
    {
      switch (input)
      {
        case "1":
          return new MooGame();


        case "2":
          return new Mastermind();

        case "Q":
          ArcadeIsRunning = false;
          return null;

        default:
          return null;
      }


    }


  }
}