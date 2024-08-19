using ReelMatics.Models;
using System;
using ReelMatics.Services;

namespace ReelMatics;

public static class ReelMatics
{
  private static void Main()
  {
    var reelSet = new ReelSet();
    var payTable = new PayTable();
    var reelEngine = new ReelEngine(reelSet, payTable);

    var keepSpinning = true;
    while (keepSpinning)
    {
      var stopPositions = reelEngine.SpinReels();
      var screen = reelEngine.GenerateScreen(stopPositions);

      ReelEngine.DisplayResults(stopPositions, screen);

      var totalWins = reelEngine.CalculateWinnings(screen, out var winDetails);
      ReelEngine.DisplayWinnings(totalWins, winDetails);

      Console.WriteLine("Do you want to spin again? (y/n)");
      var response = Console.ReadLine()?.Trim().ToLower();
      keepSpinning = response == "y";
      Console.WriteLine();
    }

    Console.WriteLine("Thank you for playing!");
  }
}
