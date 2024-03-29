﻿
namespace Grid_based_map
{
    partial class Game_Frm
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
            this.components = new System.ComponentModel.Container();
            this.Map_Pnl = new System.Windows.Forms.Panel();
            this.Info_Pnl = new System.Windows.Forms.Panel();
            this.Quit_Btn = new System.Windows.Forms.Button();
            this.Item_Pnl = new System.Windows.Forms.Panel();
            this.Gear_Btn = new System.Windows.Forms.Button();
            this.Key_Btn = new System.Windows.Forms.Button();
            this.Item_Btn = new System.Windows.Forms.Button();
            this.Equiped_Btn = new System.Windows.Forms.Button();
            this.Desc_Pnl = new System.Windows.Forms.Panel();
            this.Use_Btn = new System.Windows.Forms.Button();
            this.Combat_Pnl = new System.Windows.Forms.Panel();
            this.Action_Pnl = new System.Windows.Forms.Panel();
            this.BattleUse_Btn = new System.Windows.Forms.Button();
            this.CombatItem_Pnl = new System.Windows.Forms.Panel();
            this.CombatInfo_TxtBox = new System.Windows.Forms.RichTextBox();
            this.PlayTime_Tmr = new System.Windows.Forms.Timer(this.components);
            this.Menu_Pnl = new System.Windows.Forms.Panel();
            this.Instructions_Btn = new System.Windows.Forms.Button();
            this.Start_Pnl = new System.Windows.Forms.Button();
            this.NameInsert_Txt = new System.Windows.Forms.TextBox();
            this.Info_Pnl.SuspendLayout();
            this.Desc_Pnl.SuspendLayout();
            this.Action_Pnl.SuspendLayout();
            this.Menu_Pnl.SuspendLayout();
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
            this.Info_Pnl.Controls.Add(this.Quit_Btn);
            this.Info_Pnl.Controls.Add(this.Item_Pnl);
            this.Info_Pnl.Controls.Add(this.Gear_Btn);
            this.Info_Pnl.Controls.Add(this.Key_Btn);
            this.Info_Pnl.Controls.Add(this.Item_Btn);
            this.Info_Pnl.Controls.Add(this.Equiped_Btn);
            this.Info_Pnl.Controls.Add(this.Desc_Pnl);
            this.Info_Pnl.Location = new System.Drawing.Point(840, 0);
            this.Info_Pnl.Name = "Info_Pnl";
            this.Info_Pnl.Size = new System.Drawing.Size(433, 841);
            this.Info_Pnl.TabIndex = 1;
            this.Info_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Info_Pnl_Paint);
            // 
            // Quit_Btn
            // 
            this.Quit_Btn.BackColor = System.Drawing.Color.Wheat;
            this.Quit_Btn.FlatAppearance.BorderSize = 0;
            this.Quit_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit_Btn.Location = new System.Drawing.Point(8, 742);
            this.Quit_Btn.Name = "Quit_Btn";
            this.Quit_Btn.Size = new System.Drawing.Size(415, 90);
            this.Quit_Btn.TabIndex = 0;
            this.Quit_Btn.TabStop = false;
            this.Quit_Btn.Text = "Exit to main menu";
            this.Quit_Btn.UseVisualStyleBackColor = false;
            this.Quit_Btn.Click += new System.EventHandler(this.Quit_Btn_Click);
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
            // Gear_Btn
            // 
            this.Gear_Btn.BackColor = System.Drawing.Color.Silver;
            this.Gear_Btn.FlatAppearance.BorderSize = 0;
            this.Gear_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gear_Btn.Location = new System.Drawing.Point(330, 225);
            this.Gear_Btn.Name = "Gear_Btn";
            this.Gear_Btn.Size = new System.Drawing.Size(103, 42);
            this.Gear_Btn.TabIndex = 0;
            this.Gear_Btn.TabStop = false;
            this.Gear_Btn.Text = "Gear";
            this.Gear_Btn.UseVisualStyleBackColor = false;
            this.Gear_Btn.Click += new System.EventHandler(this.Gear_btn_Click);
            // 
            // Key_Btn
            // 
            this.Key_Btn.BackColor = System.Drawing.Color.Gold;
            this.Key_Btn.FlatAppearance.BorderSize = 0;
            this.Key_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_Btn.Location = new System.Drawing.Point(110, 225);
            this.Key_Btn.Name = "Key_Btn";
            this.Key_Btn.Size = new System.Drawing.Size(110, 42);
            this.Key_Btn.TabIndex = 0;
            this.Key_Btn.TabStop = false;
            this.Key_Btn.Text = "Key";
            this.Key_Btn.UseVisualStyleBackColor = false;
            this.Key_Btn.Click += new System.EventHandler(this.Key_btn_Click);
            // 
            // Item_Btn
            // 
            this.Item_Btn.BackColor = System.Drawing.Color.Red;
            this.Item_Btn.FlatAppearance.BorderSize = 0;
            this.Item_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Item_Btn.Location = new System.Drawing.Point(220, 225);
            this.Item_Btn.Name = "Item_Btn";
            this.Item_Btn.Size = new System.Drawing.Size(110, 42);
            this.Item_Btn.TabIndex = 0;
            this.Item_Btn.TabStop = false;
            this.Item_Btn.Text = "Item";
            this.Item_Btn.UseVisualStyleBackColor = false;
            this.Item_Btn.Click += new System.EventHandler(this.Item_btn_Click);
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
            // Desc_Pnl
            // 
            this.Desc_Pnl.BackColor = System.Drawing.Color.Gray;
            this.Desc_Pnl.Controls.Add(this.Use_Btn);
            this.Desc_Pnl.Location = new System.Drawing.Point(0, 541);
            this.Desc_Pnl.Name = "Desc_Pnl";
            this.Desc_Pnl.Size = new System.Drawing.Size(433, 195);
            this.Desc_Pnl.TabIndex = 2;
            this.Desc_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Desc_Pnl_Paint);
            // 
            // Use_Btn
            // 
            this.Use_Btn.BackColor = System.Drawing.Color.LawnGreen;
            this.Use_Btn.FlatAppearance.BorderSize = 0;
            this.Use_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Use_Btn.Location = new System.Drawing.Point(359, 0);
            this.Use_Btn.Name = "Use_Btn";
            this.Use_Btn.Size = new System.Drawing.Size(74, 195);
            this.Use_Btn.TabIndex = 0;
            this.Use_Btn.TabStop = false;
            this.Use_Btn.Text = "Use/Equip";
            this.Use_Btn.UseVisualStyleBackColor = false;
            this.Use_Btn.Click += new System.EventHandler(this.Use_Btn_Click);
            // 
            // Combat_Pnl
            // 
            this.Combat_Pnl.Location = new System.Drawing.Point(0, 0);
            this.Combat_Pnl.Name = "Combat_Pnl";
            this.Combat_Pnl.Size = new System.Drawing.Size(1273, 545);
            this.Combat_Pnl.TabIndex = 2;
            this.Combat_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Combat_Pnl_Paint);
            // 
            // Action_Pnl
            // 
            this.Action_Pnl.Controls.Add(this.BattleUse_Btn);
            this.Action_Pnl.Controls.Add(this.CombatItem_Pnl);
            this.Action_Pnl.Controls.Add(this.CombatInfo_TxtBox);
            this.Action_Pnl.Location = new System.Drawing.Point(0, 545);
            this.Action_Pnl.Name = "Action_Pnl";
            this.Action_Pnl.Size = new System.Drawing.Size(1273, 296);
            this.Action_Pnl.TabIndex = 3;
            this.Action_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Action_Pnl_Paint);
            this.Action_Pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Action_Pnl_MouseDown);
            // 
            // BattleUse_Btn
            // 
            this.BattleUse_Btn.BackColor = System.Drawing.Color.OliveDrab;
            this.BattleUse_Btn.Enabled = false;
            this.BattleUse_Btn.FlatAppearance.BorderSize = 0;
            this.BattleUse_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BattleUse_Btn.Location = new System.Drawing.Point(759, 4);
            this.BattleUse_Btn.Name = "BattleUse_Btn";
            this.BattleUse_Btn.Size = new System.Drawing.Size(135, 289);
            this.BattleUse_Btn.TabIndex = 3;
            this.BattleUse_Btn.TabStop = false;
            this.BattleUse_Btn.Text = "Use";
            this.BattleUse_Btn.UseVisualStyleBackColor = false;
            this.BattleUse_Btn.Visible = false;
            this.BattleUse_Btn.Click += new System.EventHandler(this.BattleUse_Btn_Click);
            // 
            // CombatItem_Pnl
            // 
            this.CombatItem_Pnl.AutoScroll = true;
            this.CombatItem_Pnl.BackColor = System.Drawing.Color.RosyBrown;
            this.CombatItem_Pnl.Location = new System.Drawing.Point(4, 4);
            this.CombatItem_Pnl.Name = "CombatItem_Pnl";
            this.CombatItem_Pnl.Size = new System.Drawing.Size(432, 289);
            this.CombatItem_Pnl.TabIndex = 2;
            this.CombatItem_Pnl.Visible = false;
            this.CombatItem_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.CombatItem_Pnl_Paint);
            this.CombatItem_Pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CombatItem_Pnl_MouseDown);
            // 
            // CombatInfo_TxtBox
            // 
            this.CombatInfo_TxtBox.BackColor = System.Drawing.Color.Black;
            this.CombatInfo_TxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CombatInfo_TxtBox.DetectUrls = false;
            this.CombatInfo_TxtBox.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CombatInfo_TxtBox.ForeColor = System.Drawing.SystemColors.Info;
            this.CombatInfo_TxtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CombatInfo_TxtBox.Location = new System.Drawing.Point(900, 0);
            this.CombatInfo_TxtBox.Name = "CombatInfo_TxtBox";
            this.CombatInfo_TxtBox.ReadOnly = true;
            this.CombatInfo_TxtBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.CombatInfo_TxtBox.Size = new System.Drawing.Size(372, 296);
            this.CombatInfo_TxtBox.TabIndex = 0;
            this.CombatInfo_TxtBox.TabStop = false;
            this.CombatInfo_TxtBox.Text = "->This is the Combat Action pannel\n->It will tell you what actions were taken by " +
    "everyone invloved In the combat";
            this.CombatInfo_TxtBox.Click += new System.EventHandler(this.CombatInfo_TxtBox_Click);
            this.CombatInfo_TxtBox.TextChanged += new System.EventHandler(this.CombatInfo_TxtBox_TextChanged);
            // 
            // PlayTime_Tmr
            // 
            this.PlayTime_Tmr.Interval = 1000;
            this.PlayTime_Tmr.Tick += new System.EventHandler(this.PlayTime_Tmr_Tick);
            // 
            // Menu_Pnl
            // 
            this.Menu_Pnl.Controls.Add(this.Instructions_Btn);
            this.Menu_Pnl.Controls.Add(this.Start_Pnl);
            this.Menu_Pnl.Controls.Add(this.NameInsert_Txt);
            this.Menu_Pnl.Location = new System.Drawing.Point(0, 0);
            this.Menu_Pnl.Name = "Menu_Pnl";
            this.Menu_Pnl.Size = new System.Drawing.Size(1272, 841);
            this.Menu_Pnl.TabIndex = 4;
            // 
            // Instructions_Btn
            // 
            this.Instructions_Btn.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Instructions_Btn.Location = new System.Drawing.Point(519, 439);
            this.Instructions_Btn.Name = "Instructions_Btn";
            this.Instructions_Btn.Size = new System.Drawing.Size(222, 91);
            this.Instructions_Btn.TabIndex = 2;
            this.Instructions_Btn.TabStop = false;
            this.Instructions_Btn.Text = "Instructions!";
            this.Instructions_Btn.UseVisualStyleBackColor = true;
            this.Instructions_Btn.Click += new System.EventHandler(this.Instructions_Btn_Click);
            // 
            // Start_Pnl
            // 
            this.Start_Pnl.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Start_Pnl.Location = new System.Drawing.Point(519, 267);
            this.Start_Pnl.Name = "Start_Pnl";
            this.Start_Pnl.Size = new System.Drawing.Size(222, 90);
            this.Start_Pnl.TabIndex = 1;
            this.Start_Pnl.TabStop = false;
            this.Start_Pnl.Text = "Start";
            this.Start_Pnl.UseVisualStyleBackColor = true;
            this.Start_Pnl.Click += new System.EventHandler(this.Start_Pnl_Click);
            // 
            // NameInsert_Txt
            // 
            this.NameInsert_Txt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameInsert_Txt.Location = new System.Drawing.Point(519, 386);
            this.NameInsert_Txt.MaxLength = 20;
            this.NameInsert_Txt.Name = "NameInsert_Txt";
            this.NameInsert_Txt.PlaceholderText = "Enter you name here before you begin!";
            this.NameInsert_Txt.Size = new System.Drawing.Size(222, 22);
            this.NameInsert_Txt.TabIndex = 0;
            this.NameInsert_Txt.TabStop = false;
            this.NameInsert_Txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameInsert_Txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameInsert_Txt_KeyPress);
            // 
            // Game_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 841);
            this.Controls.Add(this.Menu_Pnl);
            this.Controls.Add(this.Action_Pnl);
            this.Controls.Add(this.Combat_Pnl);
            this.Controls.Add(this.Info_Pnl);
            this.Controls.Add(this.Map_Pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Game_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crystal Takeover";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Info_Pnl.ResumeLayout(false);
            this.Desc_Pnl.ResumeLayout(false);
            this.Action_Pnl.ResumeLayout(false);
            this.Menu_Pnl.ResumeLayout(false);
            this.Menu_Pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Map_Pnl;
        private System.Windows.Forms.Panel Info_Pnl;
        private System.Windows.Forms.Button Quit_Btn;
        private System.Windows.Forms.Panel Item_Pnl;
        private System.Windows.Forms.Button Gear_Btn;
        private System.Windows.Forms.Button Item_Btn;
        private System.Windows.Forms.Button Key_Btn;
        private System.Windows.Forms.Panel Desc_Pnl;
        private System.Windows.Forms.Button Use_Btn;
        private System.Windows.Forms.Button Equiped_Btn;
        private System.Windows.Forms.Panel Combat_Pnl;
        private System.Windows.Forms.Panel Action_Pnl;
        private System.Windows.Forms.RichTextBox CombatInfo_TxtBox;
        private System.Windows.Forms.Button BattleUse_Btn;
        private System.Windows.Forms.Panel CombatItem_Pnl;
        private System.Windows.Forms.Timer PlayTime_Tmr;
        private System.Windows.Forms.Panel Menu_Pnl;
        private System.Windows.Forms.Button Instructions_Btn;
        private System.Windows.Forms.Button Start_Pnl;
        private System.Windows.Forms.TextBox NameInsert_Txt;
    }
}

