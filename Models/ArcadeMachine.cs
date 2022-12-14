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
        _uI.PrintGameMenuOptions();
        _game = GameMenuSelectedOption();

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
        GameIsRunning = true;
        RunStartup();
        GameSession();
        GameOver();
      }
      while (GameIsRunning);

      _uI.PrintGoodByeMessage();
    }

    public void RunStartup()
    {
      _uI.PrintWelcomeMessage(_game.GameName);
      _uI.PrintEnterNameMessage();
      _playerData.SetPlayerName();
      _uI.PrintRulesMessage(_game.Rules);
    }

    public void GameSession()
    {
      _game.StartNewInstanceOfGame();
      RunningRounds();
    }

    public void RunningRounds()
    {
      do
      {
        _game.PlayerIsGuessing = true;
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
          _uI.PrintResultOfPlayerGuess(_game.PlayerGuess, _game.OutPutResult);
        }
      }

      while (_game.PlayerIsGuessing);

    }


    public void GameOver()
    {
      _uI.PrintResultOfGameSession(_game.NumberOfGuesses);
      _uI.PrintTopListListMessage(_game.GameName);

      _statistics.SaveGameResultToFile(_playerData.PlayerName, _game.NumberOfGuesses, _game.GameName);
      _uI.PrintTopList(_statistics.CreateTopList(_game.GameName));
      _uI.PrintAskToPlayAgainMessage();
      GameIsRunning = _game.CheckIfPlayAgain();

    }

    public Game GameMenuSelectedOption()
    {
      //GameMenuSelectedOption(Console.ReadLine().ToUpper());
      switch (Console.ReadLine().ToUpper())
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

    // public Game GameMenu(string input)
    // {
    //   switch (input)
    //   {
    //     case "1":
    //       return new MooGame();


    //     case "2":
    //       return new Mastermind();

    //     case "Q":
    //       ArcadeIsRunning = false;
    //       return null;

    //     default:
    //       return null;
    //   }


    // }



  }
}