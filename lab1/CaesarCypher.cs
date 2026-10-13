namespace Lab1;

public static class CaesarCypher
{
    public static char Encryption(char c, int key, char[] alphabet)
    {
        int index = Array.IndexOf(alphabet, c);
        if (index == -1) return c;
        
        int shift = (index + key) % alphabet.Length;
        if (shift < 0) shift += alphabet.Length;

        return alphabet[shift];
    }

    public static char Decryption(char c, int key, char[] alphabet)
    {
        int index = Array.IndexOf(alphabet, c);
        if (index == -1) return c;
        
        int shift = (index - key) % alphabet.Length;
        if (shift < 0) shift += alphabet.Length;

        return alphabet[shift];
    }
    
}