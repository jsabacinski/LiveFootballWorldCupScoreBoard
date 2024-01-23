namespace Library.Domain;

public class Scoreboard
{
    private readonly List<Game> _games = new();
    public Game? StartNewGame(string homeTeam, string awayTeam)
    {
        try
        {
            var game = Game.Create(homeTeam, awayTeam);
            _games.Add(game);
            return game;
        }
        catch (ArgumentException) // todo: it would be better to use own custom exception or the 'Result' pattern (as result of Game.Create)
        {
            return default;
        }
    }

    public bool UpdateScore(Guid gameId, int homeScore, int awayScore)
    {
        var gameToUpdate = _games.FirstOrDefault(x => x.Id == gameId);
        if (gameToUpdate is null) return false;

        return gameToUpdate.SetScore(homeScore, awayScore);
    }

    public bool FinishGame(Guid gameId)
    {
        var gameToFinish = _games.FirstOrDefault(x => x.Id == gameId);
        if (gameToFinish is null) return false;

        gameToFinish.Finish();
        return true;
    }

    public IEnumerable<Game> GetGamesSummary()
    {
        return _games
            .Where(x => x.IsInProgress);
    }
}
