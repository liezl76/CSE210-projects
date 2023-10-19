using System;
using System.Reflection.PortableExecutable;
using System.Text;

public class Word
{
   private string _phrase; 
   
   public Word()
   {
      _phrase = "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tosssed.";
   }
   public string getWord()
   {
      return this._phrase;
   }
   public string WordHidden()
   {
      string _verse = getWord();
      string[] words = _verse.Split();

      StringBuilder new_script = new StringBuilder(_verse);
      foreach (string word in words)
      {
         new_script.Replace(word[..], new string('_', word.Length));
         Console.WriteLine(new_script.ToString());
         Console.ReadLine();
         Console.Clear();
      }
      return new_script.ToString();
   }
}