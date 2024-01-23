using Library.Domain;

namespace Tests;
public  class GameTests
{
    [Test]
    public void Create_ValidInput_CreatesObjectWithPropertiesCorrectlySet()
    {
        // arrange
        var homeTeam = "HomeTeam";
        var awayTeam = "AwayTeam";

        // act
        var game = Game.Create(homeTeam, awayTeam);

        // assert
        Assert.IsNotNull(game);
        Assert.That(game.HomeScore, Is.EqualTo(0));
        Assert.That(game.AwayScore, Is.EqualTo(0));
        Assert.That(game.HomeTeam, Is.EqualTo(homeTeam));
        Assert.That(game.AwayTeam, Is.EqualTo(awayTeam));
        Assert.IsTrue(game.IsInProgress);
    }
}
