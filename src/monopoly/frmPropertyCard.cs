using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace monopoly
{
    /******************************************************************************************************
         Created by Louis Gilmartin:          Last updated 19/10/2013
    ******************************************************************************************************/

    partial class frmPropertyCard : Form
    {
        // Boolean to determine if the player has chosen to buy the current property
        private bool PropertyPurchased = false;

        // Boolean to determine if the player has chosen to build a house
        private bool HousePurchased = false;

        // Boolean to determine if the player has chosen to build a shop
        private bool ShopPurchased = false;

        private string buildType;

        public frmPropertyCard()
        {
            InitializeComponent();
        }

        // Set form location
        public void SetFormLocation()
        {
            this.Location = new Point(this.Location.X - 800, this.Location.Y + 40);
        }


        #region Get/Set Methods for Purchases

        // Boolean to determine if a property was purchased
        public bool WasPurchased
        {
            get
            {
                return this.PropertyPurchased;
            }
            set
            {
                this.PropertyPurchased = value;
            }
        }

        // Boolean to determine if a house was purchased
        public bool HouseWasBuilt
        {
            get
            {
                return this.HousePurchased;
            }
            set
            {
                this.HousePurchased = value;
            }
        }

        // Boolean to determine if a shop was purchased
        public bool ShopWasBuilt
        {
            get
            {
                return this.ShopPurchased;
            }
            set
            {
                this.ShopPurchased = value;
            }
        }

        #endregion


        #region Property Form methods
        // These methods set the card properties according to the current location of the player

        // Set the panel type
        // This is to allow a single form to be used for multiple purposes
        public void setPanelType(string message)
        {
            if (message == "Property")
            {
                lblSpecialCard.Visible = false;
                lblCardDetails1.Visible = false;
                btnOK.Visible = false;
                panelBuildDisplay.Visible = false;
                panelPropertyDisplay.Visible = true;
            }
            else if (message == "Card")
            {    
                panelPropertyDisplay.Visible = false;
                lblSpecialCard.Visible = true;
                lblCardDetails1.Visible = true;
                btnOK.Visible = true;
            }
            else if (message == "Build Mode")
            {
                lblSpecialCard.Visible = false;
                lblCardDetails1.Visible = false;
                btnOK.Visible = false;
                panelBuildDisplay.Visible = false;
                panelPropertyDisplay.Visible = true;
                panelBuildDisplay.Visible = true;
            }
        }

        // Set property price
        public void setPropertyPrice(string message)
        {
            lblPropertyPrice.Text = (message);
        }

        // Set property rent
        public void setPropertyRent(string message)
        {
            lblPropertyRent.Text = (message);
        }

        // Set property price with house
        public void setPropertyHouse(string message)
        {
            lblPropertyHouse.Text = (message);
        }

        // Set property price with shop
        public void setPropertyShop(string message)
        {
            lblPropertyShop.Text = (message);
        }

        // Set property name
        public void setPropertyName(string message)
        {
            lblPropertyName.Text = (message);
        }

        // This switch determines what colour the property card should be
        public void setPropertyColour(string message)
        {
            switch (message)
            {
                case "Black":
                    lblPropertyName.BackColor = Color.FromArgb(38, 38, 38);
                    rectanglePropertyColour.FillColor = Color.FromArgb(38, 38, 38);
                    break;
                case "Aqua":
                    lblPropertyName.BackColor = Color.Aqua;
                    rectanglePropertyColour.FillColor = Color.Aqua;
                    break;
                case "Yellow":
                    lblPropertyName.BackColor = Color.Yellow;
                    rectanglePropertyColour.FillColor = Color.Yellow;
                    break;
                case "Green":
                    lblPropertyName.BackColor = Color.Green;
                    rectanglePropertyColour.FillColor = Color.Green;
                    break;
                case "Blue":
                    lblPropertyName.BackColor = Color.FromArgb(32, 63, 153);
                    rectanglePropertyColour.FillColor = Color.FromArgb(32, 63, 153);
                    break;
                case "Red":
                    lblPropertyName.BackColor = Color.Red;
                    rectanglePropertyColour.FillColor = Color.Red;
                    break;
                case "Pink":
                    lblPropertyName.BackColor = Color.FromArgb(243, 69, 231);
                    rectanglePropertyColour.FillColor = Color.FromArgb(243, 69, 231);
                    break;
                case "Brown":
                    lblPropertyName.BackColor = Color.FromArgb(128, 64, 0);
                    rectanglePropertyColour.FillColor = Color.FromArgb(128, 64, 0);
                    break;
                default:
                    break;
            }

            // This just prevents the text from being black on black or white on white
            if (message == "Black")
            {
                lblPropertyName.ForeColor = Color.White;
            }
            else
            {
                lblPropertyName.ForeColor = Color.Black;
            }
        }

        #endregion


        #region Build Form methods

        // Sets the build type, either house or shop
        public void setBuildType(string mode)
        {
            buildType = mode;
        }

        // This switch determines what colour the property card should be in build mode
        public void setBuildColour(string colour)
        {
            switch (colour)
            {
                case "Black":
                    lblPropertyNameBuild.BackColor = Color.FromArgb(38, 38, 38);
                    rectangleBuildColour.FillColor = Color.FromArgb(38, 38, 38);
                    break;
                case "Aqua":
                    lblPropertyNameBuild.BackColor = Color.Aqua;
                    rectangleBuildColour.FillColor = Color.Aqua;
                    break;
                case "Yellow":
                    lblPropertyNameBuild.BackColor = Color.Yellow;
                    rectangleBuildColour.FillColor = Color.Yellow;
                    break;
                case "Green":
                    lblPropertyNameBuild.BackColor = Color.Green;
                    rectangleBuildColour.FillColor = Color.Green;
                    break;
                case "Blue":
                    lblPropertyNameBuild.BackColor = Color.FromArgb(32, 63, 153);
                    rectangleBuildColour.FillColor = Color.FromArgb(32, 63, 153);
                    break;
                case "Red":
                    lblPropertyNameBuild.BackColor = Color.Red;
                    rectangleBuildColour.FillColor = Color.Red;
                    break;
                case "Pink":
                    lblPropertyNameBuild.BackColor = Color.FromArgb(243, 69, 231);
                    rectangleBuildColour.FillColor = Color.FromArgb(243, 69, 231);
                    break;
                case "Brown":
                    lblPropertyNameBuild.BackColor = Color.FromArgb(128, 64, 0);
                    rectangleBuildColour.FillColor = Color.FromArgb(128, 64, 0);
                    break;
                default:
                    break;
            }

            // This just prevents the text from being black on black or white on white
            if (colour == "Black")
            {
                lblPropertyNameBuild.ForeColor = Color.White;
            }
            else
            {
                lblPropertyNameBuild.ForeColor = Color.Black;
            }
        }

        // Sets the current rent
        public void setCurrentRent(string message)
        {
            lblCurrentRent.Text = (message);
        }

        // Sets the rent with a house
        public void setRentWithHouse(string message)
        {
            lblNewRent.Text = (message);
        }

        // Set house price
        public void setBuildPrice(string message)
        {
            lblHousePrice.Text = (message);
        }

        // Set property name in build mode
        public void setBuildName(string message)
        {
            lblPropertyNameBuild.Text = (message);
        }

        // Sets the labels text for purchasing a house
        public void resetLabelsForHouseMode()
        {
            pictureBoxShop.SendToBack();

            lblBuildPrice.Text = "Cost of House:";
            lblRentWithHouse.Text = "Rent with House:";
            lblBuild.Text = "Purchase House?";
        }

        // Sets the labels text for purchasing a shop
        public void setShopMode()
        {
            pictureBoxShop.BringToFront();

            lblBuildPrice.Text = "Cost of Shop:";
            lblRentWithHouse.Text = "Rent with Shop:";
            lblBuild.Text = "Purchase Shop?";
        }


        #endregion


        // Set special card text
        public void SetSpecialCardText(string message)
        {
            lblCardDetails1.Text = (message);
        }


        #region GUI Buttons

        // Purchase property button
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            PropertyPurchased = true;
            this.Close();
        }

        // Cancel property purchase button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            PropertyPurchased = false;
            this.Close();
        }

        // OK button
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Purchase house button
        private void btnPurchaseHouse_Click(object sender, EventArgs e)
        {
            if (buildType == "House")
            {
                HousePurchased = true;
            }
            else if (buildType == "Shop")
            {
                ShopPurchased = true;
            }

            resetLabelsForHouseMode();
            this.Close();
        }

        // Do not purchase house button
        private void btnCancelBuild_Click(object sender, EventArgs e)
        {
            if (buildType == "House")
            {
                HousePurchased = false;
            }
            else if (buildType == "Shop")
            {
                ShopPurchased = false;
            }

            resetLabelsForHouseMode();
            this.Close();
        }

        #endregion
    }
}
