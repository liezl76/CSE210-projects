using System;

public class Word
{
   private string _phrase;

   public Word()
   {
     _phrase = "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tosssed.";
   }
   public string GetPhraseString()
   {
       string words = $"{_phrase}";
       return words;
   }
   
}