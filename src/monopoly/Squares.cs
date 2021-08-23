using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace monopoly
{
    /******************************************************************************************************
         Created by Louis Gilmartin:          Last updated 16/11/2013
    ******************************************************************************************************/

    class Square
    {
        // Values for the squares
        private string squareName;
        private string squareColour;
        private int squareValue;
        private bool squareIsProperty = true;
        private int squareLocation;
        private Square _next;
        private Square _previous;

        #region Public Get/Set methods for the squares values

        // Set-Get for the square name
        public string name
        {
            get
            {
                return this.squareName;
            }
            set
            {
                this.squareName = value;
            }
        }

        // Set-Get for the square colour
        public string colour
        {
            get
            {
                return this.squareColour;
            }
            set
            {
                this.squareColour = value;
            }
        }

        // Set-Get for the square value
        public int value
        {
            get
            {
                return this.squareValue;
            }
            set
            {
                this.squareValue = value;
            }
        }

        // Set-Get for the square value
        public bool isProperty
        {
            get
            {
                return this.squareIsProperty;
            }
            set
            {
                this.squareIsProperty = value;
            }
        }

        // Set-Get for the square location
        public int location
        {
            get
            {
                return this.squareLocation;
            }
            set
            {
                this.squareLocation = value;
            }
        }

        // Set-Get for the square next pointer
        public Square next
        {
            get
            {
                return this._next;
            }
            set
            {
                this._next = value;
            }
        }

        // Set-Get for the square previous pointer
        public Square previous
        {
            get
            {
                return this._previous;
            }
            set
            {
                this._previous = value;
            }
        }

        #endregion
    }
}
