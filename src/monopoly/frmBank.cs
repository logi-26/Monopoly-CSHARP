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
    public partial class frmBank : Form
    {
     /******************************************************************************************************
         Created by Louis Gilmartin:          Last updated 26/11/2013
      ******************************************************************************************************/

        public frmBank()
        {
            InitializeComponent();
        }

        private int _loanAmount;
        private bool _loanTaken;

        #region Public get/set methods

        // Set-Get for the loan amount
        public int loanAmount
        {
            get
            {
                return this._loanAmount;
            }
            set
            {
                this._loanAmount = value;
            }
        }

        // Set-Get for the loan taken
        public bool loanTaken
        {
            get
            {
                return this._loanTaken;
            }
            set
            {
                this._loanTaken = value;
            }
        }

        #endregion


        #region Button methods

        // Loan button
        private void btnLoan_Click(object sender, EventArgs e)
        {
            // This checks to see which loan has been chosen and sets the variable
            if (radioButtonLoan1.Checked == true)
            {
                _loanAmount = 100;
            }
            else if (radioButtonLoan2.Checked == true)
            {
                _loanAmount = 200;
            }
            else if (radioButtonLoan3.Checked == true)
            {
                _loanAmount = 400;
            }

            if (radioButtonLoan1.Checked == false && radioButtonLoan2.Checked == false && radioButtonLoan3.Checked == false)
            {
                _loanTaken = false;
            }
            else
            {
                // If a loan is taken the boolean is set to true
                _loanTaken = true;
            }

            this.Close();
        }

        // Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _loanTaken = false;
            this.Close();
        }

        #endregion
    }
}
