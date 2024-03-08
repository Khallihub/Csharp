class WordFrequencyCount 
{
    static void Main(string[] args) {

        string sentence = "This is a test sentence to test the word frequency count This is a test sentence to test the word frequency count";
        Dictionary<string, int> wordFrequency = wordFrequencyCount(sentence);
        foreach (var word in wordFrequency) {
            Console.WriteLine($"{word.Key}: {word.Value}");
        }

    }

    public static Dictionary<string, int> wordFrequencyCount(string text) {
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
        string[] words = text.Split(' ');
        foreach (var word in words) {
            if (wordFrequency.ContainsKey(word)) {
                wordFrequency[word]++;
            } else {
                wordFrequency.Add(word, 1);
            }
        }

        return wordFrequency;
    }
}
