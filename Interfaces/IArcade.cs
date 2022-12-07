using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refaktorering_labb.Models;
using Refaktorering_Labb.Models;

namespace refactoring_labb2.Interfaces
{
  public interface IArcade
  {
    public UI _uI { get; set; }
    public Statistics _statistics { get; set; }
    public Game _game { get; set; }
  }
}