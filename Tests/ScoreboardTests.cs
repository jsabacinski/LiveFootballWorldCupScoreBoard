using Library.Domain;

namespace Tests;

public class ScoreboardTests
{
    [Test]
    public void StartNewGame_ValidInput_ReturnsCreatedGame()
    {
        // Arrange
        var scoreboard = new Scoreboard();

        // Act
        var game = scoreboard.StartNewGame("Mexico", "Canada");        

        // Assert
        Assert.NotNull(game);
    }

    [Test]
    [TestCase("Mexico", "NotPlaying")]
    [TestCase("NotPlaying", "Mexico")]
    public void StartNewGame_GameWithTeamCurrentlyPlaying_ReturnsNull(string homeTeam, string awayTeam)
    {
        // Arrange
        var scoreboard = new Scoreboard();
        scoreboard.StartNewGame("Mexico", "Canada");
        
        // Act
        var game = scoreboard.StartNewGame(homeTeam, awayTeam);

        // Assert
        Assert.Null(game);
    }

    [Test]
    public void StartNewGame_InvalidInputTwoSameTeams_ReturnsNull()
    {
        // Arrange
        var scoreboard = new Scoreboard();

        // Act
        var game = scoreboard.StartNewGame("Mexico", "Mexico");

        // Assert
        Assert.Null(game);
    }

    [Test]
    public void UpdateScore_GameAdded_AddedGameShouldBeInSummary()
    {
        // Arrange
        var scoreboard = new Scoreboard();
        var game = scoreboard.StartNewGame("Mexico", "Canada");
        var newHomeScore = 3;
        var newAwayScore = 2;

        // Act
        var result = scoreboard.UpdateScore(game.Id, newHomeScore, newAwayScore);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(game.HomeScore, Is.EqualTo(newHomeScore));
        Assert.That(game.AwayScore, Is.EqualTo(newAwayScore));
    }

    [Test]
    public void UpdateScore_GameNotAdded_ReturnsFalse()
    {
        // Arrange
        var scoreboard = new Scoreboard();
        var newHomeScore = 3;
        var newAwayScore = 2;

        // Act
        var result = scoreboard.UpdateScore(Guid.NewGuid(), newHomeScore, newAwayScore);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void FinishGame_GameAdded_GameFinished()
    {
        // Arrange
        var scoreboard = new Scoreboard();
        var game = scoreboard.StartNewGame("Mexico", "Canada");

        // Act
        var result = scoreboard.FinishGame(game.Id);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(game.IsInProgress, Is.False);
    }

    [Test]
    public void FinishGame_GameNotAdded_GameFinished()
    {
        // Arrange
        var scoreboard = new Scoreboard();

        // Act
        var result = scoreboard.FinishGame(Guid.NewGuid());

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void GetGamesSummary_GameAdded_AddedGameShouldBeInSummary()
    {
        // Arrange
        var scoreboard = new Scoreboard();
        var game = scoreboard.StartNewGame("Mexico", "Canada");

        // Act
        var result = scoreboard.GetGamesSummary();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.Contains(game), Is.True);
    }

    [Test]
    public void GetGamesSummary_GameFinished_AddedGameShouldNotBeInSummary()
    {
        // Arrange
        var scoreboard = new Scoreboard();
        var game = scoreboard.StartNewGame("Mexico", "Canada");
        scoreboard.FinishGame(game.Id);

        // Act
        var result = scoreboard.GetGamesSummary();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(0));
    }

    [Test]
    public void CodingExerciseExample()
    {
        // Arrange 
        var scoreboard = new Scoreboard();

        var game1 = scoreboard.StartNewGame("Mexico", "Canada");
        var game2 = scoreboard.StartNewGame("Spain", "Brazil");
        var game3 = scoreboard.StartNewGame("Germany", "France");
        var game4 = scoreboard.StartNewGame("Uruguay", "Italy");
        var game5 = scoreboard.StartNewGame("Argentina", "Australia");

        var expectedResult = new List<Game>
        {
            game4,
            game2,
            game1,
            game5,
            game3
        };

        var expectedOrderedGameIds = expectedResult.Select(x => x.Id);

        scoreboard.UpdateScore(game1.Id, 0, 5);
        scoreboard.UpdateScore(game2.Id, 10, 2);
        scoreboard.UpdateScore(game3.Id, 2, 2);
        scoreboard.UpdateScore(game4.Id, 6, 6);
        scoreboard.UpdateScore(game5.Id, 3, 1);

        // Act
        var result = scoreboard.GetGamesSummary();
        var resultGameIds = result.Select(x => x.Id);

        // Assert
        Assert.That(resultGameIds, Is.EqualTo(expectedOrderedGameIds));
    }
}
