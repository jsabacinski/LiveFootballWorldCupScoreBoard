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
        throw new NotImplementedException();
    }

    public void FinishGame(Guid gameId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Game> GetGamesSummary()
    {
        return _games;
    }
}
