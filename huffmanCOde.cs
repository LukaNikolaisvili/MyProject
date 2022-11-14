// //Assignment #2 Group Members: --- Luka Nikolaisvili - 0674677  --- Farzhad - , --- Rahman - 

// using huffmanCOde;

// namespace huffmanCOde
// {
//     //Building the node class
//     class Node : IComparable
//     {
//         private char i;
//         private int j;

//         public char Character { get; set; }
//         public int Frequency { get; set; }
//         public Node Left { get; set; }
//         public Node Right { get; set; }

//         //building the node with this parameters 
//         public Node(char Character, int Frequency, Node Left, Node Right)
//         {
//             this.Character = Character;
//             this.Frequency = Frequency;
//             this.Left = Left;
//             this.Right = Right;
//         }

//         public Node(char i, int j)
//         {
//             this.i = i;
//             this.j = j;
//         }

//         public int CompareTo(Object obj)
//         {

//             Node f = (Node)obj;
//             // return f.Frequency.CompareTo(this.Frequency);
//             //if statment checking if the f.frequecy is >
//             if (f.Frequency > Frequency)
//             {
//                 //returning 1
//                 return 1;
//             }
            
//             //else if reversed and Frequency is greater return -1
//             else if (f.Frequency < Frequency)
//             {

//                 return -1;
//             }
//         //if both of them are equal to each other we return 0
//             else if (f.Frequency == Frequency)
//             {

//                 return 0;
//             }

//             else
//             {       
//                 //if anything else it will throw the exception with the message
//                 throw new Exception("this values can not be compared");
//             }


//         }
//     }
// }


// class Huffman
// {
//     private Node HuffmanTree;


//     private Dictionary<char, string> dictionary = new Dictionary<char, string>(); //dictionary to encode text
//     private string text;
//     string theBit = "";


//     public Huffman(string S)
//     {
//         text = S;

//         Build(AnalyzeText()); //invokes the Buld();


//         CreateCodes(HuffmanTree, theBit); //invokes the createCodes()
//     }
//     //analyzetext method    
//     public int[] AnalyzeText()
//     {
//         //creating new array called arrcountain and it has 255 unalocated locations indexes(the length is 255)
//         int[] arrContain = new int[255];

//         //advanced for loop going throug the text and recording char variables called message
//         foreach (char message in text)
//         {

//             //inc message parsing the type of the message to integer
//             arrContain[(int)message]++;
//         }

//         //returning the arrContain 
//         return arrContain;
//     }

//     //build a huffman tree
//     private void Build(int[] arr)
//     {
//         //declaring the variables left and right (Node)

//         Node left, Right;

//     //Assigning and declaring the new collection variable priorityque (Node)
//         PriorityQueue<Node> priorityqueue = new PriorityQueue<Node>(255);


//         for (int i = 0; i < arr.Length; i++)
//         {
//             //if statment for checking if the i-th index of the array is > 0 
//             if (arr[i] > 0)
//             {
//                 //adding new node object to the priority que with this current credentials
//                 priorityqueue.Add(new Node((char)i, arr[i], null, null));
//             }
//         }
//         //checking the condition if the size of the pq is == 1 (boolean ) / true or fals
//         if (priorityqueue.Size() == 1)
//         {
//             // if 1 then we go in the if statment and assigning the Huffman tree to be equal to the pq
//             HuffmanTree = priorityqueue.Front();
//         }

//         // --- this else  builds a binary tree
//         else
//         {

//             while (priorityqueue.Size() > 1)
//             {
//                 //front is assigned to left
//                 left = priorityqueue.Front();
//                 //using method remove to remove
//                 priorityqueue.Remove();
//                 //right is also assigned to front
//                 Right = priorityqueue.Front();
//                 //removing
//                 priorityqueue.Remove();
//                 //adding new node in this format.
//                 priorityqueue.Add(new Node('/', left.Frequency + Right.Frequency, left, Right));
//             }
//             //and then the priority que is assigned to HuffmaNtree for future changes
//             HuffmanTree = priorityqueue.Front();
//         }
//     }
//     public void CreateCodes(Node HuffmanTree, string theBits)
//     {
//         // curr node reffers to the huffmanTree
//         Node curr = HuffmanTree;
//         //curr.left is not equal to null and right also not equal to null we are checking like that if they are not empty
//         if (curr.Left != null && curr.Right != null)
//         {   
//             //assigning 0 on the left using the concatintaion
//             CreateCodes(curr.Left, theBits + "0");
//             //assigning 1 on the right using the concatintaion
//             CreateCodes(curr.Right, theBits + "1");
//         }

//         else
//         {      //otherwise adding current node
//             dictionary.Add(curr.Character, theBits);

//         }

