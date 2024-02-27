using System.Diagnostics.Tracing;

class CV04
{
    public static void Main(string[] args)
    {
        string RawText = "Toto je retezec predstavovany nekolika radky,\n"
         + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
         + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
         + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
         + "posledni veta!";
        Console.WriteLine(RawText + "\n");

        StringStatistics testovaciText = new StringStatistics(RawText);

        Console.WriteLine($"Pocet slov: {testovaciText.WordCount()}");
        Console.WriteLine($"Pocet riadkov: {testovaciText.LineCount()}");
        Console.WriteLine($"Pocet viet: {testovaciText.SentenceCount()}");
        Console.WriteLine($"Najdlhsie slovo: {testovaciText.LongestWord()}");

        Console.Write("Najkratsie slova: ");
        foreach (string word in testovaciText.ShortestWords())
            Console.Write($"{word} ");
        Console.WriteLine();

        Console.WriteLine($"Najpocetnejsie slovo: {testovaciText.MostUsedWord()}\n");

        Console.Write("Triedene slova: ");
        foreach (string word in testovaciText.SortedWords())
            Console.Write($"{word} ");
    }
}

class StringStatistics
{
    public string text;

    public StringStatistics(string TextIn)
    {
        text = TextIn;
    }

    // pocet slov
    public int WordCount()
    {
        char[] splitters = new char[] { ' ', '.', ',', ';', '!', '?', '(', ')', '\n' };
        // string[] strings = text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

        return text.Split(splitters, StringSplitOptions.RemoveEmptyEntries).Length;
        // return strings.Length;
    }

    // pocet riadkov
    public int LineCount()
    {
        return text.Split('\n', StringSplitOptions.RemoveEmptyEntries).Length;
    }

    // pocet viet
    public int SentenceCount()
    {
        int count = 0;
        char[] EndSplitters = new char[] { '.', '!', '?' };
        char[] MiddleSplitters = new char[] { ' ', '\n' };

        for (int i = 0; i < text.Length - 1; i++)
        {
            if (EndSplitters.Contains(text[i]))
                if (MiddleSplitters.Contains(text[i + 1]))
                    if (Char.IsUpper(text[i + 2]))
                        count++;
        }

        return count + 1;
    }

    // najdlhsie slovo
    public string LongestWord()
    {
        string longest = "";
        char[] splitters = new char[] { ' ', '.', ',', ';', '!', '?', '(', ')', '\n' };

        string[] words = text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (word.Length > longest.Length)
                longest = word;
        }

        return longest;
    }

    // najkratsie slovo
    public string[] ShortestWords()
    {
        int shortestLength = 99999;
        List<string> ShortestWords = new List<string>();
        char[] splitters = new char[] { ' ', '.', ',', ';', '!', '?', '(', ')', '\n' };

        string[] words = text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (word.Length < shortestLength)
                shortestLength = word.Length;

            if (shortestLength == 1) break;
        }

        foreach (string word in words)
        {
            if (word.Length == shortestLength)
                ShortestWords.Add(word);
        }

        return ShortestWords.ToArray();
    }

    // najpocetnejsie slovo
    public string MostUsedWord()
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        char[] splitters = new char[] { ' ', '.', ',', ';', '!', '?', '(', ')', '\n' };
        string[] words = text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

        foreach(string word in words)
        {
            if(wordCount.ContainsKey(word.ToLower()))
                wordCount[word.ToLower()]++;
            else
                wordCount[word.ToLower()] = 1;
        }

        KeyValuePair<string, int> mostUsedWord = wordCount.OrderByDescending(x => x.Value).First();

        return mostUsedWord.Key;
    }

    // vytriedene slova
    public string[] SortedWords()
    {
        char[] splitters = new char[] { ' ', '.', ',', ';', '!', '?', '(', ')', '\n' };
        string[] words = text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

        System.Array.Sort(words);

        return words;
    }
}
