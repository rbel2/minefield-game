public interface IBoard
{
    Field? GetField(string position);
    bool IsPositionValid(string position);
}