//     }

//     //method for encoding
//     public string Encode(String str)
//     {   
//         //deffining the String variable and assigning it o the literal variable encoded which is assigned to "";
//         string encoded = "";
//         //this is advanced for loop / or as we call it sometimes for each loop ( which goes through the str and looks for the item which is character in this case)
//         foreach (char item in str)
//         {   
            
//             //then assigning this char values to the character char variable
//             char character = (char)item;
//             //again for loop (for each) lookin values in the dictionary using keyvaluePair which is in map
//             foreach (KeyValuePair<char, string> value in dictionary)
//             {
//                 //checking if the character is equal to map.key variable
//                 if (character == value.Key)
//                 //then the encoded is incrementigally added w the value
//                     encoded += value.Value;
//             }
//         }
//         // we are returning the encoded String
//         return encoded;
//     }
//     //Decode the given string of 0s and 1s and return original text
//     public string Decode(String text)
//     {   

//         //assigning current node to Huffman tree
//         Node curr = HuffmanTree;

    
//         Node current = HuffmanTree;
//         //declaring and assigning the String varialbe decoded to empty string to allocate the memory location in heap, for future changes
//         string decoded = "";
//         //advanced for loop going thrue text looking for characters (char)
//         foreach (char character in text)
        
//         {   //if the left == null
//             if (current.Left == null)
//             {   
//                 //incrementigally add the decoded to the current char
//                 decoded += current.Character;
//                 //current assigned to HufmanTree
//                 current = HuffmanTree;
//             }
//             else
//             {   //otherwise if the character is == 0 boolean
//                 if (character == '0')
//                 //current is assgined ot left
//                     current = current.Left;
//                 else   
//                 //otherwise current is assigned to right
//                     current = current.Right;
//             }   
//             //checking if the left == null
//             if (current.Left == null)
//             {   
//                 //decoded incrementigally add to current.character
//                 decoded += current.Character;
//                 //and current is assigned to HuffmanTree
//                 current = HuffmanTree;
//             }
//         }
//         //returning decoded
//         return decoded;
//     }

// }





// public interface IContainer<T>
// {   

//     //method w no return type so void MakeEmpty
//     void MakeEmpty();
//     //method with the boolean retrun type Empty
//     bool Empty();

//     //integer return type method size
//     int Size();
// }
// public interface IPriorityQueue<T> : IContainer<T> where T : IComparable
// {   
//     //method void add 
//     void Add(T item);
    
//     //method no return type void remove
//     void Remove();
//     T Front();
// }
// // PQ - priority que 
// // Binary heap
// public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
// {   //future in need of the encapsulation variables since they are private we have to use them in future refernaces using this. keywords....
//     private int cap;
//     private T[] arr;
//     private int counter;

//     public PriorityQueue(int size)
//     {
//         //assigning same values
//         cap = size;
//         //arr size + 1
//         arr = new T[size + 1];
//         //assigning counter to be equal to 0
//         counter = 0;
//     }
//     private void PercolateUp(int i)
//     {

//         int child = i, parent;
//     //while loop going checking the condition if child > 1 
//         while (child > 1)
//         {      
//             //parent is assigned to middle value of the child
//             parent = child / 2;
//             if (arr[child].CompareTo(arr[parent]) > 0)
//             {
//                 //assigning item to the child index of array
//                 T item = arr[child];
//                 arr[child] = arr[parent];
//                 arr[parent] = item;
//                 //assigning child to parent
//                 child = parent;
//             }
//             else
//                // Otherwise Exiting from the while loop execution
//                 return;
//         }
//     }
//     public void Add(T item)
//     {
//         // checking the condition if the counter is less then 
//         if (counter < cap)
//         {
//             //if so array at index of counter + 1 = item
//             arr[++counter] = item;
//             //calling methid perculate up and passing variable counter
//             PercolateUp(counter);

//         }
//     }
//     private void PercolateDown(int i)
//     {

//         int parent = i, child;
//         //while loop since we dont know times of the iterations we could only use the for each / or while while loop is more convinient in this case
//         //checking if 2 * parent is less or the same number as counter
//         while (2 * parent <= counter)
//         {   //if so assigning child to be equal to twice the ammount of the parent 
//             child = 2 * parent;
//             //if child is less then the count (nested if statment)
//             if (child < counter)
//             //then go in this if statmenet and do the comparison of this statment if arr at this specific index calling compareto method with the arr child is greater then 0
//                 if (arr[child + 1].CompareTo(arr[child]) > 0)
//                     //increase count of child.
//                     child++;
//             //if just array at index of child copared to parent is > 0 
//             if (arr[child].CompareTo(arr[parent]) > 0)

