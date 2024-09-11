using System;
using System.Collections.Generic;
public class FoodChain
{
    static readonly Dictionary<int, string> animals = new Dictionary<int, string>()
    {
        [0] = "fly",
        [1] = "spider",
        [2] = "bird",
        [3] = "cat",
        [4] = "dog",
        [5] = "goat",
        [6] = "cow",
        [7] = "horse"
    };
    static readonly Dictionary<int, string> lines = new Dictionary<int, string>()
    {
        [1] = "It wriggled and jiggled and tickled inside her.\n",
        [2] = "How absurd to swallow a bird!\n",
        [3] = "Imagine that, to swallow a cat!\n",
        [4] = "What a hog, to swallow a dog!\n",
        [5] = "Just opened her throat and swallowed a goat!\n",
        [6] = "I don't know how she swallowed a cow!\n",
        [7] = "She's dead, of course!",
    };
    public static string Recite(int verseNumber)
    {
        var result = string.Empty;
        var endLine = "I don't know why she swallowed the fly. Perhaps she'll die.";
        result += $"I know an old lady who swallowed a {animals[verseNumber - 1]}.\n";
        if (verseNumber != 1)
            result += lines[verseNumber - 1];
        for (int key = verseNumber - 1; key >= 1; key--)
        {
            if (verseNumber != 1 && verseNumber != 8)
            {
                if (verseNumber >= 3 && key == verseNumber - (verseNumber - 2))
                    result += $"She swallowed the {animals[key]} to catch the {animals[key - 1]} that wriggled and jiggled and tickled inside her.\n";
                else
                    result += $"She swallowed the {animals[key]} to catch the {animals[key - 1]}.\n";
            }
        }
        if (verseNumber != 8)
            result += endLine;
        return result;
    }
    public static string Recite(int startVerse, int endVerse)
    {
        var result = string.Empty;
        const string breakverse = "\n\n";
        for (int verseNumber = startVerse; verseNumber <= endVerse; verseNumber++)
        {
            if (verseNumber != endVerse)
                result += Recite(verseNumber) + breakverse;
            else
                result += Recite(verseNumber);
        }
        return result;
    }
}
