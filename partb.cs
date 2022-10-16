// public class NewBaseType
// {
//     // private Node front; // Reference to the first (header) node
//     private int length; // Number of characters in MyString



//     public static void Main(String[] args)
//     {





//         char[] arr = { 'c', 'd' };

//         partb b = new partb();

//         b.Reverse();




//     }


//     public override bool Equals(object obj)
//     {

//         // Return true if obj is both of type MyString and the same as this instance;
//         // otherwise false (6 marks)


//         if (obj.Equals(obj))
//         {
//             return true;
//         }

//         else
//         {

//             return false;
//         }


//         // Print out this instance of MyString (3 marks)

//     }

//     // Return the index of the first occurrence of c in this instance; otherwise -1 (4 marks)
//     public int IndexOf(char c)
//     {

//         if (c.Equals('c'))
//         {
//             return IndexOf('c');
//         }

//         else
//         {
//             return -1;
//         }


//     }
//     // Initialize with a header node an instance of MyString to the given character array A (4 marks)



//     // public MyString myprojet(char[] A)
//     // {


//     //     return A.;




//     // }


//     public void Print()
//     {
//         //print the instance of the MyString


//     }


//     // Remove all occurrences of c from this instance (4 marks)
//     public void Remove(char c)
//     {
//         String Str = "";
//         while (c.Equals('c'))
//             Str = Str.Replace(c.ToString(), "");

//         Console.Write(Str);
//     }
//     // Using a stack, reverse this instance of MyString (6 marks)
//     public void Reverse()
//     {

//         Stack<char> S = new Stack<char>();
//         int size = S.Count;

//         for (int i = size - 1; i >= 0; i--)
//         {
//             foreach (char output in S)
//             {
//                 Console.WriteLine(output);
//             }

//         }


//     }
// }

// public class partb : NewBaseType
// {


//  private class Node { 
//  public char item;
//  public Node next;
//  // Constructor (2 marks)
//  public Node (char item, Node next ) { 

//     this.item = item;
//     this.next = next;

//   }
// }

// public static void Main(String[]args){
//     partb b = new partb();

//     char[] arr = {'c','d','e'};

       
//         Console.WriteLine( b.IndexOf('c'));
// }


// }



// // Return the index of the first occurrence of c in this instance; otherwise -1 (4 marks)
// // public int IndexOf(char c) { }
// // // Remove all occurrences of c from this instance (4 marks)
// // public void Remove (char c) { … }
// // // Return true if obj is both of type MyString and the same as this instance;
// // // otherwise false (6 marks)
// // public override bool Equals (object obj) {  }
// // // Print out this instance of MyString (3 marks)
// // public void Print( ) {  }
// // }
