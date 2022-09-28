public class name
{

    public static void Main(String[] args)
    {
        String word = "Hello World!";
        String reverse = "";
        char[] cArray = word.ToCharArray();

        for (int i = word.Length - 1; i >= 0; i--)
        {

            reverse += cArray[i];


        }
        Console.WriteLine(reverse + "..." + "Hello");
    }
}

