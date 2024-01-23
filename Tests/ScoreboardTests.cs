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
}
