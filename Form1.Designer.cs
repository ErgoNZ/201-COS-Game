
namespace Grid_based_map
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Map_Pnl = new System.Windows.Forms.Panel();
            this.Info_Pnl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Map_Pnl
            // 
            this.Map_Pnl.Location = new System.Drawing.Point(0, 0);
            this.Map_Pnl.Name = "Map_Pnl";
            this.Map_Pnl.Size = new System.Drawing.Size(600, 600);
            this.Map_Pnl.TabIndex = 0;
            this.Map_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Info_Pnl
            // 
            this.Info_Pnl.BackColor = System.Drawing.Color.Transparent;
            this.Info_Pnl.Location = new System.Drawing.Point(600, 0);
            this.Info_Pnl.Name = "Info_Pnl";
            this.Info_Pnl.Size = new System.Drawing.Size(300, 600);
            this.Info_Pnl.TabIndex = 1;
            this.Info_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Info_Pnl_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 600);
            this.Controls.Add(this.Info_Pnl);
            this.Controls.Add(this.Map_Pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Map_Pnl;
        private System.Windows.Forms.Panel Info_Pnl;
    }
}

