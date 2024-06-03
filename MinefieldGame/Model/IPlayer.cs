public interface IPlayer
{
    string Position { get; }
    int Lives { get; }
    int Moves { get; }
    void Move(IMove moveStrategy);
    void LoseLife();
}