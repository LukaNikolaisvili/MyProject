// Group Members: Farzad Imran (0729901), Luka Nikolaisvili (0674677), Abdulrahman Saeed (0706145)  | Assignment 1 Part A
public class Square
{
    public enum TColor { WHITE, BLACK };
    private Square[,] grid;
    private int N;
    public TColor Color { set; get; } // Either WHITE or BLACK
    public int Clue { set; get; } // Either a clue number or -1 (Note: A BLACK square is always -1)
    public string Value { set; get; } // Gives each Square a value to print, X, Blank or a Number.
    
    public static void Main(string[] args)
    {
        int size, black = 0;

        Square square = new Square();

        // Enter and validate the grid size (positive interger)
        do
        {
            Console.Write("Enter the dimensions of the grid (i.e. '10' is 10x10) (> 0) → ");
            size = Convert.ToInt32(Console.ReadLine());
        } while (size < 0);
        square.N = size;
        square.Puzzle(size);
        // Enter and validate the number of black squares (positive integer, Cannot be larger than the grid dimenstion)
        do
        {
            Console.Write("Enter the number of black squares (positive value) → ");
            black = Convert.ToInt32(Console.ReadLine());
        } while (black < 0 || black > (size * size));
        square.Initialize(black);
        square.Number();
        square.PrintGrid();
        square.PrintClues();
        Console.WriteLine("Is the grid symmetrical? {0}", square.Symmetric());
        Console.ReadLine();

    }
    // Initialize a square to WHITE and its clue number to -1 (2 marks)
    public Square()
    {

        this.Color = TColor.WHITE;
        this.Clue = -1;
        this.Value = "   ";
    }


    // Create an NxN crossword grid of WHITE squares (4 marks)
    public void Puzzle(int N)
    {
        this.N = N;

        grid = new Square[N+1, N+1];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                grid[i, j] = new Square();
            }
        }
        for (int i = 0; i <= N; i++)
        {
            grid[i, N] = new Square();
        }
    }
    // Randomly initialize a crossword grid with M black squares (5 marks)
    public void Initialize(int M)
    {
        int BCount = 0;
        Random r = new Random();
        if (M != 0)
        {
            do
            {
                int rX = r.Next(0, N);
                int rY = r.Next(0, N);
                if (grid[rX, rY].Color.Equals(TColor.WHITE))
                {
                    grid[rX, rY].Color = TColor.BLACK;
                    grid[rX, rY].Value = " X ";
                    BCount++;
                }
            } while (BCount != M);
        }
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

                        Clue = count;
                        if (count >= 10)
                        {
                            grid[row, col].Clue = count;
                            grid[row, col].Value = " " + count;
                        }
                        else
                        {
                            grid[row, col].Clue = count;
                            grid[row, col].Value = " " + count + " ";
                        }
                        count++;
                }
            }
        }
    }
    // Print out the numbers for the Across and Down clues (in order) (4 marks)
    public void PrintClues()
    {
        Console.WriteLine("Across");
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (grid[row, col].Clue != -1)
                {
                    if (grid[row, col].Color != TColor.BLACK)
                    {
                        Console.Write(grid[row, col].Value + " ");
                    }
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine("Down");
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (grid[col, row].Clue != -1)
                {
                    if (grid[row, col].Color != TColor.BLACK)
                    {
                        Console.Write(grid[row, col].Value + " ");
                    }
                }
            }
        }
        Console.WriteLine();
    }

    // Print out the crossword grid including the BLACK squares and clue numbers (5 marks)
    public void PrintGrid()
    {
        const string line = "-";
        for (int row = 0; row < N; row++)
        {
            for (int x = 0; x < (N * 4) + 1; x++)
                Console.Write(line);


            Console.WriteLine();
            for (int col = 0; col < N; col++)
            {
                Console.Write("|");
                Console.Write("{0}", grid[row, col].Value);
            }
            Console.Write("|");
            Console.WriteLine();
        }
        for (int x = 0; x < (N * 4) + 1; x++)
            Console.Write(line);
        Console.WriteLine();
    }

    // Return true if the grid is  (à la New York Times); false otherwise (4 marks)
    public bool Symmetric()
    {

        bool Result = false;
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (grid[row, col].Color.Equals(TColor.BLACK))
                {
                    if ((grid[row, col].Color.Equals(TColor.BLACK)) && (grid[col, row].Color.Equals(TColor.BLACK)))
                    {
                        Result = true;
                    }
                    else
                    {
                        Result = false;
                        return Result;
                    }
                }
            }
        }
        return Result;

    }
}