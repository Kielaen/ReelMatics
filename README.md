# ReelMatics Slot Machine

## Overview

ReelMatics is a slot machine simulator implemented in C#. This application simulates spinning a slot machine with five reels, each containing a sequence of symbols. The application displays the results of each spin, following which it will calculate winnings based on a predefined paytable, and provides an option to continue spinning.

## Features

- Simulates a slot machine with 5 columns and 3 rows.
- Displays the symbols on the screen after each spin.
- Calculates winnings based on a predefined paytable.
- Allows the user to keep spinning or exit the application.
- Provides clear output of stop positions, screen symbols, total winnings, and win details.

# Getting Started

## Running the Console App

Build and run the application by running these commands:
```bash
dotnet build
dotnet run 
```

## Running the Tests

First, you will need to navigate to the Test directory:
```bash
cd ReelMatics.Tests
```

Run the following command to run the tests:
```bash 
dotnet test
```

# Unit Tests

The project includes tests on ReelMatics class, written using NUnit and [ReqnRoll](https://docs.reqnroll.net/latest/index.html).
Tests are located in the ReelMatics.Tests directory.

## Writing tests

1. Create a new feature file in the Features directory.
2. Write out your scenarios following gherkin syntax.
3. Create a matching StepDefinition file.

# Contributing

Feel free to submit your PR's (just kidding).
