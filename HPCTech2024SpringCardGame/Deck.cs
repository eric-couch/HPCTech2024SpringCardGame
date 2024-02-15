using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPCTech2024SpringCardGame;

public class Deck
{
    public List<Card> Cards { get; set; } = new List<Card>();

    int numOfCards = 0;

    public Deck()
    {
        ResetDeck();
    }

    public List<Card> DealCards(int numOfCards)
    {
        List<Card> dealtCards = new List<Card>();
        for (int cardsToDeal = 0;cardsToDeal < numOfCards;cardsToDeal++)
        {
            Card dealtCard = DealCard();
            dealtCards.Add(dealtCard);
        }
        return dealtCards;
    }

    public Card DealCard()
    {
        Random rnd = new Random();
        int cardToDeal = rnd.Next(numOfCards); // this is 0-51 if the deck is new
        Card card = Cards[cardToDeal];
        Cards.RemoveAt(cardToDeal);
        numOfCards--;
        return card;
    }

    //public void Shuffle()
    //{

    //}

    public void ResetDeck()
    {
        Cards.Clear();
        List<string> suits = new List<string>() { "♥", "♦", "♣", "♠" };
        List<string> ranks = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        List<int> values = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        foreach(var suit in suits)
        {
            foreach(var rank in ranks)
            {
                Card card = new Card(suit, rank, values[ranks.IndexOf(rank)]);
                Cards.Add(card);
            }
        }
        numOfCards = Cards.Count;
    }
}
