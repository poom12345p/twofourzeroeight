namespace twozerofoureight
{
    partial class GameOver
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
            this.gameoverlb = new System.Windows.Forms.Label();
            this.scorelb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameoverlb
            // 
            this.gameoverlb.AutoSize = true;
            this.gameoverlb.Font = new System.Drawing.Font("Microsoft YaHei UI", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameoverlb.ForeColor = System.Drawing.Color.DarkRed;
            this.gameoverlb.Location = new System.Drawing.Point(199, 86);
            this.gameoverlb.Name = "gameoverlb";
            this.gameoverlb.Size = new System.Drawing.Size(395, 86);
            this.gameoverlb.TabIndex = 0;
            this.gameoverlb.Text = "Game Over";
            this.gameoverlb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scorelb
            // 
            this.scorelb.AutoSize = true;
            this.scorelb.Font = new System.Drawing.Font("Minion Pro", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scorelb.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.scorelb.Location = new System.Drawing.Point(356, 219);
            this.scorelb.Name = "scorelb";
            this.scorelb.Size = new System.Drawing.Size(108, 48);
            this.scorelb.TabIndex = 1;
            this.scorelb.Text = "label1";
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scorelb);
            this.Controls.Add(this.gameoverlb);
            this.Name = "GameOver";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GameOver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameoverlb;
        private System.Windows.Forms.Label scorelb;
    }
}