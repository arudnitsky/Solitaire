using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SolitaireTest;

namespace Solitaire
{
   public class CardDeck
   {
      private List<Card> _cards = new List<Card>(); //TODO: How to expose this  as CardDeck[x]?

      public CardDeck()
      {
         InitStandardDeck();
      }

      private void InitStandardDeck()
      {
         for ( var ii = 1; ii <= 13; ++ii )
         {
            _cards.Add( new Card( ii, CardSuit.Spades, CardOrientation.FaceUp ) );
            _cards.Add( new Card( ii, CardSuit.Hearts, CardOrientation.FaceUp ) );
            _cards.Add( new Card( ii, CardSuit.Clubs, CardOrientation.FaceUp ) );
            _cards.Add( new Card( ii, CardSuit.Diamonds, CardOrientation.FaceUp ) );
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

      public int Count()
      {
         return _cards.Count;
      }

      public IList<Card> Deal( int howManyToDeal = 1 )
      {
         if ( _cards.Count < howManyToDeal )
         {
            var msg = string.Format( "Asked for {0} card{1} but deck had {2}", howManyToDeal, howManyToDeal > 1 ? "s" : "", _cards.Count );
            throw new NotEnoughCardsException( msg );
         }

         if ( howManyToDeal < 0 )
         {
            throw new ArgumentException( "howManyToDeal" );
         }

         var cardsToReturn = new Card[howManyToDeal];

         if ( howManyToDeal > 0 )
         {
            _cards.CopyTo( 0, cardsToReturn, 0, howManyToDeal );
            _cards.RemoveRange( 0, howManyToDeal );
         }

         return cardsToReturn;
      }

      public void Add( Card cardToAdd )
      {
         if ( cardToAdd == null )
         {
            throw new ArgumentNullException( "cardToAdd" );
         }

         _cards.Add( cardToAdd );
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
