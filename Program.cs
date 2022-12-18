using Refactoring_Lab.Models;

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
