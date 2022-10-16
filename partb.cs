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
        Stack<char> S = new Stack<char>();
        Stack<char> R = new Stack<char>();

        char topValue = S.First();
      
         S.Push('P');
         S.Push('Q');
         S.Push('R');
         Console.WriteLine("Current stack: ");
         R.Push(S.First());
         foreach(char c in S) {
            Console.Write(c + " ");
         }
         Console.WriteLine();
         while (S.Count != 0) {
            R.Push(S.Pop());
         }
         Console.WriteLine("Reversed stack: ");
         foreach(char c in R) {
            Console.Write(c + " ");
         
      
   
}
       
    }
    // Return the index of the first occurrence of c in this instance; otherwise -1 (4 marks)
    public int IndexOf(char c)
    {
        for (int i = 0; i < length; i++)
        {
            if (i == 1 && i.Equals(c))
                return i;
        }
        return -1;
    }
    // Remove all occurrences of c from this instance (4 marks)
    public void Remove(char c)
    {
        String Str = "";
        while (c.Equals('c'))
        {
            Str = Str.Replace(c.ToString(), "");
            Console.Write(Str);
        }
    }
    // Return true if obj is both of type MyString and the same as this instance;
    // otherwise false (6 marks)
    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(
                nameof(obj));

        }

        if (obj is char)
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

    public static void Main(String[] args)
    {
        char[] arr = { 'c', 'd', 'e' };
        MyString b = new MyString(arr);

        Console.WriteLine(b.IndexOf('c'));
        //MyString.Print();
        Console.ReadLine();
    }

}