using System.Collections.Generic;
using FluentAssertions;
using ReelMatics.Models;
using ReelMatics.Services;
using Reqnroll;

namespace ReelMatics.Tests.StepDefinitions;

[Binding]
public class ReelMaticsStepDefinitions
{
  private int[] _stopPositions = default!;
  private List<List<string>> _screen = default!;
  private ReelEngine _engine = default!;
  private readonly ReelSet _set = new();
  private readonly PayTable _payTable = new();

  [Given(@"the slot machine has been spun")]
  public void GivenTheSlotMachineHasBeenSpun()
  {
    _engine = new ReelEngine(_set, _payTable);
  }

  [When("capturing the results")]
  public void WhenCapturingTheResults()
  {
    _stopPositions = _engine.SpinReels();
    _screen = _engine.GenerateScreen(_stopPositions);
  }

  [Then(@"the stop positions should be displayed")]
  public void ThenTheStopPositionsShouldBeDisplayed()
  {
    _stopPositions.Should().HaveCount(5);
    foreach (var pos in _stopPositions)
    {
      pos.Should().BeGreaterOrEqualTo(0);
    }
  }

  [Then(@"the screen should display the correct symbols")]
  public void ThenTheScreenShouldDisplayTheCorrectSymbols()
  {
    _screen.Count.Should().Be(3);

    foreach (var row in _screen)
    {
      row.Count.Should().Be(5);
    }

    for (var i = 0; i < 5; i++)
    {
      var expectedTopSymbol = _set.Reels[i][(_stopPositions[i] + _set.Reels[i].Length - 1) % _set.Reels[i].Length];
      var expectedMiddleSymbol = _set.Reels[i][_stopPositions[i]];
      var expectedBottomSymbol = _set.Reels[i][(_stopPositions[i] + 1) % _set.Reels[i].Length];

      _screen[0][i].Should().Be(expectedTopSymbol);
      _screen[1][i].Should().Be(expectedMiddleSymbol);
      _screen[2][i].Should().Be(expectedBottomSymbol);
    }
  }
}