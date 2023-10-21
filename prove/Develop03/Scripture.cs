using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public class Scripture
{
    List<Scripture> scriptures = new List<Scripture>();
    private string _reference;
    private string _verses;

    public Scripture()
    {
        _reference = "James 1:5-6";
        _verses = "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tosssed.";
    }
    public string GetScripture()
    {
        string scripture = $"{_reference} {_verses}";
        return scripture;
    }
    public string IsHidden()
    {
      string verses = _verses;
      string[] words = verses.Split();
      StringBuilder new_script = new StringBuilder(verses);
      foreach (string word in words)
      {
         new_script.Replace(word, new string('_', word.Length));
         Console.WriteLine(new_script.ToString());
         Console.ReadLine();
         Console.Clear();
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