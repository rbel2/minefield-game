public abstract class MoveBase : IMove
{
    #region Fields
    protected IBoard board;
    #endregion Fields

    #region Constructors
    public MoveBase(IBoard board)
    {
        this.board = board;
    }
    #endregion Constructors

    #region AbstractMethods
    public abstract string Move(IPlayer player);
    #endregion AbstractMethods

    #region ProtectedMethods
    protected int ParseRow(string position)
    {
        int row = -1;
        int.TryParse(position.Substring(1), out row);
        return row;
    }

    protected char ParseColumn(string position)
    {
        return position[0];
    }
    #endregion ProtectedMethods
}