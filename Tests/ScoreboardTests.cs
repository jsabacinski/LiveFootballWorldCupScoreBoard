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
