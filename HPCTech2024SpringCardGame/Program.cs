namespace HPCTech2024SpringCardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // card, deck, hand, player, game
            Deck deck = new Deck();

            List<Card> hand = deck.DealCards(5);
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            foreach (Card card in hand)
            {
                Console.Write($"{card.ToString()} ");
                Console.WriteLine();
            }

            bool? checkForThreeOfAKind = deck.CheckForThreeOfAKind(hand);
            if (checkForThreeOfAKind != null)
            {
                Console.WriteLine($"Checking for three of a kind: {((bool)checkForThreeOfAKind ? "true" : "false")}");
            } else
            {
                return;
            }

        }
    }

}
