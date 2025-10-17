namespace WinFormsApp4_ziya_variant_10_
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button[,] buttons;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnReset;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.buttons = new System.Windows.Forms.Button[3, 3];
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();

            this.SuspendLayout();

         
            int size = 80;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.buttons[i, j] = new System.Windows.Forms.Button();
                    this.buttons[i, j].Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
                    this.buttons[i, j].Location = new System.Drawing.Point(20 + j * size, 20 + i * size);
                    this.buttons[i, j].Size = new System.Drawing.Size(size, size);
                    this.buttons[i, j].Tag = (i, j);
                    this.buttons[i, j].Click += new System.EventHandler(this.Button_Click);
                    this.Controls.Add(this.buttons[i, j]);
                }
            }

            
            this.btnReset.Text = "Новая игра";
            this.btnReset.Location = new System.Drawing.Point(20, 280);
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            this.Controls.Add(this.btnReset);

           
            this.lblStatus.Text = "Ходит: X";
            this.lblStatus.Location = new System.Drawing.Point(150, 285);
            this.lblStatus.AutoSize = true;
            this.Controls.Add(this.lblStatus);

            
            this.ClientSize = new System.Drawing.Size(280, 330);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Крестики-нолики";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

