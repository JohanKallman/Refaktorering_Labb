using Refactoring_Lab.Models;


namespace Refactoring_Lab.Interfaces
{
    //Anv�nds ej f�r tillf�llet
    public interface IArcade
  {
    public UI _uI { get; set; }
    public Statistics _statistics { get; set; }
    public Game _game { get; set; }
  }
}