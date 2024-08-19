using System.Collections.Generic;

namespace ReelMatics.Models;

public class PayTable
{
  private readonly Dictionary<string, int[]> _payTable = new()
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

  public int GetPayout(string symbol, int count)
  {
    return _payTable.ContainsKey(symbol) && count >= 3
      ? _payTable[symbol][count - 3]
      : 0;
  }
}