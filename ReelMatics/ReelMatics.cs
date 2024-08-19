using System;
using System.Collections.Generic;

namespace ReelMatics;

public static class ReelMatics
{
  private static void Main()
  {
    var keepSpinning = true;
    while (keepSpinning)
    {
      // Simulate the spin
      var stopPositions = SpinReels();
      var screen = GenerateScreen(stopPositions);

      // Display the stop positions and screen
      DisplayResults(stopPositions, screen);

      // Calculate and display winnings
      CalculateAndDisplayWinnings(screen);

      // Ask user if they want to spin again
      Console.WriteLine("Do you want to spin again? (y/n)");
      var response = Console.ReadLine()!.Trim().ToLower();
      keepSpinning = response == "y";
      Console.WriteLine();
    }

    Console.WriteLine("Thank you for playing!");
  }

  // Pay table
  private static readonly Dictionary<string, int[]> PayTable = new()
    {
      { "sym1", [1, 2, 3] },
      { "sym2", [1, 2, 3] },
      { "sym3", [1, 2, 5] },
      { "sym4", [2, 5, 10] },
      { "sym5", [5, 10, 15] },
      { "sym6", [5, 10, 15] },
      { "sym7", [5, 10, 20] },
      { "sym8", [10, 20, 50] }
    };

  // Reelset definition
  public static readonly string[][] ReelSet =
  [
    ["sym2", "sym7", "sym7", "sym1", "sym1", "sym5", "sym1", "sym4", "sym5", "sym3", "sym2", "sym3", "sym8", "sym4", "sym5", "sym2", "sym8", "sym5", "sym7", "sym2"],
      ["sym1", "sym6", "sym7", "sym6", "sym5", "sym5", "sym8", "sym5", "sym5", "sym4", "sym7", "sym2", "sym5", "sym7", "sym1", "sym5", "sym6", "sym8", "sym7", "sym6", "sym3", "sym3", "sym6", "sym7", "sym3"],
      ["sym5", "sym2", "sym7", "sym8", "sym3", "sym2", "sym6", "sym2", "sym2", "sym5", "sym3", "sym5", "sym1", "sym6", "sym3", "sym2", "sym4", "sym1", "sym6", "sym8", "sym6", "sym3", "sym4", "sym4", "sym8", "sym1", "sym7", "sym6", "sym1", "sym6"],
      ["sym2", "sym6", "sym3", "sym6", "sym8", "sym8", "sym3", "sym6", "sym8", "sym1", "sym5", "sym1", "sym6", "sym3", "sym6", "sym7", "sym2", "sym5", "sym3", "sym6", "sym8", "sym4", "sym1", "sym5", "sym7"],
      ["sym7", "sym8", "sym2", "sym3", "sym4", "sym1", "sym3", "sym2", "sym2", "sym4", "sym4", "sym2", "sym6", "sym4", "sym1", "sym6", "sym1", "sym6", "sym4", "sym8"]
  ];

  public static int[] SpinReels()
  {
    Random random = new();
    var stopPositions = new int[5];

    for (var i = 0; i < 5; i++)
    {
      stopPositions[i] = random.Next(ReelSet[i].Length);
    }

    return stopPositions;
  }

  public static string[,] GenerateScreen(int[] stopPositions)
  {
    var screen = new string[3, 5];

    for (var i = 0; i < 5; i++)
    {
      screen[0, i] = ReelSet[i][(stopPositions[i] + ReelSet[i].Length - 1) % ReelSet[i].Length];
      screen[1, i] = ReelSet[i][stopPositions[i]];
      screen[2, i] = ReelSet[i][(stopPositions[i] + 1) % ReelSet[i].Length];
    }

    return screen;
  }

  private static void DisplayResults(int[] stopPositions, string[,] screen)
  {
    Console.WriteLine("Stop Positions: " + string.Join(", ", stopPositions));
    Console.WriteLine("Screen:");

    for (var row = 0; row < 3; row++)
    {
      for (var col = 0; col < 5; col++)
      {
        Console.Write(screen[row, col] + (col < 4 ? " " : ""));
      }
      Console.WriteLine();
    }
  }

  private static void CalculateAndDisplayWinnings(string[,] screen)
  {
    var totalWins = 0;
    List<string> winDetails = [];

    for (var row = 0; row < 3; row++)
    {
      for (var col = 0; col < 5; col++)
      {
        var symbol = screen[row, col];
        var count = 1;
        List<int> winningPositions = [row * 5 + col];

        for (var nextCol = col + 1; nextCol < 5; nextCol++)
        {
          if (screen[row, nextCol] == symbol)
          {
            count++;
            winningPositions.Add(row * 5 + nextCol);
          }
          else
          {
            break;
          }
        }

        if (count < 3)
        {
          continue;
        }
        var payout = PayTable[symbol][count - 3];
        totalWins += payout;
        winDetails.Add($"- Ways win {string.Join("-", winningPositions)}, {symbol} x{count}, {payout}");
      }
    }

    // Display total wins and win details
    Console.WriteLine($"Total wins: {totalWins}");
    foreach (var detail in winDetails)
    {
      Console.WriteLine(detail);
    }
  }
}
