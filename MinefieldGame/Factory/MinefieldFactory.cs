public sealed class MinefieldFactory
{
    #region Fields
    private static readonly MinefieldFactory instance = new MinefieldFactory();
    IPlayer _player;
    IBoard _board;
    Dictionary<string, IMove> _movementStrategies;
    IGame _game;
    ConsoleView _consoleView;

    #endregion Fields

    #region Instance
    public static MinefieldFactory Instance
    {
        get
        {
            return instance;
        }
    }

    #endregion Instance

    #region Constructors

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static MinefieldFactory() { }
    private MinefieldFactory() { }

    #endregion Constructors

    #region Properties

    public IPlayer Player
    {
        get
        {
            if (instance._player == null)
            {
                instance._player = new Player("A1", 3);
            }
            return instance._player;
        }
    }

    public IBoard Board
    {
        get
        {
            if (instance._board == null)
            {
                instance._board = new Board(8, 8);
            }
            return instance._board;
        }
    }

    public Dictionary<string, IMove> MovementStrategies
    {
        get
        {
            if (instance._movementStrategies == null)
            {
                _movementStrategies = new Dictionary<string, IMove>
                    {
                        {"U", new MoveUp(_board)},
                        {"D", new MoveDown(_board)},
                        {"L", new MoveLeft(_board)},
                        {"R", new MoveRight(_board)}
                    };
            }
            return instance._movementStrategies;
        }
    }

    public IGame Game
    {
        get
        {
            if (instance._game == null)
            {
                instance._game = new Game(_player, _board, _movementStrategies);
            }
            return instance._game;
        }
    }

    public ConsoleView ConsoleView
    {
        get
        {
            if (instance._consoleView == null)
            {
                instance._consoleView = new ConsoleView(_game);
            }
            return instance._consoleView;
        }
    }

    #endregion Properties

}