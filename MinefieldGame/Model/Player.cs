public class Player : IPlayer
{
    #region Fields
    public string Position { get; private set; }
    public int Lives { get; private set; }
    public int Moves { get; private set; }
    #endregion Fields

    #region Constructors
    public Player(string startPosition, int initialLives)
    {
        Position = startPosition;
        Lives = initialLives;
        Moves = 0;
    }
    #endregion Constructors

    #region PublicMethods
    public void Move(IMove moveStrategy)
    {
        string nextPosition = moveStrategy.Move(this);
        if (nextPosition != Position)
        {
            Position = nextPosition;
            Moves++;
        }
    }

    public void LoseLife()
    {
        Lives--;
    }
    #endregion PublicMethods
}
