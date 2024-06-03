public class MoveDown : MoveBase
{
    #region Constructors
    public MoveDown(IBoard board) : base(board)
    {
    }
    #endregion Constructors

    #region OverrideMethods
    public override string Move(IPlayer player)
    {
        string position = $"{ParseColumn(player.Position)}{ParseRow(player.Position) - 1}";

        if (board.IsPositionValid(position))
            return position;

        return player.Position;
    }
    #endregion OverrideMethods
}