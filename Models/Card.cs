namespace CardShuffler.Models
{
    public class Card
    {
        private Tuple<string, string> kind;

        public Card(string suit, string value)
        {
            this.kind = new Tuple<string, string>(suit, value);
        }

        public string GetSuit()
        {
            return kind.Item1;
        }

        public string GetValue()
        {
            return kind.Item2;
        }

        public string GetValueAndSuit()
        {
            return kind.Item2 + " of " + kind.Item1;
        }
    }
}
