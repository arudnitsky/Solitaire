using System;
using System.Runtime.Serialization;

namespace SolitaireTest
{
   [Serializable]
   public class NotEnoughCardsException : Exception
   {
      public NotEnoughCardsException()
      {
      }

      public NotEnoughCardsException( string message )
         : base( message )
      {
      }

      public NotEnoughCardsException( string message, Exception inner )
         : base( message, inner )
      {
      }

      protected NotEnoughCardsException( SerializationInfo info, StreamingContext context )
         : base( info, context )
      {
      }

   }
}