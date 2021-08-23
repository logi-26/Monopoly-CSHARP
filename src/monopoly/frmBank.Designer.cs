namespace monopoly
{
    partial class frmBank
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBank));
            this.btnLoan = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButtonLoan1 = new System.Windows.Forms.RadioButton();
            this.radioButtonLoan2 = new System.Windows.Forms.RadioButton();
            this.radioButtonLoan3 = new System.Windows.Forms.RadioButton();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblBankInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoan
            // 
            this.btnLoan.Location = new System.Drawing.Point(278, 280);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(75, 23);
            this.btnLoan.TabIndex = 0;
            this.btnLoan.Text = "Take Loan";
            this.btnLoan.UseVisualStyleBackColor = true;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(385, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 325);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // radioButtonLoan1
            // 
            this.radioButtonLoan1.AutoSize = true;
            this.radioButtonLoan1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLoan1.Location = new System.Drawing.Point(320, 161);
            this.radioButtonLoan1.Name = "radioButtonLoan1";
            this.radioButtonLoan1.Size = new System.Drawing.Size(95, 22);
            this.radioButtonLoan1.TabIndex = 3;
            this.radioButtonLoan1.TabStop = true;
            this.radioButtonLoan1.Text = "Loan £100";
            this.radioButtonLoan1.UseVisualStyleBackColor = true;
            // 
            // radioButtonLoan2
            // 
            this.radioButtonLoan2.AutoSize = true;
            this.radioButtonLoan2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLoan2.Location = new System.Drawing.Point(320, 195);
            this.radioButtonLoan2.Name = "radioButtonLoan2";
            this.radioButtonLoan2.Size = new System.Drawing.Size(95, 22);
            this.radioButtonLoan2.TabIndex = 4;
            this.radioButtonLoan2.TabStop = true;
            this.radioButtonLoan2.Text = "Loan £200";
            this.radioButtonLoan2.UseVisualStyleBackColor = true;
            // 
            // radioButtonLoan3
            // 
            this.radioButtonLoan3.AutoSize = true;
            this.radioButtonLoan3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLoan3.Location = new System.Drawing.Point(320, 229);
            this.radioButtonLoan3.Name = "radioButtonLoan3";
            this.radioButtonLoan3.Size = new System.Drawing.Size(95, 22);
            this.radioButtonLoan3.TabIndex = 5;
            this.radioButtonLoan3.TabStop = true;
            this.radioButtonLoan3.Text = "Loan £400";
            this.radioButtonLoan3.UseVisualStyleBackColor = true;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.Location = new System.Drawing.Point(326, 12);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(90, 37);
            this.lblBank.TabIndex = 6;
            this.lblBank.Text = "Bank";
            // 
            // lblBankInfo
            // 
            this.lblBankInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankInfo.Location = new System.Drawing.Point(264, 68);
            this.lblBankInfo.Name = "lblBankInfo";
            this.lblBankInfo.Size = new System.Drawing.Size(225, 91);
            this.lblBankInfo.TabIndex = 7;
            this.lblBankInfo.Text = "Players can loan money from the bank, but the loan will incur 50% interested and " +
                "must be re-paid after 10 roll\'s of the dice.";
            // 
            // frmBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(504, 326);
            this.Controls.Add(this.lblBankInfo);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.radioButtonLoan3);
            this.Controls.Add(this.radioButtonLoan2);
            this.Controls.Add(this.radioButtonLoan1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLoan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(510, 354);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(510, 354);
            this.Name = "frmBank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bank";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioButtonLoan1;
        private System.Windows.Forms.RadioButton radioButtonLoan2;
        private System.Windows.Forms.RadioButton radioButtonLoan3;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblBankInfo;
    }
}