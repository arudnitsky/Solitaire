using System;
using System.Collections.Generic;

namespace Solitaire
{
   public class TableauPile
   {
      private readonly Stack<Card> _cards;

      public TableauPile()
      {
         _cards = new Stack<Card>();
      }

      public bool IsEmpty()
      {
         return _cards.Count == 0;
      }

      public void AddCard( Card card )
      {
         if ( card == null )
         {
            throw new ArgumentNullException();
         }
        
         if ( CanAddCard( card ) )
         {
            _cards.Push( card );
         }
         else
         {
            throw new InvalidOperationException( "Can't add this card" );
         }
      }

      public bool CanAddCard( Card card )
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

      public Card RemoveCard()
      {
         if ( IsEmpty( ) )
         {
            throw new InvalidOperationException( "Pile is empty" );
         }

         return _cards.Pop();
      }
   }
}
