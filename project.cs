// Group Members: Farzad Imran (0729901), Luka (xxxxxxx), Rahman (xxxxxxx)  | Assignment 1

public enum TColor { WHITE, BLACK };
public class Square
{
    public TColor Color { set; get; } // Either WHITE or BLACK
    public int Number { set; get; } // Either a clue number or -1 (Note: A BLACK square is always -1)
                                    // Initialize a square to WHITE and its clue number to -1 (2 marks)
    public Square()
    {
        this.Color = TColor.WHITE;
        this.Number = -1;
    }

    public class Puzzle
    {
        private Square[,] grid;
        private int N;
        // Create an NxN crossword grid of WHITE squares (4 marks)
        public Puzzle(int N)
        {
        // Enter and validate the grid size (positive interger)
            do
            {
                Console.Write("Enter the dimensions of the grid (i.e. '10' is 10x10) (> 0) → ");
                N = Convert.ToInt32(Console.ReadLine());
            } while (N < 0);
            grid = new Square[N, N]; 
        }
        // Randomly initialize a crossword grid with M black squares (5 marks)
        public void Initialize(int M)
        {

        }
        // Number the crossword grid (6 marks)
        // public void Number ( ) { … }
        // Print out the numbers for the Across and Down clues (in order) (4 marks)
        public void PrintClues() 
        { 

        }
        // Print out the crossword grid including the BLACK squares and clue numbers (5 marks)
        public void PrintGrid() 
        { 

        }
        // Return true if the grid is  (à la New York Times); false otherwise (4 marks)
        public bool Symmetric()
         {

         }
    }

}

public class MyString
{
    private class Node
    {
        public char item;
        public Node next;
        // Constructor (2 marks)
        public Node()
        {
            this.item = item;
            this.next = next;



        }
    }
    private Node front; // Reference to the first (header) node
    private int length; // Number of characters in MyString
                        // Initialize with a header node an instance of MyString to the given character array A (4 marks)
    public MyString(char[] A)
    {
        Node header = front;

        this.length = length;


    }
    // Using a stack, reverse this instance of MyString (6 marks)
    public void Reverse()
    {
        Stack<char> S;

    }
    // Return the index of the first occurrence of c in this instance; otherwise -1 (4 marks)
    public int IndexOf(char c){

      

        for (int i = 0; i < length; i++){

            if (i == 1 && i.Equals(c)){
            
                return i;
            }

            else { 

                return -1;
            }
        }

    }
    // Remove all occurrences of c from this instance (4 marks)
    public void Remove(char c)
    {

    }
    // Return true if obj is both of type MyString and the same as this instance;
    // otherwise false (6 marks)
    public override bool Equals(object obj)
    {
        if(obj == null)
        {
            throw new ArgumentNullException(
                nameof(obj));

        }

        if(obj is char)
        {
            char c1 = (char)obj;
        }

        return true;


    }


    // Print out this instance of MyString (3 marks)
    public void Print()
    {

        Console.WriteLine(MyString.Node.ReferenceEquals(this, front));

    }
}
