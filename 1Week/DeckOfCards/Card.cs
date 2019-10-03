namespace DeckOfCards
{
    public class Card
    {
        private static string[] suits = new string[]
        {
            "Clubs", "Diamonds", "Hearts", "Spades"
        };
        public string Suit;
        public int Value;
        public string StringValue
        {
            get
            {
                switch(Value)
                {
                    case 1:
                        return "Ace";
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    default:
                        return Value.ToString();
                }
            }
        }
        public Card(int suit, int value)
        {
            Suit = suits[suit];
            Value = value;
        }
        
    }
}