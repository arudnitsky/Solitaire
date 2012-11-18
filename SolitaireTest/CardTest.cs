using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solitaire;

namespace SolitaireTest
{
   [TestClass]
   public class CardTest
   {
      [TestMethod]
      public void Card_ConstructCardVariousWays_CardIsCorrect()
      {
         var card1 = new Card( CardRank.Ace, CardSuit.Spades );
         var card2 = new Card( 2, CardSuit.Hearts );
         var card3 = new Card( CardRank.Three, CardSuit.Clubs );
         var card4 = new Card( 4, CardSuit.Diamonds );

         Assert.IsTrue( card1.Color == CardColor.Black );
         Assert.IsTrue( card1.Rank == CardRank.Ace );
         Assert.IsTrue( card1.Suit == CardSuit.Spades );

         Assert.IsTrue( card2.Color == CardColor.Red );
         Assert.IsTrue( card2.Rank == CardRank.Two );
         Assert.IsTrue( card2.Suit == CardSuit.Hearts );

         Assert.IsTrue( card3.Color == CardColor.Black );
         Assert.IsTrue( card3.Rank == CardRank.Three );
         Assert.IsTrue( card3.Suit == CardSuit.Clubs );

         Assert.IsTrue( card4.Color == CardColor.Red );
         Assert.IsTrue( card4.Rank == CardRank.Four );
         Assert.IsTrue( card4.Suit == CardSuit.Diamonds );
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void Card_ConstructWithRankLessThan1_ThrowsArgumentException()
      {
         var card = new Card( 0, CardSuit.Spades );
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void Card_ConstructWithRankGreaterThan13_ThrowsArgumentException()
      {
         var card = new Card( 14, CardSuit.Spades );
      }

      [TestMethod]
      public void Card_ConstructCard_ColorIsCorrect()
      {
         var card1 = new Card( 1, CardSuit.Spades );
         var card2 = new Card( 1, CardSuit.Clubs );
         var card3 = new Card( 1, CardSuit.Hearts );
         var card4 = new Card( 1, CardSuit.Diamonds );
         Assert.IsTrue( card1.Color == CardColor.Black );
         Assert.IsTrue( card2.Color == CardColor.Black );
         Assert.IsTrue( card3.Color == CardColor.Red );
         Assert.IsTrue( card4.Color == CardColor.Red );
      }

      [TestMethod]
      public void IsOppositeColor_CalledOnSameColor_ReturnsFalse()
      {
         var card1 = new Card( 1, CardSuit.Spades );
         var card2 = new Card( 1, CardSuit.Clubs );
         var card3 = new Card( 1, CardSuit.Hearts );
         var card4 = new Card( 1, CardSuit.Diamonds );
         Assert.IsFalse( card1.IsOppositeColor( card2 ) );
         Assert.IsFalse( card3.IsOppositeColor( card4 ) );
      }

      [TestMethod]
      public void Card_NewCard_OrientationIsFaceDown()
      {
         var card1 = new Card( 1, CardSuit.Spades );
         Assert.AreEqual( CardOrientation.FaceDown, card1.Orientation );
         var card2 = new Card( CardRank.King, CardSuit.Spades );
         Assert.AreEqual( CardOrientation.FaceDown, card2.Orientation );
      }

      [TestMethod]
      public void Card_NewCardWithSpecifiedOrientation_OrientationIsCorrect()
      {
         var card1 = new Card( 1, CardSuit.Spades, CardOrientation.FaceDown );
         Assert.AreEqual( CardOrientation.FaceDown, card1.Orientation );
         var card2 = new Card( 1, CardSuit.Spades, CardOrientation.FaceUp );
         Assert.AreEqual( CardOrientation.FaceUp, card2.Orientation );
      }
   }
}
