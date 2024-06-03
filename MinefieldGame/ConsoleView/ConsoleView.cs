public class ConsoleView
{
    #region Fields
    private readonly IGame game;
    #endregion Fields

    #region Constructors
    public ConsoleView(IGame game)
    {
        this.game = game;
    }
    #endregion Constructors

    #region PublicMethods
    public void StartGame()
    {
        Console.WriteLine("Minefield Game");
        Console.WriteLine("Instructions: Use U/D/L/R to move (Up/Down/Left/Right).");
        Console.WriteLine("Avoid mines and reach the other side!");
        Console.WriteLine();

        while (true)
        {
            game.DisplayGameState();

            if (game.CheckGameEnd())
                break;

            Console.Write("Enter direction (U/D/L/R): ");
            string input = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (input == "U" || input == "D" || input == "L" || input == "R")
            {
                game.PlayGame(input);
            }
            else
            {
                Console.WriteLine("Invalid direction. Please try again.");
            }
        }
    }
    #endregion PublicMethods
}