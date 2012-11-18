namespace Solitaire
{
   public class TableauPile : Pile
   {
      public override bool CanAddCard( Card card )
      {
         if ( card.Rank == CardRank.King && !IsEmpty() )
         {
            return false;
         } 

         if ( card.Rank != CardRank.King && IsEmpty() )
         {
            return false;
         }

         if ( !IsEmpty() )
         {
            if ( ! _cards.Peek().IsOppositeColor( card) )
            {
               return false;
            }

            if ( _cards.Peek().Rank < card.Rank )
            {
               return false;
            }
         }
         
         return true;
      }
   }
}
