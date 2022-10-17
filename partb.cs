// // // Group Members: Farzad Imran (0729901), Luka Nikolaisvili (0674677), Abdulrahman Saeed (0706145)  | Assignment 1 Part A
// public class MyString
// {
//     private class Node
//     {
//         public char item;
//         public Node next;
//         // Constructor (2 marks) -- node constructor
//         public Node(char item) //node constructor with one parameter (char item)
//         {
//             this.item = item;
//             next = null;
//         }
//     }
//     private Node front; //the header
//     private int length; //----- to track how many characters in String
//                         // Initialize with a header node an instance of MyString to the given character array A (4 marks)

//     public MyString()
//     { // Constructor without any parameters known as Default Constructor. 
//         front = null;
//         length = 0;
//     }

//     public MyString(char[] charA)
//     {
//         front = new Node(charA[0]);
//         Node current = front;
//         for (int i = 1; i < charA.Length; i++) //loop starting from 1 going till the last length of the charA
//         {
//             current.next = new Node(charA[i]); //referring current.next to the new node object getting index from the Array[i]
//             current = current.next; //moving forward by assigning one more time .next
//         }
//         length = charA.Length; //assigning length to be equal to the CharA length 

//     }
//     // Using a stack, reverse this instance of MyString (6 marks)
//     public void Reverse() //reverse method 
//     {
//         Stack<char> St = new Stack<char>(); //creating new Stack object
//         Node CurrentNode = front; //this is the Node that refers to the front
//         while (CurrentNode != null) //while loop checking the condition if the current node is not empty (null)
//         {
//             St.Push(CurrentNode.item); // then we add new item on current node.item into the stack 
//             CurrentNode = CurrentNode.next; //moving forward with the .next 
//         }
//         CurrentNode = front; //assigninng Current node to be front
//         while (CurrentNode != null) //while loop checking if the Current node is not null/empty
//         {
//             CurrentNode.item = St.Pop(); // we remove the item from the St character stack<>
//             CurrentNode = CurrentNode.next; // assigning the current node to the next element

//         }

//     }
//     // Return the index of the first occurrence of c in this instance; otherwise -1 (4 marks)
//     public int IndexOf(char c) // indexOf method
//     {
//         for (int g = 0; g < length; g++) // for loop that starts from 0 and goes till the length 
//         {
//             if (g == 1 && g.Equals(c)) //checking the condition if true ---> we going in the if statement 
//                 return g; //returning the g from the loop index 
//         }
//         return -1; //same thing as else //returning -1 if the if statement does not turn out to be true 
//     }


//     // Remove all occurrences of c from this instance (4 marks)
//     public void Remove(char toremove) //remove method 
//     {
//         if (front == null) // checking if statement condition if the front is null/empty
//         {
//             return; //we terminate 
//         }

//         while (front.item == toremove) // while loop checking the condition if the front.item is equal to the character that we want to remove while true --->
//         {
//             front = front.next; // assigning the front to be the next element 
//             length--; //decrementing the length 
//         }

//         Node current = front; //creating assigning front to be the Current Node
//         while (current.next != null) // if the current node that we are at a.t.m is not empty/null we going in the while loop
//         {
//             if (current.next.item == toremove) //and checking the condition if the current.next.item is the char that we are willing to remove if true --->
//             {
//                 current.next = current.next.next; //moving to the next node 
//                 length--; //decrementing the length 
//             }
//             else //otherwise 
//             {
//                 current = current.next; // current is the node.next
//             }
//         }
//     }
//     // Return true if obj is both of type MyString and the same as this instance;
//     // otherwise false (6 marks)
//     public override bool Equals(Object objecT)
//     {
//         if (objecT == null) //checking if the object is empty/null
//         {
//             throw new ArgumentNullException( //not to crush we are throwing the exception 
//                 nameof(objecT)); //prints out the name of the object 

//         }

//         if (objecT is char) // if the Object is character 
//         {
//             char charA = (char)objecT; // and charA is the char object 
//         }
//         return true; //returning true 

//     }
//     // Print out this instance of MyString (3 marks)
//     public void Print() //print method 
//     {
//         Node current = front; //assigning current node to be front
//         while (current != null) // while loop checking if the current is not empty, if true ---> 
//         {
//             Console.Write(current.item); //printing out current item 
//             current = current.next; //moving forward
//         }
//         Console.WriteLine(); 
//     }

//     public static void Main(String[] args) //main method "Driving force"
//     {
//         MyString stringobj = new MyString(); //declaring the object calling it stringobj
//         while (true) // checking while everything in this while loop is true continue..
//         {
//             // people to know what are the functions that we have (like a menu type of thing )  
//             Console.WriteLine("#1. Create new word");  
//             Console.WriteLine("#2. Reverse the word");
//             Console.WriteLine("#3. Remove any character from word");
//             Console.WriteLine("#4. Show the result (print)");
//             Console.WriteLine("#5. Close the application");
//             Console.Write("Please Enter your choice: ");

//             int choice = Convert.ToInt32(Console.ReadLine());
//             switch (choice) //switch case to do different operation based on the filtering the input of the integer choice 
//             {
//                 case 1:
//                     Console.Write("Enter some word: ");
//                     string input = Console.ReadLine();
//                     char[] items = input.ToCharArray();
//                     stringobj = new MyString(items);
//                     Console.Write("Word that has been created is: " + "\n " + "------------------------------> ");
//                     stringobj.Print();
//                     break;
//                 case 2:
//                     Console.Write("Reversed Word is : " + "\n " + "------------------------------> ");
//                     stringobj.Reverse();
//                     stringobj.Print();
//                     break;
//                 case 3:
//                     Console.Write("Enter a letter to remove: ");
//                     char c = Convert.ToChar(Console.ReadLine());
//                     stringobj.Remove(c);
//                     Console.Write("After removing the letter the word is: " + "\n " + "------------------------------> ");
//                     stringobj.Print();

//                     break;
//                 case 4:
//                     Console.Write("Printed word is: " + "\n " + "------------------------------> ");
//                     stringobj.Print();
//                     break;

//                 case 5:
//                     Console.WriteLine("Program Exited Successfully!");
//                     return;

//                 // case 6:

//                 //    checks if they equal

//                 // return;

//                 default:
//                     Console.WriteLine("Invalid choice Try again!");
//                     break;
//             }


//         }
//     }
// }
