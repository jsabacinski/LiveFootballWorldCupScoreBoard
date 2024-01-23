﻿namespace Library.Domain;

public class Scoreboard
{
    public Game? StartNewGame(string homeTeam, string awayTeam)
    {
        var game = Game.Create(homeTeam, awayTeam);
        return game;
    }

    public void UpdateScore(Guid gameId, int homeScore, int awayScore)
    {
        throw new NotImplementedException();
    }

    public void FinishGame(Guid gameId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Game> GetGamesSummary()
    {
        throw new NotImplementedException();
    }
}
