using FluentAssertions;
using Reqnroll;

namespace ReelMatics.Tests.StepDefinitions;

[Binding]
public class ReelMaticsStepDefinitions
{
    private int[] _stopPositions = default!;
    private string[,] _screen = default!;

    [Given(@"the slot machine has been spun")]
    public void GivenTheSlotMachineHasBeenSpun()
    {
        _stopPositions = ReelMatics.SpinReels();
    }

    [When("capturing the results")]
    public void WhenCapturingTheResults()
    {
        _screen = ReelMatics.GenerateScreen(_stopPositions);
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
        _screen.GetLength(0).Should().Be(3);
        _screen.GetLength(1).Should().Be(5);

        for (var i = 0; i < 5; i++)
        {
            var expectedTopSymbol = ReelMatics.ReelSet[i][(_stopPositions[i] + ReelMatics.ReelSet[i].Length - 1) % ReelMatics.ReelSet[i].Length];
            var expectedMiddleSymbol = ReelMatics.ReelSet[i][_stopPositions[i]];
            var expectedBottomSymbol = ReelMatics.ReelSet[i][(_stopPositions[i] + 1) % ReelMatics.ReelSet[i].Length];

            _screen[0, i].Should().Be(expectedTopSymbol);
            _screen[1, i].Should().Be(expectedMiddleSymbol);
            _screen[2, i].Should().Be(expectedBottomSymbol);
        }
    }
}