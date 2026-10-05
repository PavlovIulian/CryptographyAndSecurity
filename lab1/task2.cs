namespace Lab1;

using System;
using System.Linq;
using static Lab1.CaesarCypher;

public static class Task2
{
    public static void Run()
    {   
        int key = Logger.ReadKey();
        string text = Logger.ReadText(Alphabet.RomanianAlphabet);
        string key2 = Logger.ReadKey2(Alphabet.RomanianAlphabet);

        char[] permutedAlphabet = key2.Concat(Alphabet.RomanianAlphabet).Distinct().ToArray();

        Console.WriteLine($"Permuted alphabet: {string.Join(", ", permutedAlphabet)}");
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
                    result += Encryption(c, key, permutedAlphabet);
                }
                break;
            }
            else if (choice == "2")
            {
                foreach (char c in text)
                {
                    result += Decryption(c, key, permutedAlphabet);
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
