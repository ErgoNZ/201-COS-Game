
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
            this.Item_Pnl = new System.Windows.Forms.Panel();
            this.Desc_Pnl = new System.Windows.Forms.Panel();
            this.Drop_Btn = new System.Windows.Forms.Button();
            this.Use_Btn = new System.Windows.Forms.Button();
            this.Gear_btn = new System.Windows.Forms.Button();
            this.Key_btn = new System.Windows.Forms.Button();
            this.Item_btn = new System.Windows.Forms.Button();
            this.Quit_Btn = new System.Windows.Forms.Button();
            this.Save_Btn = new System.Windows.Forms.Button();
            this.Equiped_Btn = new System.Windows.Forms.Button();
            this.Info_Pnl.SuspendLayout();
            this.Desc_Pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Map_Pnl
            // 
            this.Map_Pnl.BackColor = System.Drawing.SystemColors.Control;
            this.Map_Pnl.Location = new System.Drawing.Point(0, 0);
            this.Map_Pnl.Name = "Map_Pnl";
            this.Map_Pnl.Size = new System.Drawing.Size(841, 841);
            this.Map_Pnl.TabIndex = 0;
            this.Map_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Map_Pnl_Paint);
            // 
            // Info_Pnl
            // 
            this.Info_Pnl.BackColor = System.Drawing.Color.Transparent;
            this.Info_Pnl.Controls.Add(this.Item_Pnl);
            this.Info_Pnl.Controls.Add(this.Desc_Pnl);
            this.Info_Pnl.Controls.Add(this.Gear_btn);
            this.Info_Pnl.Controls.Add(this.Key_btn);
            this.Info_Pnl.Controls.Add(this.Item_btn);
            this.Info_Pnl.Controls.Add(this.Quit_Btn);
            this.Info_Pnl.Controls.Add(this.Save_Btn);
            this.Info_Pnl.Controls.Add(this.Equiped_Btn);
            this.Info_Pnl.Location = new System.Drawing.Point(840, 0);
            this.Info_Pnl.Name = "Info_Pnl";
            this.Info_Pnl.Size = new System.Drawing.Size(433, 841);
            this.Info_Pnl.TabIndex = 1;
            this.Info_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Info_Pnl_Paint);
            // 
            // Item_Pnl
            // 
            this.Item_Pnl.AutoScroll = true;
            this.Item_Pnl.BackColor = System.Drawing.Color.RosyBrown;
            this.Item_Pnl.Location = new System.Drawing.Point(0, 267);
            this.Item_Pnl.Name = "Item_Pnl";
            this.Item_Pnl.Size = new System.Drawing.Size(433, 274);
            this.Item_Pnl.TabIndex = 1;
            this.Item_Pnl.TabStop = true;
            this.Item_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Item_Pnl_Paint);
            this.Item_Pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Item_Pnl_MouseDown);
            // 
            // Desc_Pnl
            // 
            this.Desc_Pnl.BackColor = System.Drawing.Color.Gray;
            this.Desc_Pnl.Controls.Add(this.Drop_Btn);
            this.Desc_Pnl.Controls.Add(this.Use_Btn);
            this.Desc_Pnl.Location = new System.Drawing.Point(0, 541);
            this.Desc_Pnl.Name = "Desc_Pnl";
            this.Desc_Pnl.Size = new System.Drawing.Size(433, 195);
            this.Desc_Pnl.TabIndex = 2;
            this.Desc_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Desc_Pnl_Paint);
            // 
            // Drop_Btn
            // 
            this.Drop_Btn.BackColor = System.Drawing.Color.LightSlateGray;
            this.Drop_Btn.FlatAppearance.BorderSize = 0;
            this.Drop_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Drop_Btn.Location = new System.Drawing.Point(359, 107);
            this.Drop_Btn.Name = "Drop_Btn";
            this.Drop_Btn.Size = new System.Drawing.Size(74, 88);
            this.Drop_Btn.TabIndex = 0;
            this.Drop_Btn.TabStop = false;
            this.Drop_Btn.Text = "Discard";
            this.Drop_Btn.UseVisualStyleBackColor = false;
            // 
            // Use_Btn
            // 
            this.Use_Btn.BackColor = System.Drawing.Color.LawnGreen;
            this.Use_Btn.FlatAppearance.BorderSize = 0;
            this.Use_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Use_Btn.Location = new System.Drawing.Point(359, 0);
            this.Use_Btn.Name = "Use_Btn";
            this.Use_Btn.Size = new System.Drawing.Size(74, 88);
            this.Use_Btn.TabIndex = 0;
            this.Use_Btn.TabStop = false;
            this.Use_Btn.Text = "Use/Equip";
            this.Use_Btn.UseVisualStyleBackColor = false;
            this.Use_Btn.Click += new System.EventHandler(this.Use_Btn_Click);
            // 
            // Gear_btn
            // 
            this.Gear_btn.BackColor = System.Drawing.Color.Silver;
            this.Gear_btn.FlatAppearance.BorderSize = 0;
            this.Gear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gear_btn.Location = new System.Drawing.Point(330, 225);
            this.Gear_btn.Name = "Gear_btn";
            this.Gear_btn.Size = new System.Drawing.Size(103, 42);
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
            this.Key_btn.Location = new System.Drawing.Point(110, 225);
            this.Key_btn.Name = "Key_btn";
            this.Key_btn.Size = new System.Drawing.Size(110, 42);
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
            this.Item_btn.Location = new System.Drawing.Point(220, 225);
            this.Item_btn.Name = "Item_btn";
            this.Item_btn.Size = new System.Drawing.Size(110, 42);
            this.Item_btn.TabIndex = 0;
            this.Item_btn.TabStop = false;
            this.Item_btn.Text = "Item";
            this.Item_btn.UseVisualStyleBackColor = false;
            this.Item_btn.Click += new System.EventHandler(this.Item_btn_Click);
            // 
            // Quit_Btn
            // 
            this.Quit_Btn.BackColor = System.Drawing.Color.Wheat;
            this.Quit_Btn.FlatAppearance.BorderSize = 0;
            this.Quit_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit_Btn.Location = new System.Drawing.Point(227, 742);
            this.Quit_Btn.Name = "Quit_Btn";
            this.Quit_Btn.Size = new System.Drawing.Size(195, 90);
            this.Quit_Btn.TabIndex = 0;
            this.Quit_Btn.TabStop = false;
            this.Quit_Btn.Text = "button2";
            this.Quit_Btn.UseVisualStyleBackColor = false;
            this.Quit_Btn.Click += new System.EventHandler(this.Quit_Btn_Click);
            // 
            // Save_Btn
            // 
            this.Save_Btn.BackColor = System.Drawing.Color.Wheat;
            this.Save_Btn.FlatAppearance.BorderSize = 0;
            this.Save_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_Btn.Location = new System.Drawing.Point(7, 742);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(195, 90);
            this.Save_Btn.TabIndex = 0;
            this.Save_Btn.TabStop = false;
            this.Save_Btn.Text = "button1";
            this.Save_Btn.UseVisualStyleBackColor = false;
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // Equiped_Btn
            // 
            this.Equiped_Btn.BackColor = System.Drawing.Color.Olive;
            this.Equiped_Btn.FlatAppearance.BorderSize = 0;
            this.Equiped_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Equiped_Btn.Location = new System.Drawing.Point(0, 225);
            this.Equiped_Btn.Name = "Equiped_Btn";
            this.Equiped_Btn.Size = new System.Drawing.Size(110, 42);
            this.Equiped_Btn.TabIndex = 0;
            this.Equiped_Btn.TabStop = false;
            this.Equiped_Btn.Text = "Equiped";
            this.Equiped_Btn.UseVisualStyleBackColor = false;
            this.Equiped_Btn.Click += new System.EventHandler(this.Equiped_Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 841);
            this.Controls.Add(this.Map_Pnl);
            this.Controls.Add(this.Info_Pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Info_Pnl.ResumeLayout(false);
            this.Desc_Pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Map_Pnl;
        private System.Windows.Forms.Panel Info_Pnl;
        private System.Windows.Forms.Button Save_Btn;
        private System.Windows.Forms.Button Quit_Btn;
        private System.Windows.Forms.Panel Item_Pnl;
        private System.Windows.Forms.Button Gear_btn;
        private System.Windows.Forms.Button Item_btn;
        private System.Windows.Forms.Button Key_btn;
        private System.Windows.Forms.Panel Desc_Pnl;
        private System.Windows.Forms.Button Drop_Btn;
        private System.Windows.Forms.Button Use_Btn;
        private System.Windows.Forms.Button Equiped_Btn;
    }
}

