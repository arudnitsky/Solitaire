using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solitaire;

namespace SolitaireTest
{
   [TestClass]
   public class PileTest
   {
      private Pile _pile;

      [TestInitialize]
      public void Setup()
      {
         _pile = new Pile();
      }

      [TestMethod]
      public void Pile_NewPile_IsEmpty()
      {
         var pile = new Pile();
         Assert.IsTrue( pile.IsEmpty() );
      }

      [TestMethod]
      public void AddCard_NewPile_IsEmptyReturnsFalse()
      {
         _pile.AddCard( new Card( CardRank.King, CardSuit.Spades ) );
         Assert.IsFalse( _pile.IsEmpty() );
      }

      [TestMethod]
      [ExpectedException( typeof( ArgumentNullException ) )]
      public void AddCard_CardIsNull_ThrowsArgumentNullException()
      {
         _pile.AddCard( null );
         Assert.IsFalse( _pile.IsEmpty() );
      }

      [TestMethod]
      [ExpectedException( typeof( InvalidOperationException ) )]
      public void RemoveCard_PileIsEmpty_Throws_InvalidOperationException()
      {
         _pile.RemoveCard();
      }

      [TestMethod]
      public void RemoveCard_RemoveCard_ReturnsLastCardAdded()
      {
         var expected = new Card( CardRank.King, CardSuit.Spades );
         _pile.AddCard( expected );
         var actual = _pile.RemoveCard();
         Assert.AreEqual( actual, expected );
      }

      [TestMethod]
      public void IsFull_PileIsNotFull_ReturnsFalse()
      {
         _pile.AddCard( new Card( CardRank.King, CardSuit.Spades ) );
         Assert.IsFalse( _pile.IsFull() );
      }

      [TestMethod]
      public void IsFull_PileIsFull_ReturnsTrue()
      {
         for ( int ii = 1; ii <= 13; ++ii )
         {
            _pile.AddCard( new Card( CardRank.Ace, CardSuit.Spades ) );
         }
         Assert.IsTrue( _pile.IsFull() );
      }
   }
}
