using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace monopoly
{
    /******************************************************************************************************
         Created by Louis Gilmartin:          Last updated 08/10/2013
    ******************************************************************************************************/

    class Dice
    {
        static Random random = new Random();
        private int DiceRandom = random.Next(1, 7);

        // Set-Get for the random dice number
        public int diceValue
        {
            get
            {
                return this.DiceRandom;
            }
            set
            {
                this.DiceRandom = value;
            }
        }
    }
}