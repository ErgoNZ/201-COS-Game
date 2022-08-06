
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
            this.Desc_Pnl = new System.Windows.Forms.Panel();
            this.Item_Pnl = new System.Windows.Forms.Panel();
            this.Gear_btn = new System.Windows.Forms.Button();
            this.Key_btn = new System.Windows.Forms.Button();
            this.Item_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Info_Pnl.SuspendLayout();
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
            this.Info_Pnl.Controls.Add(this.Desc_Pnl);
            this.Info_Pnl.Controls.Add(this.Item_Pnl);
            this.Info_Pnl.Controls.Add(this.Gear_btn);
            this.Info_Pnl.Controls.Add(this.Key_btn);
            this.Info_Pnl.Controls.Add(this.Item_btn);
            this.Info_Pnl.Controls.Add(this.button2);
            this.Info_Pnl.Controls.Add(this.button1);
            this.Info_Pnl.Location = new System.Drawing.Point(600, 0);
            this.Info_Pnl.Name = "Info_Pnl";
            this.Info_Pnl.Size = new System.Drawing.Size(300, 600);
            this.Info_Pnl.TabIndex = 1;
            this.Info_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Info_Pnl_Paint);
            // 
            // Desc_Pnl
            // 
            this.Desc_Pnl.BackColor = System.Drawing.Color.Gray;
            this.Desc_Pnl.Location = new System.Drawing.Point(0, 404);
            this.Desc_Pnl.Name = "Desc_Pnl";
            this.Desc_Pnl.Size = new System.Drawing.Size(300, 96);
            this.Desc_Pnl.TabIndex = 2;
            // 
            // Item_Pnl
            // 
            this.Item_Pnl.AutoScroll = true;
            this.Item_Pnl.AutoScrollMinSize = new System.Drawing.Size(0, 300);
            this.Item_Pnl.BackColor = System.Drawing.Color.RosyBrown;
            this.Item_Pnl.Location = new System.Drawing.Point(0, 260);
            this.Item_Pnl.Name = "Item_Pnl";
            this.Item_Pnl.Size = new System.Drawing.Size(300, 144);
            this.Item_Pnl.TabIndex = 1;
            this.Item_Pnl.TabStop = true;
            this.Item_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Item_Pnl_Paint);
            this.Item_Pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Item_Pnl_MouseDown);
            // 
            // Gear_btn
            // 
            this.Gear_btn.BackColor = System.Drawing.Color.Silver;
            this.Gear_btn.FlatAppearance.BorderSize = 0;
            this.Gear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gear_btn.Location = new System.Drawing.Point(227, 225);
            this.Gear_btn.Name = "Gear_btn";
            this.Gear_btn.Size = new System.Drawing.Size(73, 36);
            this.Gear_btn.TabIndex = 0;
            this.Gear_btn.TabStop = false;
            this.Gear_btn.Text = "Gear";
            this.Gear_btn.UseVisualStyleBackColor = false;
            this.Gear_btn.Click += new System.EventHandler(this.Gear_btn_Click);
            // 
            // Key_btn
            // 
            this.Key_btn.BackColor = System.Drawing.Color.Gold;
            this.Key_btn.FlatAppearance.BorderSize = 0;
            this.Key_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_btn.Location = new System.Drawing.Point(0, 225);
            this.Key_btn.Name = "Key_btn";
            this.Key_btn.Size = new System.Drawing.Size(73, 36);
            this.Key_btn.TabIndex = 0;
            this.Key_btn.TabStop = false;
            this.Key_btn.Text = "Key";
            this.Key_btn.UseVisualStyleBackColor = false;
            this.Key_btn.Click += new System.EventHandler(this.Key_btn_Click);
            // 
            // Item_btn
            // 
            this.Item_btn.BackColor = System.Drawing.Color.Red;
            this.Item_btn.FlatAppearance.BorderSize = 0;
            this.Item_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Item_btn.Location = new System.Drawing.Point(111, 225);
            this.Item_btn.Name = "Item_btn";
            this.Item_btn.Size = new System.Drawing.Size(73, 36);
            this.Item_btn.TabIndex = 0;
            this.Item_btn.TabStop = false;
            this.Item_btn.Text = "Item";
            this.Item_btn.UseVisualStyleBackColor = false;
            this.Item_btn.Click += new System.EventHandler(this.Item_btn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Wheat;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(160, 510);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 80);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Wheat;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(10, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 80);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.Map_Pnl);
            this.Controls.Add(this.Info_Pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Info_Pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Map_Pnl;
        private System.Windows.Forms.Panel Info_Pnl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel Item_Pnl;
        private System.Windows.Forms.Button Gear_btn;
        private System.Windows.Forms.Button Item_btn;
        private System.Windows.Forms.Button Key_btn;
        private System.Windows.Forms.Panel Desc_Pnl;
    }
}

