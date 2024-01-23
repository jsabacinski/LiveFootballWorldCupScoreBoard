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

## Implementation
- I assume that you can not start a game, which two teams with same name play in (case insensitive)
- I use string for teams (which can be called a code smell [primitive obsession], but there is requirement to keep the solution simple)
- I assume you are allowed to change score by more then one score at once
  - e.g. you can go from 0:0 to 3:2 in one step
  - this makes sense in situations, when some SetScore commands 'get lost' on the way
  - I assume to update the score with the most up to date score
- I assume it is possible to go down with the score (3:3 to 1:1) e.g. because of some referee's decision
- I assume score cannot be negative
- I assume you cannot update score for a finished game