namespace Solitaire
{
   public class FoundationPile : Pile
   {
      public override bool CanAddCard(Card card)
      {
         if ( card.Rank == CardRank.Ace && !IsEmpty() )
         {
            return false;
         }

         if ( card.Rank != CardRank.Ace && IsEmpty() )
         {
            return false;
         }
        
         if ( ! IsEmpty() )
         {
            if ( card.Color != _cards.Peek().Color )
            {
               return false;
            }

            if ( (int) card.Rank != (int) ( _cards.Peek().Rank ) + 1 )
            {
               return false;
            }
         }

         return true;
      }
   }
}
