using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solitaire;

namespace SolitaireTest
{
   [TestClass]
   public class CardDeckTest
   {
      private CardDeck _deck;

      [TestInitialize]
      public void Setup()
      {
         _deck = new CardDeck();
      }

      [TestMethod]
      public void CardDeck_NewDeck_CountReturns52()
      {
         Assert.AreEqual( 52, _deck.Count() );
      }

      [TestMethod]
      public void Deal_NoCardsRequested_NoCardsReturnedFiftyTwoCardsRemain()
      {
         var cards = _deck.Deal( 0 );
         Assert.AreEqual( 0, cards.Count );
         Assert.AreEqual( 52, _deck.Count() );
      }

      [TestMethod]
      [ExpectedException( typeof( NotEnoughCardsException ) )]
      public void Deal_MoreCardsRequestedThanPresent_ThrowsNotEnoughCardsException()
      {
         var cards = _deck.Deal( _deck.Count() + 1 );
      }

      [TestMethod]
      [ExpectedException( typeof( ArgumentException ) )]
      public void Deal_NegativeCardsRequested_ThrowArgumentException()
      {
         _deck.Deal( -1 );
      }

      [TestMethod]
      public void Deal_OneCardRequested_OneCardReturnedFiftyOneCardsRemain()
      {
         var cards = _deck.Deal();
         Assert.AreEqual( 1, cards.Count );
         Assert.AreEqual( 51, _deck.Count() );
      }

      [TestMethod]
      public void Deal_ThreeCardsRequested_ThreeCardsReturnedFortyNineCardsRemain()
      {
         var cards = _deck.Deal( 3 );
         Assert.AreEqual( 3, cards.Count );
         Assert.AreEqual( 49, _deck.Count() );
      }

      [TestMethod]
      [ExpectedException( typeof( ArgumentNullException ) )]
      public void Add_CardIsNull_ThrowsArgumentNullException()
      {
         _deck.Add( null );
      }
      
      [TestMethod]
      public void Add_DeckIsEmpty_CardsAddedAreReturnedInOrder()
      {
         _deck.Deal( 52 );

         var card1ToAdd = new Card( CardRank.Ace, CardSuit.Spades );
         var card2ToAdd = new Card( CardRank.Two, CardSuit.Spades );
         var card3ToAdd = new Card( CardRank.Three, CardSuit.Spades );

         _deck.Add( card1ToAdd );
         _deck.Add( card2ToAdd );
         _deck.Add( card3ToAdd );

         var cards = _deck.Deal( 3 );

         Assert.AreEqual( card1ToAdd, cards[0] );
         Assert.AreEqual( card2ToAdd, cards[1] );
         Assert.AreEqual( card3ToAdd, cards[2] );
      }
   }
}
