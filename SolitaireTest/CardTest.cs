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
   }
}
