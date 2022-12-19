using Refactoring_Lab.Interfaces;
using System;

namespace Refactoring_Lab.Models
{
    public sealed class ArcadeMachine
    {
        private readonly string _arcadeName = "The Arcade";
        private readonly string _fileName = "result.txt";
        private readonly IStatistics _statistics;
        private readonly IPlayerData _playerData;
        private bool _gameIsRunning;
        private bool _arcadeIsRunning;
        private static ArcadeMachine _instance;
        private UI _uI;
        private Game _game;

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

        private ArcadeMachine(UI uI, IStatistics statistics, IPlayerData playerData)
        {
            _uI = uI;
            _statistics = statistics;
            _playerData = playerData;
        }

        public void Start()
        {
            do
            {
                _arcadeIsRunning = true;
                _uI.PrintWelcomeMessage(_arcadeName);
                _uI.PrintGameMenuOptions();
                _game = GameMenuSelectedOption();

                if (_game is not null)
                {
                    RunGame();
                }
            }
            while (_arcadeIsRunning);
            _uI.PrintGoodByeMessage();
        }

        public void RunGame()
        {
            do
            {
                _gameIsRunning = true;
                RunStartup();
                GameSession();
                GameOver();
            }
            while (_gameIsRunning);
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
            _game.StartNewInstanceOfGame(_game);
            RunningRounds();
        }

        public void RunningRounds()
        {
            do
            {
                _game.PlayerGuess.PlayerIsGuessing = true;
                _uI.PrintRoundStartMessage(_game.PlayerGuess.NumberOfGuesses);
                _uI.PrintGuessHereMessage();
                _game.PlayerGuess.PlayerGuesses();
                _game.PlayerGuess.ValidateInputGuess(_game);

                if (_game.PlayerGuess.IsValidGuess == false)
                {
                    _uI.PrintInputErrorMessage();
                    _uI.PrintRulesMessage(_game.Rules);
                }

                else
                {
                    _game.PrepareRoundResult(_game);
                    _game.CheckIfGameIsOver();
                    _uI.PrintResultOfPlayerGuess(_game.PlayerGuess.Guess, _game.PlayerGuess.OutputResult);
                }
            }
            while (_game.PlayerGuess.PlayerIsGuessing);
        }

        public void GameOver()
        {
            _uI.PrintResultOfGameSession(_game.PlayerGuess.NumberOfGuesses);
            _uI.PrintTopListHeaderMessage(_game.GameName);
            _statistics.SaveGameResultToFile(_playerData.PlayerName, _game.PlayerGuess.NumberOfGuesses, _game.GameName, _fileName);
            _uI.PrintTopList(_statistics.CreateTopList(_game.GameName, _fileName));
            _uI.PrintAskToPlayAgainMessage();
            _gameIsRunning = _game.CheckIfPlayAgain();
        }

        public Game GameMenuSelectedOption()
        {
            switch (Console.ReadLine().ToUpper())
            {
                case "1":
                    return new MooGame();
                case "2":
                    return new Mastermind();
                case "Q":
                    _arcadeIsRunning = false;
                    return null;
                default:
                    _uI.PrintInputErrorMessage();
                    return null;
            }
        }
    }
}