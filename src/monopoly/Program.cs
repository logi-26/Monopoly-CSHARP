using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace monopoly
{
    public class Program
    {
        /******************************************************************************************************
         Created by Louis Gilmartin:          Last updated 29/11/2013
        ******************************************************************************************************/

        #region Variables

        // String to hold the app directory
        // this is used for the save file and audio file paths
        private string appPath = System.IO.Directory.GetCurrentDirectory();

        // Create the players
        private Player player1 = new Player();
        private Player player2 = new Player();

        // Creates the board squares
        private Square head;
        private Square tail;
        private Square square0 = new Square();
        private Square square1 = new Square();
        private Square square2 = new Square();
        private Square square3 = new Square();
        private Square square4 = new Square();
        private Square square5 = new Square();
        private Square square6 = new Square();
        private Square square7 = new Square();
        private Square square8 = new Square();
        private Square square9 = new Square();
        private Square square10 = new Square();
        private Square square11 = new Square();
        private Square square12 = new Square();
        private Square square13 = new Square();
        private Square square14 = new Square();
        private Square square15 = new Square();
        private Square square16 = new Square();
        private Square square17 = new Square();
        private Square square18 = new Square();
        private Square square19 = new Square();
        private Square square20 = new Square();
        private Square square21 = new Square();
        private Square square22 = new Square();
        private Square square23 = new Square();

        // Square rent values
        // These can change if a player purchases a house or shop
        private static int squareBlack1Rent = 220;
        private static int squareBlack2Rent = 220;
        private static int squareAqua1Rent = 280;
        private static int squareAqua2Rent = 280;
        private static int squareYellow1Rent = 300;
        private static int squareYellow2Rent = 300;
        private static int squareGreen1Rent = 400;
        private static int squareGreen2Rent = 400;
        private static int squareBlue1Rent = 60;
        private static int squareBlue2Rent = 60;
        private static int squareRed1Rent = 100;
        private static int squareRed2Rent = 100;
        private static int squarePink1Rent = 140;
        private static int squarePink2Rent = 140;
        private static int squareBrown1Rent = 180;
        private static int squareBrown2Rent = 180;

        // Create the card array
        private string[] cardArray = new string[16];
        private static string currentPlayer;

        private string specialCard;
        private static int lastSpecialCard = 20;
        private bool PropertyBeenPurchased = false;
        private Random random = new Random();

        // Holds player 1 values
        private Square player1CurrentSquare;
        public static int playerMoney1 = 2000;
        public static int playerPosition1 = 0;
        public static int _Player1TimeInJail;
        public static bool _Player1InJail;
        private static int player1RollNumber;
        private static bool player1HasLoan;
        private static int player1LoanAmount;
        private int Player1x = 50;
        private int Player1y = 55;

        // Holds player 2 values
        private Square player2CurrentSquare;
        public static int playerMoney2 = 2000;
        public static int playerPosition2 = 0;
        public static int _Player2TimeInJail;
        public static bool _Player2InJail;
        private static int player2RollNumber;
        private static bool player2HasLoan;
        private static int player2LoanAmount;
        private int Player2x = 25;
        private int Player2y = 55;

        // Property lists for the players
        public static List<string> PlayerProperyList1 = new List<string>();
        public static List<string> PlayerProperyList2 = new List<string>();

        // House lists for the players
        private static List<string> PlayerHouseList1 = new List<string>();
        private static List<string> PlayerHouseList2 = new List<string>();

        // Shop lists for the players
        private static List<string> PlayerShopList1 = new List<string>();
        private static List<string> PlayerShopList2 = new List<string>();

        private frmBoard frmBoard;

        #endregion

        // Initialize the form
        public Program(monopoly.frmBoard frmBoard)
        {
            this.frmBoard = frmBoard;
            startGame();
        }

        #region Initialize Board List method

        // Initialises the board list
        // This creates a linked list of squares and sets the values for each square
        public void InitializeBoardList()
        {
            head = square0;
            tail = square23;

            square0.name = "GO";
            square0.colour = "None";
            square0.isProperty = false;
            square0.location = 0;
            square0.next = square1;
            square0.previous = square23;

            square1.name = "Strand";
            square1.colour = "Black";
            square1.value = squareBlack1Rent;
            square1.location = 1;
            square1.next = square2;
            square1.previous = square0;

            square2.name = "Trafalgar Sq";
            square2.colour = "Black";
            square2.value = squareBlack2Rent;
            square2.location = 2;
            square2.next = square3;
            square2.previous = square1;

            square3.name = "Gas";
            square3.colour = "None";
            square3.isProperty = false;
            square3.location = 3;
            square3.next = square4;
            square3.previous = square2;

            square4.name = "Leicester Sq";
            square4.colour = "Aqua";
            square4.value = squareAqua1Rent;
            square4.location = 4;
            square4.next = square5;
            square4.previous = square3;

            square5.name = "Piccadilly";
            square5.colour = "Aqua";
            square5.value = squareAqua2Rent;
            square5.location = 5;
            square5.next = square6;
            square5.previous = square4;

            square6.name = "Card 1";
            square6.colour = "None";
            square6.isProperty = false;
            square6.location = 6;
            square6.next = square7;
            square6.previous = square5;

            square7.name = "Regent St";
            square7.colour = "Yellow";
            square7.value = squareYellow1Rent;
            square7.location = 7;
            square7.next = square8;
            square7.previous = square6;

            square8.name = "Oxford St";
            square8.colour = "Yellow";
            square8.value = squareYellow2Rent;
            square8.location = 8;
            square8.next = square9;
            square8.previous = square7;

            square9.name = "Electric";
            square9.colour = "None";
            square9.isProperty = false;
            square9.location = 9;
            square9.next = square10;
            square9.previous = square8;

            square10.name = "Mayfair";
            square10.colour = "Green";
            square10.value = squareGreen1Rent;
            square10.location = 10;
            square10.next = square11;
            square10.previous = square9;

            square11.name = "Park Lane";
            square11.colour = "Green";
            square11.value = squareGreen2Rent;
            square11.location = 11;
            square11.next = square12;
            square11.previous = square10;

            square12.name = "Jail";
            square12.colour = "None";
            square12.isProperty = false;
            square12.location = 12;
            square12.next = square13;
            square12.previous = square11;

            square13.name = "Old Kent Rd";
            square13.colour = "Blue";
            square13.value = squareBlue1Rent;
            square13.location = 13;
            square13.next = square14;
            square13.previous = square12;

            square14.name = "Whitechapel";
            square14.colour = "Blue";
            square14.value = squareBlue2Rent;
            square14.location = 14;
            square14.next = square15;
            square14.previous = square13;

            square15.name = "Water";
            square15.colour = "None";
            square15.isProperty = false;
            square15.location = 15;
            square15.next = square16;
            square15.previous = square14;

            square16.name = "Islington";
            square16.colour = "Red";
            square16.value = squareRed1Rent;
            square16.location = 16;
            square16.next = square17;
            square16.previous = square15;

            square17.name = "Euston";
            square17.colour = "Red";
            square17.value = squareRed2Rent;
            square17.location = 17;
            square17.next = square18;
            square17.previous = square16;

            square18.name = "Card 2";
            square18.colour = "None";
            square18.isProperty = false;
            square18.location = 18;
            square18.next = square19;
            square18.previous = square17;

            square19.name = "Pall Mall";
            square19.colour = "Pink";
            square19.value = squarePink1Rent;
            square19.location = 19;
            square19.next = square20;
            square19.previous = square18;

            square20.name = "Whitehall";
            square20.colour = "Pink";
            square20.value = squarePink2Rent;
            square20.location = 20;
            square20.next = square21;
            square20.previous = square19;

            square21.name = "Phone";
            square21.colour = "None";
            square21.isProperty = false;
            square21.location = 21;
            square21.next = square22;
            square21.previous = square20;

            square22.name = "Bow St";
            square22.colour = "Brown";
            square22.value = squareBrown1Rent;
            square22.location = 22;
            square22.next = square23;
            square22.previous = square21;

            square23.name = "Vine St";
            square23.colour = "Brown";
            square23.value = squareBrown2Rent;
            square23.location = 23;
            square23.next = square0;
            square23.previous = square22;
        }

        #endregion


        #region Initialize Card Array method

        // Initialises the card array
        // This array holds the strings that represent chance cards
        // This method is called each time a player lands on a chance square
        public void InitializeCardArray()
        {
            cardArray[0] = "You have won the lottery, collect £1000";
            cardArray[1] = "You have been awarded a regeneration grant, collect £500";
            cardArray[2] = "Advance to Go and collect £200";
            cardArray[3] = "It is your birthday, collect £50";
            cardArray[4] = "You inherit £1200";
            cardArray[5] = "Doctor's fees, pay £50";
            cardArray[6] = "Pay income tax of £100";
            cardArray[7] = "Pay medical fees of £200";
            cardArray[8] = "Pay for street repairs of £500";
            cardArray[9] = "Go to Jail, do not pass Go and do not collect £200";
            cardArray[10] = "Bank error in your favour, collect £200";
            cardArray[11] = "Holiday fund matures, collect £150";
            cardArray[12] = "Income tax refund, collect £100";
            cardArray[13] = "Speeding fine, pay £150";
            cardArray[14] = "Pay school fees of £200";
            cardArray[15] = "Parking fine, pay £50";

            // Generates a random number between 0-15
            int CardRandom = random.Next(0, 16);

            // This prevents the same card from being picked twice in a row
            while (CardRandom == lastSpecialCard)
            {
                CardRandom = random.Next(0, 16);
            }

            // This sets the value of the last card picked
            lastSpecialCard = CardRandom;

            specialCard = cardArray[CardRandom];
        }

        #endregion


        #region Initialise Player method

        // Initialises the players
        // this gives each player a name and starts them off at the GO square
        public void InitializePlayers()
        {
            player1.Name = "Car";
            player1.CurrentSquare = 0;
            player1CurrentSquare = square0;

            player2.Name = "Dog";
            player2.CurrentSquare = 0;
            player2CurrentSquare = square0;
        }

        #endregion


        #region Start Game method

        // This method is called when a game is started
        // The method initialises the players and the board
        public void startGame()
        {
            InitializePlayers();
            InitializeBoardList();
        }

        #endregion


        #region New Game method

        // This method is called when a new game is selected
        // The method resets all of the main values in the game so that a fresh game can begin
        public void newGame()
        {
            InitializePlayers();
            InitializeBoardList();

            // Resets the value of the property squares
            squareBlack1Rent = 220;
            squareBlack2Rent = 220;
            squareAqua1Rent = 280;
            squareAqua2Rent = 280;
            squareYellow1Rent = 300;
            squareYellow2Rent = 300;
            squareGreen1Rent = 400;
            squareGreen2Rent = 400;
            squareBlue1Rent = 60;
            squareBlue2Rent = 60;
            squareRed1Rent = 100;
            squareRed2Rent = 100;
            squarePink1Rent = 140;
            squarePink2Rent = 140;
            squareBrown1Rent = 180;
            squareBrown2Rent = 180;

            // This resets all of the houses and shops in the game
            frmBoard.resetBuiltProperties();

            // This resets the players purchased properties from the GUI panel
            frmBoard.resetPurchasedProperties();

            // Clears the player 1 property, house and shop lists
            PlayerProperyList1.Clear();
            PlayerHouseList1.Clear();
            PlayerShopList1.Clear();

            // Clears the player 2 property, house and shop lists
            PlayerProperyList2.Clear();
            PlayerHouseList2.Clear();
            PlayerShopList2.Clear();

            // Resets player 1 values
            player1CurrentSquare = square0;
            playerMoney1 = 2000;
            playerPosition1 = 0;
            _Player1TimeInJail = 0;
            _Player1InJail = false;
            Player1x = 50;
            Player1y = 55;

            // Resets player 2 values
            player2CurrentSquare = square0;
            playerMoney2 = 2000;
            playerPosition2 = 0;
            _Player2TimeInJail = 0;
            _Player2InJail = false;
            Player2x = 50;
            Player2y = 55;

            currentPlayer = player1.Name;
            lastSpecialCard = 20;

            // Moves the player images to the correct location
            MovePlayerImage1();
            MovePlayerImage2();

            // Displays the players current money
            frmBoard.setPlayerMoney1(playerMoney1.ToString());
            frmBoard.setPlayerMoney2(playerMoney2.ToString());
        }

        #endregion


        #region Add House/Shop methods

        // Adds houses to the players house list
        // These methods are called when a game is loaded
        public void addToPlayerHouseList(int player, string house)
        {
            if (player == 1)
            {
                PlayerHouseList1.Add(house);
            }
            else if (player == 2)
            {
                PlayerHouseList2.Add(house);
            }
        }

        // Adds shops to the players shop list
        public void addToPlayerShopList(int player, string shop)
        {
            if (player == 1)
            {
                PlayerShopList1.Add(shop);
            }
            else if (player == 2)
            {
                PlayerShopList2.Add(shop);
            }
        }

        #endregion


        #region Property Form Display method

        // Displays the property form and passes the specific values
        // The property card form is used to display the chance cards, property cards, and build cards
        // The form contains 3 panels that have slightly different elements
        // Different panels are displayed depending on the situation
        public void DisplayPropertyForm()
        {
            // Displays the property purchase form
            frmPropertyCard PropertyCardForm = new frmPropertyCard();

            if (frmBoard.CurrentPlayer == 1)
            {
                if (player1CurrentSquare.isProperty == true)
                {
                    // Set the form type
                    PropertyCardForm.setPanelType("Property");

                    // Set the form text
                    PropertyCardForm.Text = "Property";

                    // Sets the property price that will be displayed
                    PropertyCardForm.setPropertyPrice(player1CurrentSquare.value.ToString());

                    // Sets the price of rent that will be displayed
                    int PropertyRent = player1CurrentSquare.value / 2;
                    PropertyCardForm.setPropertyRent(PropertyRent.ToString());

                    // Sets the price of rent with houses
                    int PropertyRentHouse = (PropertyRent) + (player1CurrentSquare.value / 10);
                    PropertyCardForm.setPropertyHouse(PropertyRentHouse.ToString());

                    // Sets the price of rent with shops
                    int PropertyRentShop = (PropertyRent) + (player1CurrentSquare.value / 10) * 3;
                    PropertyCardForm.setPropertyShop(PropertyRentShop.ToString());

                    // Sets the property name
                    PropertyCardForm.setPropertyName(player1CurrentSquare.name);

                    // Sets the property colour
                    PropertyCardForm.setPropertyColour(player1CurrentSquare.colour);
                }
                else
                {
                    // Set the form type
                    PropertyCardForm.setPanelType("Card");

                    // Set the form text
                    PropertyCardForm.Text = "Special Card";
                    PropertyCardForm.SetSpecialCardText(specialCard);
                }
            }
            else if (frmBoard.CurrentPlayer == 2)
            {
                if (player2CurrentSquare.isProperty == true)
                {
                    // Set the form type
                    PropertyCardForm.setPanelType("Property");

                    // Set the form text
                    PropertyCardForm.Text = "Property";

                    // Sets the property price that will be displayed
                    PropertyCardForm.setPropertyPrice(player2CurrentSquare.value.ToString());

                    // Sets the price of rent that will be displayed
                    int PropertyRent = player2CurrentSquare.value / 2;
                    PropertyCardForm.setPropertyRent(PropertyRent.ToString());

                    // Sets the price of rent with houses
                    int PropertyRentHouse = (PropertyRent) + (player2CurrentSquare.value / 10);
                    PropertyCardForm.setPropertyHouse(PropertyRentHouse.ToString());

                    // Sets the price of rent with shops
                    int PropertyRentShop = (PropertyRent) + (player2CurrentSquare.value / 10) * 3;
                    PropertyCardForm.setPropertyShop(PropertyRentShop.ToString());

                    // Sets the property name
                    PropertyCardForm.setPropertyName(player2CurrentSquare.name);

                    // Sets the property colour
                    PropertyCardForm.setPropertyColour(player2CurrentSquare.colour);
                }
                else
                {
                    // Set the form type
                    PropertyCardForm.setPanelType("Card");

                    // Set the form text
                    PropertyCardForm.Text = "Special Card";
                    PropertyCardForm.SetSpecialCardText(specialCard);
                }
            }

            // Positions the property form
            PropertyCardForm.SetFormLocation();

            // Shows the property form
            PropertyCardForm.ShowDialog();

            // sets the boolean
            if (PropertyCardForm.WasPurchased == true)
            {
                PropertyBeenPurchased = true;
            }
            else
            {
                PropertyBeenPurchased = false;
            }
        }

        #endregion


        #region Update Square Rent method

        public void updateSquareRent(int newRent, string theSqaure)
        {
            // This updates the value of the specific squares
            // This method is called when a house or shop is purchased by a player
            switch (theSqaure)
            {
                case "Black 1":
                    squareBlack1Rent = newRent;
                    break;
                case "Black 2":
                    squareBlack2Rent = newRent;
                    break;
                case "Aqua 1":
                    squareAqua1Rent = newRent;
                    break;
                case "Aqua 2":
                    squareAqua2Rent = newRent;
                    break;
                case "Yellow 1":
                    squareYellow1Rent = newRent;
                    break;
                case "Yellow 2":
                    squareYellow2Rent = newRent;
                    break;
                case "Green 1":
                    squareGreen1Rent = newRent;
                    break;
                case "Green 2":
                    squareGreen2Rent = newRent;
                    break;
                case "Blue 1":
                    squareBlue1Rent = newRent;
                    break;
                case "Blue 2":
                    squareBlue2Rent = newRent;
                    break;
                case "Red 1":
                    squareRed1Rent = newRent;
                    break;
                case "Red 2":
                    squareRed2Rent = newRent;
                    break;
                case "Pink 1":
                    squarePink1Rent = newRent;
                    break;
                case "Pink 2":
                    squarePink2Rent = newRent;
                    break;
                case "Brown 1":
                    squareBrown1Rent = newRent;
                    break;
                case "Brown 2":
                    squareBrown2Rent = newRent;
                    break;
            }
        }

        #endregion


        #region Jail Update method

        // This updates the variables when player 1 is in jail
        public void UpdatePlayer1InJail()
        {
            frmBoard.Player1TimeInJail = _Player1TimeInJail;
            frmBoard.Player1InJail = _Player1InJail;
        }

        // This is used to update the variables when player 1 is released from jail
        public void ResetPlayer1InJail()
        {
            _Player1TimeInJail = 0;
            _Player1InJail = false;
        }

        // This updates the variables when player 2 is in jail
        public void UpdatePlayer2InJail()
        {
            frmBoard.Player2TimeInJail = _Player2TimeInJail;
            frmBoard.Player2InJail = _Player2InJail;
        }

        // This is used to update the variables when player 2 is released from jail
        public void ResetPlayer2InJail()
        {
            _Player2TimeInJail = 0;
            _Player2InJail = false;
        }

        #endregion


        #region Update Loan methods

        // When a player takes a loan, the playerRollNumber variable is reset to zero
        // The variable is used to determine how many rolls have passed since the player accepted the loan
        public void resetPlayerRollNumber(int player)
        {
            if (player == 1)
            {
                player1RollNumber = 0;
            }
            else if (player == 2)
            {
                player2RollNumber = 0;
            }
        }

        // This sets the value of the loan
        public void setPlayerLoan(int player, int loan)
        {
            if (player == 1)
            {
                player1HasLoan = true;
                player1LoanAmount = loan;
                playerMoney1 += loan;
                frmBoard.setPlayerMoney1(playerMoney1.ToString());
            }
            else if (player == 2)
            {
                player2HasLoan = true;
                player2LoanAmount = loan;
                playerMoney2 += loan;
                frmBoard.setPlayerMoney2(playerMoney2.ToString());
            }
        }

        // Set-Get for the player loan boolean values
        public static bool _player1HasLoan
        {
            get
            {
                return player1HasLoan;
            }
            set
            {
                player1HasLoan = value;
            }
        }

        public static bool _player2HasLoan
        {
            get
            {
                return player2HasLoan;
            }
            set
            {
                player2HasLoan = value;
            }
        }

        // Set-Get for the player roll number
        public static int _player1RollNumber
        {
            get
            {
                return player1RollNumber;
            }
            set
            {
                player1RollNumber = value;
            }
        }

        public static int _player2RollNumber
        {
            get
            {
                return player2RollNumber;
            }
            set
            {
                player2RollNumber = value;
            }
        }

        #endregion


        #region Player Image Update method

        // This method is used to move the player 1 image (red circle) around the board 
        // This method is called everytime player 1 rolls the dice
        public void MovePlayerImage1()
        {
            string locationSwitch = (player1CurrentSquare.name);
            switch (locationSwitch)
            {
                case "Go":
                    Player1x = 80;
                    Player1y = 80;
                    break;
                case "Strand":
                    Player1x = 200;
                    Player1y = 80;
                    break;
                case "Trafalgar Sq":
                    Player1x = 300;
                    Player1y = 80;
                    break;
                case "Gas":
                    Player1x = 415;
                    Player1y = 80;
                    break;
                case "Leicester Sq":
                    Player1x = 535;
                    Player1y = 80;
                    break;
                case "Piccadilly":
                    Player1x = 635;
                    Player1y = 80;
                    break;
                case "Card 1":
                    Player1x = 760;
                    Player1y = 80;
                    break;
                case "Regent St":
                    Player1x = 760;
                    Player1y = 190;
                    break;
                case "Oxford St":
                    Player1x = 760;
                    Player1y = 290;
                    break;
                case "Electric":
                    Player1x = 760;
                    Player1y = 420;
                    break;
                case "Mayfair":
                    Player1x = 760;
                    Player1y = 530;
                    break;
                case "Park Lane":
                    Player1x = 760;
                    Player1y = 630;
                    break;
                case "Jail":
                    Player1x = 760;
                    Player1y = 770;
                    break;
                case "Old Kent Rd":
                    Player1x = 590;
                    Player1y = 770;
                    break;
                case "Whitechapel":
                    Player1x = 490;
                    Player1y = 770;
                    break;
                case "Water":
                    Player1x = 365;
                    Player1y = 770;
                    break;
                case "Islington":
                    Player1x = 250;
                    Player1y = 770;
                    break;
                case "Euston":
                    Player1x = 150;
                    Player1y = 770;
                    break;
                case "Card 2":
                    Player1x = 60;
                    Player1y = 770;
                    break;
                case "Pall Mall":
                    Player1x = 60;
                    Player1y = 590;
                    break;
                case "Whitehall":
                    Player1x = 60;
                    Player1y = 490;
                    break;
                case "Phone":
                    Player1x = 60;
                    Player1y = 355;
                    break;
                case "Bow St":
                    Player1x = 60;
                    Player1y = 255;
                    break;
                case "Vine St":
                    Player1x = 60;
                    Player1y = 155;
                    break;
                default:
                    Player1x = 80;
                    Player1y = 80;
                    break;
            }

            // This passes the players X and Y co-ordinates to the board form
            // The co-ordinates are then used to set the location of the image on the screen
            frmBoard.setPlayerImage1(Player1x, Player1y);
        }

        // This method is used to move the player 2 image (green circle) around the board 
        // This method is called everytime player 2 rolls the dice
        public void MovePlayerImage2()
        {
            string locationSwitch = (player2CurrentSquare.name);
            switch (locationSwitch)
            {
                case "Go":
                    Player2x = 30;
                    Player2y = 80;
                    break;
                case "Strand":
                    Player2x = 155;
                    Player2y = 80;
                    break;
                case "Trafalgar Sq":
                    Player2x = 255;
                    Player2y = 80;
                    break;
                case "Gas":
                    Player2x = 370;
                    Player2y = 80;
                    break;
                case "Leicester Sq":
                    Player2x = 490;
                    Player2y = 80;
                    break;
                case "Piccadilly":
                    Player2x = 590;
                    Player2y = 80;
                    break;
                case "Card 1":
                    Player2x = 715;
                    Player2y = 80;
                    break;
                case "Regent St":
                    Player2x = 715;
                    Player2y = 190;
                    break;
                case "Oxford St":
                    Player2x = 715;
                    Player2y = 290;
                    break;
                case "Electric":
                    Player2x = 715;
                    Player2y = 420;
                    break;
                case "Mayfair":
                    Player2x = 715;
                    Player2y = 530;
                    break;
                case "Park Lane":
                    Player2x = 715;
                    Player2y = 630;
                    break;
                case "Jail":
                    Player2x = 715;
                    Player2y = 770;
                    break;
                case "Old Kent Rd":
                    Player2x = 635;
                    Player2y = 770;
                    break;
                case "Whitechapel":
                    Player2x = 535;
                    Player2y = 770;
                    break;
                case "Water":
                    Player2x = 410;
                    Player2y = 770;
                    break;
                case "Islington":
                    Player2x = 295;
                    Player2y = 770;
                    break;
                case "Euston":
                    Player2x = 195;
                    Player2y = 770;
                    break;
                case "Card 2":
                    Player2x = 15;
                    Player2y = 770;
                    break;
                case "Pall Mall":
                    Player2x = 15;
                    Player2y = 590;
                    break;
                case "Whitehall":
                    Player2x = 15;
                    Player2y = 490;
                    break;
                case "Phone":
                    Player2x = 15;
                    Player2y = 355;
                    break;
                case "Bow St":
                    Player2x = 15;
                    Player2y = 255;
                    break;
                case "Vine St":
                    Player2x = 15;
                    Player2y = 155;
                    break;
                default:
                    Player2x = 30;
                    Player2y = 80;
                    break;
            }

            // This passes the players X and Y co-ordinates to the board form
            // The co-ordinates are then used to set the location of the image on the screen
            frmBoard.setPlayerImage2(Player2x, Player2y);
        }

        #endregion


        #region Set Player Location method

        // This method sets the value of the player 1 location
        // This method is called everytime player 1 rolls the dice
        public void movePlayer1()
        {
            switch (playerPosition1)
            {
                case 0:
                    player1CurrentSquare = head;
                    break;
                case 1:
                    player1CurrentSquare = head.next;
                    break;
                case 2:
                    player1CurrentSquare = head.next.next;
                    break;
                case 3:
                    player1CurrentSquare = head.next.next.next;
                    break;
                case 4:
                    player1CurrentSquare = head.next.next.next.next;
                    break;
                case 5:
                    player1CurrentSquare = head.next.next.next.next.next;
                    break;
                case 6:
                    player1CurrentSquare = head.next.next.next.next.next.next;
                    break;
                case 7:
                    player1CurrentSquare = head.next.next.next.next.next.next.next;
                    break;
                case 8:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next;
                    break;
                case 9:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next;
                    break;
                case 10:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 11:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 12:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 13:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 14:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 15:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 16:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 17:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 18:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 19:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 20:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 21:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 22:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 23:
                    player1CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
            }
        }

        // This method sets the value of the player 2 location
        // This method is called everytime player 2 rolls the dice
        public void movePlayer2()
        {
            switch (playerPosition2)
            {
                case 0:
                    player2CurrentSquare = head;
                    break;
                case 1:
                    player2CurrentSquare = head.next;
                    break;
                case 2:
                    player2CurrentSquare = head.next.next;
                    break;
                case 3:
                    player2CurrentSquare = head.next.next.next;
                    break;
                case 4:
                    player2CurrentSquare = head.next.next.next.next;
                    break;
                case 5:
                    player2CurrentSquare = head.next.next.next.next.next;
                    break;
                case 6:
                    player2CurrentSquare = head.next.next.next.next.next.next;
                    break;
                case 7:
                    player2CurrentSquare = head.next.next.next.next.next.next.next;
                    break;
                case 8:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next;
                    break;
                case 9:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next;
                    break;
                case 10:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 11:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 12:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 13:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 14:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 15:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 16:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 17:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 18:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 19:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 20:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 21:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 22:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
                case 23:
                    player2CurrentSquare = head.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next.next;
                    break;
            }
        }

        #endregion


        #region Special Card method

        public void player1GetSpecialCard()
        {
            // Initialises the card array and retrieves a random card
            InitializeCardArray();

            // This determines the apropiate action depending on the random card that is retieved
            bool GoingToJail = false;

            switch (specialCard)
            {
                case "You have won the lottery, collect £1000":
                    playerMoney1 += 1000;
                    break;
                case "You have been awarded a regeneration grant, collect £500":
                    playerMoney1 += 500;
                    break;
                case "Advance to Go and collect £200":
                    // When this card is produced the player will be moved to GO
                    frmBoard.setPlayerImage1(80, 80);
                    player1CurrentSquare = square0;
                    playerMoney1 += 200;
                    break;
                case "It is your birthday, collect £50":
                    playerMoney1 += 50;
                    break;
                case "You inherit £1200":
                    playerMoney1 += 1200;
                    break;
                case "Doctor's fees, pay £50":
                    if (playerMoney1 >= 50)
                    {
                        playerMoney1 -= 50;
                    }
                    else
                    {
                        playerMoney1 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Pay income tax of £100":
                    if (playerMoney1 >= 100)
                    {
                        playerMoney1 -= 100;
                    }
                    else
                    {
                        playerMoney1 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Pay medical fees of £200":
                    if (playerMoney1 >= 200)
                    {
                        playerMoney1 -= 200;
                    }
                    else
                    {
                        playerMoney1 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Pay for street repairs of £500":
                    if (playerMoney1 >= 500)
                    {
                        playerMoney1 -= 500;
                    }
                    else
                    {
                        playerMoney1 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Go to Jail, do not pass Go and do not collect £200":
                    // When this card is produced the player will be moved to Jail
                    frmBoard.setPlayerImage1(760, 770);
                    player1CurrentSquare = square12;
                    // This sets the variables when the player is first sent to jail
                    _Player1InJail = true;
                    _Player1TimeInJail = 1;
                    UpdatePlayer1InJail();
                    break;
                case "Bank error in your favour, collect £200":
                    playerMoney1 += 200;
                    break;
                case "Holiday fund matures, collect £150":
                    playerMoney1 += 150;
                    break;
                case "Income tax refund, collect £100":
                    playerMoney1 += 100;
                    break;
                case "Speeding fine, pay £150":
                    if (playerMoney1 >= 150)
                    {
                        playerMoney1 -= 150;
                    }
                    else
                    {
                        playerMoney1 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Pay school fees of £200":
                    if (playerMoney1 >= 200)
                    {
                        playerMoney1 -= 200;
                    }
                    else
                    {
                        playerMoney1 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Parking fine, pay £50":
                    if (playerMoney1 >= 50)
                    {
                        playerMoney1 -= 50;
                    }
                    else
                    {
                        playerMoney1 = 0;
                        GoingToJail = true;
                    }
                    break;
            }
            frmBoard.setPlayerMoney1(playerMoney1.ToString());
            MovePlayerImage1();
            DisplayPropertyForm();

            // This code is called when a player receives a chance card that requires money to be paid and they do not have enough
            if (GoingToJail == true)
            {
                // Display a message informing the player that they have been sent to jail
                DialogResult JailMessage = MessageBox.Show("You did not have enought money to pay, You have been sent to jail!", "Jail", MessageBoxButtons.OK);

                // The player is then sent to jail because they did not have enough money to pay the full amount
                frmBoard.setPlayerImage1(650, 665);
                player1CurrentSquare = square12;
                // This sets the variables when the player is first sent to jail
                _Player1InJail = true;
                _Player1TimeInJail = 1;
                UpdatePlayer1InJail();
            }
        }

        public void player2GetSpecialCard()
        {
            // Initialises the card array and retrieves a random card
            InitializeCardArray();

            // This determines the apropiate action depending on the random card that is retieved
            bool GoingToJail = false;

            switch (specialCard)
            {
                case "You have won the lottery, collect £1000":
                    playerMoney2 += 1000;
                    break;
                case "You have been awarded a regeneration grant, collect £500":
                    playerMoney2 += 500;
                    break;
                case "Advance to Go and collect £200":
                    // When this card is produced the player will be moved to GO
                    frmBoard.setPlayerImage2(30, 80);
                    player2CurrentSquare = square0;
                    playerMoney2 += 200;
                    break;
                case "It is your birthday, collect £50":
                    playerMoney2 += 50;
                    break;
                case "You inherit £1200":
                    playerMoney2 += 1200;
                    break;
                case "Doctor's fees, pay £50":
                    if (playerMoney2 >= 50)
                    {
                        playerMoney2 -= 50;
                    }
                    else
                    {
                        playerMoney2 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Pay income tax of £100":
                    if (playerMoney2 >= 100)
                    {
                        playerMoney2 -= 100;
                    }
                    else
                    {
                        playerMoney2 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Pay medical fees of £200":
                    if (playerMoney2 >= 200)
                    {
                        playerMoney2 -= 200;
                    }
                    else
                    {
                        playerMoney2 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Pay for street repairs of £500":
                    if (playerMoney2 >= 500)
                    {
                        playerMoney2 -= 500;
                    }
                    else
                    {
                        playerMoney2 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Go to Jail, do not pass Go and do not collect £200":
                    // When this card is produced the player will be moved to Jail
                    frmBoard.setPlayerImage2(715, 770);
                    player2CurrentSquare = square12;
                    // This sets the variables when the player is first sent to jail
                    _Player2InJail = true;
                    _Player2TimeInJail = 1;
                    UpdatePlayer2InJail();
                    break;
                case "Bank error in your favour, collect £200":
                    playerMoney2 += 200;
                    break;
                case "Holiday fund matures, collect £150":
                    playerMoney2 += 150;
                    break;
                case "Income tax refund, collect £100":
                    playerMoney2 += 100;
                    break;
                case "Speeding fine, pay £150":
                    if (playerMoney2 >= 150)
                    {
                        playerMoney2 -= 150;
                    }
                    else
                    {
                        playerMoney2 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Pay school fees of £200":
                    if (playerMoney2 >= 200)
                    {
                        playerMoney2 -= 200;
                    }
                    else
                    {
                        playerMoney2 = 0;
                        GoingToJail = true;
                    }
                    break;
                case "Parking fine, pay £50":
                    if (playerMoney2 >= 50)
                    {
                        playerMoney2 -= 50;
                    }
                    else
                    {
                        playerMoney2 = 0;
                        GoingToJail = true;
                    }
                    break;
            }
            frmBoard.setPlayerMoney2(playerMoney2.ToString());
            MovePlayerImage2();
            DisplayPropertyForm();

            // This code is called when a player receives a chance card that requires money to be paid and they do not have enough
            if (GoingToJail == true)
            {
                // Display a message informing the player that they have been sent to jail
                DialogResult JailMessage = MessageBox.Show("You did not have enought money to pay, You have been sent to jail!", "Jail", MessageBoxButtons.OK);

                // The player is then sent to jail because they did not have enough money to pay the full amount
                frmBoard.setPlayerImage2(650, 665);
                player2CurrentSquare = square12;
                // This sets the variables when the player is first sent to jail
                _Player2InJail = true;
                _Player2TimeInJail = 1;
                UpdatePlayer2InJail();
            }
        }

        #endregion


        #region Dice Roll Method

        public void Player1DiceRoll()
        {
            // This gets a random number from the dice class for player 1
            Dice d1 = new Dice();

            string diceNumber = d1.diceValue.ToString();

            // This sets the appropriate image for the dice
            frmBoard.setDiceImage(diceNumber);

            switch (d1.diceValue)
            {
                case 1:
                    player1CurrentSquare = player1CurrentSquare.next;
                    break;
                case 2:
                    player1CurrentSquare = player1CurrentSquare.next.next;
                    break;
                case 3:
                    player1CurrentSquare = player1CurrentSquare.next.next.next;
                    break;
                case 4:
                    player1CurrentSquare = player1CurrentSquare.next.next.next.next;
                    break;
                case 5:
                    player1CurrentSquare = player1CurrentSquare.next.next.next.next.next;
                    break;
                case 6:
                    player1CurrentSquare = player1CurrentSquare.next.next.next.next.next.next;
                    break;
            }
        }

        public void Player2DiceRoll()
        {
            // This gets a random number from the dice class for player 2
            Dice d1 = new Dice();

            string diceNumber = d1.diceValue.ToString();

            // This sets the appropriate image for the dice
            frmBoard.setDiceImage(diceNumber);

            switch (d1.diceValue)
            {
                case 1:
                    player2CurrentSquare = player2CurrentSquare.next;
                    break;
                case 2:
                    player2CurrentSquare = player2CurrentSquare.next.next;
                    break;
                case 3:
                    player2CurrentSquare = player2CurrentSquare.next.next.next;
                    break;
                case 4:
                    player2CurrentSquare = player2CurrentSquare.next.next.next.next;
                    break;
                case 5:
                    player2CurrentSquare = player2CurrentSquare.next.next.next.next.next;
                    break;
                case 6:
                    player2CurrentSquare = player2CurrentSquare.next.next.next.next.next.next;
                    break;
            }
        }

        #endregion


        #region Player 1 move method

        public void Player1Move()
        {
            // This is the main method for the players roll
            // This method is called from the board form when a user clicks the dice roll button

            // Sets the current player and updates the money in the GUI
            movePlayer1();
            currentPlayer = player1.Name;
            frmBoard.setPlayerMoney1(playerMoney1.ToString());

            // Rolls the dice
            Player1DiceRoll();

            player1RollNumber += 1;

            // These booleans are to check the property list to see if the current location already exists in the lists
            bool InPlayerPropertyList1 = PlayerProperyList1.Contains(player1CurrentSquare.name);
            bool InPlayerPropertyList2 = PlayerProperyList2.Contains(player1CurrentSquare.name);

            // If player 1 lands on Go they recieve £200
            if (player1CurrentSquare == square0)
            {
                playerMoney1 += 200;
                MovePlayerImage1();
                frmBoard.setPlayerMoney1(playerMoney1.ToString());
                // Display a message informing the player that they have been sent to jail
                DialogResult JailMessage = MessageBox.Show("You have collected £200 for landing on GO!", "Message", MessageBoxButtons.OK);
            }
            // If player 1 lands on a utility they loose £100
            else if (player1CurrentSquare == square3 || player1CurrentSquare == square9 || player1CurrentSquare == square15 || player1CurrentSquare == square21)
            {
                // If the player has enough money to pay for landing on the utility
                if (playerMoney1 >= 100)
                {
                    playerMoney1 -= 100;
                    MovePlayerImage1();
                    frmBoard.setPlayerMoney1(playerMoney1.ToString());
                    // Display a message informing the player that they have been sent to jail
                    DialogResult JailMessage = MessageBox.Show("You have paid £100 for landing on this utility!", "Message", MessageBoxButtons.OK);
                }
                else
                {
                    // The player is sent to jail because they did not have enough money to pay the full rent
                    frmBoard.setPlayerImage1(760, 770);
                    player1CurrentSquare = square12;
                    // This sets the variables when the player is first sent to jail
                    _Player1InJail = true;
                    _Player1TimeInJail = 1;
                    UpdatePlayer1InJail();

                    // Display a message informing the player that they have been sent to jail
                    DialogResult JailMessage = MessageBox.Show("You did not have enought money to pay for this utility, You have been sent to jail!", "Jail", MessageBoxButtons.OK);
                }
            }
            // If player 1 lands on an un-owned property and they have enough money, they will be given the option to purchase it
            else if (player1CurrentSquare.isProperty == true && InPlayerPropertyList1 == false && InPlayerPropertyList2 == false)
            {
                if (playerMoney1 >= player1CurrentSquare.value)
                {
                    MovePlayerImage1();
                    DisplayPropertyForm();

                    if (PropertyBeenPurchased == true)
                    {
                        playerMoney1 -= player1CurrentSquare.value;
                        frmBoard.setPlayerMoney1(playerMoney1.ToString());

                        // When the player purchases a property it is added to the players property list
                        PlayerProperyList1.Add(player1CurrentSquare.name);

                        // Sends the current location to fill the correct player property square
                        frmBoard.DisplayPlayerProperties1(player1CurrentSquare.name);
                    }
                }
            }
            // If player 1 lands on an owned property and they have enough money, they will pay the owner 50% rent
            else if (InPlayerPropertyList2 == true && frmBoard.Player2InJail == false)
            {
                if (playerMoney1 >= (player1CurrentSquare.value / 2))
                {
                    int amount = player1CurrentSquare.value / 2;

                    playerMoney1 -= amount;
                    playerMoney2 += amount;

                    frmBoard.setPlayerMoney2(playerMoney2.ToString());
                    frmBoard.setPlayerMoney1(playerMoney1.ToString());

                    // Display a message informing the player that they have paid rent
                    DialogResult JailMessage = MessageBox.Show("Car has paid Dog £" + amount + " in rent", "Message", MessageBoxButtons.OK);
                }
                else
                // If the player lands on an owned property and they do not have enough money to pay the rent
                {
                    // The player is sent to jail because they did not have enough money to pay the full rent
                    frmBoard.setPlayerImage1(760, 770);
                    player1CurrentSquare = square12;
                    // This sets the variables when the player is first sent to jail
                    _Player1InJail = true;
                    _Player1TimeInJail = 1;
                    UpdatePlayer1InJail();

                    // Display a message informing the player that they have been sent to jail
                    DialogResult JailMessage = MessageBox.Show("You did not have enought money to pay the rent, You have been sent to jail!", "Jail", MessageBoxButtons.OK);
                }
            }
            // If player 1 lands on a special card square
            else if (player1CurrentSquare == square6 || player1CurrentSquare == square18)
            {
                player1GetSpecialCard();
            }

            // Updates static values
            playerPosition1 = player1CurrentSquare.location;

            // Displays the players list of properties in the list box
            for (int i = 0; i < PlayerProperyList1.Count; i++)
            {
                frmBoard.setPropertyListText1(PlayerProperyList1[i]);
            }

            if (player1HasLoan == true && player1RollNumber == 8)
            {
                // Display a message informing the player that they two turns left before their loan is due
                DialogResult LoanMessage = MessageBox.Show("Your loan will be collected after 2 more rolls!", "Loan", MessageBoxButtons.OK);
            }

            // This is when the loan is due to be paid
            if (player1HasLoan == true && player1RollNumber == 10)
            {
                int amountDue = player1LoanAmount + (player1LoanAmount / 2);

                if (playerMoney1 >= amountDue)
                {
                    playerMoney1 -= amountDue;

                    // Display a message informing the player that they have paid the loan
                    DialogResult LoanMessage = MessageBox.Show("You have paid £" + amountDue + " to the bank for your loan of £" + player1LoanAmount + "!", "Loan", MessageBoxButtons.OK);

                    // Resets the loan values
                    player1LoanAmount = 0;
                    player1RollNumber = 0;
                    player1HasLoan = false;
                    frmBoard.setPlayerMoney1(playerMoney1.ToString());
                }
                else
                {
                    // Display a message informing the player that they have been sent to jail due to not being able to pay their loan
                    DialogResult LoanMessage = MessageBox.Show("You do not have enough money to pay for your loan, you have been sent to jail!", "Loan", MessageBoxButtons.OK);

                    // Resets the loan values and updates the jail values
                    player1LoanAmount = 0;
                    player1RollNumber = 0;
                    player1HasLoan = false;
                    frmBoard.setPlayerImage1(760, 770);
                    player1CurrentSquare = square12;
                    _Player1InJail = true;
                    _Player1TimeInJail = 1;
                    UpdatePlayer1InJail();
                    playerPosition1 = player1CurrentSquare.location;
                }
            }
        }

        #endregion


        #region Player 2 move method

        public void Player2Move()
        {
            // This is the main method for the players roll
            // This method is called from the board form when a user clicks the dice roll button

            // Sets the current player and updates the money in the GUI
            movePlayer2();
            currentPlayer = player2.Name;
            frmBoard.setPlayerMoney2(playerMoney2.ToString());

            // Rolls the dice
            Player2DiceRoll();

            player2RollNumber += 1;

            // These booleans are to check the property list to see if the current location already exists in the lists
            bool InPlayerPropertyList1 = PlayerProperyList1.Contains(player2CurrentSquare.name);
            bool InPlayerPropertyList2 = PlayerProperyList2.Contains(player2CurrentSquare.name);

            // If player 1 lands on Go they recieve £200
            if (player2CurrentSquare == square0)
            {
                playerMoney2 += 200;
                MovePlayerImage2();
                frmBoard.setPlayerMoney2(playerMoney2.ToString());
                // Display a message informing the player that they have been sent to jail
                DialogResult JailMessage = MessageBox.Show("You have collected £200 for landing on GO!", "Message", MessageBoxButtons.OK);
            }
            // If player 1 lands on a utility they loose £100
            else if (player2CurrentSquare == square3 || player2CurrentSquare == square9 || player2CurrentSquare == square15 || player2CurrentSquare == square21)
            {
                // If the player has enough money to pay for landing on the utility
                if (playerMoney2 >= 100)
                {
                    playerMoney2 -= 100;
                    MovePlayerImage2();
                    frmBoard.setPlayerMoney2(playerMoney2.ToString());
                    // Display a message informing the player that they have been sent to jail
                    DialogResult JailMessage = MessageBox.Show("You have paid £100 for landing on this utility!", "Message", MessageBoxButtons.OK);
                }
                else
                {
                    // The player is sent to jail because they did not have enough money to pay the full rent
                    frmBoard.setPlayerImage2(715, 770);
                    player2CurrentSquare = square12;
                    // This sets the variables when the player is first sent to jail
                    _Player2InJail = true;
                    _Player2TimeInJail = 1;
                    UpdatePlayer2InJail();

                    // Display a message informing the player that they have been sent to jail
                    DialogResult JailMessage = MessageBox.Show("You did not have enought money to pay for this utility, You have been sent to jail!", "Jail", MessageBoxButtons.OK);
                }
            }
            // If player 2 lands on an un-owned property and they have enough money, they will be given the option to purchase it
            else if (player2CurrentSquare.isProperty == true && InPlayerPropertyList2 == false && InPlayerPropertyList1 == false)
            {
                if (playerMoney2 >= player2CurrentSquare.value)
                {
                    MovePlayerImage2();
                    DisplayPropertyForm();

                    if (PropertyBeenPurchased == true)
                    {
                        playerMoney2 -= player2CurrentSquare.value;
                        frmBoard.setPlayerMoney2(playerMoney2.ToString());

                        // When the player purchases a property it is added to the players property list
                        PlayerProperyList2.Add(player2CurrentSquare.name);

                        // Sends the current location to fill the correct player property square
                        frmBoard.DisplayPlayerProperties2(player2CurrentSquare.name);
                    }
                }
            }
            // If player 2 lands on an owned property and they have enough money, they will pay the owner 50% rent
            else if (InPlayerPropertyList1 == true && frmBoard.Player1InJail == false)
            {
                if (playerMoney2 >= (player2CurrentSquare.value / 2))
                {
                    int amount = player2CurrentSquare.value / 2;

                    playerMoney2 -= amount;
                    playerMoney1 += amount;

                    frmBoard.setPlayerMoney1(playerMoney1.ToString());
                    frmBoard.setPlayerMoney2(playerMoney2.ToString());

                    // Display a message informing the player that they have paid rent
                    DialogResult JailMessage = MessageBox.Show("Dog has paid Car £" + amount + " in rent", "Message", MessageBoxButtons.OK);
                }
                else
                // If the player lands on an owned property and they do not have enough money to pay the rent
                {
                    // The player is sent to jail because they did not have enough money to pay the full rent
                    frmBoard.setPlayerImage2(715, 770);
                    player2CurrentSquare = square12;
                    // This sets the variables when the player is first sent to jail
                    _Player2InJail = true;
                    _Player2TimeInJail = 1;
                    UpdatePlayer2InJail();

                    // Display a message informing the player that they have been sent to jail
                    DialogResult JailMessage = MessageBox.Show("You did not have enought money to pay the rent, You have been sent to jail!", "Jail", MessageBoxButtons.OK);
                }
            }
            // If player 1 lands on a special card square
            else if (player2CurrentSquare == square6 || player2CurrentSquare == square18)
            {
                player2GetSpecialCard();
            }

            // Updates static values
            playerPosition2 = player2CurrentSquare.location;

            // Displays the players list of properties in the list box
            for (int i = 0; i < PlayerProperyList2.Count; i++)
            {
                frmBoard.setPropertyListText2(PlayerProperyList2[i]);
            }

            if (player2HasLoan == true && player2RollNumber == 8)
            {
                // Display a message informing the player that they two turns left before their loan is due
                DialogResult LoanMessage = MessageBox.Show("Your loan will be collected after 2 more rolls!", "Loan", MessageBoxButtons.OK);
            }

            // This is when the loan is due to be paid
            if (player2HasLoan == true && player2RollNumber == 10)
            {
                int amountDue = player2LoanAmount + (player2LoanAmount / 2);

                if (playerMoney2 >= amountDue)
                {
                    playerMoney2 -= amountDue;

                    // Display a message informing the player that they have paid the loan
                    DialogResult LoanMessage = MessageBox.Show("You have paid £" + amountDue + " to the bank for your loan of £" + player2LoanAmount + "!", "Loan", MessageBoxButtons.OK);

                    // Resets the loan values
                    player2LoanAmount = 0;
                    player2RollNumber = 0;
                    player2HasLoan = false;
                    frmBoard.setPlayerMoney2(playerMoney2.ToString());
                }
                else
                {
                    // Display a message informing the player that they have been sent to jail due to not being able to pay their loan
                    DialogResult LoanMessage = MessageBox.Show("You do not have enough money to pay for your loan, you have been sent to jail!", "Loan", MessageBoxButtons.OK);

                    // Resets the loan values and updates the jail values
                    player2LoanAmount = 0;
                    player2RollNumber = 0;
                    player2HasLoan = false;
                    frmBoard.setPlayerImage2(715, 770);
                    player2CurrentSquare = square12;
                    _Player2InJail = true;
                    _Player2TimeInJail = 1;
                    UpdatePlayer2InJail();
                    playerPosition2 = player2CurrentSquare.location;
                }
            }
        }

        #endregion


        #region Save game method

        public void SaveGame()
        {
            // This is the save game method, it is called everytime a user clicks on the save game button
            // This method takes all of the main values from the game and then writes them to a text file in a specific order

            // This sets the path of the save file
            string gameDataPath = appPath.Remove(appPath.Length - 9);
            gameDataPath = gameDataPath + "Data\\Save.txt";

            // This checks to see if a save file already exists
            if (File.Exists(gameDataPath))
            {
                // If a save file exists a message is dsplay asking the user if they want to overight the save file
                DialogResult dialogResult = MessageBox.Show("There is already a save file, do you want to overight it?", "Save Game", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Delete(gameDataPath);

                    // Opens the text file for writting the values
                    System.IO.StreamWriter sw = System.IO.File.AppendText(gameDataPath);

                    // Writes the values to the text file on seperate lines
                    sw.WriteLine(currentPlayer);
                    sw.WriteLine(lastSpecialCard);

                    // Writes a blank line to the text file, this is just to make the sections of data easier to distinguish for a human
                    sw.WriteLine();

                    // Player 1 save values
                    //Player location
                    sw.WriteLine(playerPosition1);

                    // Player Money
                    sw.WriteLine(playerMoney1);

                    // Jail values
                    sw.WriteLine(_Player1TimeInJail);
                    sw.WriteLine(_Player1InJail);

                    // Loan values
                    sw.WriteLine(player1HasLoan);
                    sw.WriteLine(player1LoanAmount);
                    sw.WriteLine(_player1RollNumber);

                    // Player co-ordinates
                    sw.WriteLine(Player1x);
                    sw.WriteLine(Player1y);

                    // This writes the number of properties that player 1 currently owns
                    // The load game method will use this value to determine how many many lines of the text file must be read
                    sw.WriteLine(PlayerProperyList1.Count);

                    // This loops the number of properties and writes each property to the text file
                    for (int i = 0; i < PlayerProperyList1.Count; i++)
                    {
                        sw.WriteLine(PlayerProperyList1[i]);
                    }

                    // This writes the number of houses that player 1 currently owns
                    // The load game method will use this value to determine how many many lines of the text file must be read
                    sw.WriteLine(PlayerHouseList1.Count);

                    // This loops the number of houses and writes each house to the text file
                    for (int i = 0; i < PlayerHouseList1.Count; i++)
                    {
                        sw.WriteLine(PlayerHouseList1[i]);
                    }

                    // This writes the number of shops that player 1 currently owns
                    // The load game method will use this value to determine how many many lines of the text file must be read
                    sw.WriteLine(PlayerShopList1.Count);

                    // This loops the number of shops and writes each shop to the text file
                    for (int i = 0; i < PlayerShopList1.Count; i++)
                    {
                        sw.WriteLine(PlayerShopList1[i]);
                    }

                    // Writes a blank line to the text file, this is just to make the sections of data easier to distinguish for a human
                    sw.WriteLine();

                    // Player 2 save values
                    // Player location 
                    sw.WriteLine(playerPosition2);

                    // Player money
                    sw.WriteLine(playerMoney2);

                    // Player jail values
                    sw.WriteLine(_Player2TimeInJail);
                    sw.WriteLine(_Player2InJail);

                    // Player loan values
                    sw.WriteLine(player2HasLoan);
                    sw.WriteLine(player2LoanAmount);
                    sw.WriteLine(_player2RollNumber);

                    // Player co-ordinates
                    sw.WriteLine(Player2x);
                    sw.WriteLine(Player2y);

                    // This writes the number of properties that player 2 currently owns
                    // The load game method will use this value to determine how many many lines of the text file must be read
                    sw.WriteLine(PlayerProperyList2.Count);

                    // This loops the number of properties and writes each property to the text file
                    for (int i = 0; i < PlayerProperyList2.Count; i++)
                    {
                        sw.WriteLine(PlayerProperyList2[i]);
                    }

                    // This writes the number of houses that player 2 currently owns
                    // The load game method will use this value to determine how many many lines of the text file must be read
                    sw.WriteLine(PlayerHouseList2.Count);

                    // This loops the number of houses and writes each house to the text file
                    for (int i = 0; i < PlayerHouseList2.Count; i++)
                    {
                        sw.WriteLine(PlayerHouseList2[i]);
                    }

                    // This writes the number of shops that player 2 currently owns
                    // The load game method will use this value to determine how many many lines of the text file must be read
                    sw.WriteLine(PlayerShopList2.Count);

                    // This loops the number of shops and writes each shop to the text file
                    for (int i = 0; i < PlayerShopList2.Count; i++)
                    {
                        sw.WriteLine(PlayerShopList2[i]);
                    }

                    sw.Close();
                }
            }
        }

        #endregion


        #region Load game method

        public void LoadGame(string fileName)
        {
            // This method is used to read the saved data from a text file so that the users can continue from where they last saved
            // This method is called when a user clicks on the load game button
            // This method is also called when the debug menu is used

            // This sets the path of the text file that will be read
            string gameDataPath = appPath.Remove(appPath.Length - 9);
            gameDataPath = gameDataPath + "Data\\" + fileName;

            // Strings to store the values from the text file
            string _currentPlayer;
            string _lastSpecialCard;

            // Player 1 values
            string _player1CurrentSquare;
            string _playerMoney1;
            string Player1TimeInJail;
            string Player1InJail;
            string player1Loan;
            string player1loanvalue;
            string player1RollCount;
            string _Player1x;
            string _Player1y;
            string player1ListCount;
            List<string> _PlayerProperyList1 = new List<string>();
            string player1HouseCount;
            List<string> _PlayerHouseList1 = new List<string>();
            string player1ShopCount;
            List<string> _PlayerShopList1 = new List<string>();

            // Player 2 values
            string _player2CurrentSquare;
            string _playerMoney2;
            string Player2TimeInJail;
            string Player2InJail;
            string player2Loan;
            string player2loanvalue;
            string player2RollCount;
            string _Player2x;
            string _Player2y;
            string player2ListCount;
            List<string> _PlayerProperyList2 = new List<string>();
            string player2HouseCount;
            List<string> _PlayerHouseList2 = new List<string>();
            string player2ShopCount;
            List<string> _PlayerShopList2 = new List<string>();

            // Opens the file for reading
            System.IO.StreamReader sw = new System.IO.StreamReader(gameDataPath);

            // Reads each line of the text file, storing the values in the appropriate strings
            _currentPlayer = sw.ReadLine();
            _lastSpecialCard = sw.ReadLine();

            // This just reads the blank line between the different sections of data
            sw.ReadLine();

            // Player 1 values from the text file
            _player1CurrentSquare = sw.ReadLine();
            _playerMoney1 = sw.ReadLine();
            Player1TimeInJail = sw.ReadLine();
            Player1InJail = sw.ReadLine();
            player1Loan = sw.ReadLine();
            player1loanvalue = sw.ReadLine();
            player1RollCount = sw.ReadLine();
            _Player1x = sw.ReadLine();
            _Player1y = sw.ReadLine();
            player1ListCount = sw.ReadLine();

            // This switch is used to read the correct number of properties that the player 1 had when they last saved the game
            // There are only 16 purchasable properties in the games
            switch (player1ListCount)
            {
                case "0":

                    break;
                case "1":
                    _PlayerProperyList1.Add(sw.ReadLine());
                    break;
                case "2":
                    for (int i = 0; i < 2; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "3":
                    for (int i = 0; i < 3; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "4":
                    for (int i = 0; i < 4; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "5":
                    for (int i = 0; i < 5; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "6":
                    for (int i = 0; i < 6; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "7":
                    for (int i = 0; i < 7; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "8":
                    for (int i = 0; i < 8; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "9":
                    for (int i = 0; i < 9; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "10":
                    for (int i = 0; i < 10; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "11":
                    for (int i = 0; i < 11; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "12":
                    for (int i = 0; i < 12; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "13":
                    for (int i = 0; i < 13; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "14":
                    for (int i = 0; i < 14; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "15":
                    for (int i = 0; i < 15; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
                case "16":
                    for (int i = 0; i < 16; i++)
                    {
                        _PlayerProperyList1.Add(sw.ReadLine());
                    }
                    break;
            }

            // Reads the number of houses
            player1HouseCount = sw.ReadLine();

            // This switch is used to read the correct number of houses that the player 1 had when they last saved the game
            switch (player1HouseCount)
            {
                case "0":

                    break;
                case "1":
                    _PlayerHouseList1.Add(sw.ReadLine());
                    break;
                case "2":
                    for (int i = 0; i < 2; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "3":
                    for (int i = 0; i < 3; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "4":
                    for (int i = 0; i < 4; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "5":
                    for (int i = 0; i < 5; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "6":
                    for (int i = 0; i < 6; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "7":
                    for (int i = 0; i < 7; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "8":
                    for (int i = 0; i < 8; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "9":
                    for (int i = 0; i < 9; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "10":
                    for (int i = 0; i < 10; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "11":
                    for (int i = 0; i < 11; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "12":
                    for (int i = 0; i < 12; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "13":
                    for (int i = 0; i < 13; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "14":
                    for (int i = 0; i < 14; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "15":
                    for (int i = 0; i < 15; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
                case "16":
                    for (int i = 0; i < 16; i++)
                    {
                        _PlayerHouseList1.Add(sw.ReadLine());
                    }
                    break;
            }

            // Reads the number of shops
            player1ShopCount = sw.ReadLine();

            // This switch is used to read the correct number of shops that the player 1 had when they last saved the game
            switch (player1ShopCount)
            {
                case "0":

                    break;
                case "1":
                    _PlayerShopList1.Add(sw.ReadLine());
                    break;
                case "2":
                    for (int i = 0; i < 2; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "3":
                    for (int i = 0; i < 3; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "4":
                    for (int i = 0; i < 4; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "5":
                    for (int i = 0; i < 5; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "6":
                    for (int i = 0; i < 6; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "7":
                    for (int i = 0; i < 7; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "8":
                    for (int i = 0; i < 8; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "9":
                    for (int i = 0; i < 9; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "10":
                    for (int i = 0; i < 10; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "11":
                    for (int i = 0; i < 11; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "12":
                    for (int i = 0; i < 12; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "13":
                    for (int i = 0; i < 13; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "14":
                    for (int i = 0; i < 14; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "15":
                    for (int i = 0; i < 15; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
                case "16":
                    for (int i = 0; i < 16; i++)
                    {
                        _PlayerShopList1.Add(sw.ReadLine());
                    }
                    break;
            }

            // This just reads the blank line between the different sections of data
            sw.ReadLine();

            // Player 2 values from the text file
            _player2CurrentSquare = sw.ReadLine();
            _playerMoney2 = sw.ReadLine();
            Player2TimeInJail = sw.ReadLine();
            Player2InJail = sw.ReadLine();
            player2Loan = sw.ReadLine();
            player2loanvalue = sw.ReadLine();
            player2RollCount = sw.ReadLine();
            _Player2x = sw.ReadLine();
            _Player2y = sw.ReadLine();
            player2ListCount = sw.ReadLine();

            // This switch is used to read the correct number of properties that the player 2 had when they last saved the game
            // There are only 16 purchasable properties in the games
            switch (player2ListCount)
            {
                case "0":

                    break;
                case "1":
                    _PlayerProperyList2.Add(sw.ReadLine());
                    break;
                case "2":
                    for (int i = 0; i < 2; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "3":
                    for (int i = 0; i < 3; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "4":
                    for (int i = 0; i < 4; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "5":
                    for (int i = 0; i < 5; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "6":
                    for (int i = 0; i < 6; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "7":
                    for (int i = 0; i < 8; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "9":
                    for (int i = 0; i < 9; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "10":
                    for (int i = 0; i < 10; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "11":
                    for (int i = 0; i < 11; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "12":
                    for (int i = 0; i < 12; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "13":
                    for (int i = 0; i < 13; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "14":
                    for (int i = 0; i < 14; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "15":
                    for (int i = 0; i < 15; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
                case "16":
                    for (int i = 0; i < 16; i++)
                    {
                        _PlayerProperyList2.Add(sw.ReadLine());
                    }
                    break;
            }

            // Reads the number of houses
            player2HouseCount = sw.ReadLine();

            // This switch is used to read the correct number of houses that the player 2 had when they last saved the game
            switch (player2HouseCount)
            {
                case "0":

                    break;
                case "1":
                    _PlayerHouseList2.Add(sw.ReadLine());
                    break;
                case "2":
                    for (int i = 0; i < 2; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "3":
                    for (int i = 0; i < 3; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "4":
                    for (int i = 0; i < 4; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "5":
                    for (int i = 0; i < 5; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "6":
                    for (int i = 0; i < 6; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "7":
                    for (int i = 0; i < 8; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "9":
                    for (int i = 0; i < 9; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "10":
                    for (int i = 0; i < 10; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "11":
                    for (int i = 0; i < 11; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "12":
                    for (int i = 0; i < 12; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "13":
                    for (int i = 0; i < 13; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "14":
                    for (int i = 0; i < 14; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "15":
                    for (int i = 0; i < 15; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
                case "16":
                    for (int i = 0; i < 16; i++)
                    {
                        _PlayerHouseList2.Add(sw.ReadLine());
                    }
                    break;
            }

            // Reads the number of shops
            player2ShopCount = sw.ReadLine();

            // This switch is used to read the correct number of shops that the player 2 had when they last saved the game
            switch (player2ShopCount)
            {
                case "0":

                    break;
                case "1":
                    _PlayerShopList2.Add(sw.ReadLine());
                    break;
                case "2":
                    for (int i = 0; i < 2; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "3":
                    for (int i = 0; i < 3; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "4":
                    for (int i = 0; i < 4; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "5":
                    for (int i = 0; i < 5; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "6":
                    for (int i = 0; i < 6; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "7":
                    for (int i = 0; i < 8; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "9":
                    for (int i = 0; i < 9; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "10":
                    for (int i = 0; i < 10; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "11":
                    for (int i = 0; i < 11; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "12":
                    for (int i = 0; i < 12; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "13":
                    for (int i = 0; i < 13; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "14":
                    for (int i = 0; i < 14; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "15":
                    for (int i = 0; i < 15; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
                case "16":
                    for (int i = 0; i < 16; i++)
                    {
                        _PlayerShopList2.Add(sw.ReadLine());
                    }
                    break;
            }

            // Closes the file
            sw.Close();

            // This takes the strings that have been read from the file and sets all of the values in the game
            currentPlayer = _currentPlayer;

            // Sets the current player when a game is loaded
            frmBoard.setCurrentplayer(currentPlayer);

            lastSpecialCard = Convert.ToInt32(_lastSpecialCard);

            // These are the player 1 values that are being set
            int p1CurrentSquare = Convert.ToInt32(_player1CurrentSquare);
            switchPlayerCurrentSquare(p1CurrentSquare, 1);
            playerMoney1 = Convert.ToInt32(_playerMoney1);

            // Player 1 jail values
            _Player1TimeInJail = Convert.ToInt32(Player1TimeInJail);

            if (Player1InJail == "True")
            {
                _Player1InJail = true;
                UpdatePlayer1InJail();
            }
            else
            {
                _Player1InJail = false;
            }

            // Player 1 loan values
            if (player1Loan == "True")
            {
                player1HasLoan = true;
                _player1HasLoan = true;
            }
            else
            {
                player1HasLoan = false;
                _player1HasLoan = false;
            }

            player1LoanAmount = Convert.ToInt32(player1loanvalue);
            player1RollNumber = Convert.ToInt32(player1RollCount);

            // Player 1 location values
            Player1x = Convert.ToInt32(_Player1x);
            Player1y = Convert.ToInt32(_Player1y);

            frmBoard.clearPlayerPropertiesDisplay();

            PlayerProperyList1 = _PlayerProperyList1;

            for (int i = 0; i < PlayerProperyList1.Count; i++)
            {
                frmBoard.DisplayPlayerProperties1(PlayerProperyList1[i]);
            }

            PlayerHouseList1 = _PlayerHouseList1;
            PlayerShopList1 = _PlayerShopList1;

            // These are the player 2 values that are being set
            int p2CurrentSquare = Convert.ToInt32(_player2CurrentSquare);
            switchPlayerCurrentSquare(p2CurrentSquare, 2);
            playerMoney2 = Convert.ToInt32(_playerMoney2);
            _Player2TimeInJail = Convert.ToInt32(Player2TimeInJail);

            // Player 2 jail values
            if (Player2InJail == "True")
            {
                _Player2InJail = true;
                UpdatePlayer2InJail();
            }
            else
            {
                _Player2InJail = false;
            }

            // Player 2 loan values
            if (player2Loan == "True")
            {
                player2HasLoan = true;
                _player2HasLoan = true;
            }
            else
            {
                player2HasLoan = false;
                _player2HasLoan = false;
            }

            player2LoanAmount = Convert.ToInt32(player2loanvalue);
            player2RollNumber = Convert.ToInt32(player2RollCount);

            // player 2 location values
            Player2x = Convert.ToInt32(_Player2x);
            Player2y = Convert.ToInt32(_Player2y);

            PlayerProperyList2 = _PlayerProperyList2;

            for (int i = 0; i < PlayerProperyList2.Count; i++)
            {
                frmBoard.DisplayPlayerProperties2(PlayerProperyList2[i]);
            }

            PlayerHouseList2 = _PlayerHouseList2;
            PlayerShopList2 = _PlayerShopList2;

            // Moves the player images to the correct location
            MovePlayerImage1();
            MovePlayerImage2();

            // Displays the players current money
            frmBoard.setPlayerMoney1(playerMoney1.ToString());
            frmBoard.setPlayerMoney2(playerMoney2.ToString());

            // Checks the houses that are in the player 1 house list
            // If a house is in the list, it is displayed on the board and the price of rent is updated
            if (PlayerHouseList1.Contains("Black 1"))
            {
                frmBoard.displayPlayerHouses("Black 1");
                squareBlack1Rent = 264;
            }
            if (PlayerHouseList1.Contains("Black 2"))
            {
                frmBoard.displayPlayerHouses("Black 2");
                squareBlack2Rent = 264;
            }
            if (PlayerHouseList1.Contains("Aqua 1"))
            {
                frmBoard.displayPlayerHouses("Aqua 1");
                squareAqua1Rent = 336;
            }
            if (PlayerHouseList1.Contains("Aqua 2"))
            {
                frmBoard.displayPlayerHouses("Aqua 2");
                squareAqua2Rent = 336;
            }
            if (PlayerHouseList1.Contains("Yellow 1"))
            {
                frmBoard.displayPlayerHouses("Yellow 1");
                squareYellow1Rent = 360;
            }
            if (PlayerHouseList1.Contains("Yellow 2"))
            {
                frmBoard.displayPlayerHouses("Yellow 2");
                squareYellow2Rent = 360;
            }
            if (PlayerHouseList1.Contains("Green 1"))
            {
                frmBoard.displayPlayerHouses("Green 1");
                squareGreen1Rent = 480;
            }
            if (PlayerHouseList1.Contains("Green 2"))
            {
                frmBoard.displayPlayerHouses("Green 2");
                squareGreen2Rent = 480;
            }
            if (PlayerHouseList1.Contains("Blue 1"))
            {
                frmBoard.displayPlayerHouses("Blue 1");
                squareBlue1Rent = 72;
            }
            if (PlayerHouseList1.Contains("Blue 2"))
            {
                frmBoard.displayPlayerHouses("Blue 2");
                squareBlue2Rent = 72;
            }
            if (PlayerHouseList1.Contains("Red 1"))
            {
                frmBoard.displayPlayerHouses("Red 1");
                squareRed1Rent = 120;
            }
            if (PlayerHouseList1.Contains("Red 2"))
            {
                frmBoard.displayPlayerHouses("Red 2");
                squareRed2Rent = 120;
            }
            if (PlayerHouseList1.Contains("Pink 1"))
            {
                frmBoard.displayPlayerHouses("Pink 1");
                squarePink1Rent = 168;
            }
            if (PlayerHouseList1.Contains("Pink 2"))
            {
                frmBoard.displayPlayerHouses("Pink 2");
                squarePink2Rent = 168;
            }
            if (PlayerHouseList1.Contains("Brown 1"))
            {
                frmBoard.displayPlayerHouses("Brown 1");
                squareBrown1Rent = 216;
            }
            if (PlayerHouseList1.Contains("Brown 2"))
            {
                frmBoard.displayPlayerHouses("Brown 2");
                squareBrown2Rent = 216;
            }

            // Checks the houses that are in the player 2 house list
            // If a house is in the list, it is displayed on the board and the price of rent is updated
            if (PlayerHouseList2.Contains("Black 1"))
            {
                frmBoard.displayPlayerHouses("Black 1");
                squareBlack1Rent = 264;
            }
            if (PlayerHouseList2.Contains("Black 2"))
            {
                frmBoard.displayPlayerHouses("Black 2");
                squareBlack2Rent = 264;
            }
            if (PlayerHouseList2.Contains("Aqua 1"))
            {
                frmBoard.displayPlayerHouses("Aqua 1");
                squareAqua1Rent = 336;
            }
            if (PlayerHouseList2.Contains("Aqua 2"))
            {
                frmBoard.displayPlayerHouses("Aqua 2");
                squareAqua2Rent = 336;
            }
            if (PlayerHouseList2.Contains("Yellow 1"))
            {
                frmBoard.displayPlayerHouses("Yellow 1");
                squareYellow1Rent = 360;
            }
            if (PlayerHouseList2.Contains("Yellow 2"))
            {
                frmBoard.displayPlayerHouses("Yellow 2");
                squareYellow2Rent = 360;
            }
            if (PlayerHouseList2.Contains("Green 1"))
            {
                frmBoard.displayPlayerHouses("Green 1");
                squareGreen1Rent = 480;
            }
            if (PlayerHouseList2.Contains("Green 2"))
            {
                frmBoard.displayPlayerHouses("Green 2");
                squareGreen2Rent = 480;
            }
            if (PlayerHouseList2.Contains("Blue 1"))
            {
                frmBoard.displayPlayerHouses("Blue 1");
                squareBlue1Rent = 72;
            }
            if (PlayerHouseList2.Contains("Blue 2"))
            {
                frmBoard.displayPlayerHouses("Blue 2");
                squareBlue2Rent = 72;
            }
            if (PlayerHouseList2.Contains("Red 1"))
            {
                frmBoard.displayPlayerHouses("Red 1");
                squareRed1Rent = 120;
            }
            if (PlayerHouseList2.Contains("Red 2"))
            {
                frmBoard.displayPlayerHouses("Red 2");
                squareRed2Rent = 120;
            }
            if (PlayerHouseList2.Contains("Pink 1"))
            {
                frmBoard.displayPlayerHouses("Pink 1");
                squarePink1Rent = 168;
            }
            if (PlayerHouseList2.Contains("Pink 2"))
            {
                frmBoard.displayPlayerHouses("Pink 2");
                squarePink2Rent = 168;
            }
            if (PlayerHouseList2.Contains("Brown 1"))
            {
                frmBoard.displayPlayerHouses("Brown 1");
                squareBrown1Rent = 216;
            }
            if (PlayerHouseList2.Contains("Brown 2"))
            {
                frmBoard.displayPlayerHouses("Brown 2");
                squareBrown2Rent = 216;
            }

            // Checks the shops that are in the player 1 shop list
            // If a shop is in the list, it is displayed on the board and the price of rent is updated
            if (PlayerShopList1.Contains("Black 1"))
            {
                frmBoard.displayPlayerShops("Black 1");
                squareBlack1Rent = 352;
            }
            if (PlayerShopList1.Contains("Black 2"))
            {
                frmBoard.displayPlayerShops("Black 2");
                squareBlack2Rent = 352;
            }
            if (PlayerShopList1.Contains("Aqua 1"))
            {
                frmBoard.displayPlayerShops("Aqua 1");
                squareAqua1Rent = 448;
            }
            if (PlayerShopList1.Contains("Aqua 2"))
            {
                frmBoard.displayPlayerShops("Aqua 2");
                squareAqua2Rent = 448;
            }
            if (PlayerShopList1.Contains("Yellow 1"))
            {
                frmBoard.displayPlayerShops("Yellow 1");
                squareYellow1Rent = 480;
            }
            if (PlayerShopList1.Contains("Yellow 2"))
            {
                frmBoard.displayPlayerShops("Yellow 2");
                squareYellow2Rent = 480;
            }
            if (PlayerShopList1.Contains("Green 1"))
            {
                frmBoard.displayPlayerShops("Green 1");
                squareGreen1Rent = 640;
            }
            if (PlayerShopList1.Contains("Green 2"))
            {
                frmBoard.displayPlayerShops("Green 2");
                squareGreen2Rent = 640;
            }
            if (PlayerShopList1.Contains("Blue 1"))
            {
                frmBoard.displayPlayerShops("Blue 1");
                squareBlue1Rent = 96;
            }
            if (PlayerShopList1.Contains("Blue 2"))
            {
                frmBoard.displayPlayerShops("Blue 2");
                squareBlue2Rent = 96;
            }
            if (PlayerShopList1.Contains("Red 1"))
            {
                frmBoard.displayPlayerShops("Red 1");
                squareRed1Rent = 160;
            }
            if (PlayerShopList1.Contains("Red 2"))
            {
                frmBoard.displayPlayerShops("Red 2");
                squareRed2Rent = 160;
            }
            if (PlayerShopList1.Contains("Pink 1"))
            {
                frmBoard.displayPlayerShops("Pink 1");
                squarePink1Rent = 224;
            }
            if (PlayerShopList1.Contains("Pink 2"))
            {
                frmBoard.displayPlayerShops("Pink 2");
                squarePink2Rent = 224;
            }
            if (PlayerShopList1.Contains("Brown 1"))
            {
                frmBoard.displayPlayerShops("Brown 1");
                squareBrown1Rent = 288;
            }
            if (PlayerShopList1.Contains("Brown 2"))
            {
                frmBoard.displayPlayerShops("Brown 2");
                squareBrown2Rent = 288;
            }

            // Checks the shops that are in the player 2 shop list
            // If a shop is in the list, it is displayed on the board and the price of rent is updated
            if (PlayerShopList2.Contains("Black 1"))
            {
                frmBoard.displayPlayerShops("Black 1");
                squareBlack1Rent = 352;
            }
            if (PlayerShopList2.Contains("Black 2"))
            {
                frmBoard.displayPlayerShops("Black 2");
                squareBlack2Rent = 352;
            }
            if (PlayerShopList2.Contains("Aqua 1"))
            {
                frmBoard.displayPlayerShops("Aqua 1");
                squareAqua1Rent = 448;
            }
            if (PlayerShopList2.Contains("Aqua 2"))
            {
                frmBoard.displayPlayerShops("Aqua 2");
                squareAqua2Rent = 448;
            }
            if (PlayerShopList2.Contains("Yellow 1"))
            {
                frmBoard.displayPlayerShops("Yellow 1");
                squareYellow1Rent = 480;
            }
            if (PlayerShopList2.Contains("Yellow 2"))
            {
                frmBoard.displayPlayerShops("Yellow 2");
                squareYellow2Rent = 480;
            }
            if (PlayerShopList2.Contains("Green 1"))
            {
                frmBoard.displayPlayerShops("Green 1");
                squareGreen1Rent = 640;
            }
            if (PlayerShopList2.Contains("Green 2"))
            {
                frmBoard.displayPlayerShops("Green 2");
                squareGreen2Rent = 640;
            }
            if (PlayerShopList2.Contains("Blue 1"))
            {
                frmBoard.displayPlayerShops("Blue 1");
                squareBlue1Rent = 96;
            }
            if (PlayerShopList2.Contains("Blue 2"))
            {
                frmBoard.displayPlayerShops("Blue 2");
                squareBlue2Rent = 96;
            }
            if (PlayerShopList2.Contains("Red 1"))
            {
                frmBoard.displayPlayerShops("Red 1");
                squareRed1Rent = 160;
            }
            if (PlayerShopList2.Contains("Red 2"))
            {
                frmBoard.displayPlayerShops("Red 2");
                squareRed2Rent = 160;
            }
            if (PlayerShopList2.Contains("Pink 1"))
            {
                frmBoard.displayPlayerShops("Pink 1");
                squarePink1Rent = 224;
            }
            if (PlayerShopList2.Contains("Pink 2"))
            {
                frmBoard.displayPlayerShops("Pink 2");
                squarePink2Rent = 224;
            }
            if (PlayerShopList2.Contains("Brown 1"))
            {
                frmBoard.displayPlayerShops("Brown 1");
                squareBrown1Rent = 288;
            }
            if (PlayerShopList2.Contains("Brown 2"))
            {
                frmBoard.displayPlayerShops("Brown 2");
                squareBrown2Rent = 288;
            }
        }

        #endregion


        #region Switch Current Square method

        public void switchPlayerCurrentSquare(int currentSquare, int player)
        {
            switch (currentSquare)
            {
                case 0:
                    if (player == 1)
                    {
                        player1CurrentSquare = square0;
                        playerPosition1 = 0;
                    }
                    else
                    {
                        player2CurrentSquare = square0;
                        playerPosition2 = 0;
                    }
                    break;
                case 1:
                    if (player == 1)
                    {
                        player1CurrentSquare = square1;
                        playerPosition1 = 1;
                    }
                    else
                    {
                        player2CurrentSquare = square1;
                        playerPosition2 = 1;
                    }
                    break;
                case 2:
                    if (player == 1)
                    {
                        player1CurrentSquare = square2;
                        playerPosition1 = 2;
                    }
                    else
                    {
                        player2CurrentSquare = square2;
                        playerPosition2 = 2;
                    }
                    break;
                case 3:
                    if (player == 1)
                    {
                        player1CurrentSquare = square3;
                        playerPosition1 = 3;
                    }
                    else
                    {
                        player2CurrentSquare = square3;
                        playerPosition2 = 3;
                    }
                    break;
                case 4:
                    if (player == 1)
                    {
                        player1CurrentSquare = square4;
                        playerPosition1 = 4;
                    }
                    else
                    {
                        player2CurrentSquare = square4;
                        playerPosition2 = 4;
                    }
                    break;
                case 5:
                    if (player == 1)
                    {
                        player1CurrentSquare = square5;
                        playerPosition1 = 5;
                    }
                    else
                    {
                        player2CurrentSquare = square5;
                        playerPosition2 = 5;
                    }
                    break;
                case 6:
                    if (player == 1)
                    {
                        player1CurrentSquare = square6;
                        playerPosition1 = 6;
                    }
                    else
                    {
                        player2CurrentSquare = square6;
                        playerPosition2 = 6;
                    }
                    break;
                case 7:
                    if (player == 1)
                    {
                        player1CurrentSquare = square7;
                        playerPosition1 = 7;
                    }
                    else
                    {
                        player2CurrentSquare = square7;
                        playerPosition2 = 7;
                    }
                    break;
                case 8:
                    if (player == 1)
                    {
                        player1CurrentSquare = square8;
                        playerPosition1 = 8;
                    }
                    else
                    {
                        player2CurrentSquare = square8;
                        playerPosition2 = 8;
                    }
                    break;
                case 9:
                    if (player == 1)
                    {
                        player1CurrentSquare = square9;
                        playerPosition1 = 9;
                    }
                    else
                    {
                        player2CurrentSquare = square9;
                        playerPosition2 = 9;
                    }
                    break;
                case 10:
                    if (player == 1)
                    {
                        player1CurrentSquare = square10;
                        playerPosition1 = 10;
                    }
                    else
                    {
                        player2CurrentSquare = square10;
                        playerPosition2 = 10;
                    }
                    break;
                case 11:
                    if (player == 1)
                    {
                        player1CurrentSquare = square11;
                        playerPosition1 = 11;
                    }
                    else
                    {
                        player2CurrentSquare = square11;
                        playerPosition2 = 11;
                    }
                    break;
                case 12:
                    if (player == 1)
                    {
                        player1CurrentSquare = square12;
                        playerPosition1 = 12;
                    }
                    else
                    {
                        player2CurrentSquare = square12;
                        playerPosition2 = 12;
                    }
                    break;
                case 13:
                    if (player == 1)
                    {
                        player1CurrentSquare = square13;
                        playerPosition1 = 13;
                    }
                    else
                    {
                        player2CurrentSquare = square13;
                        playerPosition2 = 13;
                    }
                    break;
                case 14:
                    if (player == 1)
                    {
                        player1CurrentSquare = square14;
                        playerPosition1 = 14;
                    }
                    else
                    {
                        player2CurrentSquare = square14;
                        playerPosition2 = 14;
                    }
                    break;
                case 15:
                    if (player == 1)
                    {
                        player1CurrentSquare = square15;
                        playerPosition1 = 15;
                    }
                    else
                    {
                        player2CurrentSquare = square15;
                        playerPosition2 = 15;
                    }
                    break;
                case 16:
                    if (player == 1)
                    {
                        player1CurrentSquare = square16;
                        playerPosition1 = 16;
                    }
                    else
                    {
                        player2CurrentSquare = square16;
                        playerPosition2 = 16;
                    }
                    break;
                case 17:
                    if (player == 1)
                    {
                        player1CurrentSquare = square17;
                        playerPosition1 = 17;
                    }
                    else
                    {
                        player2CurrentSquare = square17;
                        playerPosition2 = 17;
                    }
                    break;
                case 18:
                    if (player == 1)
                    {
                        player1CurrentSquare = square18;
                        playerPosition1 = 18;
                    }
                    else
                    {
                        player2CurrentSquare = square18;
                        playerPosition2 = 18;
                    }
                    break;
                case 19:
                    if (player == 1)
                    {
                        player1CurrentSquare = square19;
                        playerPosition1 = 19;
                    }
                    else
                    {
                        player2CurrentSquare = square19;
                        playerPosition2 = 19;
                    }
                    break;
                case 20:
                    if (player == 1)
                    {
                        player1CurrentSquare = square20;
                        playerPosition1 = 20;
                    }
                    else
                    {
                        player2CurrentSquare = square20;
                        playerPosition2 = 20;
                    }
                    break;
                case 21:
                    if (player == 1)
                    {
                        player1CurrentSquare = square21;
                        playerPosition1 = 21;
                    }
                    else
                    {
                        player2CurrentSquare = square21;
                        playerPosition2 = 21;
                    }
                    break;
                case 22:
                    if (player == 1)
                    {
                        player1CurrentSquare = square22;
                        playerPosition1 = 22;
                    }
                    else
                    {
                        player2CurrentSquare = square22;
                        playerPosition2 = 22;
                    }
                    break;
                case 23:
                    if (player == 1)
                    {
                        player1CurrentSquare = square23;
                        playerPosition1 = 23;
                    }
                    else
                    {
                        player2CurrentSquare = square23;
                        playerPosition2 = 23;
                    }
                    break;
            }
        }

        #endregion


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmBoard());
        }
    }
}






