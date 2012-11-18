using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solitaire;

namespace SolitaireTest
{
   [TestClass]
   public class FoundationPileTest
   {
      private FoundationPile _pile;

      private readonly Card _aceOfSpades;
      private readonly Card _twoOfSpades;
      private readonly Card _threeOfSpades;
      private readonly Card _aceOfDiamonds;
      private readonly Card _twoOfDiamonds;
      private readonly Card _threeOfDiamonds;

      public FoundationPileTest()
      {
         _aceOfSpades = new Card( 1, CardSuit.Spades );
         _twoOfSpades = new Card( 2, CardSuit.Spades );
         _threeOfSpades = new Card( 3, CardSuit.Spades );
         _aceOfDiamonds = new Card( 1, CardSuit.Diamonds );
         _twoOfDiamonds = new Card( 2, CardSuit.Diamonds );
         _threeOfDiamonds = new Card( 3, CardSuit.Diamonds );
      }

      [TestInitialize]
      public void Setup()
      {
         _pile = new FoundationPile();
      }

      [TestMethod]
      public void CanAddCard_PileIsEmpty_CanAddAce()
      {
         Assert.IsTrue( _pile.CanAddCard( _aceOfSpades ) );
      }

      [TestMethod]
      public void CanAddCard_PileIsEmpty_CannotAddNonAce()
      {
         Assert.IsFalse( _pile.CanAddCard( _twoOfSpades ) );
      }

      [TestMethod]
      public void CanAddCard_PileIsNotEmpty_CannotAddAce()
      {
         _pile.AddCard( _aceOfSpades );
         Assert.IsFalse( _pile.CanAddCard( _aceOfDiamonds ) );
      }

      [TestMethod]
      public void CanAddCard_AddingCardOfDifferentColor_CannotAdd()
      {
         _pile.AddCard( _aceOfSpades );
         Assert.IsFalse( _pile.CanAddCard( _twoOfDiamonds ) );
      }

      [TestMethod]
      public void CanAddCard_AddingCardOfSameOrLowerRank_CannotAdd()
      {
         _pile.AddCard( _aceOfDiamonds );
         _pile.AddCard( _twoOfDiamonds );
         _pile.AddCard( _threeOfDiamonds );
         Assert.IsFalse( _pile.CanAddCard( _twoOfDiamonds ) );
      }

      [TestMethod]
      public void CanAddCard_AddingCardOfMuchHigherRank_CannotAdd()
      {
         _pile.AddCard( _aceOfDiamonds );
         Assert.IsFalse( _pile.CanAddCard( _threeOfDiamonds ) );
      }

      [TestMethod]
      public void CanAddCard_AddingCardOfNextHigherRank_CanAdd()
      {
         _pile.AddCard( _aceOfDiamonds );
         _pile.AddCard( _twoOfDiamonds );
         Assert.IsTrue( _pile.CanAddCard( _threeOfDiamonds ) );
      }

      [TestMethod]
      [ExpectedException( typeof( InvalidOperationException ) )]
      public void AddCard_AddingInvalidCard_ThrowsInvalidOperationException()
      {
         _pile.AddCard( _twoOfSpades );
         Assert.Fail();
      }
   }
}
