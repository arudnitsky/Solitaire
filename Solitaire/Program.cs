using System;

namespace Solitaire
{
   static class Program
   {
      static void Main( string[] args )
      {
         var deck = new CardDeck();
         deck.Shuffle();
         Console.WriteLine( deck );
         Console.ReadLine();
      }
   }
}
