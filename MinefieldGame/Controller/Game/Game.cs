public class Game : IGame
{
    #region Fields
    private readonly IPlayer player;
    private readonly IBoard board;
    private readonly Dictionary<string, IMove> movementStrategies;
    #endregion Fields 

    #region Constructors
    public Game(IPlayer player, IBoard board, Dictionary<string, IMove> movementStrategies)
    {
        this.player = player;
        this.board = board;
        this.movementStrategies = movementStrategies;
    }
    #endregion Constructors

    #region PublicMethods
    public void PlayGame(string input)
    {
        IMove moveStrategy = movementStrategies[input];
        player.Move(moveStrategy);
        CheckPlayerPosition();
    }

    public bool CheckGameEnd()
    {
        if (player.Position.EndsWith("8"))
        {
            Console.WriteLine($"Congratulations! You reached the other side in {player.Moves} moves.");
            return true;
        }

        if (player.Lives <= 0)
        {
            Console.WriteLine("Game over! You ran out of lives.");
            return true;
        }
        return false;
    }
    public void DisplayGameState()
    {
        Console.WriteLine($"Player position: {player.Position} | Lives: {player.Lives} | Moves: {player.Moves}");
    }
    #endregion PublicMethods

    #region PrivateMethods
    private void CheckPlayerPosition()
    {
        Field? currentField = board.GetField(player.Position);
        if (currentField is Field)
        {
            if (currentField.HasMine)
            {
                player.LoseLife();
                Console.WriteLine($"---> Mine hit! Lives remaining: {player.Lives} <---");
            }
        }
    }
    #endregion PrivateMethods
}