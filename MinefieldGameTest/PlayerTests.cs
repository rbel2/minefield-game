using Moq;

[TestClass]
public class PlayerTests
{
    private Mock<IMove> _moveMock;
    private IPlayer _player;

    [TestInitialize]
    public void TestInitialize()
    {
        _player = new Player("A1", 3);
        _moveMock = new Mock<IMove>();
    }

    [TestMethod]
    public void TestPlayer_PositionChanged()
    {
        string nextPosition = "A2";
        _moveMock.Setup(m => m.Move(_player)).Returns(nextPosition);
        
        _player.Move(_moveMock.Object);

        Assert.AreEqual(nextPosition, _player.Position);
        Assert.AreEqual(1, _player.Moves);
    }

    [TestMethod]
    public void TestPlayer_PositionNotChanged()
    {
        string samePosition = "A1";
        _moveMock.Setup(m => m.Move(_player)).Returns(samePosition);
        
        _player.Move(_moveMock.Object);
        
        Assert.AreEqual(samePosition, _player.Position);
        Assert.AreEqual(0, _player.Moves);
    }

    [TestMethod]
    public void TestPlayer_LifeLost()
    {
        int initialLives = _player.Lives;
        
        _player.LoseLife();

        Assert.AreEqual(initialLives - 1, _player.Lives);
    }
}
