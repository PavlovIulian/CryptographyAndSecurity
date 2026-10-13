namespace Lab1;

using System;
using System.Linq;

public static class Logger
{
    public static bool IsValidKey(int key)
    {
        return key > 0 && key < 31;
    }

    public static bool IsLetterInAlphabet(char c, char[] alphabet)
    {
        return Array.IndexOf(alphabet, char.ToUpper(c)) != -1;
    }

    public static bool ValidateText(string text, char[] alphabet, out char invalidChar)
    {
        invalidChar = '\0';
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("[Error] Text cannot be empty.");
            return false;
        }

        foreach (char c in text)
        {
            if (!IsLetterInAlphabet(c, alphabet))
            {
                if (c == ' ') continue;
                invalidChar = c;
                Console.WriteLine($"[Error] '{c}' is not a valid letter in the alphabet.");
                return false;
            }
        }
        return true;
    }

    public static bool ValidateKey2(string key2, char[] alphabet)
    {
        if (string.IsNullOrEmpty(key2) || key2.Length < 7)
        {
            Console.WriteLine("[Error] Key 2 must be at least 7 characters long.");
            return false;
        }

        foreach (char c in key2)
        {
            if (!IsLetterInAlphabet(c, alphabet))
            {
                Console.WriteLine($"[Error] Key 2 contains '{c}', which is not a valid letter in the alphabet.");
                return false;
            }
        }

        return true;
    }

    public static int ReadKey(string prompt = "Enter the key (0 < key < 31): ")
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int key))
            {
                Console.WriteLine("[Error] Invalid input. Please enter an integer.");
                continue;
            }

            if (!IsValidKey(key))
            {
                Console.WriteLine($"[Error] Key must satisfy 0 < key < 30 (between 1 and 29). You entered: {key}");
                continue;
            }

            return key;
        }
    }

   public static string ReadText(char[]? alphabet = null, string prompt = "Enter the text: ")
    {
        alphabet ??= Alphabet.RomanianAlphabet;
        while (true)
        {
            Console.Write(prompt);
            string text = Console.ReadLine() ?? "";

            if (ValidateText(text, alphabet, out _))
            {
                return text.ToUpper();
            }
        }
    }

    public static string ReadKey2(char[]? alphabet = null, string prompt = "Enter the second key (at least 7 letters): ")
    {
        alphabet ??= Alphabet.RomanianAlphabet;
        while (true)
        {
            Console.Write(prompt);
            string key2 = (Console.ReadLine() ?? "").Trim();

            if (key2.Length < 7)
            {
                Console.WriteLine($"[Error] Key 2 must be at least 7 characters long (you entered {key2.Length}). Try again.");
                continue;
            }

            if (ValidateKey2(key2, alphabet))
            {
                return key2.ToUpper();
            }
        }
    }
}