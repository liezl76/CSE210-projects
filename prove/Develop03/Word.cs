using System;
using System.Reflection.Metadata.Ecma335;

public class Word
{
   private string _phrase;
   private string word;

    public Word()
   {
     _phrase = "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tosssed.";
   }
   public string GetPhraseString()
   {
       string phrase = $"{_phrase}";
       return phrase;
   }
   public string GetPhraseSplit()
   {
      string phrase = $"{_phrase}";
      
      foreach (var word in phrase.Split(' '))
      {
        Console.WriteLine($"{word}");
      }
      return word;
   }
}
