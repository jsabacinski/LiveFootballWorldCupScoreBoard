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
        Assert.That(game.IsInProgress, Is.True);
        Assert.That(game.StartedOn != default, Is.True);
    }

    [Test]
    [TestCase(null, null)]
    [TestCase("Home", null)]
    [TestCase(null, "Away")]
    [TestCase("Same", "Same")]
    [TestCase("same", "Same")]
    public void Create_InvalidInput_ThrowsArgumentException(string? homeTeam, string? awayTeam)
    {
        Assert.Throws<ArgumentException>(delegate ()
        {
            var _ = Game.Create(homeTeam, awayTeam);
        });
    }
}