//             {
//                 //item is equal to arr [child]
//                 T item = arr[child];
//                 //assigning child index to parent index of arrays
//                 arr[child] = arr[parent];
//                 //assigning the parent index of array to item
//                 arr[parent] = item;
//                 //and parent now is equal to child 
//                 parent = child;
//             }
//             else

//             //else stop exectuion and get out of the while loop

//                 return;
//         }
//     }

//     public void Remove()
//     {   //Basic check of it its not empty
//         if (!Empty())
//         {   //assigning array's 2nd element to eqaul to the counter -1
//             arr[1] = arr[counter--];
//             //moving down by 1
//             PercolateDown(1);
//         }
//     }
//     public T Front()
//     {
//         //statmenet for checking if its not empty
//         if (!Empty())
//         {   //we are returninig the 2nd element of the arr index (1)
//             return arr[1];
//         }

//         else
//         {   //else returning T
//             return default(T);
//         }

//     }
//     private void BuildHeap()
//     {   
//         //Integer variable c
//         int c;
//         //for loop that goes to tge middle of the counter and untill the c >= 1 it decrements
//         for (c = counter / 2; c >= 1; c--)
//         {
//             //calling the percolatedown method and passing the variable c freshly from loop, so it will do iterations c times.
//             PercolateDown(c);
//         }
//     }
//     public void HeapSort(T[] inputArray)
//     {   
//         // Integer varible K for tracking the count
//         int k;
//         //assigning them variables to be eqaul to each other
//         cap = counter = inputArray.Length;
         
//          //for loop going backwards, cap is same sa the array length, and each time we decrement

//         for (k = cap - 1; k >= 0; k--)
//         {
//             //assgning arr at index K + 1 to inputarray at index of K in the for loop so it will do it K times
//             arr[k + 1] = inputArray[k];

//         }
//         //calling method buldHeap outside the for loop 
//         BuildHeap();

//         //for loop doing iterations till the K<cap times and incrementing the K each time 
//         for (k = 0; k < cap; k++)
//         {

//             //doing the assignment of the inputArray index of K to the front
//             inputArray[k] = Front();
//             //removing
//             Remove();
//         }
//     }

//     public void MakeEmpty()
//     {
//         //resseting the counter back to 0
//         counter = 0;
//     }

//     public bool Empty()
//     {
//         //checking if the counter really equals to 0 if true means its empty.
//         return counter == 0;
//     }
//     public int Size()
//     {
//         //counter counts how many things in there, so if we want to know the size we have to return the counter.
//         //so we are getting the size/length back.
//         return counter;
//     }
// }

// public class PriorityClass
// {
//     private int priorValue;
//     private String name;

//     public PriorityClass(int priority, String name)
//     {   
//         // Encapsulating the private variables to the metod parameters (priority and name)
//         this.name = name;
//         priorValue = priority;
//     }

//     //overriding the existing to string method, so when called toString it will write in this format.
//     public override string ToString()
//     {

//         return name + " --- " + priorValue;
//     }
// }
// //-----------------------------------------------------------------------------
// public class mainMethod
// {   
//     //our program for the testing 
//     static void Main(string[] args)
//     {
            
//         //this is a while loop which will be running unconditionaly, untill you manually not stop the process.
//         while (true)
//         { // checking while everything in this while loop is true continue..
//             // people to know what are the functions that we have (like a menu type of thing )  
//             Console.WriteLine("#1. Encode and decode");
//             Console.WriteLine("#2. Close the application");
//             Console.Write("Please Enter your choice: ");
//             int choice = Convert.ToInt32(Console.ReadLine());
//             switch (choice)
//             { //switch case to do different operation based on the filtering the input of the integer choice 
//                 case 1: //doing encode and decode demonstration same time, in one step to see instand output of the processes
//                     Console.Write("Enter some word to be encoded and decoded afrer : ");
//                     string StringToBeDecoded = Console.ReadLine().ToString();
//                     Huffman huffman = new Huffman(StringToBeDecoded);
//                     //huffman.print();
//                     Console.WriteLine("\n---------------------------");
//                     Console.WriteLine("\n");
//                     Console.WriteLine("Encoded string: " + huffman.Encode(StringToBeDecoded));
//                     Console.WriteLine("Decoded string: " + huffman.Decode(huffman.Encode(StringToBeDecoded)));
//                     Console.WriteLine("\n---------------------------");
                

//                     break;


//                 case 2: // exits the program
//                     Console.WriteLine("Program Exited Successfully!");
//                     return;

//                 default: // in case of wrong input it will always say this and continue the execution
//                     Console.WriteLine("Invalid choice Try again!");
//                     Console.WriteLine("------------------------------");
                    
//                     break;
//             }

//             //dotnet run
//         }
//     }
// }