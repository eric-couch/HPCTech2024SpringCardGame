using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPCTech2024SpringCardGame
{
    public class Card
    {
        public string suit { get; set; }
        public string rank { get; set; }
        public int val { get; set; }

        /// <summary>
        /// This is a card class for creating playing cards (games0
        /// </summary>
        /// <param name="suit">♥,♦,♣,♠</param>
        /// <param name="rank">2,3,4...10,J,Q,K,A</param>
        /// <param name="val">2,3,4...10,11,12,13,14</param>
        public Card(string suit, string rank, int val)
        {
            this.suit = suit;
            this.rank = rank;
            this.val = val;
        }

        public override string? ToString()
        {
            return $"{rank}{suit}"; 
        }
    }
}
