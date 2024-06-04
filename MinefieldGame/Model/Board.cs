public class Board : IBoard
{
    #region Fields
    private readonly Dictionary<string, List<Field>> fields;
    #endregion Fields

    #region Constructors
    public Board(int rows, int cols)
    {
        fields = new Dictionary<string, List<Field>>();

        InitializeFields(rows, cols);
        PlaceMines(rows, cols);
    }
    #endregion Constructors

    #region PublicMethods

    public Field? GetField(string position)
    {
        int row = -1;
        int.TryParse(position.Substring(1), out row);

        string col = position.Substring(0, 1);
        if (this.fields.TryGetValue(col, out List<Field> fields))
        {
            if (row > 0 && row <= fields.Count)
                return fields[row - 1];
        }
        return null;
    }

    public bool IsPositionValid(string position)
    {
        int row = -1;
        int.TryParse(position.Substring(1), out row);

        string col = position.Substring(0, 1);
        if (this.fields.TryGetValue(col, out List<Field> fields))
        {
            if (row > 0 && row <= fields.Count)
                return true;
        }

        return false;
    }
    #endregion PublicMethods
    
    #region PrivateMethods
    private void InitializeFields(int rows, int cols)
    {
        for (int col = 1; col <= cols; col++)
        {
            string key = $"{(char)(col + 64)}";
            fields[key] = new List<Field>(rows);

            for (int row = 1; row <= rows; row++)
            {
                fields[key].Add(new Field());
            }
        }
    }

    private void PlaceMines(int rows, int cols)
    {
        Random random = new Random();
        int numMines = rows * cols / 10; // Mine placment ratio
        for (int i = 0; i < numMines; i++)
        {
            int randomRow = random.Next(1, rows);
            int randomCol = random.Next(1, cols);
            string key = $"{(char)(randomCol + 64)}";
            Console.WriteLine($"Placing mine at position {key}{randomRow + 1}");
            fields[key][randomRow].HasMine = true;
        }
    }

    #endregion PrivateMethods
}