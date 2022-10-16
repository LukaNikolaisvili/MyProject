public class MyString
{
    private class Node
    {
        public char item;
        public Node next;
        // Constructor (2 marks) -- node constructor
        public Node(char item) //with one parameter (char item)
        {
            this.item = item;
            next = null;
        }
    }
    private Node front; //the header
    private int length; //----- to track how many characters in String
                        // Initialize with a header node an instance of MyString to the given character array A (4 marks)

    public MyString()
    { // Constructor without any parameters known as Default Constructor. 
        front = null;
        length = 0;
    }

    public MyString(char[] A)
    {
        front = new Node(A[0]);
        Node current = front;
        for (int i = 1; i < A.Length; i++)
        {
            current.next = new Node(A[i]);
            current = current.next;
        }
        length = A.Length;

    }
    // Using a stack, reverse this instance of MyString (6 marks)
    public void Reverse()
    {
        Stack<char> S = new Stack<char>();
        Node CurrentNode = front;
        while (CurrentNode != null)
        {
            S.Push(CurrentNode.item);
            CurrentNode = CurrentNode.next;
        }
        CurrentNode = front;
        while (CurrentNode != null)
        {
            CurrentNode.item = S.Pop();
            CurrentNode = CurrentNode.next;

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
    public void Remove(char toremove)
    {
        if (front == null)
        {
            return;
        }

        while (front.item == toremove)
        {
            front = front.next;
            length--;
        }

        Node current = front;
        while (current.next != null)
        {
            if (current.next.item == toremove)
            {
                current.next = current.next.next;
                length--;
            }
            else
            {
                current = current.next;
            }
        }
    }
    // Return true if obj is both of type MyString and the same as this instance;
    // otherwise false (6 marks)
    public override bool Equals(Object obj)
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
        Node current = front;
        while (current != null)
        {
            Console.Write(current.item);
            current = current.next;
        }
        Console.WriteLine();
    }

    public static void Main(String[] args)
    {
        MyString myString = new MyString();
        while (true)
        {
            // Menu
            Console.WriteLine("#1. Create new word");
            Console.WriteLine("#2. Reverse the word");
            Console.WriteLine("#3. Remove any character from word");
            Console.WriteLine("#4. Show the result (print)");
            Console.WriteLine("#5. Close the application");
            Console.Write("Please Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter some word: ");
                    string input = Console.ReadLine();
                    char[] items = input.ToCharArray();
                    myString = new MyString(items);
                    Console.Write("Word that has been created is: " + "\n " + "------------------------------> ");
                    myString.Print();
                    break;
                case 2:
                    Console.Write("Reversed Word is : " + "\n " + "------------------------------> ");
                    myString.Reverse();
                    myString.Print();
                    break;
                case 3:
                    Console.Write("Enter a letter to remove: ");
                    char c = Convert.ToChar(Console.ReadLine());
                    myString.Remove(c);
                    Console.Write("After removing the letter the word is: " + "\n " + "------------------------------> ");
                    myString.Print();

                    break;
                case 4:
                    Console.Write("Printed word is: " + "\n " + "------------------------------> ");
                    myString.Print();
                    break;

                case 5:
                    Console.WriteLine("Program Exited Successfuly!");
                    return;


                default:
                    Console.WriteLine("Invalid choice Try again!");
                    break;
            }


        }
    }
}
