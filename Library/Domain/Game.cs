namespace Library.Domain;

public class Game
{
    public static Game Create(string homeTeam, string awayTeam)
    {
        return new Game(homeTeam, awayTeam);
    }
    
    public Guid Id { get; }
    public string HomeTeam { get; init; }
    public string AwayTeam { get; init; }
    public int HomeScore { get; private set; }
    public int AwayScore { get; private set; }
    public DateTimeOffset StartedOn { get; init; }
    public bool IsInProgress { get; private set; }

    protected Game(string homeTeam, string awayTeam)
    {
    }
}
