using Moq;

[TestClass]
public class MoveTests
{
    private Mock<IBoard> _boardMock;
    private Mock<IPlayer> _playerMock;
    private IMove _moveDown;
    private IMove _moveLeft;
    private IMove _moveRight;
    private IMove _moveUp;


    [TestInitialize]
    public void TestInitialize()
    {
        _boardMock = new Mock<IBoard>();
        _playerMock = new Mock<IPlayer>();
        _moveDown = new MoveDown(_boardMock.Object);
        _moveLeft = new MoveLeft(_boardMock.Object);
        _moveRight = new MoveRight(_boardMock.Object);
        _moveUp = new MoveUp(_boardMock.Object);
    }

    [TestMethod]
    public void TestMoveDown_ReturnsNewPosition()
    {
        string initialPosition = "B2";
        string newPosition = "B1";
        _playerMock.Setup(p => p.Position).Returns(initialPosition);
        _boardMock.Setup(b => b.IsPositionValid(newPosition)).Returns(true);

        string result = _moveDown.Move(_playerMock.Object);

        Assert.AreEqual(newPosition, result);
    }


    [TestMethod]
    public void TestMoveDown_ReturnsInitialPosition()
    {
        string initialPosition = "B1";
        string newPosition = "B0";
        _playerMock.Setup(p => p.Position).Returns(initialPosition);
        _boardMock.Setup(b => b.IsPositionValid(newPosition)).Returns(false);

        string result = _moveDown.Move(_playerMock.Object);

        Assert.AreEqual(initialPosition, result);
    }

    [TestMethod]
    public void TestMoveLeft_ReturnsNewPosition()
    {
        string initialPosition = "B2";
        string newPosition = "A2";
        _playerMock.Setup(p => p.Position).Returns(initialPosition);
        _boardMock.Setup(b => b.IsPositionValid(newPosition)).Returns(true);

        string result = _moveLeft.Move(_playerMock.Object);

        Assert.AreEqual(newPosition, result);
    }

    [TestMethod]
    public void TestMoveLeft_ReturnsInitialPosition()
    {
        string initialPosition = "B1";
        string newPosition = "B0";
        _playerMock.Setup(p => p.Position).Returns(initialPosition);
        _boardMock.Setup(b => b.IsPositionValid(newPosition)).Returns(false);

        string result = _moveLeft.Move(_playerMock.Object);

        Assert.AreEqual(initialPosition, result);
    }

    [TestMethod]
    public void TestMoveRight_ReturnsNewPosition()
    {
        string initialPosition = "B2";
        string newPosition = "C2";
        _playerMock.Setup(p => p.Position).Returns(initialPosition);
        _boardMock.Setup(b => b.IsPositionValid(newPosition)).Returns(true);

        string result = _moveRight.Move(_playerMock.Object);

        Assert.AreEqual(newPosition, result);
    }

    [TestMethod]
    public void TestMoveRight_ReturnsInitialPosition()
    {
        string initialPosition = "B1";
        string newPosition = "B0";
        _playerMock.Setup(p => p.Position).Returns(initialPosition);
        _boardMock.Setup(b => b.IsPositionValid(newPosition)).Returns(false);

        string result = _moveRight.Move(_playerMock.Object);

        Assert.AreEqual(initialPosition, result);
    }

    [TestMethod]
    public void TestMoveUp_ReturnsNewPosition()
    {
        string initialPosition = "B2";
        string newPosition = "B3";
        _playerMock.Setup(p => p.Position).Returns(initialPosition);
        _boardMock.Setup(b => b.IsPositionValid(newPosition)).Returns(true);

        string result = _moveUp.Move(_playerMock.Object);

        Assert.AreEqual(newPosition, result);
    }

    [TestMethod]
    public void TestMoveUp_ReturnsInitialPosition()
    {
        string initialPosition = "B1";
        string newPosition = "B0";
        _playerMock.Setup(p => p.Position).Returns(initialPosition);
        _boardMock.Setup(b => b.IsPositionValid(newPosition)).Returns(false);

        string result = _moveUp.Move(_playerMock.Object);

        Assert.AreEqual(initialPosition, result);
    }
}
