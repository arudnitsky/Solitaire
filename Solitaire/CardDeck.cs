using System;
using System.Collections.Generic;
using System.Text;

namespace Solitaire
{
   class CardDeck
   {
      private List<Card> _cards = new List<Card>(); //TODO: How to expose this  as CardDeck[x]?

      public CardDeck()
      {
         InitDeck();
      }

      private void InitDeck()
      {
         for ( var ii = 1; ii <= 13; ++ii )
         {
            _cards.Add( new Card( ii, CardSuit.Spades) );
            _cards.Add( new Card( ii, CardSuit.Hearts ) );
            _cards.Add( new Card( ii, CardSuit.Clubs ) );
            _cards.Add( new Card( ii, CardSuit.Diamonds ) );
         }
      }

      // Fisher-Yates shuffle
      // http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
      // To shuffle an array a of n elements (indices 0..n-1):
      //    for i from n − 1 downto 1 do
      //          j ← random integer with 0 ≤ j ≤ i
      //          exchange a[j] and a[i]
      public void Shuffle()
      {
         var rng = new Random();
         for (int ii = _cards.Count - 1; ii > 0; --ii )
         {
            var jj = rng.Next( ii - 1 );
            var tmp = _cards[jj];
            _cards[jj] = _cards[ii];
            _cards[ii] = tmp;
         }
      }

      public override string ToString()
      {
         var sb = new StringBuilder();
         foreach ( var card in _cards)
         {
            sb.Append(card);
            sb.Append("\n");
         }
         return sb.ToString();
      }
   }
}
