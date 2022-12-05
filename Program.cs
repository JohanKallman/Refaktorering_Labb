using System;
using System.IO;
using System.Collections.Generic;
using Refaktorering_Labb.Models;
using refaktorering_labb.Models;

namespace MooGame
{
  class Program
  {

    public static void Main(string[] args)
    {


      ArcadeMachine arcadeMachine = ArcadeMachine.GetInstance();

      arcadeMachine.Start();


    }

  }

}

//   ArcadeMachine.Start();


//   class ArcadeMachine
// {
//   MessageHandler.PrintWelcome();
// 		MenuHandler.ChoseGame();
// 		ArcadeMachine.LoadGame(iGame);

// 		public static void LoadGame(IGame iGame)
//   {
//     // Här kan alla spel laddas.
//     // metoder som används av bägge spelen bör ligga i IGame-interfacet
//     // Spelspecifika metoder ligger i Mastermind-klassen eller BULL/COW-klassen
//     // Göra en GameFactory?
//     Game newGame = new Game(iGame);
// 		//Detta möjliggör att kunna köra t ex iGame.PrintRules och kunna få olika regler 
// 		//beroende på vilket spel som är laddat. Man kan också göra Game-klassen abstrakt

// 		// I princip så ska bara startuppen dvs innan spelet startar och när spelet är slut följa samma kod.
// 		//Det som händer mellan start och stop sköter spelen själv. Typ som ROMs i en emulator.

//    //I Game bör det vara uppelat i  Uppstart, Rundor, Slut. Eget Pattern?
//
//		// foreach var iGame in iGames {if( iGame.Name == input) {Game newGame = new IGame(iGame); }}
//   }
// }

// class Game
// {
//   public Game(IGame iGame)
//   {

//   }
// }