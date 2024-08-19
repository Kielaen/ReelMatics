Feature: ReelMatics Slot Machine Spin

  Scenario: Spin the reels and display the screen
    Given the slot machine has been spun
    When capturing the results
    Then the stop positions should be displayed
    And the screen should display the correct symbols
