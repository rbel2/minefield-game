public class MoveRight : MoveBase
{
    #region Constructors
    public MoveRight(IBoard board) : base(board)
    {
    }
    #endregion Constructors

    #region OverrideMethods
    public override string Move(IPlayer player)
    {
        string position = $"{(char)(ParseColumn(player.Position) + 1)}{ParseRow(player.Position)}";

        if (board.IsPositionValid(position))
            return position;

        return player.Position;
    }
    #endregion OverrideMethods

}