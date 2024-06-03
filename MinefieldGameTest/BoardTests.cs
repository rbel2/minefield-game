[TestClass]
public class BoardTests
{
    private IBoard _board;

    [TestInitialize]
    public void TestInitialize()
    {
        _board = new Board(5, 5);
    }

    [TestMethod]
    public void TestBoard_ReturnsField()
    { 
        string position = "A1";
        var result = _board.GetField(position);
        
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void TestBoard_ReturnsNull()
    {
        string position = "Z9";
        var result = _board.GetField(position);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void TestBoard_ValidPosition()
    {
        string position = "B2";
        bool isValid = _board.IsPositionValid(position);

        Assert.IsTrue(isValid);
    }

    [TestMethod]
    public void TestBoard_InvalidPosition()
    {
        string position = "Y6";
        bool isValid = _board.IsPositionValid(position);
        
        Assert.IsFalse(isValid);
    }
}
