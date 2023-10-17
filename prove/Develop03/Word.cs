using System;

public class Word
{
   public string[] _verses = {
    "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tosssed.",
    "I can do all things through Christ which strenghteneth me.",
    "Even so faith, if it hath not works, is dead, being alone.  Yea, a man may say, Thou hast faith, and I have works: shew me thy faith without thy works, and I will shew thee my faith by my works."
   };
   public string WordDisplay(string wordToHide)
   {
      Random rnd = new Random();
      int num_verses = rnd.Next(0, 2);
      string selected_verses = _verses[num_verses];
      string[]  subs = selected_verses.Split();
      string new_script = "";
      for (int i = 0; i < subs.Length; i++)
      {
          if (subs[i] == wordToHide)
          {
              new_script += "_ ";
          }
          else
          {
              new_script += subs[i] + " ";
          }
      }
      return new_script;
   }
}