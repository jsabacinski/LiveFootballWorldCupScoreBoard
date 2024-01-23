namespace Library.Domain;

public class Game
{
    public static Game Create(string homeTeam, string awayTeam)
    {
        if (string.IsNullOrWhiteSpace(homeTeam))
        {
            throw new ArgumentException(nameof(homeTeam));
        }
        if (string.IsNullOrWhiteSpace(awayTeam))
        {
            throw new ArgumentException(nameof(awayTeam));
        }
        if (homeTeam.Equals(awayTeam, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new ArgumentException("A team cannot play against itself");
        }

        return new Game(homeTeam, awayTeam);
    }
    
    public Guid Id { get; }
    public string HomeTeam { get; init; }
    public string AwayTeam { get; init; }
    public int HomeScore { get; private set; }
    public int AwayScore { get; private set; }
    public int TotalScore => HomeScore + AwayScore;
    public DateTimeOffset StartedOn { get; init; }
    public bool IsInProgress { get; private set; }

    protected Game(string homeTeam, string awayTeam)
    {
        Id = Guid.NewGuid();
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        HomeScore = 0;
        AwayScore = 0;
        StartedOn = DateTimeOffset.UtcNow;
        IsInProgress = true;
    }

    public bool SetScore(int newHomeScore, int newAwayScore)
    {
        if (!IsInProgress) return false;
        if (newHomeScore < 0) return false;
        if (newAwayScore < 0) return false;

        HomeScore = newHomeScore;
        AwayScore = newAwayScore;
        return true;
    }

    public void Finish()
    {
        IsInProgress = false;
    }
}
