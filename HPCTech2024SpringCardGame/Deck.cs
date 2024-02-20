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

    public bool CheckForAce(List<Card> cards)
    {
        return cards.Exists(card => card.rank == "A");
    }

    public bool? CheckForThreeOfAKind(List<Card> cards)
    {
        //return (from card 
        //        in cards 
        //        group card by card.rank into g
        //        select new {rank = g.Key, count = g.Count() }).Any(c => c.count == 3);
        try
        {
            var group = cards.GroupBy(card => card.val);
            // group is a GroupedEnumerable, which is part of the System.Linq library.  It implements the IGrouping 
            // interface.  Each item in the GroupedEnumerable is a dictionary object with the number of items equal to 
            // the group.  so, in this case if you DO have three of a kind, one of the groups is dictionary with 
            // all three cards.  Each dictionary in this case has a key, and a card
            bool? res = group.Any(group => group.Count() == 3);

            return res;
        } catch (Exception ex)
        {
            Console.WriteLine("An error occured.  Error Message: {0}", ex.Message);
            return null;
        }


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
