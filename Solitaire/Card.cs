using System;

namespace Solitaire
{
   public enum CardSuit { Hearts, Clubs, Diamonds, Spades };

   public enum CardColor { Red, Black };

   public class Card
   {
      public CardSuit Suit { get; private set; }
      public int Rank { get; private set; }
      public CardColor Color { get; private set; } 

      public Card( int rank, CardSuit suit )
      {
         Rank = rank;
         Suit = suit;
         if ( Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds )
            Color = CardColor.Red;
         else
            Color = CardColor.Black;
      }

      public override string ToString()
      {
         return string.Format("{0} of {1}", CardName(), Suit.ToString());
      }

      private string CardName()
      {
         string cardName;
         if ( Rank > 1 && Rank < 11 )
         {
            cardName = Rank.ToString();
         }
         else
         {
            switch ( Rank )
            {
               case 11:
                  cardName = "Jack";
                  break;
               case 12:
                  cardName = "Queen";
                  break;
               case 13:
                  cardName = "King";
                  break;
               case 1:
                  cardName = "Ace";
                  break;
               default:
                  throw new ArgumentException( "Rank is not 1 or > 10" );
            }
         }
         return cardName;
      }
   }
}
