using System;
using System.Reflection.Metadata.Ecma335;

public class Scripture
{
    private List<Scripture> scriptures = new List<Scripture>();
    public Reference GetReference { get; set; }
    public Word GetWord { get; set; }

    public Scripture()
    {
        GetReference = new Reference("James", 2, 5, 6);
        GetWord = new Word("If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tosssed.";);
    }

    public void ScriptureDisplay()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Reference r1 = new Reference("James", 2, 5, 6);
            Console.WriteLine(r1.GetReferenceVerse2());

            Word w1 = new Word();
            Console.WriteLine(w1.getWord());
            break;
        }
    }
    public string IsHidden()
    {
      string verses = GenerateVerses();
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
}