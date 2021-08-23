using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace monopoly
{
    /******************************************************************************************************
         Created by Louis Gilmartin:          Last updated 17/11/2013
    ******************************************************************************************************/

    class Player
    {
        private string _playerName;
        private int _playerCurrentSquare;

        #region Public Get/Set methods for the players values

        // Set-Get for the player current position
        public int CurrentSquare
        {
            get
            {
                return this._playerCurrentSquare;
            }
            set
            {
                this._playerCurrentSquare = value;
            }
        }

        // Set-Get for the player name
        public string Name
        {
            get
            {
                return this._playerName;
            }
            set
            {
                this._playerName = value;
            }
        }

        #endregion
    }
}
