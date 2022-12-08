using Refactoring_Lab.Interfaces;
using System;

namespace Refactoring_Lab.Models
{
  public sealed class ArcadeMachine
  {
    private readonly string Name = "The Arcade";

    public UI _uI;
    public Game _game;


    private readonly IStatistics _statistics;
    private readonly IPlayerData _playerData;

    public static bool GameIsRunning { get; set; } = false;


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
      _statistics.SaveGameResultToFile(_game.PlayerName, _game.NumberOfGuesses);
      _statistics.DisplayTopList();
      _uI.PrintAskToPlayAgainMessage();
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