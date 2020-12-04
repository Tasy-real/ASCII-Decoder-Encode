using System;
using System.Linq;
using System.Text;

namespace ASCII__
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
             //Sets Color Normal
             Console.ForegroundColor = ConsoleColor.White;

             //Encoding 
             Encoding ascii = Encoding.ASCII;

            //Ask if Encoding or Decoding
            Console.WriteLine("\nDecode (D) or Encode (E)?");
            string d_OR_e = Console.ReadLine();

            //If e its Encoding
            if (d_OR_e == "E")
            {
                //Asks for String
                Console.WriteLine("\nPls give your string!\n");
                String unicodeString = Console.ReadLine();

                //Some things you need
                int indexOfPi = unicodeString.IndexOf('\u03a0');
                int indexOfSigma = unicodeString.IndexOf('\u03a3');

                //Encode the string.
                Byte[] encodedBytes = ascii.GetBytes(unicodeString);

                Console.WriteLine("\nEncoded bytes:");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (Byte b in encodedBytes)
                {
                    //Writes the Result in [] like [121][87]
                    Console.Write("{0} ", b);
                }
                //Makes Space
                Console.WriteLine();

                //Prints the String in original form
                String decodedString = ascii.GetString(encodedBytes);
                Console.ForegroundColor = ConsoleColor.White;
            }

                //if d its Decoding
                if (d_OR_e == "D")
                {
                    Console.WriteLine("\nPls give your Numbers!\n");

                    Char[] chars;
                    Byte[] bytes = new Byte[] { };

                    string text = Console.ReadLine();
                    bytes = text.Split(' ').Select(x => Convert.ToByte(x)).ToArray();

                    Decoder utf8Decoder = Encoding.UTF8.GetDecoder();

                    int charCount = utf8Decoder.GetCharCount(bytes, 0, bytes.Length);
                    chars = new Char[charCount];
                    int charsDecodedCount = utf8Decoder.GetChars(bytes, 0, bytes.Length, chars, 0);

                    Console.Write("\nDecoded chars: \n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (Char c in chars)
                    {
                        Console.Write("{0}", c);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
