using System;

namespace Solitaire
{
   class Program
   {
      static void Main( string[] args )
      {
         var deck = new CardDeck();
         Console.WriteLine(deck);
         Console.ReadLine();
      }
   }
}
