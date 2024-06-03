using Moq;

namespace MinefieldGameTest;

[TestClass]
public class GameTests
{
    private Mock<IPlayer> _playerMock;
    private Mock<IBoard> _boardMock;
    private Dictionary<string, IMove> _movementStrategies;
    private IGame _game;

    [TestInitialize]
    public void Setup()
    {
        _playerMock = new Mock<IPlayer>();
        _boardMock = new Mock<IBoard>();
        _movementStrategies = new Dictionary<string, IMove>();
        _game = new Game(_playerMock.Object, _boardMock.Object, _movementStrategies);
    }

    [TestMethod]
    public void TestGame_MovePlayerInvoked()
    {   
        var moveMock = new Mock<IMove>();
        _movementStrategies.Add("input", moveMock.Object);
        
        _game.PlayGame("input");
        
        _playerMock.Verify(p => p.Move(moveMock.Object), Times.Once);
    }

    [TestMethod]
    public void TestGame_GameEnded()
    {
        _playerMock.Setup(p => p.Lives).Returns(0);
        _playerMock.Setup(p => p.Position).Returns("A8");
        
        var result = _game.CheckGameEnd();
        
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestGame_GameNotEnded()
    {
        _playerMock.Setup(p => p.Position).Returns("A2");
        _playerMock.Setup(p => p.Lives).Returns(1);
        
        var result = _game.CheckGameEnd();
        
        Assert.IsFalse(result);
    }
}
