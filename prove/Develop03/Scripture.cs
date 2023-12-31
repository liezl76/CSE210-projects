using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public class Scripture
{
    List<Scripture> scriptures = new List<Scripture>(); // Make list of scriptures
    private string GetReferenceVerse2;
    private string _verses;
    public Scripture()
    {
        GetReferenceVerse2 = "James 1:5-6";
        _verses = "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tosssed.";
    }
    public string GetScripture()
    {
        string scripture = $"{GetReferenceVerse2} {_verses}";
        return scripture;
    }
    public string IsHidden()
    {
        string verses = _verses;
        string[] words = verses.Split();
        StringBuilder new_script = new StringBuilder(verses);
        foreach (string word in words)
        {
            int index = new_script.ToString().IndexOf(word);
            while (index != -1)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    new_script[index + i] = '_';
                }
                index = new_script.ToString().IndexOf(word, index + word.Length);
            }
        }
        return new_script.ToString();
    }
    public void SaveToFile()
    {
        Console.WriteLine("Saving the file...");
        string file = "scripture.txt";

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Scripture script in scriptures)
            {
                outputFile.WriteLine(script.scriptures);
            }
        }
    }
}