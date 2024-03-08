using System.Text.RegularExpressions;

class Palindrome
{
    static void Main(string[] args)
    {
        string word = "abcba";
        Console.WriteLine(IsPalindrome(word));

    }
    public static bool IsAlphabet(Char text)
    {
        return Regex.IsMatch(text.ToString(), "^[a-zA-Z]+$");
    }
    public static bool IsPalindrome(string text)
    {
        int left = 0;
        int right = text.Length - 1;
        text = text.ToLower();
        while (left < right)
        {

            if (!IsAlphabet(text[left]))
            { 
                left++;
                continue;
            }
            if (!IsAlphabet(text[right]))
            {
                right--;
                continue;
            }

            if (text[left] != text[right])
            {
                return false;
            }
            left++;
            right--;
        }
    return true;
    }
}
