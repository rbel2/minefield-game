MinefieldFactory instance = MinefieldFactory.Instance;
IPlayer player = instance.Player;
IBoard board = instance.Board;
Dictionary<string, IMove> movementStrategies = instance.MovementStrategies;
IGame game = instance.Game;
ConsoleView consoleView = instance.ConsoleView;
consoleView.StartGame();
