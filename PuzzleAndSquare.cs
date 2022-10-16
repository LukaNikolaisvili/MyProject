public class Square
{
    public enum TColor { WHITE, BLACK };
    private Square[,] grid;
    private int N;
    public TColor Color { set; get; } // Either WHITE or BLACK
    public int Clue { set; get; } // Either a clue number or -1 (Note: A BLACK square is always -1)
    public static void Main(string[] args)
    {
        int size, black = 0;
        string[,] arr = { { "   " } };
        Square square = new Square(arr);

        // Enter and validate the grid size (positive interger)
        do
        {
            Console.Write("Enter the dimensions of the grid (i.e. '10' is 10x10) (> 0) → ");
            size = Convert.ToInt32(Console.ReadLine());
        } while (size < 0);
        square.N = size;
        square.Puzzle(size);
        // Enter and validate the number of black squares (positive interger)
        do
        {
            Console.Write("Enter the number of black squares (positive value) → ");
            black = Convert.ToInt32(Console.ReadLine());
        } while (black < 0 || black > (size * size));
        // square.Initialize(black);
        square.PrintGrid();

    }
    // Initialize a square to WHITE and its clue number to -1 (2 marks)
    public Square(string[,] grid)
    {
       
        
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                this.Color = TColor.WHITE;
                this.Clue = -1;
                grid[row, col] = "   ";
            }
        }
    }
    // Create an NxN crossword grid of WHITE squares (4 marks)
    public object Puzzle(int N)
    {
        Square[,] grid = new Square[N, N];
        return grid;
    }
    // Randomly initialize a crossword grid with M black squares (5 marks)
    public void Initialize(int M)
    {
        int BCount = 0;
        Random r = new Random();
        do
        {
            int rX = r.Next(0, M);
            int rY = r.Next(0, M);
            if (grid[rX, rY].Color == TColor.WHITE)
            {
                this.Color = TColor.BLACK;
                grid[rX, rY] = " X ";
                BCount++;
            }
        } while (BCount != M);
    }
    // Number the crossword grid (6 marks)
    public void Number()
    {
        int count = 1;
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (grid[row, col].Color != TColor.BLACK)
                {
                    if (grid[row, col+1].Color != TColor.BLACK || grid[row + 1, col].Color != TColor.BLACK)
                    {
                        Clue = count;
                        if (count >= 10)
                        {
                            grid[row, col] = " " + count;
                        }
                        else
                        {
                            grid[row, col] = " " + count + " ";
                        }
                        count++;
                    }
                }
            }
        }
    }
    // Print out the numbers for the Across and Down clues (in order) (4 marks)
    public void PrintClues()
    {

    }
    // Print out the crossword grid including the BLACK squares and clue numbers (5 marks)
    public void PrintGrid()
    {
        const string line = "-";

        int[,] arr = {{1,2,5,4,3,5,4,7,8,9,1,2,5,4,3,5,4,7,8,9,1,2,5,4,3,5,4,7,8,9},{2,1,7,5,4,8,7,6,8,9,1,2,5,4,3,5,4,7,8,9,1,2,5,4,3,5,4,7,8,9}};

        for (int row = 0; row < N; row++)
        {
            for (int x = 0; x < (N * 4) + 1; x++)
                Console.Write(line);
            Console.WriteLine();
            for (int col = 0; col < N; col++)
            {
                Console.Write(" | ");
                 Console.Write("{0}", arr[row, col]);
            }
            Console.Write(" | ");
            Console.WriteLine();
        }
        for (int x = 0; x < (N * 4) + 1; x++)
            Console.Write(line);
        Console.WriteLine();
        Console.ReadLine();
    }

    public static implicit operator Square(string v)
    {
        throw new NotImplementedException();
    }
    // Return true if the grid is  (à la New York Times); false otherwise (4 marks)
    /*public bool Symmetric()
    {

    } */
}
