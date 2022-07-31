
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
            this.Gear_btn = new System.Windows.Forms.Button();
            this.Item_btn = new System.Windows.Forms.Button();
            this.Key_btn = new System.Windows.Forms.Button();
            this.Item_Pnl = new System.Windows.Forms.Panel();
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
            this.Info_Pnl.Controls.Add(this.Gear_btn);
            this.Info_Pnl.Controls.Add(this.Item_btn);
            this.Info_Pnl.Controls.Add(this.Key_btn);
            this.Info_Pnl.Controls.Add(this.Item_Pnl);
            this.Info_Pnl.Controls.Add(this.button2);
            this.Info_Pnl.Controls.Add(this.button1);
            this.Info_Pnl.Location = new System.Drawing.Point(600, 0);
            this.Info_Pnl.Name = "Info_Pnl";
            this.Info_Pnl.Size = new System.Drawing.Size(300, 600);
            this.Info_Pnl.TabIndex = 1;
            this.Info_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Info_Pnl_Paint);
            // 
            // Gear_btn
            // 
            this.Gear_btn.Location = new System.Drawing.Point(6, 360);
            this.Gear_btn.Name = "Gear_btn";
            this.Gear_btn.Size = new System.Drawing.Size(67, 23);
            this.Gear_btn.TabIndex = 0;
            this.Gear_btn.TabStop = false;
            this.Gear_btn.Text = "Gear";
            this.Gear_btn.UseVisualStyleBackColor = true;
            this.Gear_btn.Click += new System.EventHandler(this.Gear_btn_Click);
            // 
            // Item_btn
            // 
            this.Item_btn.Location = new System.Drawing.Point(6, 300);
            this.Item_btn.Name = "Item_btn";
            this.Item_btn.Size = new System.Drawing.Size(67, 23);
            this.Item_btn.TabIndex = 0;
            this.Item_btn.TabStop = false;
            this.Item_btn.Text = "Item";
            this.Item_btn.UseVisualStyleBackColor = true;
            this.Item_btn.Click += new System.EventHandler(this.Item_btn_Click);
            // 
            // Key_btn
            // 
            this.Key_btn.Location = new System.Drawing.Point(6, 240);
            this.Key_btn.Name = "Key_btn";
            this.Key_btn.Size = new System.Drawing.Size(67, 23);
            this.Key_btn.TabIndex = 0;
            this.Key_btn.TabStop = false;
            this.Key_btn.Text = "Key";
            this.Key_btn.UseVisualStyleBackColor = true;
            this.Key_btn.Click += new System.EventHandler(this.Key_btn_Click);
            // 
            // Item_Pnl
            // 
            this.Item_Pnl.BackColor = System.Drawing.Color.RosyBrown;
            this.Item_Pnl.Location = new System.Drawing.Point(79, 225);
            this.Item_Pnl.Name = "Item_Pnl";
            this.Item_Pnl.Size = new System.Drawing.Size(220, 275);
            this.Item_Pnl.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Wheat;
            this.button2.Location = new System.Drawing.Point(160, 510);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 80);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Wheat;
            this.button1.Location = new System.Drawing.Point(10, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 80);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.Info_Pnl);
            this.Controls.Add(this.Map_Pnl);
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
    }
}

