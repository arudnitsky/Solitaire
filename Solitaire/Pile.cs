using System;
using System.Collections.Generic;

namespace Solitaire
{
   public class Pile
   {
      protected readonly Stack<Card> _cards;

      public Pile()
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
         
         if ( ! CanAddCard( card ) )
         {
            throw new InvalidOperationException( "Can't add this card" );
         }

         _cards.Push( card );
      }

      public Card RemoveCard()
      {
         if ( IsEmpty() )
         {
            throw new InvalidOperationException( "Pile is empty" );
         }

         return _cards.Pop();
      }

      public virtual bool CanAddCard( Card card )
      {
         return true;
      }
   }
}
