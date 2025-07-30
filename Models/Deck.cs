using System.Collections;
using System.Security.Cryptography;

namespace CardShuffler.Models
{
    public class Deck : IEnumerable
    {
        private List<Card> cards;
        private int count;

        public Deck()
        {
            this.cards = new List<Card>();

            string[] suits = { "hearts", "clubs", "diamonds", "spades" };
            List<string> vals = new List<string>{"ace", "king", "queen", "jack",
            "2", "3", "4", "5", "6", "7", "8", "9", "10"};

            foreach(string suit in suits)
            {
                foreach(string val in vals)
                {
                   Card c = new Card(suit, val);
                    this.cards.Add(c);
                }
            }
        }

        public void Shuffle ()
        {
            RandomNumberGenerator provider = RandomNumberGenerator.Create();
            //is less than half of the deck
            int n = 25;
            
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Card value = this.cards[k];
                this.cards[k] = this.cards[n];
                this.cards[n] = value;
            }
        }

        public int GetCount ()
        {
            return this.cards.Count();
        }

        public Card Draw ()
        {
            Card c = this.cards.First();
            cards.Remove(c);
            return c;
        }
        
        public List<Card> getAllCards()
        {
            return this.cards;
        }


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
