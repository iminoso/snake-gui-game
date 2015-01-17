namespace Snake
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.picGamefield = new System.Windows.Forms.PictureBox();
            this.tmrGameClock = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGamefield)).BeginInit();
            this.SuspendLayout();
            // 
            // picGamefield
            // 
            this.picGamefield.BackColor = System.Drawing.Color.LightGray;
            this.picGamefield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGamefield.Location = new System.Drawing.Point(93, 38);
            this.picGamefield.Name = "picGamefield";
            this.picGamefield.Size = new System.Drawing.Size(300, 150);
            this.picGamefield.TabIndex = 0;
            this.picGamefield.TabStop = false;
            this.picGamefield.Click += new System.EventHandler(this.picGamefield_Click);
            // 
            // tmrGameClock
            // 
            this.tmrGameClock.Interval = 75;
            this.tmrGameClock.Tick += new System.EventHandler(this.tmrGameClock_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(93, 19);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(47, 13);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "Score: 0";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(185, 195);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(128, 13);
            this.lblMsg.TabIndex = 9;
            this.lblMsg.Text = "Press Space Bar to Begin";
            this.lblMsg.Click += new System.EventHandler(this.lblMsg_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(492, 260);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.picGamefield);
            this.Name = "frmMain";
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picGamefield)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGamefield;
        private System.Windows.Forms.Timer tmrGameClock;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblMsg;
    }
}

