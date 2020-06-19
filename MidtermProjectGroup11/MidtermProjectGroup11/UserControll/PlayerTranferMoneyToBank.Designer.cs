namespace MidtermProjectGroup11.UserControll
{
    partial class PlayerTranferMoneyToBank
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerTranferMoneyToBank));
            this.pbxPlayer = new System.Windows.Forms.PictureBox();
            this.pbxBank = new System.Windows.Forms.PictureBox();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblTranMoney = new System.Windows.Forms.Label();
            this.tmTran = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBank)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxPlayer
            // 
            this.pbxPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxPlayer.Location = new System.Drawing.Point(21, 59);
            this.pbxPlayer.Name = "pbxPlayer";
            this.pbxPlayer.Size = new System.Drawing.Size(130, 130);
            this.pbxPlayer.TabIndex = 0;
            this.pbxPlayer.TabStop = false;
            // 
            // pbxBank
            // 
            this.pbxBank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxBank.BackgroundImage")));
            this.pbxBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxBank.Location = new System.Drawing.Point(417, 59);
            this.pbxBank.Name = "pbxBank";
            this.pbxBank.Size = new System.Drawing.Size(130, 130);
            this.pbxBank.TabIndex = 1;
            this.pbxBank.TabStop = false;
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.Location = new System.Drawing.Point(45, 192);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(78, 25);
            this.lblMoney.TabIndex = 2;
            this.lblMoney.Text = "00000$";
            // 
            // lblTranMoney
            // 
            this.lblTranMoney.AutoSize = true;
            this.lblTranMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranMoney.Location = new System.Drawing.Point(155, 192);
            this.lblTranMoney.Name = "lblTranMoney";
            this.lblTranMoney.Size = new System.Drawing.Size(78, 25);
            this.lblTranMoney.TabIndex = 3;
            this.lblTranMoney.Text = "00000$";
            this.lblTranMoney.Visible = false;
            // 
            // tmTran
            // 
            this.tmTran.Tick += new System.EventHandler(this.tmTran_Tick);
            // 
            // PlayerTranferMoneyToBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTranMoney);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.pbxBank);
            this.Controls.Add(this.pbxPlayer);
            this.Name = "PlayerTranferMoneyToBank";
            this.Size = new System.Drawing.Size(568, 272);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxPlayer;
        private System.Windows.Forms.PictureBox pbxBank;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblTranMoney;
        private System.Windows.Forms.Timer tmTran;
    }
}
