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

        // Enter and validate the grid size (positive integer)
        do
        {
            Console.Write("Enter the dimensions of the grid (i.e. '10' is 10x10) (> 0) → ");
            size = Convert.ToInt32(Console.ReadLine());
        } while (size < 0);
        square.N = size;
        square.Puzzle(size); //Initializes the grid
        // Enter and validate the number of black squares (positive integer, Cannot be larger than the grid dimenstion)
        do
        {
            Console.Write("Enter the number of black squares (positive value) → ");
            black = Convert.ToInt32(Console.ReadLine());
        } while (black < 0 || black > (size * size));
        square.Initialize(black); // Begins populating with black squares
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
        this.Value = "   "; // Sets the value to a blank for a white square
    }


    // Create an NxN crossword grid of WHITE squares (4 marks)
    public void Puzzle(int N)
    {
        this.N = N;

        grid = new Square[N + 1, N + 1]; // the space initializaed is 1 row and collumn larger for
                                        //  an invisble border (See Line
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                grid[i, j] = new Square();
            }
        }
        // The following code below is for printing a border on the bottom and right edges of the grid.
        for (int i = 0; i <= N; i++)
        {
            grid[i, N] = new Square();
            grid[i, N].Color = TColor.BLACK;
            grid[i, N].Value = " X ";
        }
        for (int j = 0; j <= N; j++)
        {
            grid[N, j] = new Square();
            grid[N, j].Color = TColor.BLACK;
            grid[N, j].Value = " X ";
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
                int rX = r.Next(0, N); // Generates a random X coordinate
                int rY = r.Next(0, N); // Generates a random Y coordinate
                if (grid[rX, rY].Color.Equals(TColor.WHITE)) // If the the square is black,
                {                                           //  the count will not increase and it will try again.
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
                    if (grid[row + 1, col].Color != TColor.BLACK || grid[row, col + 1].Color != TColor.BLACK) // A clue will not be printed if there is a black square to the right or below.
                    {
                        Clue = count;
                        if (count >= 10)
                        {
                            grid[row, col].Clue = count;
                            grid[row, col].Value = " " + count;
                        }
                        else // this else statement is purely for spacing, as each cell is 3 spaces between lines.
                        {
                            grid[row, col].Clue = count;
                            grid[row, col].Value = " " + count + " ";
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
        Console.WriteLine("Across");
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (grid[row, col].Clue != -1)
                {
                    if (grid[row, col + 1].Color != TColor.BLACK) // if the next square over is black, it will not print the clue.
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
                if (grid[row, col].Clue != -1)
                {
                    if (grid[row + 1, col].Color != TColor.BLACK) // if the next square down is black, it will not print the clue.
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
        const string line = "-";            // For horizontal lines, N is multiplied by 4 as each clue is 4 spaces long.
        for (int row = 0; row < N; row++)
        {
            for (int x = 0; x < (N * 4) + 1; x++)
                Console.Write(line);


            Console.WriteLine();
            for (int col = 0; col < N; col++)
            {
                Console.Write("|");
                Console.Write("{0}", grid[row, col].Value);  // Printing of the Crossword values for each cell.
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
                if (grid[row, col].Color.Equals(TColor.BLACK)) // Only starts comparing if square is black.
                {
                    if ((grid[row, col].Color.Equals(TColor.BLACK)) && (grid[col, row].Color.Equals(TColor.BLACK))) // Switching Axes to test for symmetry.
                    {
                        Result = true;
                    }
                    else
                    {
                        Result = false;  // After the first instance of unsymmetric behavior,
                        return Result;  //  the progame will break the loop and return false.
                    }
                }
            }
        }
        return Result;
    }
}