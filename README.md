# LiveFootballWorldCupScoreBoard

Requirements:
- World Cup Scoreboard library 
- shows all the ongoing matches and their scores

The scoreboard supports the following operations:
1. Start a new game, assuming initial score 0 � 0 and adding it the scoreboard. This should capture following parameters:
	a. Home team
	b. Away team
2. Update score. This should receive a pair of absolute scores: home team score and away team score.
3. Finish game currently in progress. This removes a match from the scoreboard.
4. Get a summary of games in progress ordered by their total score. The games with the same total score will be returned ordered by the most recently started match in the scoreboard.

## Assumptions 
- I will create a simple solution, my goal is to work time-boxed 
- I will create 2 projects	
  - Library - Domain logic (probably 2 classes: Game and Scoreboard)
  - Test - Unit Tests for Library
- I will document here my considerations

## Implementation - Game
- I assume that you can not start a game, which two teams with same name play in (case insensitive)
- I use string for teams (which can be called a code smell [primitive obsession], but there is requirement to keep the solution simple)
- I assume you are allowed to change score by more then one score at once
  - e.g. you can go from 0:0 to 3:2 in one step
  - this makes sense in situations, when some SetScore commands 'get lost' on the way
  - I assume to update the score with the most up to date score
- I assume it is possible to go down with the score (3:3 to 1:1) e.g. because of some referee's decision
- I assume score cannot be negative
- I assume you cannot update score for a finished game

## Implementation - Scoreboard
- I used a List to store Games, as suggested in the task description
- I used soft delete for 'finishing a game' - so it will grow infinitely, which is probably bad for an in memory collection in real life scenario, but would we use an in memory collection in real world scenario? - alternative would be to remove a game from the list
- in real life I would probably provide some method to add the scoreboard to the DI container, it would force me use interface, at least for the Scoreboard class
- Scoreboard class is not thread-safe, it can cause problems in a multi-threaded application
- Before starting I was considering splitting the read and write models (e.g. separate list for adding and editing games and separate list for querying the data which would be updated via events), but I wouldn't have enough time and the solution was supposed to be as simple as possible, so I didn't go for it. 