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

    [Test]
    public void SetScore_ValidInput_ScoreIsUpdated()
    {
        // arrange
        var game = Game.Create("HomeTeam", "AwayTeam");
        var newHomeScore = 3;
        var newAwayScore = 3;

        // act
        var result = game.SetScore(newHomeScore, newAwayScore);

        // assert
        Assert.That(result, Is.EqualTo(true));
        Assert.That(game.HomeScore, Is.EqualTo(newHomeScore));
        Assert.That(game.AwayScore, Is.EqualTo(newAwayScore));
    }

    [Test]
    public void SetScore_ValidInput_TotalScoreIsSumOfHomeScoreAndAwayScore()
    {
        // arrange
        var game = Game.Create("HomeTeam", "AwayTeam");
        var newHomeScore = 5;
        var newAwayScore = 8;
        var expectedTotalScore = 13;

        // act
        var result = game.SetScore(newHomeScore, newAwayScore);

        // assert
        Assert.That(game.TotalScore, Is.EqualTo(expectedTotalScore));
    }

    [Test]
    [TestCase(-1, 0)]
    [TestCase(0, -1)]
    [TestCase(-1, -1)]
    public void SetScore_NegativeScore_SetScoreUnsuccessful(int newHomeScore, int newAwayScore)
    {
        // arrange
        var game = Game.Create("HomeTeam", "AwayTeam");

        // act
        var result = game.SetScore(newHomeScore, newAwayScore);

        // assert
        Assert.That(result, Is.EqualTo(false));
        Assert.That(game.HomeScore, Is.EqualTo(0));
        Assert.That(game.AwayScore, Is.EqualTo(0));
    }

    [Test]
    public void SetScore_FinishedGame_YouCantUpdateScoreForFinishedGame()
    {
        // arrange
        var game = Game.Create("HomeTeam", "AwayTeam");
        game.SetScore(3, 3);
        game.Finish();

        // act
        var result = game.SetScore(4, 4);

        // assert
        Assert.That(result, Is.EqualTo(false));
        Assert.That(game.HomeScore, Is.EqualTo(3));
        Assert.That(game.AwayScore, Is.EqualTo(3));
    }

    [Test]
    public void Finish_GameInProgress_IsInProgressSetToFalse()
    {
        // arrange
        var homeTeam = "HomeTeam";
        var awayTeam = "AwayTeam";
        var game = Game.Create(homeTeam, awayTeam);

        // act
        game.Finish();

        // assert
        Assert.IsFalse(game.IsInProgress);
    }
}
