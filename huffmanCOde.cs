//Assignment #2 Group Members: --- Luka Nikolaisvili - 0674677  --- Farzhad - , --- Rahman - 

using huffmanCOde;

namespace huffmanCOde
{

    class Node : IComparable
    {
        private char i;
        private int v;

        public char Character { get; set; }
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

       
        public Node(char Character, int Frequency, Node Left, Node Right)
        {
            this.Character = Character;
            this.Frequency = Frequency;
            this.Left = Left;
            this.Right = Right;
        }

        public Node(char i, int v)
        {
            this.i = i;
            this.v = v;
        }

        public int CompareTo(Object obj)
        {

            Node f = (Node)obj;
            return f.Frequency.CompareTo(this.Frequency);
            // if (f.Frequency > Frequency)
            // {

            //     return 1;
            // }

            // else if (f.Frequency < Frequency)
            // {

            //     return -1;
            // }

            // else if (f.Frequency == Frequency)
            // {

            //     return 0;
            // }

            // else
            // {

            //     throw new Exception("They can not be compared");
            // }

        
        }
    }
}


class Huffman
{
    private Node HuffmanTree;


    private Dictionary<char, string> dictionary = new Dictionary<char, string>(); //dictionary to encode text
    private string text;
    string theBit = "";
   

    public Huffman(string S)
    {
        text = S;

        Build(AnalyzeText()); //invokes the Buld();


        CreateCodes(HuffmanTree, theBit); //invokes the createCodes()
    }

    private int[] AnalyzeText()
    {

        int[] arrContain = new int[255];


        foreach (char m in text)
        {


            arrContain[(int)m]++;
        }


        return arrContain;
    }

    //build a huffman tree
    private void Build(int[] arr)
    {


        Node left, Right;

        PriorityQueue<Node> priorityqueue = new PriorityQueue<Node>(255);


        for (int i = 32; i < arr.Length; i++)
        {

            if (arr[i] > 0)
            {

                priorityqueue.Add(new Node((char)i, arr[i],null,null));
            }
        }

        if (priorityqueue.Size() == 1)
        {

            HuffmanTree = priorityqueue.Front();
        }

        // --- this else  builds a binary tree
        else
        {

            while (priorityqueue.Size() > 1)
            {

                left = priorityqueue.Front();
                priorityqueue.Remove();
                Right = priorityqueue.Front();
                priorityqueue.Remove();
                priorityqueue.Add(new Node('/', left.Frequency + Right.Frequency, left, Right));
            }

            HuffmanTree = priorityqueue.Front();
        }
    }
    private void CreateCodes(Node HuffmanTree, string theBits)
    {

        Node curr = HuffmanTree;
        //traverses through the binary tree
        if (curr.Left != null && curr.Right != null)
        {
            CreateCodes(curr.Left, theBits + "0");
            CreateCodes(curr.Right, theBits + "1");
        }

        else
        {
            dictionary.Add(curr.Character, theBits);

        }

    }
    public string Encode(String str)
    {
        string encoded = "";

        foreach (char item in str)
        {

            char character = (char)item;

            foreach (KeyValuePair<char, string> value in dictionary)
            {

                if ( character== value.Key)
                    encoded += value.Value;
            }
        }

        return encoded;
    }
    //Decode the given string of 0s and 1s and return original text
    public string Decode(String text)
    {
        Node curr = HuffmanTree;
     

        Node current = HuffmanTree;
        string decoded = "";

        foreach (char ch in text)
        {
            if (current.Left == null)
            {
                decoded += current.Character;
                current = HuffmanTree;
            }
            else
            {
                if (ch == '0')
                    current = current.Left;
                else
                    current = current.Right;
            }
            if (current.Left == null)
            {
                decoded += current.Character;
                current = HuffmanTree;
            }
        }

        return decoded;
    }
}
 
