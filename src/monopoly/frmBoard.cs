using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace monopoly
{
    /******************************************************************************************************
         Created by Louis Gilmartin:          Last updated 29/11/2013
    ******************************************************************************************************/

    public partial class frmBoard : Form
    {
        // Initialise the game class
        private Program game;

        public int CurrentPlayer = 1;
        private bool _Player1InJail = false;
        private int _Player1TimeInJail = 0;
        private bool _Player2InJail = false;
        private int _Player2TimeInJail = 0;

        // String to hold the app directory
        // This is used for the save file and audio file paths
        private string appPath = System.IO.Directory.GetCurrentDirectory();

        System.Media.SoundPlayer openingThemePlayer;

        public frmBoard()
        {
            InitializeComponent();

            #region Form Visual Settings

            // These set the location of the elements and also the parent
            // This enables the items to have transparency

            // Sets the start image location
            pbStartImage.Location = new Point(220, 100);

            // Sets the image parent
            Player1Image.Parent = pictureBoxBoard;
            Player2Image.Parent = pictureBoxBoard;
            pictureBoardLogo.Parent = pictureBoxBoard;

            // Sets the property panel parent and location
            panelPlayerProperties1.Parent = pbPropertyPanelImage;
            panelPlayerProperties1.Location = new Point(71, 34);

            panelPlayerProperties2.Parent = pbPropertyPanelImage;
            panelPlayerProperties2.Location = new Point(71, 34);

            // Sets the dice image parent and location
            pbDiceImage.Parent = pbPropertyPanelImage;
            pbDiceImage.Location = new Point(140, 660);

            // Sets the labels parent and location
            lblBank.Parent = pbPropertyPanelImage;
            lblBank.Location = new Point(75, 500);
            lblPlayersTurn.Parent = pbPropertyPanelImage;
            lblPlayersTurn.Location = new Point(75, 620);
            lblCar.Parent = pbPropertyPanelImage;
            lblCar.Location = new Point(90, 400);
            lblDog.Parent = pbPropertyPanelImage;
            lblDog.Location = new Point(90, 430);
            lblPoundSign1.Parent = pbPropertyPanelImage;
            lblPoundSign1.Location = new Point(210, 400);
            lblCurrentMoney1.Parent = pbPropertyPanelImage;
            lblCurrentMoney1.Location = new Point(225, 400);
            lblPoundSign2.Parent = pbPropertyPanelImage;
            lblPoundSign2.Location = new Point(210, 430);
            lblCurrentMoney2.Parent = pbPropertyPanelImage;
            lblCurrentMoney2.Location = new Point(225, 430);

            // Sets the buttons parent and location
            btnPlayer1.Parent = pbPropertyPanelImage;
            btnPlayer1.Location = new Point(90, 245);
            btnPlayer2.Parent = pbPropertyPanelImage;
            btnPlayer2.Location = new Point(200, 245);

            btnRollDice.BackColor = Color.FromArgb(236, 62, 62);

            #endregion

            // This sets the path of the audio files
            string gameDataPath = appPath.Remove(appPath.Length - 9);
            gameDataPath = gameDataPath + "Data\\Monopoly_Theme.wav";

            openingThemePlayer = new System.Media.SoundPlayer(gameDataPath);

            // Plays the theme music when the form is initialised
            openingThemePlayer.PlayLooping();

            Program game = new Program(this);
        }

        #region Retrieve Value methods
        // These methods retrieve values from the program class
        // Set player 1 money in the label
        public void setPlayerMoney1(string message)
        {
            lblCurrentMoney1.Text = message;
        }

        // Set player 2 money in the label
        public void setPlayerMoney2(string message)
        {
            lblCurrentMoney2.Text = message;
        }

        // Set player 1 property listbox
        public void setPropertyListText1(string message)
        {
            listBoxProperties1.Items.Add(message);
        }

        // Set player 2 property listbox
        public void setPropertyListText2(string message)
        {
            listBoxProperties2.Items.Add(message);
        }

        // Sets the visibility of the main panel
        public void showMainPanel(bool visible)
        {
            panelMainGame.Visible = visible;
        }

        // Sets the current player when a game is loaded
        public void setCurrentplayer(string player)
        {
            if (player == "Dog")
            {
                lblPlayersTurn.Text = "It's Car's Turn";
                btnRollDice.BackColor = Color.FromArgb(236, 62, 62);
                CurrentPlayer = 1;
            }
            else if (player == "Car")
            {
                lblPlayersTurn.Text = "It's Dog's Turn";
                btnRollDice.BackColor = Color.FromArgb(100, 220, 100);
                CurrentPlayer = 2;
            }
        }

        #endregion


        #region Display House/Shop methods

        public void displayPlayerHouses(string house)
        {
            // This method is called when a game is loaded and the player had previously built houses
            // Each of the players houses are displayed on the board
            switch (house)
            {
                case "Black 1":
                    pictureBoxBlack1House.Visible = true;
                    break;
                case "Black 2":
                    pictureBoxBlack2House.Visible = true;
                    break;
                case "Aqua 1":
                    pictureBoxAqua1House.Visible = true;
                    break;
                case "Aqua 2":
                    pictureBoxAqua2House.Visible = true;
                    break;
                case "Yellow 1":
                    pictureBoxYellow1House.Visible = true;
                    break;
                case "Yellow 2":
                    pictureBoxYellow2House.Visible = true;
                    break;
                case "Green 1":
                    pictureBoxGreen1House.Visible = true;
                    break;
                case "Green 2":
                    pictureBoxGreen2House.Visible = true;
                    break;
                case "Blue 1":
                    pictureBoxBlue1House.Visible = true;
                    break;
                case "Blue 2":
                    pictureBoxBlue2House.Visible = true;
                    break;
                case "Red 1":
                    pictureBoxRed1House.Visible = true;
                    break;
                case "Red 2":
                    pictureBoxRed2House.Visible = true;
                    break;
                case "Pink 1":
                    pictureBoxPink1House.Visible = true;
                    break;
                case "Pink 2":
                    pictureBoxPink2House.Visible = true;
                    break;
                case "Brown 1":
                    pictureBoxBrown1House.Visible = true;
                    break;
                case "Brown 2":
                    pictureBoxBrown2House.Visible = true;
                    break;
            }
        }

        public void displayPlayerShops(string shop)
        {
            // This method is called when a game is loaded and the player had previously built shops
            // Each of the players shops are displayed on the board
            switch (shop)
            {
                case "Black 1":
                    pictureBoxBlack1Shop.Visible = true;
                    pictureBoxBlack1Shop.BringToFront();
                    break;
                case "Black 2":
                    pictureBoxBlack2Shop.Visible = true;
                    pictureBoxBlack2Shop.BringToFront();
                    break;
                case "Aqua 1":
                    pictureBoxAqua1Shop.Visible = true;
                    pictureBoxAqua1Shop.BringToFront();
                    break;
                case "Aqua 2":
                    pictureBoxAqua2Shop.Visible = true;
                    pictureBoxAqua2Shop.BringToFront();
                    break;
                case "Yellow 1":
                    pictureBoxYellow1Shop.Visible = true;
                    pictureBoxYellow1Shop.BringToFront();
                    break;
                case "Yellow 2":
                    pictureBoxYellow2Shop.Visible = true;
                    pictureBoxYellow2Shop.BringToFront();
                    break;
                case "Green 1":
                    pictureBoxGreen1Shop.Visible = true;
                    pictureBoxGreen1Shop.BringToFront();
                    break;
                case "Green 2":
                    pictureBoxGreen2Shop.Visible = true;
                    pictureBoxGreen2Shop.BringToFront();
                    break;
                case "Blue 1":
                    pictureBoxBlue1Shop.Visible = true;
                    pictureBoxBlue1Shop.BringToFront();
                    break;
                case "Blue 2":
                    pictureBoxBlue2Shop.Visible = true;
                    pictureBoxBlue2Shop.BringToFront();
                    break;
                case "Red 1":
                    pictureBoxRed1Shop.Visible = true;
                    pictureBoxRed1Shop.BringToFront();
                    break;
                case "Red 2":
                    pictureBoxRed2Shop.Visible = true;
                    pictureBoxRed2Shop.BringToFront();
                    break;
                case "Pink 1":
                    pictureBoxPink1Shop.Visible = true;
                    pictureBoxPink1Shop.BringToFront();
                    break;
                case "Pink 2":
                    pictureBoxPink2Shop.Visible = true;
                    pictureBoxPink2Shop.BringToFront();
                    break;
                case "Brown 1":
                    pictureBoxBrown1Shop.Visible = true;
                    pictureBoxBrown1Shop.BringToFront();
                    break;
                case "Brown 2":
                    pictureBoxBrown2Shop.Visible = true;
                    pictureBoxBrown2Shop.BringToFront();
                    break;
            }
        }

        #endregion


        #region Reset Properties methods

        public void resetBuiltProperties()
        {
            // This method resets all of the house and shop images
            // The method is called when a new game is selected

            // Makes all of the house images not visible
            pictureBoxBlack1House.Visible = false;
            pictureBoxBlack2House.Visible = false;
            pictureBoxAqua1House.Visible = false;
            pictureBoxAqua2House.Visible = false;
            pictureBoxYellow1House.Visible = false;
            pictureBoxYellow2House.Visible = false;
            pictureBoxGreen1House.Visible = false;
            pictureBoxGreen2House.Visible = false;
            pictureBoxBlue1House.Visible = false;
            pictureBoxBlue2House.Visible = false;
            pictureBoxRed1House.Visible = false;
            pictureBoxRed2House.Visible = false;
            pictureBoxPink1House.Visible = false;
            pictureBoxPink2House.Visible = false;
            pictureBoxBrown1House.Visible = false;
            pictureBoxBrown2House.Visible = false;

            // Makes all of the shop images not visible
            pictureBoxBlack1Shop.Visible = false;
            pictureBoxBlack2Shop.Visible = false;
            pictureBoxAqua1Shop.Visible = false;
            pictureBoxAqua2Shop.Visible = false;
            pictureBoxYellow1Shop.Visible = false;
            pictureBoxYellow2Shop.Visible = false;
            pictureBoxGreen1Shop.Visible = false;
            pictureBoxGreen2Shop.Visible = false;
            pictureBoxBlue1Shop.Visible = false;
            pictureBoxBlue2Shop.Visible = false;
            pictureBoxRed1Shop.Visible = false;
            pictureBoxRed2Shop.Visible = false;
            pictureBoxPink1Shop.Visible = false;
            pictureBoxPink2Shop.Visible = false;
            pictureBoxBrown1Shop.Visible = false;
            pictureBoxBrown2Shop.Visible = false;
        }

        public void resetPurchasedProperties()
        {
            // Resets the transparency of the player 1 properties in the GUI panel
            P1PropertyBlack1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyBlack2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyAqua1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyAqua2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyYellow1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyYellow2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyGreen1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyGreen2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyBlue1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyBlue2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyRed1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyRed2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyPink1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyPink2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyBrown1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyBrown2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;

            // Resets the transparency of the player 2 properties in the GUI panel
            P2PropertyBlack1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyBlack2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyAqua1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyAqua2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyYellow1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyYellow2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyGreen1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyGreen2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyBlue1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyBlue2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyRed1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyRed2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyPink1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyPink2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyBrown1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyBrown2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
        }

        #endregion


        #region Get Player Jail Time methods

        // Set-Get to check if player 1 is in jail
        public bool Player1InJail
        {
            get
            {
                return this._Player1InJail;
            }
            set
            {
                this._Player1InJail = value;
            }
        }
        // Set-Get to check the amount of time player 1 has spent in jail
        public int Player1TimeInJail
        {
            get
            {
                return this._Player1TimeInJail;
            }
            set
            {
                this._Player1TimeInJail = value;
            }
        }
        // Set-Get to check if player 2 is in jail
        public bool Player2InJail
        {
            get
            {
                return this._Player2InJail;
            }
            set
            {
                this._Player2InJail = value;
            }
        }
        // Set-Get to check the amount of time player 2 has spent in jail
        public int Player2TimeInJail
        {
            get
            {
                return this._Player2TimeInJail;
            }
            set
            {
                this._Player2TimeInJail = value;
            }
        }

        #endregion


        #region Player Property methods

        // This shows the current purchased properties by filling their colour for player 1 properties panel in the GUI
        // This method is called everytime a player purchases a new property
        public void DisplayPlayerProperties1(string message)
        {
            switch (message)
            {
                case "Strand":
                    P1PropertyBlack1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyBlack1.BackColor = Color.FromArgb(38, 38, 38);
                    break;
                case "Trafalgar Sq":
                    P1PropertyBlack2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyBlack2.BackColor = Color.FromArgb(38, 38, 38);
                    break;
                case "Leicester Sq":
                    P1PropertyAqua1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyAqua1.BackColor = Color.Aqua;
                    break;
                case "Piccadilly":
                    P1PropertyAqua2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyAqua2.BackColor = Color.Aqua;
                    break;
                case "Regent St":
                    P1PropertyYellow1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyYellow1.BackColor = Color.Yellow;
                    break;
                case "Oxford St":
                    P1PropertyYellow2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyYellow2.BackColor = Color.Yellow;
                    break;
                case "Mayfair":
                    P1PropertyGreen1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyGreen1.BackColor = Color.Green;
                    break;
                case "Park Lane":
                    P1PropertyGreen2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyGreen2.BackColor = Color.Green;
                    break;
                case "Old Kent Rd":
                    P1PropertyBlue1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyBlue1.BackColor = Color.FromArgb(32, 63, 153);
                    break;
                case "Whitechapel":
                    P1PropertyBlue2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyBlue2.BackColor = Color.FromArgb(32, 63, 153);
                    break;
                case "Islington":
                    P1PropertyRed1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyRed1.BackColor = Color.Red;
                    break;
                case "Euston":
                    P1PropertyRed2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyRed2.BackColor = Color.Red;
                    break;
                case "Pall Mall":
                    P1PropertyPink1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyPink1.BackColor = Color.FromArgb(243, 69, 231);
                    break;
                case "Whitehall":
                    P1PropertyPink2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyPink2.BackColor = Color.FromArgb(243, 69, 231);
                    break;
                case "Bow St":
                    P1PropertyBrown1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyBrown1.BackColor = Color.FromArgb(128, 64, 0);
                    break;
                case "Vine St":
                    P1PropertyBrown2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P1PropertyBrown2.BackColor = Color.FromArgb(128, 64, 0);
                    break;
                default:

                    break;
            }
        }

        // This shows the current purchased properties by filling their colour for player 2 properties panel in the GUI
        // This method is called everytime a player purchases a new property
        public void DisplayPlayerProperties2(string message)
        {
            switch (message)
            {
                case "Strand":
                    P2PropertyBlack1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyBlack1.BackColor = Color.FromArgb(38, 38, 38);
                    break;
                case "Trafalgar Sq":
                    P2PropertyBlack2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyBlack2.BackColor = Color.FromArgb(38, 38, 38);
                    break;
                case "Leicester Sq":
                    P2PropertyAqua1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyAqua1.BackColor = Color.Aqua;
                    break;
                case "Piccadilly":
                    P2PropertyAqua2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyAqua2.BackColor = Color.Aqua;
                    break;
                case "Regent St":
                    P2PropertyYellow1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyYellow1.BackColor = Color.Yellow;
                    break;
                case "Oxford St":
                    P2PropertyYellow2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyYellow2.BackColor = Color.Yellow;
                    break;
                case "Mayfair":
                    P2PropertyGreen1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyGreen1.BackColor = Color.Green;
                    break;
                case "Park Lane":
                    P2PropertyGreen2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyGreen2.BackColor = Color.Green;
                    break;
                case "Old Kent Rd":
                    P2PropertyBlue1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyBlue1.BackColor = Color.FromArgb(32, 63, 153);
                    break;
                case "Whitechapel":
                    P2PropertyBlue2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyBlue2.BackColor = Color.FromArgb(32, 63, 153);
                    break;
                case "Islington":
                    P2PropertyRed1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyRed1.BackColor = Color.Red;
                    break;
                case "Euston":
                    P2PropertyRed2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyRed2.BackColor = Color.Red;
                    break;
                case "Pall Mall":
                    P2PropertyPink1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyPink1.BackColor = Color.FromArgb(243, 69, 231);
                    break;
                case "Whitehall":
                    P2PropertyPink2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyPink2.BackColor = Color.FromArgb(243, 69, 231);
                    break;
                case "Bow St":
                    P2PropertyBrown1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyBrown1.BackColor = Color.FromArgb(128, 64, 0);
                    break;
                case "Vine St":
                    P2PropertyBrown2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                    P2PropertyBrown2.BackColor = Color.FromArgb(128, 64, 0);
                    break;
                default:

                    break;
            }
        }

        public void clearPlayerPropertiesDisplay()
        {
            // Clears player 1 properties
            P1PropertyBlack1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyBlack2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyAqua1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyAqua2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyYellow1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyYellow2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyGreen1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyGreen2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyBlue1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyBlue2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyRed1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyRed2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyPink1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyPink2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyBrown1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P1PropertyBrown2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;

            // Clears player 1 properties
            P2PropertyBlack1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyBlack2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyAqua1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyAqua2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyYellow1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyYellow2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyGreen1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyGreen2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyBlue1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyBlue2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyRed1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyRed2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyPink1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyPink2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyBrown1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            P2PropertyBrown2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
        }

        #endregion


        #region Dice Display methods

        // Set dice box method
        public void setDiceImage(string message)
        {
            lblDiceDisplay.Text = (message);

            // Switches the dice image so that the correct image is displayed depending on the random number that is generated by the dice
            // This method is called from the program class everytime a player clicks on the dice roll button
            switch (message)
            {
                case "1":
                    pbDiceImage.Image = monopoly.Properties.Resources.Dice_1;
                    break;
                case "2":
                    pbDiceImage.Image = monopoly.Properties.Resources.Dice_2;
                    break;
                case "3":
                    pbDiceImage.Image = monopoly.Properties.Resources.Dice_3;
                    break;
                case "4":
                    pbDiceImage.Image = monopoly.Properties.Resources.Dice_4;
                    break;
                case "5":
                    pbDiceImage.Image = monopoly.Properties.Resources.Dice_5;
                    break;
                case "6":
                    pbDiceImage.Image = monopoly.Properties.Resources.Dice_6;
                    break;
                default:
                    break;
            }
        }

        #endregion


        #region Player Image Update methods

        // These set player image methods are called from the program class everytime a player moves
        // The players co-ordinates are passed in and the image location is updated on the screen

        // Set player 1 image location method
        public void setPlayerImage1(int X, int Y)
        {
            this.Player1Image.Location = new Point(X, Y);
        }

        // Set player 2 image location method
        public void setPlayerImage2(int X, int Y)
        {
            this.Player2Image.Location = new Point(X, Y);
        }

        // Set form enabled method
        public void SetFormEnabled(bool BoardFormEnable)
        {
            this.Enabled = BoardFormEnable;
        }

        #endregion


        #region Player Jail Update methods

        public void Player1JailTime()
        {
            // This method is called when a player is in jail
            // The method is used to determine how long a player has been in jail and the appropriate action to be taken
            switch (Player1TimeInJail)
            {
                case 1:
                    // Player misses a turn
                    MessageBox.Show("Your are in jail, so you miss a turn!");
                    Player1TimeInJail = 2;
                    break;
                case 2:
                    if (Program.playerMoney1 >= 250)
                    {
                        // Show the pay fine dialog box
                        DialogResult JailMessage = MessageBox.Show("Pay £250 fine or miss another turn?", "Jail", MessageBoxButtons.OKCancel);

                        if (JailMessage == DialogResult.OK)
                        {
                            // If the player chooses to pay the fine, they are released from prison
                            Program.playerMoney1 -= 250;
                            game.ResetPlayer1InJail();
                            Player1InJail = false;
                            Player1TimeInJail = 0;
                        }
                        else if (JailMessage == DialogResult.Cancel)
                        {
                            // If the player chooses not to pay the fine, they miss another turn
                            Player1TimeInJail = 3;
                        }
                    }
                    // If the player does not have enough money to pay the fine a message is displayed
                    else if (Program.playerMoney1 < 250)
                    {
                        MessageBox.Show("You do not have enough money to pay the fine, so you miss another turn!");
                        Player1TimeInJail = 3;
                    }
                    break;
                case 3:
                    // After missing 2 turns the player will be released from jail
                    game.ResetPlayer1InJail();
                    Player1InJail = false;
                    Player1TimeInJail = 0;
                    break;
            }
        }

        // This method is the same as above but for player 2
        public void Player2JailTime()
        {
            switch (Player2TimeInJail)
            {
                case 1:
                    // Player misses a turn
                    MessageBox.Show("Your are in jail, so you miss a turn!");
                    Player2TimeInJail = 2;
                    break;
                case 2:
                    if (Program.playerMoney2 >= 250)
                    {
                        // Show the pay fine dialog box
                        DialogResult JailMessage = MessageBox.Show("Pay £250 fine or miss another turn?", "Jail", MessageBoxButtons.OKCancel);

                        if (JailMessage == DialogResult.OK)
                        {
                            // If the player chooses to pay the fine, they are released from prison
                            Program.playerMoney2 -= 250;
                            game.ResetPlayer2InJail();
                            Player2InJail = false;
                            Player2TimeInJail = 0;
                        }
                        else if (JailMessage == DialogResult.Cancel)
                        {
                            // If the player chooses not to pay the fine, they miss another turn
                            Player2TimeInJail = 3;
                        }
                    }
                    // If the player does not have enough money to pay the fine a message is displayed
                    else if (Program.playerMoney2 < 250)
                    {
                        MessageBox.Show("You do not have enough money to pay the fine, so you miss another turn!");
                        Player2TimeInJail = 3;
                    }
                    break;
                case 3:
                    // After missing 2 turns the player will be released from jail
                    game.ResetPlayer2InJail();
                    Player2InJail = false;
                    Player2TimeInJail = 0;
                    break;
            }
        }

        #endregion


        #region Display Build Form method

        public void DisplayBuildForm(int player, string colour)
        {
            // This method displays the build form to allow users to build houses or shops on their properties
            // This method is called when a player clicks on a property in their property panel and they own both corresponding colours

            // Refrences the property purchase form 
            // I am using the property purchase form and changing the way its is presented to avoid creating multiple similar forms
            frmPropertyCard PropertyCardForm = new frmPropertyCard();

            // This tells the form how it should be presented (The panel that will be displayed)
            PropertyCardForm.setPanelType("Build Mode");

            bool showForm = false;
            int cost = 0;
            int newRent = 0;

            // Switches the build form values
            switch (colour)
            {
                case "Black 1":
                    // Sets the property name on the build form
                    PropertyCardForm.setBuildName("Strand");

                    // Sets the property colour for the build form
                    PropertyCardForm.setBuildColour("Black");

                    // If the user does not own a house on the current property the purchase house details are displayed
                    // If the user already owns a house, the purchase shop details are displayed
                    // An if the user already owns a shop, no form is displayed
                    if (pictureBoxBlack1Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxBlack1House.Visible == true)
                    {
                        // Sets the build type
                        PropertyCardForm.setBuildType("Shop");

                        PropertyCardForm.setShopMode();

                        // Displays the cost of a shop
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");

                        // Displays the rent with a shop
                        newRent = 352;
                        PropertyCardForm.setRentWithHouse("176");

                        // Displays the current rent
                        PropertyCardForm.setCurrentRent("132");

                        showForm = true;
                    }
                    else
                    {
                        // Sets the build type
                        PropertyCardForm.setBuildType("House");

                        // Displays the cost of a house
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");

                        // Displays the rent with a house
                        newRent = 264;
                        PropertyCardForm.setRentWithHouse("132");

                        // Displays the current rent
                        PropertyCardForm.setCurrentRent("110");

                        showForm = true;
                    }
                    break;
                case "Black 2":
                    PropertyCardForm.setBuildName("Trafalgar Sq");
                    PropertyCardForm.setBuildColour("Black");

                    if (pictureBoxBlack2Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxBlack2House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 352;
                        PropertyCardForm.setRentWithHouse("176");
                        PropertyCardForm.setCurrentRent("132");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 264;
                        PropertyCardForm.setRentWithHouse("132");
                        PropertyCardForm.setCurrentRent("110");
                        showForm = true;
                    }
                    break;
                case "Aqua 1":
                    PropertyCardForm.setBuildName("Leicester Sq");
                    PropertyCardForm.setBuildColour("Aqua");

                    if (pictureBoxAqua1Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxAqua1House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 448;
                        PropertyCardForm.setRentWithHouse("224");
                        PropertyCardForm.setCurrentRent("168");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 336;
                        PropertyCardForm.setRentWithHouse("168");
                        PropertyCardForm.setCurrentRent("140");
                        showForm = true;
                    }
                    break;
                case "Aqua 2":
                    PropertyCardForm.setBuildName("Picadilly");
                    PropertyCardForm.setBuildColour("Aqua");

                    if (pictureBoxAqua2Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxAqua2House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 448;
                        PropertyCardForm.setRentWithHouse("224");
                        PropertyCardForm.setCurrentRent("168");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 336;
                        PropertyCardForm.setRentWithHouse("168");
                        PropertyCardForm.setCurrentRent("140");
                        showForm = true;
                    }
                    break;
                case "Yellow 1":
                    PropertyCardForm.setBuildName("Regent St");
                    PropertyCardForm.setBuildColour("Yellow");

                    if (pictureBoxYellow1Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxYellow1House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 480;
                        PropertyCardForm.setRentWithHouse("240");
                        PropertyCardForm.setCurrentRent("180");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 360;
                        PropertyCardForm.setRentWithHouse("180");
                        PropertyCardForm.setCurrentRent("150");
                        showForm = true;
                    }
                    break;
                case "Yellow 2":
                    PropertyCardForm.setBuildName("Oxford St");
                    PropertyCardForm.setBuildColour("Yellow");

                    if (pictureBoxYellow2Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxYellow2House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 480;
                        PropertyCardForm.setRentWithHouse("240");
                        PropertyCardForm.setCurrentRent("180");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 360;
                        PropertyCardForm.setRentWithHouse("180");
                        PropertyCardForm.setCurrentRent("150");
                        showForm = true;
                    }
                    break;
                case "Green 1":
                    PropertyCardForm.setBuildName("Mayfair");
                    PropertyCardForm.setBuildColour("Green");

                    if (pictureBoxGreen1Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxGreen1House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 640;
                        PropertyCardForm.setRentWithHouse("320");
                        PropertyCardForm.setCurrentRent("240");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 480;
                        PropertyCardForm.setRentWithHouse("240");
                        PropertyCardForm.setCurrentRent("200");
                        showForm = true;
                    }
                    break;
                case "Green 2":
                    PropertyCardForm.setBuildName("Park Lane");
                    PropertyCardForm.setBuildColour("Green");

                    if (pictureBoxGreen2Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxGreen2House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 640;
                        PropertyCardForm.setRentWithHouse("320");
                        PropertyCardForm.setCurrentRent("240");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 480;
                        PropertyCardForm.setRentWithHouse("240");
                        PropertyCardForm.setCurrentRent("200");
                        showForm = true;
                    }
                    break;
                case "Blue 1":
                    PropertyCardForm.setBuildName("Old Kent Rd");
                    PropertyCardForm.setBuildColour("Blue");

                    if (pictureBoxBlue1Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxBlue1House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 96;
                        PropertyCardForm.setRentWithHouse("48");
                        PropertyCardForm.setCurrentRent("36");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 72;
                        PropertyCardForm.setRentWithHouse("36");
                        PropertyCardForm.setCurrentRent("30");
                        showForm = true;
                    }
                    break;
                case "Blue 2":
                    PropertyCardForm.setBuildName("Whitechapel Rd");
                    PropertyCardForm.setBuildColour("Blue");

                    if (pictureBoxBlue2Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxBlue2House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 96;
                        PropertyCardForm.setRentWithHouse("48");
                        PropertyCardForm.setCurrentRent("36");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 72;
                        PropertyCardForm.setRentWithHouse("36");
                        PropertyCardForm.setCurrentRent("30");
                        showForm = true;
                    }
                    break;
                case "Red 1":
                    PropertyCardForm.setBuildName("Islington");
                    PropertyCardForm.setBuildColour("Red");

                    if (pictureBoxRed1Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxRed1House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 160;
                        PropertyCardForm.setRentWithHouse("80");
                        PropertyCardForm.setCurrentRent("60");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 120;
                        PropertyCardForm.setRentWithHouse("60");
                        PropertyCardForm.setCurrentRent("50");
                        showForm = true;
                    }
                    break;
                case "Red 2":
                    PropertyCardForm.setBuildName("Euston");
                    PropertyCardForm.setBuildColour("Red");

                    if (pictureBoxRed2Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxRed2House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 160;
                        PropertyCardForm.setRentWithHouse("80");
                        PropertyCardForm.setCurrentRent("60");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 120;
                        PropertyCardForm.setRentWithHouse("60");
                        PropertyCardForm.setCurrentRent("50");
                        showForm = true;
                    }
                    break;
                case "Pink 1":
                    PropertyCardForm.setBuildName("Pall Mall");
                    PropertyCardForm.setBuildColour("Pink");

                    if (pictureBoxPink1Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxPink1House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 224;
                        PropertyCardForm.setRentWithHouse("112");
                        PropertyCardForm.setCurrentRent("84");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 168;
                        PropertyCardForm.setRentWithHouse("84");
                        PropertyCardForm.setCurrentRent("70");
                        showForm = true;
                    }
                    break;
                case "Pink 2":
                    PropertyCardForm.setBuildName("Whitehall");
                    PropertyCardForm.setBuildColour("Pink");

                    if (pictureBoxPink2Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxPink2House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 224;
                        PropertyCardForm.setRentWithHouse("112");
                        PropertyCardForm.setCurrentRent("84");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 168;
                        PropertyCardForm.setRentWithHouse("84");
                        PropertyCardForm.setCurrentRent("70");
                        showForm = true;
                    }
                    break;
                case "Brown 1":
                    PropertyCardForm.setBuildName("Vine St");
                    PropertyCardForm.setBuildColour("Brown");

                    if (pictureBoxBrown1Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxBrown1House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 288;
                        PropertyCardForm.setRentWithHouse("144");
                        PropertyCardForm.setCurrentRent("108");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 216;
                        PropertyCardForm.setRentWithHouse("108");
                        PropertyCardForm.setCurrentRent("90");
                        showForm = true;
                    }
                    break;
                case "Brown 2":
                    PropertyCardForm.setBuildName("Bow St");
                    PropertyCardForm.setBuildColour("Brown");

                    if (pictureBoxBrown2Shop.Visible == true)
                    {
                        showForm = false;
                    }
                    else if (pictureBoxBrown2House.Visible == true)
                    {
                        PropertyCardForm.setShopMode();
                        PropertyCardForm.setBuildType("Shop");
                        cost = 200;
                        PropertyCardForm.setBuildPrice("200");
                        newRent = 288;
                        PropertyCardForm.setRentWithHouse("144");
                        PropertyCardForm.setCurrentRent("108");
                        showForm = true;
                    }
                    else
                    {
                        PropertyCardForm.setBuildType("House");
                        cost = 100;
                        PropertyCardForm.setBuildPrice("100");
                        newRent = 216;
                        PropertyCardForm.setRentWithHouse("108");
                        PropertyCardForm.setCurrentRent("90");
                        showForm = true;
                    }
                    break;
            }

            // Shows the form as a dialog if the user has enough money to build on the property
            if (showForm == true)
            {
                if (player == 1 && Program.playerMoney1 >= cost)
                {
                    PropertyCardForm.ShowDialog();
                }
                else if (player == 1 && Program.playerMoney1 < cost)
                {
                    DialogResult Message = MessageBox.Show("You do not have enough money to build on this property!", "Message", MessageBoxButtons.OK);
                }

                if (player == 2 && Program.playerMoney2 >= cost)
                {
                    PropertyCardForm.ShowDialog();
                }
                else if (player == 2 && Program.playerMoney2 < cost)
                {
                    DialogResult Message = MessageBox.Show("You do not have enough money to build on this property!", "Message", MessageBoxButtons.OK);
                }
            }

            if (PropertyCardForm.HouseWasBuilt == true)
            {
                // If a house was purchased, the method is called to display the house on the board
                MakeHouseVisible(colour);

                // The cost of the house is then removed from the current players money
                if (player == 1)
                {
                    Program game = new Program(this);

                    Program.playerMoney1 -= cost;
                    setPlayerMoney1(Program.playerMoney1.ToString());

                    // Adds the house to the players house list
                    game.addToPlayerHouseList(1, colour);

                    // Updates the rent to reflect the type of building purchased
                    game.updateSquareRent(newRent, colour);

                }
                else if (player == 2)
                {
                    Program game = new Program(this);

                    Program.playerMoney2 -= cost;
                    setPlayerMoney2(Program.playerMoney2.ToString());

                    // Adds the house to the players house list
                    game.addToPlayerHouseList(2, colour);

                    // Updates the rent to reflect the type of building purchased
                    game.updateSquareRent(newRent, colour);
                }
            }
            else if (PropertyCardForm.ShopWasBuilt == true)
            {
                // If a shop was purchased, the method is called to display the shop on the board
                MakeShopVisible(colour);

                // The cost of the shop is then removed from the current players money
                if (player == 1)
                {
                    Program game = new Program(this);

                    Program.playerMoney1 -= cost;
                    setPlayerMoney1(Program.playerMoney1.ToString());

                    // Adds the shop to the players shop list
                    game.addToPlayerShopList(1, colour);

                    // Updates the rent to reflect the type of building purchased
                    game.updateSquareRent(newRent, colour);
                }
                else if (player == 2)
                {
                    Program game = new Program(this);

                    Program.playerMoney2 -= cost;
                    setPlayerMoney2(Program.playerMoney2.ToString());

                    // Adds the shop to the players shop list
                    game.addToPlayerShopList(2, colour);

                    // Updates the rent to reflect the type of building purchased
                    game.updateSquareRent(newRent, colour);
                }

            }
        }

        #endregion


        #region Build House method

        public void MakeHouseVisible(string colour)
        {
            // This method is used to make a specific house visible on the board
            // The method is called when a player builds a house for their property

            // Switches the build form values
            switch (colour)
            {
                case "Black 1":
                    pictureBoxBlack1House.Visible = true;
                    break;
                case "Black 2":
                    pictureBoxBlack2House.Visible = true;
                    break;
                case "Aqua 1":
                    pictureBoxAqua1House.Visible = true;
                    break;
                case "Aqua 2":
                    pictureBoxAqua2House.Visible = true;
                    break;
                case "Yellow 1":
                    pictureBoxYellow1House.Visible = true;
                    break;
                case "Yellow 2":
                    pictureBoxYellow2House.Visible = true;
                    break;
                case "Green 1":
                    pictureBoxGreen1House.Visible = true;
                    break;
                case "Green 2":
                    pictureBoxGreen2House.Visible = true;
                    break;
                case "Blue 1":
                    pictureBoxBlue1House.Visible = true;
                    break;
                case "Blue 2":
                    pictureBoxBlue2House.Visible = true;
                    break;
                case "Red 1":
                    pictureBoxRed1House.Visible = true;
                    break;
                case "Red 2":
                    pictureBoxRed2House.Visible = true;
                    break;
                case "Pink 1":
                    pictureBoxPink1House.Visible = true;
                    break;
                case "Pink 2":
                    pictureBoxPink2House.Visible = true;
                    break;
                case "Brown 1":
                    pictureBoxBrown1House.Visible = true;
                    break;
                case "Brown 2":
                    pictureBoxBrown2House.Visible = true;
                    break;
            }
        }

        #endregion


        #region Build Shop method

        public void MakeShopVisible(string colour)
        {
            // This makes the shop image visible after it has been purchased
            // Because I have made the shop image visible and brought it to the front,
            // I would not normally need to set the house visibilty to false, because the shop image would hide the house image
            // But another part of the code does a check to determine the house visibilty value, which is why I have included it here
            switch (colour)
            {
                case "Black 1":
                    pictureBoxBlack1House.Visible = false;
                    pictureBoxBlack1Shop.Visible = true;
                    pictureBoxBlack1Shop.BringToFront();
                    break;
                case "Black 2":
                    pictureBoxBlack2House.Visible = false;
                    pictureBoxBlack2Shop.Visible = true;
                    pictureBoxBlack2Shop.BringToFront();
                    break;
                case "Aqua 1":
                    pictureBoxAqua1House.Visible = false;
                    pictureBoxAqua1Shop.Visible = true;
                    pictureBoxAqua1Shop.BringToFront();
                    break;
                case "Aqua 2":
                    pictureBoxAqua2House.Visible = false;
                    pictureBoxAqua2Shop.Visible = true;
                    pictureBoxAqua2Shop.BringToFront();
                    break;
                case "Yellow 1":
                    pictureBoxYellow1House.Visible = false;
                    pictureBoxYellow1Shop.Visible = true;
                    pictureBoxYellow1Shop.BringToFront();
                    break;
                case "Yellow 2":
                    pictureBoxYellow2House.Visible = false;
                    pictureBoxYellow2Shop.Visible = true;
                    pictureBoxYellow2Shop.BringToFront();
                    break;
                case "Green 1":
                    pictureBoxGreen1House.Visible = false;
                    pictureBoxGreen1Shop.Visible = true;
                    pictureBoxGreen1Shop.BringToFront();
                    break;
                case "Green 2":
                    pictureBoxGreen2House.Visible = false;
                    pictureBoxGreen2Shop.Visible = true;
                    pictureBoxGreen2Shop.BringToFront();
                    break;
                case "Blue 1":
                    pictureBoxBlue1House.Visible = false;
                    pictureBoxBlue1Shop.Visible = true;
                    pictureBoxBlue1Shop.BringToFront();
                    break;
                case "Blue 2":
                    pictureBoxBlue2House.Visible = false;
                    pictureBoxBlue2Shop.Visible = true;
                    pictureBoxBlue2Shop.BringToFront();
                    break;
                case "Red 1":
                    pictureBoxRed1House.Visible = false;
                    pictureBoxRed1Shop.Visible = true;
                    pictureBoxRed1Shop.BringToFront();
                    break;
                case "Red 2":
                    pictureBoxRed2House.Visible = false;
                    pictureBoxRed2Shop.Visible = true;
                    pictureBoxRed2Shop.BringToFront();
                    break;
                case "Pink 1":
                    pictureBoxPink1House.Visible = false;
                    pictureBoxPink1Shop.Visible = true;
                    pictureBoxPink1Shop.BringToFront();
                    break;
                case "Pink 2":
                    pictureBoxPink2House.Visible = false;
                    pictureBoxPink2Shop.Visible = true;
                    pictureBoxPink2Shop.BringToFront();
                    break;
                case "Brown 1":
                    pictureBoxBrown1House.Visible = false;
                    pictureBoxBrown1Shop.Visible = true;
                    pictureBoxBrown1Shop.BringToFront();
                    break;
                case "Brown 2":
                    pictureBoxBrown2House.Visible = false;
                    pictureBoxBrown2Shop.Visible = true;
                    pictureBoxBrown2Shop.BringToFront();
                    break;
            }
        }

        #endregion


        #region GUI Buttons


        #region Dice Button

        // Dice roll button
        // this method is called everytime the dice roll button is clicked
        private void btnRollDice_Click(object sender, EventArgs e)
        {
            if (CurrentPlayer == 1)
            {
                game = new Program(this);

                listBoxProperties1.Items.Clear();

                // Checks if Player 1 is currently in jail
                Player1JailTime();

                if (Player1InJail == false)
                {
                    // This calls the method that performs the players actual move in the program class
                    game.Player1Move();

                    // Moves the player 1 image
                    game.MovePlayerImage1();
                }
                CurrentPlayer = 2;
                lblPlayersTurn.Text = "It's Dog's Turn";
                btnRollDice.BackColor = Color.FromArgb(100, 220, 100);

                // This prevents the player from taking multiple loans
                if (Program._player2HasLoan == true)
                {
                    btnBank.Enabled = false;
                }
                else
                {
                    btnBank.Enabled = true;
                }
            }
            else if (CurrentPlayer == 2)
            {
                game = new Program(this);

                listBoxProperties2.Items.Clear();

                // Checks if Player 2 is currently in jail
                Player2JailTime();

                if (Player2InJail == false)
                {
                    // This calls the method that performs the players actual move in the program class
                    game.Player2Move();

                    // Moves the player 2 image
                    game.MovePlayerImage2();
                }
                CurrentPlayer = 1;
                lblPlayersTurn.Text = "It's Car's Turn";
                btnRollDice.BackColor = Color.FromArgb(236, 62, 62);

                // This prevents the player from taking multiple loans
                if (Program._player1HasLoan == true)
                {
                    btnBank.Enabled = false;
                }
                else
                {
                    btnBank.Enabled = true;
                }
            }
        }

        #endregion


        #region Menu Buttons

        // Menu file button
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This sets the path of the save file
            string gameDataPath = appPath.Remove(appPath.Length - 9);
            gameDataPath = gameDataPath + "Data\\Save.txt";

            // This checks to see if there is a previously saved file
            // If the file exists, the load game menu item will be enabled
            if (File.Exists(gameDataPath))
            {
                loadGameToolStripMenuItem.Enabled = true;
            }
            else
            {
                loadGameToolStripMenuItem.Enabled = false;
            }
        }

        // Menu start button
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program game = new Program(this);
            saveGameToolStripMenuItem.Enabled = true;

            // Stops the opening theme music
            openingThemePlayer.Stop();

            // This sets the path of the audio files
            string gameDataPath = appPath.Remove(appPath.Length - 9);
            gameDataPath = gameDataPath + "Data\\Background_Theme.wav";

            // Starts the main game background music
            System.Media.SoundPlayer backgroundThemePlayer = new System.Media.SoundPlayer(gameDataPath);
            backgroundThemePlayer.PlayLooping();

            // Starts a new game
            showMainPanel(true);
            game.newGame();
        }

        // Menu save button
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program game = new Program(this);
            game.SaveGame();
        }

        // Menu load button
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program game = new Program(this);
            showMainPanel(true);
            game.LoadGame("Save.txt");
            saveGameToolStripMenuItem.Enabled = true;

            // Stops the opening theme music
            openingThemePlayer.Stop();

            // This sets the path of the audio files
            string gameDataPath = appPath.Remove(appPath.Length - 9);
            gameDataPath = gameDataPath + "Data\\Background_Theme.wav";

            // Starts the main game background music
            System.Media.SoundPlayer backgroundThemePlayer = new System.Media.SoundPlayer(gameDataPath);
            backgroundThemePlayer.PlayLooping();
        }

        // Menu debug button
        private void debugMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This displays the debug form
            frmDebug debug = new frmDebug();
            debug.ShowDialog();

            if (debug.debugEnabled == true)
            {
                Program game = new Program(this);

                showMainPanel(true);

                // This uses the load game method and just passes in the debug.txt file instead of the Save.txt file
                game.LoadGame("Debug.txt");
                saveGameToolStripMenuItem.Enabled = true;

                // Stops the opening theme music
                openingThemePlayer.Stop();

                // This sets the path of the audio files
                string gameDataPath = appPath.Remove(appPath.Length - 9);
                gameDataPath = gameDataPath + "Data\\Background_Theme.wav";

                // Starts the main game background music
                System.Media.SoundPlayer backgroundThemePlayer = new System.Media.SoundPlayer(gameDataPath);
                backgroundThemePlayer.PlayLooping();

                debugMenuToolStripMenuItem.Enabled = false;
            }
        }

        // Menu exit button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exits the program
            this.Close();
        }

        // Player 1 button
        private void btnPlayer1_Click_1(object sender, EventArgs e)
        {
            panelPlayerProperties1.BringToFront();
        }

        // Player 2 button
        private void btnPlayer2_Click_1(object sender, EventArgs e)
        {
            panelPlayerProperties2.BringToFront();
        }

        // Bank button
        private void btnBank_Click(object sender, EventArgs e)
        {
            frmBank Bank = new frmBank();
            Bank.ShowDialog();

            // If a player accepts a loan, the values are set in the program class
            if (Bank.loanTaken == true)
            {
                Program game = new Program(this);

                game.resetPlayerRollNumber(CurrentPlayer);
                game.setPlayerLoan(CurrentPlayer, Bank.loanAmount);
                btnBank.Enabled = false;
            }
        }

        #endregion


        #region Player 1 Property Click methods

        // If a player clicks on a property square, this will check to see if the player owns both of the properties
        // If the player only owns 1 of the properties a message is displayed
        // If the player owns both of the propertis the display build form method is called

        // Player 1 black property 1 click event
        private void P1PropertyBlack1_Click(object sender, EventArgs e)
        {
            if (P1PropertyBlack1.BackColor == Color.FromArgb(38, 38, 38))
            {
                if (P1PropertyBlack2.BackColor == Color.FromArgb(38, 38, 38))
                {
                    DisplayBuildForm(1, "Black 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other black property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 black property 2 click event
        private void P1PropertyBlack2_Click(object sender, EventArgs e)
        {
            if (P1PropertyBlack2.BackColor == Color.FromArgb(38, 38, 38))
            {
                if (P1PropertyBlack1.BackColor == Color.FromArgb(38, 38, 38))
                {
                    DisplayBuildForm(1, "Black 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other black property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 Aqua property 1 click event
        private void P1PropertyAqua1_Click(object sender, EventArgs e)
        {
            if (P1PropertyAqua1.BackColor == Color.Aqua)
            {
                if (P1PropertyAqua2.BackColor == Color.Aqua)
                {
                    DisplayBuildForm(1, "Aqua 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other aqua property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 Aqua property 2 click event
        private void P1PropertyAqua2_Click(object sender, EventArgs e)
        {
            if (P1PropertyAqua2.BackColor == Color.Aqua)
            {
                if (P1PropertyAqua1.BackColor == Color.Aqua)
                {
                    DisplayBuildForm(1, "Aqua 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other aqua property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 yellow property 1 click event
        private void P1PropertyYellow1_Click(object sender, EventArgs e)
        {
            if (P1PropertyYellow1.BackColor == Color.Yellow)
            {
                if (P1PropertyYellow2.BackColor == Color.Yellow)
                {
                    DisplayBuildForm(1, "Yellow 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other yellow property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 yellow property 2 click event
        private void P1PropertyYellow2_Click(object sender, EventArgs e)
        {
            if (P1PropertyYellow2.BackColor == Color.Yellow)
            {
                if (P1PropertyYellow1.BackColor == Color.Yellow)
                {
                    DisplayBuildForm(1, "Yellow 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other yellow property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 green property 1 click event
        private void P1PropertyGreen1_Click(object sender, EventArgs e)
        {
            if (P1PropertyGreen1.BackColor == Color.Green)
            {
                if (P1PropertyGreen2.BackColor == Color.Green)
                {
                    DisplayBuildForm(1, "Green 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other green property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 green property 2 click event
        private void P1PropertyGreen2_Click(object sender, EventArgs e)
        {
            if (P1PropertyGreen2.BackColor == Color.Green)
            {
                if (P1PropertyGreen1.BackColor == Color.Green)
                {
                    DisplayBuildForm(1, "Green 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other green property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 blue property 1 click event
        private void P1PropertyBlue1_Click(object sender, EventArgs e)
        {
            if (P1PropertyBlue1.BackColor == Color.FromArgb(32, 63, 153))
            {
                if (P1PropertyBlue2.BackColor == Color.FromArgb(32, 63, 153))
                {
                    DisplayBuildForm(1, "Blue 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other blue property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 blue property 2 click event
        private void P1PropertyBlue2_Click(object sender, EventArgs e)
        {
            if (P1PropertyBlue2.BackColor == Color.FromArgb(32, 63, 153))
            {
                if (P1PropertyBlue1.BackColor == Color.FromArgb(32, 63, 153))
                {
                    DisplayBuildForm(1, "Blue 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other blue property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 red property 1 click event
        private void P1PropertyRed1_Click(object sender, EventArgs e)
        {
            if (P1PropertyRed1.BackColor == Color.Red)
            {
                if (P1PropertyRed2.BackColor == Color.Red)
                {
                    DisplayBuildForm(1, "Red 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other red property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 red property 2 click event
        private void P1PropertyRed2_Click(object sender, EventArgs e)
        {
            if (P1PropertyRed2.BackColor == Color.Red)
            {
                if (P1PropertyRed1.BackColor == Color.Red)
                {
                    DisplayBuildForm(1, "Red 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other red property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 pink property 1 click event
        private void P1PropertyPink1_Click(object sender, EventArgs e)
        {
            if (P1PropertyPink1.BackColor == Color.FromArgb(243, 69, 231))
            {
                if (P1PropertyPink2.BackColor == Color.FromArgb(243, 69, 231))
                {
                    DisplayBuildForm(1, "Pink 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other pink property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 pink property 2 click event
        private void P1PropertyPink2_Click(object sender, EventArgs e)
        {
            if (P1PropertyPink2.BackColor == Color.FromArgb(243, 69, 231))
            {
                if (P1PropertyPink1.BackColor == Color.FromArgb(243, 69, 231))
                {
                    DisplayBuildForm(1, "Pink 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other pink property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 brown property 1 click event
        private void P1PropertyBrown1_Click(object sender, EventArgs e)
        {
            if (P1PropertyBrown1.BackColor == Color.FromArgb(128, 64, 0))
            {
                if (P1PropertyBrown2.BackColor == Color.FromArgb(128, 64, 0))
                {
                    DisplayBuildForm(1, "Brown 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other brown property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 1 brown property 2 click event
        private void P1PropertyBrown2_Click(object sender, EventArgs e)
        {
            if (P1PropertyBrown2.BackColor == Color.FromArgb(128, 64, 0))
            {
                if (P1PropertyBrown1.BackColor == Color.FromArgb(128, 64, 0))
                {
                    DisplayBuildForm(1, "Brown 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other brown property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }

        #endregion


        #region Player 2 Property Click methods

        // Player 2 black property 1 click event
        private void P2PropertyBlack1_Click(object sender, EventArgs e)
        {
            if (P2PropertyBlack1.BackColor == Color.FromArgb(38, 38, 38))
            {
                if (P2PropertyBlack2.BackColor == Color.FromArgb(38, 38, 38))
                {
                    DisplayBuildForm(2, "Black 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other black property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 black property 2 click event
        private void P2PropertyBlack2_Click(object sender, EventArgs e)
        {
            if (P2PropertyBlack2.BackColor == Color.FromArgb(38, 38, 38))
            {
                if (P2PropertyBlack1.BackColor == Color.FromArgb(38, 38, 38))
                {
                    DisplayBuildForm(2, "Black 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other black property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 aqua property 1 click event
        private void P2PropertyAqua1_Click(object sender, EventArgs e)
        {
            if (P2PropertyAqua1.BackColor == Color.Aqua)
            {
                if (P2PropertyAqua2.BackColor == Color.Aqua)
                {
                    DisplayBuildForm(2, "Aqua 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other aqua property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 aqua property 2 click event
        private void P2PropertyAqua2_Click(object sender, EventArgs e)
        {
            if (P2PropertyAqua2.BackColor == Color.Aqua)
            {
                if (P2PropertyAqua1.BackColor == Color.Aqua)
                {
                    DisplayBuildForm(2, "Aqua 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other aqua property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 yellow property 1 click event
        private void P2PropertyYellow1_Click(object sender, EventArgs e)
        {
            if (P2PropertyYellow1.BackColor == Color.Yellow)
            {
                if (P2PropertyYellow2.BackColor == Color.Yellow)
                {
                    DisplayBuildForm(2, "Yellow 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other yellow property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 yellow property 2 click event
        private void P2PropertyYellow2_Click(object sender, EventArgs e)
        {
            if (P2PropertyYellow2.BackColor == Color.Yellow)
            {
                if (P2PropertyYellow1.BackColor == Color.Yellow)
                {
                    DisplayBuildForm(2, "Yellow 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other yellow property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 green property 1 click event
        private void P2PropertyGreen1_Click(object sender, EventArgs e)
        {
            if (P2PropertyGreen1.BackColor == Color.Green)
            {
                if (P2PropertyGreen2.BackColor == Color.Green)
                {
                    DisplayBuildForm(2, "Green 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other green property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 green property 2 click event
        private void P2PropertyGreen2_Click(object sender, EventArgs e)
        {
            if (P2PropertyGreen2.BackColor == Color.Green)
            {
                if (P2PropertyGreen1.BackColor == Color.Green)
                {
                    DisplayBuildForm(2, "Green 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other green property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 blue property 1 click event
        private void P2PropertyBlue1_Click(object sender, EventArgs e)
        {
            if (P2PropertyBlue1.BackColor == Color.FromArgb(32, 63, 153))
            {
                if (P2PropertyBlue2.BackColor == Color.FromArgb(32, 63, 153))
                {
                    DisplayBuildForm(2, "Blue 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other blue property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 blue property 2 click event
        private void P2PropertyBlue2_Click(object sender, EventArgs e)
        {
            if (P2PropertyBlue2.BackColor == Color.FromArgb(32, 63, 153))
            {
                if (P2PropertyBlue1.BackColor == Color.FromArgb(32, 63, 153))
                {
                    DisplayBuildForm(2, "Blue 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other blue property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 red property 1 click event
        private void P2PropertyRed1_Click(object sender, EventArgs e)
        {
            if (P2PropertyRed1.BackColor == Color.Red)
            {
                if (P2PropertyRed2.BackColor == Color.Red)
                {
                    DisplayBuildForm(2, "Red 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other red property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 red property 2 click event
        private void P2PropertyRed2_Click(object sender, EventArgs e)
        {
            if (P2PropertyRed2.BackColor == Color.Red)
            {
                if (P2PropertyRed1.BackColor == Color.Red)
                {
                    DisplayBuildForm(2, "Red 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other red property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 pink property 1 click event
        private void P2PropertyPink1_Click(object sender, EventArgs e)
        {
            if (P2PropertyPink1.BackColor == Color.FromArgb(243, 69, 231))
            {
                if (P2PropertyPink2.BackColor == Color.FromArgb(243, 69, 231))
                {
                    DisplayBuildForm(2, "Pink 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other pink property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 pink property 2 click event
        private void P2PropertyPink2_Click(object sender, EventArgs e)
        {
            if (P2PropertyPink2.BackColor == Color.FromArgb(243, 69, 231))
            {
                if (P2PropertyPink1.BackColor == Color.FromArgb(243, 69, 231))
                {
                    DisplayBuildForm(2, "Pink 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other pink property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 brown property 1 click event
        private void P2PropertyBrown1_Click(object sender, EventArgs e)
        {
            if (P2PropertyBrown1.BackColor == Color.FromArgb(128, 64, 0))
            {
                if (P2PropertyBrown2.BackColor == Color.FromArgb(128, 64, 0))
                {
                    DisplayBuildForm(2, "Brown 1");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other brown property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }
        // Player 2 brown property 2 click event
        private void P2PropertyBrown2_Click(object sender, EventArgs e)
        {
            if (P2PropertyBrown2.BackColor == Color.FromArgb(128, 64, 0))
            {
                if (P2PropertyBrown1.BackColor == Color.FromArgb(128, 64, 0))
                {
                    DisplayBuildForm(2, "Brown 2");
                }
                else
                {
                    DialogResult Message = MessageBox.Show("You need to own the other brown property in order to build!", "Message", MessageBoxButtons.OK);
                }
            }
        }

        #endregion

    }
        #endregion
}
