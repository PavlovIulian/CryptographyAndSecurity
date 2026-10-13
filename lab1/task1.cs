namespace Lab1;

using System;
using static Lab1.CaesarCypher;

public static class Task1
{
    public static void Run()
    {   
        int key = Logger.ReadKey();
        string text = Logger.ReadText(Alphabet.RomanianAlphabet);

        string result = "";
        while (true)
        {
            Console.WriteLine("1. Encrypt text");
            Console.WriteLine("2. Decrypt text");
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();
            if (choice == "1")
            {
                foreach (char c in text)
                {   
                    if (c == ' ') continue;
                    result += Encryption(c, key, Alphabet.RomanianAlphabet);
                }
                break;
            }
            else if (choice == "2")
            {
                foreach (char c in text)
                {
                    if (c == ' ') continue;
                    result += Decryption(c, key, Alphabet.RomanianAlphabet);
                }
                break;
            }
            else
            {
                Console.WriteLine("[Error] Invalid choice. Please enter 1 or 2.");
            }
        }
        Console.WriteLine($"Result: {result}");
    }
}