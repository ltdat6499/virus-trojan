namespace MidtermProjectGroup11.UserControll
{
    partial class PlayerTranferMoneyToPlayer
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
            this.pbxPlayer = new System.Windows.Forms.PictureBox();
            this.pbxDesPlayer = new System.Windows.Forms.PictureBox();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblTranMoney = new System.Windows.Forms.Label();
            this.tmTran = new System.Windows.Forms.Timer(this.components);
            this.lblDesMoney = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDesPlayer)).BeginInit();
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
            // pbxDesPlayer
            // 
            this.pbxDesPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxDesPlayer.Location = new System.Drawing.Point(417, 59);
            this.pbxDesPlayer.Name = "pbxDesPlayer";
            this.pbxDesPlayer.Size = new System.Drawing.Size(130, 130);
            this.pbxDesPlayer.TabIndex = 1;
            this.pbxDesPlayer.TabStop = false;
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
            // lblDesMoney
            // 
            this.lblDesMoney.AutoSize = true;
            this.lblDesMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesMoney.Location = new System.Drawing.Point(444, 192);
            this.lblDesMoney.Name = "lblDesMoney";
            this.lblDesMoney.Size = new System.Drawing.Size(78, 25);
            this.lblDesMoney.TabIndex = 4;
            this.lblDesMoney.Text = "00000$";
            // 
            // PlayerTranferMoneyToPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDesMoney);
            this.Controls.Add(this.lblTranMoney);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.pbxDesPlayer);
            this.Controls.Add(this.pbxPlayer);
            this.Name = "PlayerTranferMoneyToPlayer";
            this.Size = new System.Drawing.Size(568, 272);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDesPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxPlayer;
        private System.Windows.Forms.PictureBox pbxDesPlayer;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblTranMoney;
        private System.Windows.Forms.Timer tmTran;
        private System.Windows.Forms.Label lblDesMoney;
    }
}
