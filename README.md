# Project Description

This game is meant to have a similar gameplay as Romance of the Three Kindgoms 2 (for Super Nintendo). It will feature simple mechanics and very basic graphics. It will be easy to modify the historical context to adapt it to other places, not only China. The war resolution will not feature an action phase, this way it will make it easy to play online from a smartphone/PC/etc and be able to quit anytime. The war gameplay may borrow ideas from the game of go with a hint of Diplomacy.

# Unit tests
To run the unit tests automatically in VS Code, run the following command in a Terminal: dotnet watch --project .\Tests\Kerglerec.Tests\ test

# Code coverage
1. dotnet-coverage collect -f cobertura -o "coveragereport\coverage.cobertura.xml" "dotnet test"
2. reportgenerator -reports:"coveragereport\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
3. Open coveragereport\index.html
## prerequisite
- Install dotnet-coverage: dotnet tool install --global dotnet-coverage
- Install reportgenerator: dotnet tool install -g dotnet-reportgenerator-globaltool

# Task List
TODO-Highlight List highlighted annotations.
Only UNDONE (high priority), TODO (normal priority) and HACK (low priority) are used.
## prerequisite
- Install TODO Highlight v2

# Contributing
This project is not yet ready for contributions.
