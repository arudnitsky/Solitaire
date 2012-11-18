﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solitaire;

namespace SolitaireTest
{
   [TestClass]
   public class TableauPileTest
   {
      private TableauPile _pile;
      private readonly Card _kingOfSpades;
      private readonly Card _queenOfSpades;
      private readonly Card _kingOfDiamonds;
      private readonly Card _queenOfDiamonds;
      private readonly Card _jackOfSpades;
      private readonly Card _jackOfDiamonds;

      public TableauPileTest()
      {
         _kingOfSpades = new Card( 13, CardSuit.Spades );
         _queenOfSpades = new Card( 12, CardSuit.Spades );
         _kingOfDiamonds = new Card( 13, CardSuit.Diamonds );
         _queenOfDiamonds = new Card( 12, CardSuit.Diamonds );
         _jackOfSpades = new Card( 11, CardSuit.Spades );
         _jackOfDiamonds = new Card( 11, CardSuit.Diamonds );
      }

      [TestInitialize]
      public void Setup()
      {
         _pile = new TableauPile();
      }

      [TestMethod]
      public void TableauPile_NewTableauPile_IsEmpty()
      {
         var pile = new TableauPile();
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
         var expected = _kingOfDiamonds;
         _pile.AddCard( expected );
         var actual = _pile.RemoveCard();
         Assert.AreEqual( actual, expected );
      }

      [TestMethod]
      public void CanAddCard_PileIsEmpty_CanAddKing()
      {
         Assert.IsTrue( _pile.CanAddCard( _kingOfSpades ) );
      }

      [TestMethod]
      public void CanAddCard_PileIsEmpty_CanNotAddNonKing()
      {
         Assert.IsFalse( _pile.CanAddCard( _jackOfSpades ) );
      }

      [TestMethod]
      public void CanAddCard_PileIsNotEmpty_CanNotAddKing()
      {
         _pile.AddCard( _kingOfSpades );
         Assert.IsFalse( _pile.CanAddCard( _kingOfDiamonds ) );
      }

      [TestMethod]
      public void CanAddCard_PileIsEmpty_CanNotAddCardOtherThanKing()
      {
         Assert.IsFalse( _pile.CanAddCard( new Card( CardRank.Queen, CardSuit.Spades ) ) );
      }

      [TestMethod]
      public void CanAddCard_AddingCardOfSameColor_CanNotAdd()
      {
         _pile.AddCard( _kingOfDiamonds );
         Assert.IsFalse( _pile.CanAddCard( _queenOfDiamonds ) );
      }

      [TestMethod]
      public void CanAddCard_AddingCardOfDifferentColor_CanAdd()
      {
         _pile.AddCard( _kingOfDiamonds );
         Assert.IsTrue( _pile.CanAddCard( _queenOfSpades ) );
      }
      
      [TestMethod]
      public void CanAddCard_AddingCardOfSameOrHigherRank_CanNotAdd()
      {
         _pile.AddCard( _kingOfDiamonds );
         _pile.AddCard( _queenOfSpades );
         _pile.AddCard( _jackOfDiamonds );
         Assert.IsFalse( _pile.CanAddCard( _queenOfSpades ) );
         Assert.IsFalse( _pile.CanAddCard( _kingOfSpades ) );
      }

      [TestMethod]
      public void CanAddCard_AddingCardOfLowerRank_CanAdd()
      {
         _pile.AddCard( _kingOfDiamonds );
         Assert.IsTrue( _pile.CanAddCard( _queenOfSpades ) );
      }
   }
}
