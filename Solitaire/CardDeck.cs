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
            _cards.Add( new Card(ii, CardSuit.Spades));
            _cards.Add( new Card(ii, CardSuit.Hearts));
            _cards.Add( new Card(ii, CardSuit.Clubs));
            _cards.Add( new Card(ii, CardSuit.Diamonds));
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
