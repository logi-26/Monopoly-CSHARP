using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace monopoly
{
    /******************************************************************************************************
         Created by Louis Gilmartin:          Last updated 01/12/2013
    ******************************************************************************************************/

    public partial class frmDebug : Form
    {

        #region Variables

        private string _fileName = "Debug.txt";
        private bool _debugEnabled;

        // String to hold the app directory
        // this is used for the save file and audio file paths
        private string appPath = System.IO.Directory.GetCurrentDirectory();

        // Property lists for the players
        public static List<string> PlayerProperyList1 = new List<string>();
        public static List<string> PlayerProperyList2 = new List<string>();

        // House lists for the players
        private static List<string> PlayerHouseList1 = new List<string>();
        private static List<string> PlayerHouseList2 = new List<string>();

        // Shop lists for the players
        private static List<string> PlayerShopList1 = new List<string>();
        private static List<string> PlayerShopList2 = new List<string>();

        #endregion

        public frmDebug()
        {
            InitializeComponent();

            // Adds key press event listeners to the 2 text boxes
            txtP1CurrentMoney.KeyPress += new KeyPressEventHandler(txtP1CurrentMoney_KeyPress);
            txtP2CurrentMoney.KeyPress += new KeyPressEventHandler(txtP2CurrentMoney_KeyPress);
        }

        // Set-Get for the debug mode
        public bool debugEnabled
        {
            get
            {
                return this._debugEnabled;
            }
            set
            {
                this._debugEnabled = value;
            }
        }

        // Player 1 money textbox key press event 
        private void txtP1CurrentMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            // This prevents any characters other than numeric digits from being entered into the text box
            // It also allows the use of a backspace
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        // Player 2 money textbox key press event 
        private void txtP2CurrentMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            // This prevents any characters other than numeric digits from being entered into the text box
            // It also allows the use of a backspace
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        #region Player 1 Property Checkboxes

        // Checkbox change events for the player 1 properties, houses and shops
        // These methods add the selected properties to the players properties, houses and shop lists
        // These methods ensure that two players cannot own the same property
        // The methods also ensure that a player cannot own a house or shop for a property that they do not own
        // It also ensures that a player owns both properties of a particular colour if a house or shop is being set
        // The code is basically the same for each set of checkboxes, just relating to different properties

        // Black 1 property
        private void P1PropertyBlack1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyBlack1.Checked == true)
            {
                // If the player owns the property the checkbox for the house is enabled
                P1HouseBlack1.Enabled = true;

                // If player 1 has the property player 2 cannot, so this un-checks the player 2 box
                P2PropertyBlack1.Checked = false;

                // The property is added to the player 1 properties list
                PlayerProperyList1.Add("Strand");
            }
            else
            {
                // If the property checkbox is un-checked, then the checkboxes for the corresponding houses and shops are disabled and un-checked
                // Also if the other corresponding property colour had house or shops, they are removed.
                // This is to prevent houses and shops being selected when the player only owns 1 property from the two of a particular colour
                P1HouseBlack2.Checked = false;
                P1HouseBlack1.Enabled = false;
                P1HouseBlack1.Checked = false;
                P1ShopBlack1.Enabled = false;
                P1ShopBlack1.Checked = false;

                // The property is removed from the player 1 properties list
                PlayerProperyList1.Remove("Strand");
            }
        }

        //Black 1 house
        private void P1HouseBlack1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseBlack1.Checked == true)
            {
                // Once a house has been selected, the checkbox for a shop will be enabled
                P1ShopBlack1.Enabled = true;

                // The house is added to the player 1 house list
                PlayerHouseList1.Add("Black 1");

                // If a house is selected, the corresponding colour property card must be selected
                P1PropertyBlack2.Checked = true;
            }
            else
            {
                // If a house is not selected, then the shop checkbox is disabled and un-checked
                P1ShopBlack1.Enabled = false;
                P1ShopBlack1.Checked = false;

                // The house is removed from the player 1 house list
                PlayerHouseList1.Remove("Black 1");
            }
        }

        //Black 1 shop
        private void P1ShopBlack1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopBlack1.Checked == true)
            {
                // This adds the shop to the player 1 shop list
                PlayerShopList1.Add("Black 1");
            }
            else
            {
                // This removes the shop from the player 1 shop list
                PlayerShopList1.Remove("Black 1");
            }
        }

        //Black 2 property
        private void P1PropertyBlack2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyBlack2.Checked == true)
            {
                P1HouseBlack2.Enabled = true;
                P2PropertyBlack2.Checked = false;
                PlayerProperyList1.Add("Trafalgar Sq");
            }
            else
            {
                P1HouseBlack1.Checked = false;
                P1HouseBlack2.Enabled = false;
                P1HouseBlack2.Checked = false;
                P1ShopBlack2.Enabled = false;
                P1ShopBlack2.Checked = false;
                PlayerProperyList1.Remove("Trafalgar Sq");
            }
        }

        //Black 2 house
        private void P1HouseBlack2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseBlack2.Checked == true)
            {
                P1ShopBlack2.Enabled = true;
                PlayerHouseList1.Add("Black 2");
                P1PropertyBlack1.Checked = true;
            }
            else
            {
                P1ShopBlack2.Enabled = false;
                P1ShopBlack2.Checked = false;
                PlayerHouseList1.Remove("Black 2");
            }
        }

        //Black 2 shop
        private void P1ShopBlack2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopBlack2.Checked == true)
            {
                PlayerShopList1.Add("Black 2");
            }
            else
            {
                PlayerShopList1.Remove("Black 2");
            }
        }

        //Aqua 1 property
        private void P1PropertyAqua1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyAqua1.Checked == true)
            {
                P1HouseAqua1.Enabled = true;
                P2PropertyAqua1.Checked = false;
                PlayerProperyList1.Add("Leicester Sq");
            }
            else
            {
                P1HouseAqua2.Checked = false;
                P1HouseAqua1.Enabled = false;
                P1HouseAqua1.Checked = false;
                P1ShopAqua1.Enabled = false;
                P1ShopAqua1.Checked = false;
                PlayerProperyList1.Remove("Leicester Sq");
            }
        }

        //Aqua 1 house
        private void P1HouseAqua1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseAqua1.Checked == true)
            {
                P1ShopAqua1.Enabled = true;
                PlayerHouseList1.Add("Aqua 1");
                P1PropertyAqua2.Checked = true;
            }
            else
            {
                P1ShopAqua1.Enabled = false;
                P1ShopAqua1.Checked = false;
                PlayerHouseList1.Remove("Aqua 1");
            }
        }

        //Aqua 1 shop
        private void P1ShopAqua1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopAqua1.Checked == true)
            {
                PlayerShopList1.Add("Aqua 1");
            }
            else
            {
                PlayerShopList1.Remove("Aqua 1");
            }
        }

        // Aqua 2 property
        private void P1PropertyAqua2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyAqua2.Checked == true)
            {
                P1HouseAqua2.Enabled = true;
                P2PropertyAqua2.Checked = false;
                PlayerProperyList1.Add("Piccadilly");
            }
            else
            {
                P1HouseAqua1.Checked = false;
                P1HouseAqua2.Enabled = false;
                P1HouseAqua2.Checked = false;
                P1ShopAqua2.Enabled = false;
                P1ShopAqua2.Checked = false;
                PlayerProperyList1.Remove("Piccadilly");
            }
        }

        // Aqua 2 house
        private void P1HouseAqua2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseAqua2.Checked == true)
            {
                P1ShopAqua2.Enabled = true;
                PlayerHouseList1.Add("Aqua 2");
                P1PropertyAqua1.Checked = true;
            }
            else
            {
                P1ShopAqua2.Enabled = false;
                P1ShopAqua2.Checked = false;
                PlayerHouseList1.Remove("Aqua 2");
            }
        }

        // Aqua 2 shop
        private void P1ShopAqua2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopAqua2.Checked == true)
            {
                PlayerShopList1.Add("Aqua 2");
            }
            else
            {
                PlayerShopList1.Remove("Aqua 2");
            }
        }

        // Yellow 1 property
        private void P1PropertyYellow1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyYellow1.Checked == true)
            {
                P1HouseYellow1.Enabled = true;
                P2PropertyYellow1.Checked = false;
                PlayerProperyList1.Add("Regent St");
            }
            else
            {
                P1HouseYellow2.Checked = false;
                P1HouseYellow1.Enabled = false;
                P1HouseYellow1.Checked = false;
                P1ShopYellow1.Enabled = false;
                P1ShopYellow1.Checked = false;
                PlayerProperyList1.Remove("Regent St");
            }
        }

        // Yellow 1 house
        private void P1HouseYellow1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseYellow1.Checked == true)
            {
                P1ShopYellow1.Enabled = true;
                PlayerHouseList1.Add("Yellow 1");
                P1PropertyYellow2.Checked = true;
            }
            else
            {
                P1ShopYellow1.Enabled = false;
                P1ShopYellow1.Checked = false;
                PlayerHouseList1.Remove("Yellow 1");
            }
        }

        // Yellow 1 shop
        private void P1ShopYellow1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopYellow1.Checked == true)
            {
                PlayerShopList1.Add("Yellow 1");
            }
            else
            {
                PlayerShopList1.Remove("Yellow 1");
            }
        }

        // Yellow 2 property
        private void P1PropertyYellow2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyYellow2.Checked == true)
            {
                P1HouseYellow2.Enabled = true;
                P2PropertyYellow2.Checked = false;
                PlayerProperyList1.Add("Oxford St");
            }
            else
            {
                P1HouseYellow1.Checked = false;
                P1HouseYellow2.Enabled = false;
                P1HouseYellow2.Checked = false;
                P1ShopYellow2.Enabled = false;
                P1ShopYellow2.Checked = false;
                PlayerProperyList1.Remove("Oxford St");
            }
        }

        // Yellow 2 house
        private void P1HouseYellow2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseYellow2.Checked == true)
            {
                P1ShopYellow2.Enabled = true;
                PlayerHouseList1.Add("Yellow 2");
                P1PropertyYellow1.Checked = true;
            }
            else
            {
                P1ShopYellow2.Enabled = false;
                P1ShopYellow2.Checked = false;
                PlayerHouseList1.Remove("Yellow 2");
            }
        }

        // Yellow 2 shop
        private void P1ShopYellow2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopYellow2.Checked == true)
            {
                PlayerShopList1.Add("Yellow 2");
            }
            else
            {
                PlayerShopList1.Remove("Yellow 2");
            }
        }

        // Green 1 property
        private void P1PropertyGreen1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyGreen1.Checked == true)
            {
                P1HouseGreen1.Enabled = true;
                P2PropertyGreen1.Checked = false;
                PlayerProperyList1.Add("Mayfair");
            }
            else
            {
                P1HouseGreen2.Checked = false;
                P1HouseGreen1.Enabled = false;
                P1HouseGreen1.Checked = false;
                P1ShopGreen1.Enabled = false;
                P1ShopGreen1.Checked = false;
                PlayerProperyList1.Remove("Mayfair");
            }
        }

        // Green 1 house
        private void P1HouseGreen1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseGreen1.Checked == true)
            {
                P1ShopGreen1.Enabled = true;
                PlayerHouseList1.Add("Green 1");
                P1PropertyGreen2.Checked = true;
            }
            else
            {
                P1ShopGreen1.Enabled = false;
                P1ShopGreen1.Checked = false;
                PlayerHouseList1.Remove("Green 1");
            }
        }

        // Green 1 shop
        private void P1ShopGreen1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopGreen1.Checked == true)
            {
                PlayerShopList1.Add("Green 1");
            }
            else
            {
                PlayerShopList1.Remove("Green 1");
            }
        }

        // Green 2 property
        private void P1PropertyGreen2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyGreen2.Checked == true)
            {
                P1HouseGreen2.Enabled = true;
                P2PropertyGreen2.Checked = false;
                PlayerProperyList1.Add("Park Lane");
            }
            else
            {
                P1HouseGreen1.Checked = false;
                P1HouseGreen2.Enabled = false;
                P1HouseGreen2.Checked = false;
                P1ShopGreen2.Enabled = false;
                P1ShopGreen2.Checked = false;
                PlayerProperyList1.Remove("Park Lane");
            }
        }

        // Green 2 house
        private void P1HouseGreen2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseGreen2.Checked == true)
            {
                P1ShopGreen2.Enabled = true;
                PlayerHouseList1.Add("Green 2");
                P1PropertyGreen1.Checked = true;
            }
            else
            {
                P1ShopGreen2.Enabled = false;
                P1ShopGreen2.Checked = false;
                PlayerHouseList1.Remove("Green 2");
            }
        }

        // Green 2 shop
        private void P1ShopGreen2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopGreen2.Checked == true)
            {
                PlayerShopList1.Add("Green 2");
            }
            else
            {
                PlayerShopList1.Remove("Green 2");
            }
        }

        // Blue 1 property
        private void P1PropertyBlue1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyBlue1.Checked == true)
            {
                P1HouseBlue1.Enabled = true;
                P2PropertyBlue1.Checked = false;
                PlayerProperyList1.Add("Old Kent Rd");
            }
            else
            {
                P1HouseBlue2.Checked = false;
                P1HouseBlue1.Enabled = false;
                P1HouseBlue1.Checked = false;
                P1ShopBlue1.Enabled = false;
                P1ShopBlue1.Checked = false;
                PlayerProperyList1.Remove("Old Kent Rd");
            }
        }

        // Blue 1 house
        private void P1HouseBlue1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseBlue1.Checked == true)
            {
                P1ShopBlue1.Enabled = true;
                PlayerHouseList1.Add("Blue 1");
                P1PropertyBlue2.Checked = true;
            }
            else
            {
                P1ShopBlue1.Enabled = false;
                P1ShopBlue1.Checked = false;
                PlayerHouseList1.Remove("Blue 1");
            }
        }

        // Blue 1 shop
        private void P1ShopBlue1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopBlue1.Checked == true)
            {
                PlayerShopList1.Add("Blue 1");
            }
            else
            {
                PlayerShopList1.Remove("Blue 1");
            }
        }

        // Blue 2 property
        private void P1PropertyBlue2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyBlue2.Checked == true)
            {
                P1HouseBlue2.Enabled = true;
                P2PropertyBlue2.Checked = false;
                PlayerProperyList1.Add("Whitechapel");
            }
            else
            {
                P1HouseBlue1.Checked = false;
                P1HouseBlue2.Enabled = false;
                P1HouseBlue2.Checked = false;
                P1ShopBlue2.Enabled = false;
                P1ShopBlue2.Checked = false;
                PlayerProperyList1.Remove("Whitechapel");
            }
        }

        // Blue 2 house
        private void P1HouseBlue2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseBlue2.Checked == true)
            {
                P1ShopBlue2.Enabled = true;
                PlayerHouseList1.Add("Blue 2");
                P1PropertyBlue1.Checked = true;
            }
            else
            {
                P1ShopBlue2.Enabled = false;
                P1ShopBlue2.Checked = false;
                PlayerHouseList1.Remove("Blue 2");
            }
        }

        // Blue 2 shop
        private void P1ShopBlue2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopBlue2.Checked == true)
            {
                PlayerShopList1.Add("Blue 2");
            }
            else
            {
                PlayerShopList1.Remove("Blue 2");
            }
        }

        // Red 1 property
        private void P1PropertyRed1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyRed1.Checked == true)
            {
                P1HouseRed1.Enabled = true;
                P2PropertyRed1.Checked = false;
                PlayerProperyList1.Add("Islington");
            }
            else
            {
                P1HouseRed2.Checked = false;
                P1HouseRed1.Enabled = false;
                P1HouseRed1.Checked = false;
                P1ShopRed1.Enabled = false;
                P1ShopRed1.Checked = false;
                PlayerProperyList1.Remove("Islington");
            }
        }

        // Red 1 house
        private void P1HouseRed1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseRed1.Checked == true)
            {
                P1ShopRed1.Enabled = true;
                PlayerHouseList1.Add("Red 1");
                P1PropertyRed2.Checked = true;
            }
            else
            {
                P1ShopRed1.Enabled = false;
                P1ShopRed1.Checked = false;
                PlayerHouseList1.Remove("Red 1");
            }
        }

        // Red 1 shop
        private void P1ShopRed1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopRed1.Checked == true)
            {
                PlayerShopList1.Add("Red 1");
            }
            else
            {
                PlayerShopList1.Remove("Red 1");
            }
        }

        // Red 2 property
        private void P1PropertyRed2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyRed2.Checked == true)
            {
                P1HouseRed2.Enabled = true;
                P2PropertyRed2.Checked = false;
                PlayerProperyList1.Add("Euston");
            }
            else
            {
                P1HouseRed1.Checked = false;
                P1HouseRed2.Enabled = false;
                P1HouseRed2.Checked = false;
                P1ShopRed2.Enabled = false;
                P1ShopRed2.Checked = false;
                PlayerProperyList1.Remove("Euston");
            }
        }

        // Red 2 house
        private void P1HouseRed2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseRed2.Checked == true)
            {
                P1ShopRed2.Enabled = true;
                PlayerHouseList1.Add("Red 2");
                P1PropertyRed1.Checked = true;
            }
            else
            {
                P1ShopRed2.Enabled = false;
                P1ShopRed2.Checked = false;
                PlayerHouseList1.Remove("Red 2");
            }
        }

        // Red 2 shop
        private void P1ShopRed2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopRed2.Checked == true)
            {
                PlayerShopList1.Add("Red 2");
            }
            else
            {
                PlayerShopList1.Remove("Red 2");
            }
        }

        // Pink 1 property
        private void P1PropertyPink1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyPink1.Checked == true)
            {
                P1HousePink1.Enabled = true;
                P2PropertyPink1.Checked = false;
                PlayerProperyList1.Add("Pall Mall");
            }
            else
            {
                P1HousePink2.Checked = false;
                P1HousePink1.Enabled = false;
                P1HousePink1.Checked = false;
                P1ShopPink1.Enabled = false;
                P1ShopPink1.Checked = false;
                PlayerProperyList1.Remove("Pall Mall");
            }
        }

        // Pink 1 house
        private void P1HousePink1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HousePink1.Checked == true)
            {
                P1ShopPink1.Enabled = true;
                PlayerHouseList1.Add("Pink 1");
                P1PropertyPink2.Checked = true;
            }
            else
            {
                P1ShopPink1.Enabled = false;
                P1ShopPink1.Checked = false;
                PlayerHouseList1.Remove("Pink 1");
            }
        }

        // Pink 1 shop
        private void P1ShopPink1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopPink1.Checked == true)
            {
                PlayerShopList1.Add("Pink 1");
            }
            else
            {
                PlayerShopList1.Remove("Pink 1");
            }
        }

        // Pink 2 property
        private void P1PropertyPink2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyPink2.Checked == true)
            {
                P1HousePink2.Enabled = true;
                P2PropertyPink2.Checked = false;
                PlayerProperyList1.Add("Whitehall");
            }
            else
            {
                P1HousePink1.Checked = false;
                P1HousePink2.Enabled = false;
                P1HousePink2.Checked = false;
                P1ShopPink2.Enabled = false;
                P1ShopPink2.Checked = false;
                PlayerProperyList1.Remove("Whitehall");
            }
        }

        // Pink 2 house
        private void P1HousePink2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HousePink2.Checked == true)
            {
                P1ShopPink2.Enabled = true;
                PlayerHouseList1.Add("Pink 2");
                P1PropertyPink1.Checked = true;
            }
            else
            {
                P1ShopPink2.Enabled = false;
                P1ShopPink2.Checked = false;
                PlayerHouseList1.Remove("Pink 2");
            }
        }

        // Pink 2 shop
        private void P1ShopPink2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopPink2.Checked == true)
            {
                PlayerShopList1.Add("Pink 2");
            }
            else
            {
                PlayerShopList1.Remove("Pink 2");
            }
        }

        // Brown 1 property
        private void P1PropertyBrown1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyBrown1.Checked == true)
            {
                P1HouseBrown1.Enabled = true;
                P2PropertyBrown1.Checked = false;
                PlayerProperyList1.Add("Bow St");
            }
            else
            {
                P1HouseBrown2.Checked = false;
                P1HouseBrown1.Enabled = false;
                P1HouseBrown1.Checked = false;
                P1ShopBrown1.Enabled = false;
                P1ShopBrown1.Checked = false;
                PlayerProperyList1.Remove("Bow St");
            }
        }

        // Brown 1 house
        private void P1HouseBrown1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseBrown1.Checked == true)
            {
                P1ShopBrown1.Enabled = true;
                PlayerHouseList1.Add("Brown 1");
                P1PropertyBrown2.Checked = true;
            }
            else
            {
                P1ShopBrown1.Enabled = false;
                P1ShopBrown1.Checked = false;
                PlayerHouseList1.Remove("Brown 1");
            }
        }

        // Brown 1 shop
        private void P1ShopBrown1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopBrown1.Checked == true)
            {
                PlayerShopList1.Add("Brown 1");
            }
            else
            {
                PlayerShopList1.Remove("Brown 1");
            }
        }

        // Brown 2 property
        private void P1PropertyBrown2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1PropertyBrown2.Checked == true)
            {
                P1HouseBrown2.Enabled = true;
                P2PropertyBrown2.Checked = false;
                PlayerProperyList1.Add("Vine St");
            }
            else
            {
                P1HouseBrown1.Checked = false;
                P1HouseBrown2.Enabled = false;
                P1HouseBrown2.Checked = false;
                P1ShopBrown2.Enabled = false;
                P1ShopBrown2.Checked = false;
                PlayerProperyList1.Remove("Vine St");
            }
        }

        // Brown 2 house
        private void P1HouseBrown2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1HouseBrown2.Checked == true)
            {
                P1ShopBrown2.Enabled = true;
                PlayerHouseList1.Add("Brown 2");
                P1PropertyBrown1.Checked = true;
            }
            else
            {
                P1ShopBrown2.Enabled = false;
                P1ShopBrown2.Checked = false;
                PlayerHouseList1.Remove("Brown 2");
            }
        }

        // Brown 2 shop
        private void P1ShopBrown2_CheckedChanged(object sender, EventArgs e)
        {
            if (P1ShopBrown2.Checked == true)
            {
                PlayerShopList1.Add("Brown 2");
            }
            else
            {
                PlayerShopList1.Remove("Brown 2");
            }
        }


        #endregion


        #region Player 2 Property Checkboxes
        // These are the same methods as above, but for the player 2 checkboxes and player 2 lists
        // The code is basically the same for each set of checkboxes, just relating to different properties

        // Black 1 property
        private void P2PropertyBlack1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyBlack1.Checked == true)
            {
                // When the property is selected, the house checkbox is enabled
                P2HouseBlack1.Enabled = true;

                // This un-checks the player 1 property box to ensure two players do not own the same property
                P1PropertyBlack1.Checked = false;

                // This adds the property to the player 2 properties list
                PlayerProperyList2.Add("Strand");
            }
            else
            {
                // If the property is un-checked the corresponding checkboxes for the house and shop are disabled and un-checked
                P2HouseBlack2.Checked = false;
                P2HouseBlack1.Enabled = false;
                P2HouseBlack1.Checked = false;
                P2ShopBlack1.Enabled = false;
                P2ShopBlack1.Checked = false;

                // The property is removed from the player 2 properties list
                PlayerProperyList2.Remove("Strand");
            }
        }

        // Black 1 house
        private void P2HouseBlack1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseBlack1.Checked == true)
            {
                // When the house checkbox is checked, the shop checkbox is enabled
                P2ShopBlack1.Enabled = true;

                // The house is added to the player 2 house list
                PlayerHouseList2.Add("Black 1");

                // When the house is selected the checkbox for the other property of the same colour is checked
                // This is to prevent a house being built when a player only has 1 property of a particular colour
                P2PropertyBlack2.Checked = true;
            }
            else
            {
                // When the house checkbox is un-checked, the shop checkbox is disabled and un-checked
                P2ShopBlack1.Enabled = false;
                P2ShopBlack1.Checked = false;

                // This removes the house from the player 2 house list
                PlayerHouseList2.Remove("Black 1");
            }
        }

        // Black 1 shop
        private void P2ShopBlack1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopBlack1.Checked == true)
            {
                // This adds the shop to the player 2 shop list
                PlayerShopList2.Add("Black 1");
            }
            else
            {
                // This removes the shop from the player 2 shop list
                PlayerShopList2.Remove("Black 1");
            }
        }

        // Black 2 property
        private void P2PropertyBlack2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyBlack2.Checked == true)
            {
                P2HouseBlack2.Enabled = true;
                P1PropertyBlack2.Checked = false;
                PlayerProperyList2.Add("Trafalgar Sq");
            }
            else
            {
                P2HouseBlack1.Checked = false;
                P2HouseBlack2.Enabled = false;
                P2HouseBlack2.Checked = false;
                P2ShopBlack2.Enabled = false;
                P2ShopBlack2.Checked = false;
                PlayerProperyList2.Remove("Trafalgar Sq");
            }
        }

        // Black 2 house
        private void P2HouseBlack2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseBlack2.Checked == true)
            {
                P2ShopBlack2.Enabled = true;
                PlayerHouseList2.Add("Black 2");
                P2PropertyBlack1.Checked = true;
            }
            else
            {
                P2ShopBlack2.Enabled = false;
                P2ShopBlack2.Checked = false;
                PlayerHouseList2.Remove("Black 2");
            }
        }

        // Black 2 shop
        private void P2ShopBlack2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopBlack2.Checked == true)
            {
                PlayerShopList2.Add("Black 2");
            }
            else
            {
                PlayerShopList2.Remove("Black 2");
            }
        }

        // Aqua 1 property
        private void P2PropertyAqua1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyAqua1.Checked == true)
            {
                P2HouseAqua1.Enabled = true;
                P1PropertyAqua1.Checked = false;
                PlayerProperyList2.Add("Leicester Sq");
            }
            else
            {
                P2HouseAqua2.Checked = false;
                P2HouseAqua1.Enabled = false;
                P2HouseAqua1.Checked = false;
                P2ShopAqua1.Enabled = false;
                P2ShopAqua1.Checked = false;
                PlayerProperyList2.Remove("Leicester Sq");
            }
        }

        // Aqua 1 house
        private void P2HouseAqua1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseAqua1.Checked == true)
            {
                P2ShopAqua1.Enabled = true;
                PlayerHouseList2.Add("Aqua 1");
                P2PropertyAqua2.Checked = true;
            }
            else
            {
                P2ShopAqua1.Enabled = false;
                P2ShopAqua1.Checked = false;
                PlayerHouseList2.Remove("Aqua 1");
            }
        }

        // Aqua 1 shop
        private void P2ShopAqua1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopAqua1.Checked == true)
            {
                PlayerShopList2.Add("Aqua 1");
            }
            else
            {
                PlayerShopList2.Remove("Aqua 1");
            }
        }

        // Aqua 2 property
        private void P2PropertyAqua2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyAqua2.Checked == true)
            {
                P2HouseAqua2.Enabled = true;
                P1PropertyAqua2.Checked = false;
                PlayerProperyList2.Add("Piccadilly");
            }
            else
            {
                P2HouseAqua1.Checked = false;
                P2HouseAqua2.Enabled = false;
                P2HouseAqua2.Checked = false;
                P2ShopAqua2.Enabled = false;
                P2ShopAqua2.Checked = false;
                PlayerProperyList2.Remove("Piccadilly");
            }
        }

        // Aqua 2 house
        private void P2HouseAqua2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseAqua2.Checked == true)
            {
                P2ShopAqua2.Enabled = true;
                PlayerHouseList2.Add("Aqua 2");
                P2PropertyAqua1.Checked = true;
            }
            else
            {
                P2ShopAqua2.Enabled = false;
                P2ShopAqua2.Checked = false;
                PlayerHouseList2.Remove("Aqua 2");
            }
        }

        // Aqua 2 shop
        private void P2ShopAqua2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopAqua2.Checked == true)
            {
                PlayerShopList2.Add("Aqua 2");
            }
            else
            {
                PlayerShopList2.Remove("Aqua 2");
            }
        }

        // Yellow 1 property
        private void P2PropertyYellow1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyYellow1.Checked == true)
            {
                P2HouseYellow1.Enabled = true;
                P1PropertyYellow1.Checked = false;
                PlayerProperyList2.Add("Regent St");
            }
            else
            {
                P2HouseYellow2.Checked = false;
                P2HouseYellow1.Enabled = false;
                P2HouseYellow1.Checked = false;
                P2ShopYellow1.Enabled = false;
                P2ShopYellow1.Checked = false;
                PlayerProperyList2.Remove("Regent St");
            }
        }

        // Yellow 1 house
        private void P2HouseYellow1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseYellow1.Checked == true)
            {
                P2ShopYellow1.Enabled = true;
                PlayerHouseList2.Add("Yellow 1");
                P2PropertyYellow2.Checked = true;
            }
            else
            {
                P2ShopYellow1.Enabled = false;
                P2ShopYellow1.Checked = false;
                PlayerHouseList2.Remove("Yellow 1");
            }
        }

        // Yellow 1 shop
        private void P2ShopYellow1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopYellow1.Checked == true)
            {
                PlayerShopList2.Add("Yellow 1");
            }
            else
            {
                PlayerShopList2.Remove("Yellow 1");
            }
        }

        // Yellow 2 property
        private void P2PropertyYellow2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyYellow2.Checked == true)
            {
                P2HouseYellow2.Enabled = true;
                P1PropertyYellow2.Checked = false;
                PlayerProperyList2.Add("Oxford St");
            }
            else
            {
                P2HouseYellow1.Checked = false;
                P2HouseYellow2.Enabled = false;
                P2HouseYellow2.Checked = false;
                P2ShopYellow2.Enabled = false;
                P2ShopYellow2.Checked = false;
                PlayerProperyList2.Remove("Oxford St");
            }
        }

        // Yellow 2 house
        private void P2HouseYellow2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseYellow2.Checked == true)
            {
                P2ShopYellow2.Enabled = true;
                PlayerHouseList2.Add("Yellow 2");
                P2PropertyYellow1.Checked = true;
            }
            else
            {
                P2ShopYellow2.Enabled = false;
                P2ShopYellow2.Checked = false;
                PlayerHouseList2.Remove("Yellow 2");
            }
        }

        // Yellow 2 shop
        private void P2ShopYellow2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopYellow2.Checked == true)
            {
                PlayerShopList2.Add("Yellow 2");
            }
            else
            {
                PlayerShopList2.Remove("Yellow 2");
            }
        }

        // Green 1 property
        private void P2PropertyGreen1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyGreen1.Checked == true)
            {
                P2HouseGreen1.Enabled = true;
                P1PropertyGreen1.Checked = false;
                PlayerProperyList2.Add("Mayfair");
            }
            else
            {
                P2HouseGreen2.Checked = false;
                P2HouseGreen1.Enabled = false;
                P2HouseGreen1.Checked = false;
                P2ShopGreen1.Enabled = false;
                P2ShopGreen1.Checked = false;
                PlayerProperyList2.Remove("Mayfair");
            }
        }

        // Green 1 house
        private void P2HouseGreen1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseGreen1.Checked == true)
            {
                P2ShopGreen1.Enabled = true;
                PlayerHouseList2.Add("Green 1");
                P2PropertyGreen2.Checked = true;
            }
            else
            {
                P2ShopGreen1.Enabled = false;
                P2ShopGreen1.Checked = false;
                PlayerHouseList2.Remove("Green 1");
            }
        }

        // Green 1 shop
        private void P2ShopGreen1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopGreen1.Checked == true)
            {
                PlayerShopList2.Add("Green 1");
            }
            else
            {
                PlayerShopList2.Remove("Green 1");
            }
        }

        // Green 2 property
        private void P2PropertyGreen2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyGreen2.Checked == true)
            {
                P2HouseGreen2.Enabled = true;
                P1PropertyGreen2.Checked = false;
                PlayerProperyList2.Add("Park Lane");
            }
            else
            {
                P2HouseGreen1.Checked = false;
                P2HouseGreen2.Enabled = false;
                P2HouseGreen2.Checked = false;
                P2ShopGreen2.Enabled = false;
                P2ShopGreen2.Checked = false;
                PlayerProperyList2.Remove("Park Lane");
            }
        }

        // Green 2 house
        private void P2HouseGreen2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseGreen2.Checked == true)
            {
                P2ShopGreen2.Enabled = true;
                PlayerHouseList2.Add("Green 2");
                P2PropertyGreen1.Checked = true;
            }
            else
            {
                P2ShopGreen2.Enabled = false;
                P2ShopGreen2.Checked = false;
                PlayerHouseList2.Remove("Green 2");
            }
        }

        // Green 2 shop
        private void P2ShopGreen2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopGreen2.Checked == true)
            {
                PlayerShopList2.Add("Green 2");
            }
            else
            {
                PlayerShopList2.Remove("Green 2");
            }
        }

        // Blue 1 property
        private void P2PropertyBlue1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyBlue1.Checked == true)
            {
                P2HouseBlue1.Enabled = true;
                P1PropertyBlue1.Checked = false;
                PlayerProperyList2.Add("Old Kent Rd");
            }
            else
            {
                P2HouseBlue2.Checked = false;
                P2HouseBlue1.Enabled = false;
                P2HouseBlue1.Checked = false;
                P2ShopBlue1.Enabled = false;
                P2ShopBlue1.Checked = false;
                PlayerProperyList2.Remove("Old Kent Rd");
            }
        }

        // Blue 1 house
        private void P2HouseBlue1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseBlue1.Checked == true)
            {
                P2ShopBlue1.Enabled = true;
                PlayerHouseList2.Add("Blue 1");
                P2PropertyBlue2.Checked = true;
            }
            else
            {
                P2ShopBlue1.Enabled = false;
                P2ShopBlue1.Checked = false;
                PlayerHouseList2.Remove("Blue 1");
            }
        }

        // Blue 1 shop
        private void P2ShopBlue1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopBlue1.Checked == true)
            {
                PlayerShopList2.Add("Blue 1");
            }
            else
            {
                PlayerShopList2.Remove("Blue 1");
            }
        }

        // Blue 2 property
        private void P2PropertyBlue2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyBlue2.Checked == true)
            {
                P2HouseBlue2.Enabled = true;
                P1PropertyBlue2.Checked = false;
                PlayerProperyList2.Add("Whitechapel");
            }
            else
            {
                P2HouseBlue1.Checked = false;
                P2HouseBlue2.Enabled = false;
                P2HouseBlue2.Checked = false;
                P2ShopBlue2.Enabled = false;
                P2ShopBlue2.Checked = false;
                PlayerProperyList2.Remove("Whitechapel");
            }
        }

        // Blue 2 house
        private void P2HouseBlue2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseBlue2.Checked == true)
            {
                P2ShopBlue2.Enabled = true;
                PlayerHouseList2.Add("Blue 2");
                P2PropertyBlue1.Checked = true;
            }
            else
            {
                P2ShopBlue2.Enabled = false;
                P2ShopBlue2.Checked = false;
                PlayerHouseList2.Remove("Blue 2");
            }
        }

        // Blue 2 shop
        private void P2ShopBlue2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopBlue2.Checked == true)
            {
                PlayerShopList2.Add("Blue 2");
            }
            else
            {
                PlayerShopList2.Remove("Blue 2");
            }
        }

        // Red 1 property
        private void P2PropertyRed1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyRed1.Checked == true)
            {
                P2HouseRed1.Enabled = true;
                P1PropertyRed1.Checked = false;
                PlayerProperyList2.Add("Islington");
            }
            else
            {
                P2HouseRed2.Checked = false;
                P2HouseRed1.Enabled = false;
                P2HouseRed1.Checked = false;
                P2ShopRed1.Enabled = false;
                P2ShopRed1.Checked = false;
                PlayerProperyList2.Remove("Islington");
            }
        }

        // Red 1 house
        private void P2HouseRed1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseRed1.Checked == true)
            {
                P2ShopRed1.Enabled = true;
                PlayerHouseList2.Add("Red 1");
                P2PropertyRed2.Checked = true;
            }
            else
            {
                P2ShopRed1.Enabled = false;
                P2ShopRed1.Checked = false;
                PlayerHouseList2.Remove("Red 1");
            }
        }

        // Red 1 shop
        private void P2ShopRed1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopRed1.Checked == true)
            {
                PlayerShopList2.Add("Red 1");
            }
            else
            {
                PlayerShopList2.Remove("Red 1");
            }
        }

        // Red 2 property
        private void P2PropertyRed2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyRed2.Checked == true)
            {
                P2HouseRed2.Enabled = true;
                P1PropertyRed2.Checked = false;
                PlayerProperyList2.Add("Euston");
            }
            else
            {
                P2HouseRed1.Checked = false;
                P2HouseRed2.Enabled = false;
                P2HouseRed2.Checked = false;
                P2ShopRed2.Enabled = false;
                P2ShopRed2.Checked = false;
                PlayerProperyList2.Remove("Euston");
            }
        }

        // Red 2 house
        private void P2HouseRed2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseRed2.Checked == true)
            {
                P2ShopRed2.Enabled = true;
                PlayerHouseList2.Add("Red 2");
                P2PropertyRed1.Checked = true;
            }
            else
            {
                P2ShopRed2.Enabled = false;
                P2ShopRed2.Checked = false;
                PlayerHouseList2.Remove("Red 2");
            }
        }

        // Red 2 shop
        private void P2ShopRed2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopRed2.Checked == true)
            {
                PlayerShopList2.Add("Red 2");
            }
            else
            {
                PlayerShopList2.Remove("Red 2");
            }
        }

        // Pink 1 property
        private void P2PropertyPink1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyPink1.Checked == true)
            {
                P2HousePink1.Enabled = true;
                P1PropertyPink1.Checked = false;
                PlayerProperyList2.Add("Pall Mall");
            }
            else
            {
                P2HousePink2.Checked = false;
                P2HousePink1.Enabled = false;
                P2HousePink1.Checked = false;
                P2ShopPink1.Enabled = false;
                P2ShopPink1.Checked = false;
                PlayerProperyList2.Remove("Pall Mall");
            }
        }

        // Pink 1 house
        private void P2HousePink1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HousePink1.Checked == true)
            {
                P2ShopPink1.Enabled = true;
                PlayerHouseList2.Add("Pink 1");
                P2PropertyPink2.Checked = true;
            }
            else
            {
                P2ShopPink1.Enabled = false;
                P2ShopPink1.Checked = false;
                PlayerHouseList2.Remove("Pink 1"); ;
            }
        }

        // Pink 1 shop
        private void P2ShopPink1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopPink1.Checked == true)
            {
                PlayerShopList2.Add("Pink 1");
            }
            else
            {
                PlayerShopList2.Remove("Pink 1");
            }
        }

        // Pink 2 property
        private void P2PropertyPink2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyPink2.Checked == true)
            {
                P2HousePink2.Enabled = true;
                P1PropertyPink2.Checked = false;
                PlayerProperyList2.Add("Whitehall");
            }
            else
            {
                P2HousePink1.Checked = false;
                P2HousePink2.Enabled = false;
                P2HousePink2.Checked = false;
                P2ShopPink2.Enabled = false;
                P2ShopPink2.Checked = false;
                PlayerProperyList2.Remove("Whitehall");
            }
        }

        // Pink 2 house
        private void P2HousePink2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HousePink2.Checked == true)
            {
                P2ShopPink2.Enabled = true;
                PlayerHouseList2.Add("Pink 2");
                P2PropertyPink1.Checked = true;
            }
            else
            {
                P2ShopPink2.Enabled = false;
                P2ShopPink2.Checked = false;
                PlayerHouseList2.Remove("Pink 2");
            }
        }

        // Pink 2 shop
        private void P2ShopPink2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopPink2.Checked == true)
            {
                PlayerShopList2.Add("Pink 2");
            }
            else
            {
                PlayerShopList2.Remove("Pink 2");
            }
        }

        // Brown 1 property
        private void P2PropertyBrown1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyBrown1.Checked == true)
            {
                P2HouseBrown1.Enabled = true;
                P1PropertyBrown1.Checked = false;
                PlayerProperyList2.Add("Bow St");
            }
            else
            {
                P2HouseBrown2.Checked = false;
                P2HouseBrown1.Enabled = false;
                P2HouseBrown1.Checked = false;
                P2ShopBrown1.Enabled = false;
                P2ShopBrown1.Checked = false;
                PlayerProperyList2.Remove("Bow St");
            }
        }

        // Brown 1 house
        private void P2HouseBrown1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseBrown1.Checked == true)
            {
                P2ShopBrown1.Enabled = true;
                PlayerHouseList2.Add("Brown 1");
                P2PropertyBrown2.Checked = true;
            }
            else
            {
                P2ShopBrown1.Enabled = false;
                P2ShopBrown1.Checked = false;
                PlayerHouseList2.Remove("Brown 1");
            }
        }

        // Brown 1 shop
        private void P2ShopBrown1_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopBrown1.Checked == true)
            {
                PlayerShopList2.Add("Brown 1");
            }
            else
            {
                PlayerShopList2.Remove("Brown 1");
            }
        }

        // Brown 2 property
        private void P2PropertyBrown2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2PropertyBrown2.Checked == true)
            {
                P2HouseBrown2.Enabled = true;
                P1PropertyBrown2.Checked = false;
                PlayerProperyList2.Add("Vine St");
            }
            else
            {
                P2HouseBrown1.Checked = false;
                P2HouseBrown2.Enabled = false;
                P2HouseBrown2.Checked = false;
                P2ShopBrown2.Enabled = false;
                P2ShopBrown2.Checked = false;
                PlayerProperyList2.Remove("Vine St");
            }
        }

        // Brown 2 house
        private void P2HouseBrown2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2HouseBrown2.Checked == true)
            {
                P2ShopBrown2.Enabled = true;
                PlayerHouseList2.Add("Brown 2");
                P2PropertyBrown1.Checked = true;
            }
            else
            {
                P2ShopBrown2.Enabled = false;
                P2ShopBrown2.Checked = false;
                PlayerHouseList2.Remove("Brown 2");
            }
        }

        // Brown 2 shop
        private void P2ShopBrown2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2ShopBrown2.Checked == true)
            {
                PlayerShopList2.Add("Brown 2");
            }
            else
            {
                PlayerShopList2.Remove("Brown 2");
            }
        }

        #endregion


        #region Apply Debug Settings method

        public void SetDebugSettings()
        {
            // The settings are saved to a text file named Debug.txt
            // A text file is used, rather than just passing the variables over to the program class
            // This was done because all of the methods are already in place to load a save file
            // The load game method is called passing in the debug.txt file rather than the save.txt which would normally be loaded

            // This sets the path of the debug file
            string gameDataPath = appPath.Remove(appPath.Length - 9);
            gameDataPath = gameDataPath + "Data\\" + _fileName;

            // This deletes any previous file
            if (File.Exists(gameDataPath))
            {
                File.Delete(gameDataPath);
            }

            // Opens the text file for writting the values
            System.IO.StreamWriter sw = System.IO.File.AppendText(gameDataPath);

            // This Writes the values to the text file on seperate lines
            // This sets the current player in the Program class
            if (comboBoxCurrentPlayer.SelectedItem == comboBoxCurrentPlayer.Items[1])
            {
                sw.WriteLine("Car");
            }
            else
            {
                sw.WriteLine("Dog");
            }

            // This sets the last special card
            sw.WriteLine(comboBoxPreviousCard.SelectedIndex);

            // Writes a blank line to the text file, this is required for the load game method
            sw.WriteLine();

            // This writes the player 1 current position on the board/screen
            // If the player is in jail the position must be square 12
            if (comboBoxP1Jail.SelectedItem == comboBoxP1Jail.Items[0])
            {
                sw.WriteLine("12");
            }
            else
            {
                sw.WriteLine(comboBoxP1CurrentSquare.SelectedIndex);
            }

            // This writes the player 1 current money
            sw.WriteLine(txtP1CurrentMoney.Text);

            // This writes the player 1 jail time if the player is in jail
            bool player1Jail;
            if (comboBoxP1Jail.SelectedIndex == 0)
            {
                sw.WriteLine(comboBoxP1JailTime.SelectedIndex + 1);
                player1Jail = true;
            }
            else
            {
                sw.WriteLine("0");
                player1Jail = false;
            }

            // This writes the player in jail boolean to the file
            sw.WriteLine(player1Jail);

            int player1LoanAmount = 0;
            // Sets wheather the player has a loan
            bool player1Loan;
            if (comboBoxP1Loan.SelectedIndex == 0)
            {
                if (comboBoxP1LoanAmount.SelectedIndex == 0)
                {
                    player1LoanAmount = 100;
                }
                else if (comboBoxP1LoanAmount.SelectedIndex == 1)
                {
                    player1LoanAmount = 200;
                }
                else if (comboBoxP1LoanAmount.SelectedIndex == 2)
                {
                    player1LoanAmount = 400;
                }

                player1Loan = true;
            }
            else
            {
                player1Loan = false;
            }

            // This writes the player 1 loan boolean and loan time to the file
            sw.WriteLine(player1Loan);
            sw.WriteLine(player1LoanAmount);

            if (player1Loan == true)
            {
                sw.WriteLine(comboBoxP1LoanTime.SelectedIndex +1);
            }
            else
            {
                sw.WriteLine("0");
            }
            
            // This writes the player 1 X and Y values based on the players current location
            int Player1x;
            int Player1y;

            switch (comboBoxP1CurrentSquare.SelectedIndex)
            {
                case 0:
                    Player1x = 80;
                    Player1y = 80;
                    break;
                case 1:
                    Player1x = 200;
                    Player1y = 80;
                    break;
                case 2:
                    Player1x = 300;
                    Player1y = 80;
                    break;
                case 3:
                    Player1x = 415;
                    Player1y = 80;
                    break;
                case 4:
                    Player1x = 535;
                    Player1y = 80;
                    break;
                case 5:
                    Player1x = 635;
                    Player1y = 80;
                    break;
                case 6:
                    Player1x = 760;
                    Player1y = 80;
                    break;
                case 7:
                    Player1x = 760;
                    Player1y = 190;
                    break;
                case 8:
                    Player1x = 760;
                    Player1y = 290;
                    break;
                case 9:
                    Player1x = 760;
                    Player1y = 420;
                    break;
                case 10:
                    Player1x = 760;
                    Player1y = 530;
                    break;
                case 11:
                    Player1x = 760;
                    Player1y = 630;
                    break;
                case 12:
                    Player1x = 760;
                    Player1y = 770;
                    break;
                case 13:
                    Player1x = 590;
                    Player1y = 770;
                    break;
                case 14:
                    Player1x = 490;
                    Player1y = 770;
                    break;
                case 15:
                    Player1x = 365;
                    Player1y = 770;
                    break;
                case 16:
                    Player1x = 250;
                    Player1y = 770;
                    break;
                case 17:
                    Player1x = 150;
                    Player1y = 770;
                    break;
                case 18:
                    Player1x = 60;
                    Player1y = 770;
                    break;
                case 19:
                    Player1x = 60;
                    Player1y = 590;
                    break;
                case 20:
                    Player1x = 60;
                    Player1y = 490;
                    break;
                case 21:
                    Player1x = 60;
                    Player1y = 355;
                    break;
                case 22:
                    Player1x = 60;
                    Player1y = 255;
                    break;
                case 23:
                    Player1x = 60;
                    Player1y = 155;
                    break;
                default:
                    Player1x = 80;
                    Player1y = 80;
                    break;
            }

            sw.WriteLine(Player1x);
            sw.WriteLine(Player1y);

            // This writes the number of properties that player 1 currently owns
            sw.WriteLine(PlayerProperyList1.Count);

            // This loops the number of properties and writes each property to the text file
            for (int i = 0; i < PlayerProperyList1.Count; i++)
            {
                sw.WriteLine(PlayerProperyList1[i]);
            }

            // This writes the number of houses that player 1 currently owns
            sw.WriteLine(PlayerHouseList1.Count);

            // This loops the number of houses and writes each property to the text file
            for (int i = 0; i < PlayerHouseList1.Count; i++)
            {
                sw.WriteLine(PlayerHouseList1[i]);
            }

            // This writes the number of shops that player 1 currently owns
            sw.WriteLine(PlayerShopList1.Count);

            // This loops the number of shops and writes each property to the text file
            for (int i = 0; i < PlayerShopList1.Count; i++)
            {
                sw.WriteLine(PlayerShopList1[i]);
            }

            // Writes a blank line to the text file, this is required for the load game method
            sw.WriteLine();

            // This writes the player 2 values

            // This writes the player 2 current position on the board/screen
            // If the player is in jail the position must be square 12
            if (comboBoxP2Jail.SelectedItem == comboBoxP2Jail.Items[0])
            {
                sw.WriteLine("12");
            }
            else
            {
                sw.WriteLine(comboBoxP2CurrentSquare.SelectedIndex);
            }

            // This writes the player 2 current money
            sw.WriteLine(txtP2CurrentMoney.Text);

            // This writes the player 1 jail time if the player is in jail
            bool player2Jail;
            if (comboBoxP2Jail.SelectedIndex == 0)
            {
                sw.WriteLine(comboBoxP2JailTime.SelectedIndex + 1);
                player2Jail = true;
            }
            else
            {
                sw.WriteLine("0");
                player2Jail = false;
            }

            // This writes the player 2 in jail boolean to the file
            sw.WriteLine(player2Jail);

            int player2LoanAmount = 0;
            // Sets wheather the player 2 has a loan
            bool player2Loan;
            if (comboBoxP2Loan.SelectedIndex == 0)
            {
                if (comboBoxP2LoanAmount.SelectedIndex == 0)
                {
                    player2LoanAmount = 100;
                }
                else if (comboBoxP2Loan.SelectedIndex == 1)
                {
                    player2LoanAmount = 200;
                }
                else if (comboBoxP2Loan.SelectedIndex == 2)
                {
                    player2LoanAmount = 400;
                }

                player2Loan = true;
            }
            else
            {
                player2Loan = false;
            }

            // This writes the player 2 loan details to the text file
            sw.WriteLine(player2Loan);
            sw.WriteLine(player2LoanAmount);

            if (player2Loan == true)
            {
                sw.WriteLine(comboBoxP2LoanTime.SelectedIndex +1);
            }
            else
            {
                sw.WriteLine("0");
            }

            int Player2x;
            int Player2y;

            // This writes the player 2 X and Y values based on the players current location
            switch (comboBoxP2CurrentSquare.SelectedIndex)
            {
                case 0:
                    Player2x = 30;
                    Player2y = 80;
                    break;
                case 1:
                    Player2x = 155;
                    Player2y = 80;
                    break;
                case 2:
                    Player2x = 255;
                    Player2y = 80;
                    break;
                case 3:
                    Player2x = 370;
                    Player2y = 80;
                    break;
                case 4:
                    Player2x = 490;
                    Player2y = 80;
                    break;
                case 5:
                    Player2x = 590;
                    Player2y = 80;
                    break;
                case 6:
                    Player2x = 715;
                    Player2y = 80;
                    break;
                case 7:
                    Player2x = 715;
                    Player2y = 190;
                    break;
                case 8:
                    Player2x = 715;
                    Player2y = 290;
                    break;
                case 9:
                    Player2x = 715;
                    Player2y = 420;
                    break;
                case 10:
                    Player2x = 715;
                    Player2y = 530;
                    break;
                case 11:
                    Player2x = 715;
                    Player2y = 630;
                    break;
                case 12:
                    Player2x = 715;
                    Player2y = 770;
                    break;
                case 13:
                    Player2x = 635;
                    Player2y = 770;
                    break;
                case 14:
                    Player2x = 535;
                    Player2y = 770;
                    break;
                case 15:
                    Player2x = 410;
                    Player2y = 770;
                    break;
                case 16:
                    Player2x = 295;
                    Player2y = 770;
                    break;
                case 17:
                    Player2x = 195;
                    Player2y = 770;
                    break;
                case 18:
                    Player2x = 15;
                    Player2y = 770;
                    break;
                case 19:
                    Player2x = 15;
                    Player2y = 590;
                    break;
                case 20:
                    Player2x = 15;
                    Player2y = 490;
                    break;
                case 21:
                    Player2x = 15;
                    Player2y = 355;
                    break;
                case 22:
                    Player2x = 15;
                    Player2y = 255;
                    break;
                case 23:
                    Player2x = 15;
                    Player2y = 155;
                    break;
                default:
                    Player2x = 30;
                    Player2y = 80;
                    break;
            }

            sw.WriteLine(Player2x);
            sw.WriteLine(Player2y);

            // This writes the number of properties that player 2 currently owns
            sw.WriteLine(PlayerProperyList2.Count);

            // This loops the number of properties and writes each property to the text file
            for (int i = 0; i < PlayerProperyList2.Count; i++)
            {
                sw.WriteLine(PlayerProperyList2[i]);
            }

            // This writes the number of houses that player 2 currently owns
            sw.WriteLine(PlayerHouseList2.Count);

            // This loops the number of houses and writes each property to the text file
            for (int i = 0; i < PlayerHouseList2.Count; i++)
            {
                sw.WriteLine(PlayerHouseList2[i]);
            }

            // This writes the number of shops that player 2 currently owns
            sw.WriteLine(PlayerShopList2.Count);

            // This loops the number of shops and writes each property to the text file
            for (int i = 0; i < PlayerShopList2.Count; i++)
            {
                sw.WriteLine(PlayerShopList2[i]);
            }

            // Closes the file after writting
            sw.Close();
        } 
        
        
        #endregion


        #region Button Click methods

        // Enter button
        private void btnEnter_Click(object sender, EventArgs e)
        {
            // This is used to check if the password is correct
            if (txtDebugPassword.Text == "debug")
            {
                // If the correct password is entered, the debugging menu is displayed
                panelMainDebug.Visible = true;

                // This sets default values
                comboBoxCurrentPlayer.SelectedItem = comboBoxCurrentPlayer.Items[0];
                comboBoxPreviousCard.SelectedItem = comboBoxPreviousCard.Items[0];
                comboBoxP1CurrentSquare.SelectedItem = comboBoxP1CurrentSquare.Items[0];
                comboBoxP2CurrentSquare.SelectedItem = comboBoxP2CurrentSquare.Items[0];
                txtP1CurrentMoney.Text = "2000";
                txtP2CurrentMoney.Text = "2000";
                comboBoxP1Jail.SelectedItem = comboBoxP1Jail.Items[1];
                comboBoxP2Jail.SelectedItem = comboBoxP2Jail.Items[1];
                comboBoxP1Loan.SelectedItem = comboBoxP1Loan.Items[1];
                comboBoxP2Loan.SelectedItem = comboBoxP2Loan.Items[1];
            }
            else
            {
                // If the password is not correct, a message is displayed and the form closes
                DialogResult DebugMessage = MessageBox.Show("You have enterd an incorrect password!", "Message", MessageBoxButtons.OK);
                this.Close();
            }
        }

        // Set button
        private void btnSet_Click(object sender, EventArgs e)
        {
            // This applies the debug settings
            _debugEnabled = true;
            SetDebugSettings();
            this.Close();
        }

        // Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Closes the form
            _debugEnabled = false;
            this.Close();
        }

        #endregion


        #region ComboBox Click Event methods

        // If player 1 is in jail, the jail time combobox is enabled otherwise it is disabled
        private void comboBoxP1Jail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxP1Jail.SelectedItem == comboBoxP1Jail.Items[0])
            {
                comboBoxP1JailTime.Enabled = true;
                comboBoxP1JailTime.SelectedItem = comboBoxP1JailTime.Items[0];
            }
            else
            {
                comboBoxP1JailTime.Enabled = false;
                comboBoxP1JailTime.Text = "";
            }
        }

        // If player 1 has a loan, the loan time and loan amount comboboxes are enabled otherwise they are disabled
        private void comboBoxP1Loan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxP1Loan.SelectedItem == comboBoxP1Loan.Items[0])
            {
                comboBoxP1LoanTime.Enabled = true;
                comboBoxP1LoanTime.SelectedItem = comboBoxP1LoanTime.Items[0];
                comboBoxP1LoanAmount.Enabled = true;
                comboBoxP1LoanAmount.SelectedItem = comboBoxP1LoanAmount.Items[0];
            }
            else
            {
                comboBoxP1LoanTime.Enabled = false;
                comboBoxP1LoanTime.Text = "";
                comboBoxP1LoanAmount.Enabled = false;
                comboBoxP1LoanAmount.Text = "";
            }
        }

        // If player 2 is in jail, the jail time combobox is enabled otherwise it is disabled
        private void comboBoxP2Jail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxP2Jail.SelectedItem == comboBoxP2Jail.Items[0])
            {
                comboBoxP2JailTime.Enabled = true;
                comboBoxP2JailTime.SelectedItem = comboBoxP2JailTime.Items[0];
            }
            else
            {
                comboBoxP2JailTime.Enabled = false;
                comboBoxP2JailTime.Text = "";
            }
        }

        // If player 2 has a loan, the loan time and loan amount comboboxes are enabled otherwise they are disabled
        private void comboBoxP2Loan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxP2Loan.SelectedItem == comboBoxP2Loan.Items[0])
            {
                comboBoxP2LoanTime.Enabled = true;
                comboBoxP2LoanTime.SelectedItem = comboBoxP2LoanTime.Items[0];
                comboBoxP2LoanAmount.Enabled = true;
                comboBoxP2LoanAmount.SelectedItem = comboBoxP2LoanAmount.Items[0];
            }
            else
            {
                comboBoxP2LoanTime.Enabled = false;
                comboBoxP2LoanTime.Text = "";
                comboBoxP2LoanAmount.Enabled = false;
                comboBoxP2LoanAmount.Text = "";
            }
        }

        #endregion

    }
}
