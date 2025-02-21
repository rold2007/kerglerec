# Project Description

This game is meant to have a similar gameplay as a mix of Romance of the Three Kindgoms 2 (for Super Nintendo), Lord of the Realms, Ultimate Domain and Fantasy Empires. It will feature simple combat mechanics and very basic graphics. It will be easy to modify the historical context to adapt it to other places (Rome, Ancient China, Feudal Japan, etc.). The war resolution will not feature an action phase, this way it will make it easy to play online from a smartphone/PC/etc and be able to quit anytime. The war gameplay may borrow ideas from the game of go with a hint of Diplomacy.

##Combats
Use pre-established strategies, like Tecmo Super Bowl. More strategies are available as your general gain experience and based on its war level. Better strateguies allow to win even when the odd are not favorable, but some combinaisons will make the odds change. In the early version the combat will be entirely simulated, but in a later version it could look like Lord of the Realms (with different limited unit types), but without direct control of the armies.

##Corruption
To mimic the corruption and th fall of big empires, the number of actions is limited even if more generals are available. This makes it possible to micro-manage (like Lord of the Realms' famrlands) at first, but it will become impossibel as the empire grows.

##Provinces
There will be no neutral lands, only more lands with a weak ruler.

##Generals
The generals will have 

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

# Update packages
dotnet-outdated -u
## prerequisite
dotnet tool install --global dotnet-outdated-tool

# Contributing
This project is not yet ready for contributions.
