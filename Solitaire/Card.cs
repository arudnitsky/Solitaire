using System;

namespace Solitaire
{
   public enum CardSuit { Hearts, Clubs, Diamonds, Spades };

   public enum CardColor { Red, Black };

   public enum CardRank { Ace = 1, Two, Three, Four, Five, Six, Seven,
                          Eight, Nine, Ten, Jack, Queen, King };

   public enum CardOrientation { FaceDown, FaceUp };

   public class Card
   {
      public CardSuit Suit { get; private set; }
      public CardRank Rank { get; private set; }
      public CardColor Color { get; private set; } 
      public CardOrientation Orientation { get; private set; }

      public Card( int rank, CardSuit suit, CardOrientation orientation = CardOrientation.FaceDown )
      {
         if ( rank < (int)CardRank.Ace || rank > (int)CardRank.King )
         {
            throw new ArgumentException( "Invalid card rank" );
         }
         InitCard( (CardRank) rank, suit, orientation );
      }
      
      public Card( CardRank rank, CardSuit suit, CardOrientation orientation = CardOrientation.FaceDown )
      {
         InitCard( rank, suit, orientation );
      }

      private void InitCard( CardRank rank, CardSuit suit, CardOrientation orientation )
      {
         Orientation = orientation;
         Rank = rank;
         Suit = suit;
         if ( Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds )
         {
            Color = CardColor.Red;
         }
         else
         {
            Color = CardColor.Black;
         }
      }

      public bool IsOppositeColor( Card card )
      {
         if ( Color == card.Color )
         {
            return false;
         }
         return true;
      }

      public override string ToString()
      {
         string output;
         if ( Orientation == CardOrientation.FaceDown )
         {
            output = "Card";
         }
         else
         {
            output = string.Format("{0} of {1}", Rank.ToString(), Suit.ToString());
         }
         return output;
      }
   }
}