public interface IContainer<T>
{
    void MakeEmpty();
    bool Empty();
    int Size();
}
public interface IPriorityQueue<T> : IContainer<T> where T : IComparable
{
    void Add(T item);
    void Remove();
    T Front();
}
// Priority Queue
// Implementation: Binary heap
public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
{
    private int cap;
    private T[] arr;
    private int counter;

    public PriorityQueue(int size)
    {

        cap = size;
        arr = new T[size + 1];
        counter = 0;
    }
    private void PercolateUp(int i)
    {

        int child = i, parent;

        while (child > 1)
        {
            parent = child / 2;
            if (arr[child].CompareTo(arr[parent]) > 0)
            {

                T item = arr[child];
                arr[child] = arr[parent];
                arr[parent] = item;
                child = parent;
            }
            else

                return;
        }
    }
    public void Add(T item)
    {

        if (counter < cap)
        {

            arr[++counter] = item;
            PercolateUp(counter);

        }
    }
    private void PercolateDown(int i)
    {

        int parent = i, child;
        while (2 * parent <= counter)
        {
            child = 2 * parent;
            if (child < counter)
                if (arr[child + 1].CompareTo(arr[child]) > 0)

                    child++;

            if (arr[child].CompareTo(arr[parent]) > 0)

            {

                T item = arr[child];
                arr[child] = arr[parent];
                arr[parent] = item;
                parent = child;
            }
            else

                return;
        }
    }

    public void Remove()
    {
        if (!Empty())
        {
            arr[1] = arr[counter--];
            PercolateDown(1);
        }
    }
    public T Front()
    {

        if (!Empty())
        {
            return arr[1];
        }

        else
        {
            return default(T);
        }

    }
    private void BuildHeap()
    {
        int i;
        for (i = counter / 2; i >= 1; i--)
        {

            PercolateDown(i);
        }
    }
    public void HeapSort(T[] inputArray)
    {
        int i;

        cap = counter = inputArray.Length;

        for (i = cap - 1; i >= 0; i--)
        {

            arr[i + 1] = inputArray[i];

        }
        BuildHeap();

        for (i = 0; i < cap; i++)
        {

            inputArray[i] = Front();
            Remove();
        }
    }

    public void MakeEmpty()
    {

        counter = 0;
    }

    public bool Empty()
    {

        return counter == 0;
    }
    public int Size()
    {

        return counter;
    }
}

public class PriorityClass : IComparable
{
    private int priorValue;
    private String name;

    public PriorityClass(int priority, String name)
    {
        this.name = name;
        priorValue = priority;
    }
    public int CompareTo(Object obj)
    {

        PriorityClass other = (PriorityClass)obj;
        return priorValue - other.priorValue;
    }
    public override string ToString()
    {

        return name + " --- " + priorValue;
    }
}
//-----------------------------------------------------------------------------
public class mainMethod
{
    static void Main(string[] args)
    {

        while (true)
        { // checking while everything in this while loop is true continue..
            // people to know what are the functions that we have (like a menu type of thing )  
            Console.WriteLine("#1. Encode");
            Console.WriteLine("#2. Decode");
            Console.WriteLine("#3. Equals");
            Console.WriteLine("#4. Close the application");
            Console.Write("Please Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            { //switch case to do different operation based on the filtering the input of the integer choice 
                case 1:
                    Console.Write("Enter some word to : ");
                    String encode = Console.ReadLine();
                    Huffman huffman = new Huffman(encode);
                    Console.WriteLine(huffman.Encode(encode));
                    break;
                case 2:
                    Console.Write("decode: ");
                    String decode = Console.ReadLine();
                    huffman = new Huffman(decode);
                    Console.WriteLine(huffman.Decode(decode));
                    break;
                case 3:
                    Console.Write("Equals: ");
                    String isEqual = Console.ReadLine();
                    huffman = new Huffman(isEqual);
                    Console.WriteLine(huffman.Equals(isEqual));
                    break;

                case 4:
                    Console.WriteLine("Program Exited Successfully!");
                    return;

                default:
                    Console.WriteLine("Invalid choice Try again!");
                    Console.WriteLine("------------------------------");
                    break;
            }


        }
    }
}