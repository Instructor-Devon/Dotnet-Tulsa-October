using System.Collections.Generic;
namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> Cards;
        public Deck()
        {
            Cards = new List<Card>();
            for(int suit=0; suit<4; suit++) {
                // suits
                for(int val=1; val<14; val++) {
                    // vals
                    Cards.Add(new Card(suit, val));
                }
            }
        }
        public Card Draw()
        {
            Card toRemove = Cards[0];
            Cards.RemoveAt(0);
            return toRemove;
        }
    }
}