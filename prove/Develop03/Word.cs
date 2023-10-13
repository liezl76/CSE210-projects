using System;

public class Word
{
   private string _word;

   public Word(string phrase)
   {
       this._word = phrase;
   }

   public string getWord()
   {
    return this._word;
   }

}