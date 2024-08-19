using System;
using System.Collections.Generic;
using System.Linq;
using ReelMatics.Models;

namespace ReelMatics.Services;

public class ReelEngine(ReelSet reelSet, PayTable payTable)
{
  public int[] SpinReels()
  {
    Random random = new();
    var stopPositions = new int[5];

    for (var i = 0; i < 5; i++)
    {
      stopPositions[i] = random.Next(reelSet.Reels[i].Length);
    }

    return stopPositions;
  }

  public List<List<string>> GenerateScreen(int[] stopPositions)
  {
    var screen = new List<List<string>>
      {
        new(new string[5]),
        new(new string[5]),
        new(new string[5])
      };

    for (var i = 0; i < 5; i++)
    {
      screen[0][i] = reelSet.Reels[i][(stopPositions[i] + reelSet.Reels[i].Length - 1) % reelSet.Reels[i].Length];
      screen[1][i] = reelSet.Reels[i][stopPositions[i]];
      screen[2][i] = reelSet.Reels[i][(stopPositions[i] + 1) % reelSet.Reels[i].Length];
    }

    return screen;
  }

  public int CalculateWinnings(List<List<string>> screen, out List<string> winDetails)
  {
    var totalWins = 0;
    winDetails = [];

    for (var row = 0; row < 3; row++)
    {
      for (var col = 0; col < 5; col++)
      {
        var symbol = screen[row][col];

        var winningPositions = Enumerable.Range(col, 5 - col)
          .TakeWhile(nextCol => screen[row][nextCol] == symbol)
          .Select(nextCol => row * 5 + nextCol)
          .ToList();

        var count = winningPositions.Count;

        if (count < 3)
        {
          continue;
        }
        var payout = payTable.GetPayout(symbol, count);
        totalWins += payout;
        winDetails.Add($"- Ways win {string.Join("-", winningPositions)}, {symbol} x{count}, {payout}");
      }
    }

    return totalWins;
  }


  public static void DisplayResults(int[] stopPositions, List<List<string>> screen)
  {
    Console.WriteLine("Stop Positions: " + string.Join(", ", stopPositions));

    Console.WriteLine("Screen:");

    screen.Select(row => string.Join(" ", row))
      .ToList()
      .ForEach(Console.WriteLine);
  }

  public static void DisplayWinnings(int totalWins, List<string> winDetails)
  {
    Console.WriteLine($"Total wins: {totalWins}");
    foreach (var detail in winDetails)
    {
      Console.WriteLine(detail);
    }
  }
}