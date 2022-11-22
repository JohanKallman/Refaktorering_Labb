using System;
using System.IO;
using System.Collections.Generic;
using Refaktorering_Labb.Models;

namespace MooGame
{
	class Program
	{

		public static void Main(string[] args)
		{	
			MessageHandler.PrintWelcome();
			Game game = new Game();
			game.RunGame();
		}
		
	}
}