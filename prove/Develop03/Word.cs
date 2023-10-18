using System;
using System.Reflection.PortableExecutable;
using System.Text;

public class Word
{
   public List<Word> words = new List<Word>();
   public string[] _verses = {
    "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tosssed.",
    "I can do all things through Christ which strenghteneth me.",
    "Even so faith, if it hath not works, is dead, being alone.  Yea, a man may say, Thou hast faith, and I have works: shew me thy faith without thy works, and I will shew thee my faith by my works."
   };
   
   public string GenerateVerses()
   {
      Random rnd = new Random();
      int num_verses = rnd.Next(0,2);
      string selected_verses = _verses[num_verses];
      return selected_verses;
   }
   
   public string WordHidden()
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