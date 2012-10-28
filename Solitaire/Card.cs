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
         return string.Format("{0} of {1}", Rank, Suit.ToString());
      }
   }
}
