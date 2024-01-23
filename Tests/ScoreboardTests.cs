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
}
