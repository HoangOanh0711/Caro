﻿
namespace caro
{
    partial class Caro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caro));
            this.player1 = new System.Windows.Forms.Panel();
            this.name1 = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.player2 = new System.Windows.Forms.Panel();
            this.name2 = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.banco = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.hienchat = new System.Windows.Forms.TextBox();
            this.undo = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.redo = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.ToolTip(this.components);
            this.newgame = new System.Windows.Forms.ToolTip(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.nhapchat = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ruless = new System.Windows.Forms.ToolTip(this.components);
            this.rules = new System.Windows.Forms.Button();
            this.sendd = new System.Windows.Forms.ToolTip(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.emoji = new System.Windows.Forms.ToolTip(this.components);
            this.player1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.player2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // player1
            // 
            this.player1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player1.BackColor = System.Drawing.Color.White;
            this.player1.BackgroundImage = global::caro.Properties.Resources.camhong;
            this.player1.Controls.Add(this.name1);
            this.player1.Controls.Add(this.pictureBox5);
            this.player1.Controls.Add(this.textBox1);
            this.player1.Controls.Add(this.pictureBox3);
            this.player1.Controls.Add(this.pictureBox1);
            this.player1.Location = new System.Drawing.Point(8, 5);
            this.player1.Margin = new System.Windows.Forms.Padding(2);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(205, 210);
            this.player1.TabIndex = 0;
            // 
            // name1
            // 
            this.name1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(224)))), ((int)(((byte)(202)))));
            this.name1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name1.Enabled = false;
            this.name1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name1.Location = new System.Drawing.Point(3, 152);
            this.name1.Multiline = true;
            this.name1.Name = "name1";
            this.name1.Size = new System.Drawing.Size(107, 27);
            this.name1.TabIndex = 11;
            this.name1.Text = "Player1";
            this.name1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(124, 125);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(80, 80);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(140, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(60, 50);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Location = new System.Drawing.Point(140, 54);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 60);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::caro.Properties.Resources.camhong;
            this.pictureBox1.Image = global::caro.Properties.Resources.soccer_player;
            this.pictureBox1.Location = new System.Drawing.Point(0, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // player2
            // 
            this.player2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player2.BackColor = System.Drawing.Color.Transparent;
            this.player2.BackgroundImage = global::caro.Properties.Resources.camhong;
            this.player2.Controls.Add(this.name2);
            this.player2.Controls.Add(this.pictureBox6);
            this.player2.Controls.Add(this.textBox2);
            this.player2.Controls.Add(this.pictureBox4);
            this.player2.Controls.Add(this.pictureBox2);
            this.player2.Location = new System.Drawing.Point(8, 220);
            this.player2.Margin = new System.Windows.Forms.Padding(2);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(205, 210);
            this.player2.TabIndex = 1;
            // 
            // name2
            // 
            this.name2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(224)))), ((int)(((byte)(202)))));
            this.name2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name2.Enabled = false;
            this.name2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name2.Location = new System.Drawing.Point(3, 152);
            this.name2.Multiline = true;
            this.name2.Name = "name2";
            this.name2.Size = new System.Drawing.Size(107, 27);
            this.name2.TabIndex = 12;
            this.name2.Text = "Player2";
            this.name2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.ErrorImage = null;
            this.pictureBox6.InitialImage = null;
            this.pictureBox6.Location = new System.Drawing.Point(124, 125);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(80, 80);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 10;
            this.pictureBox6.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(140, 0);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(60, 50);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Location = new System.Drawing.Point(140, 54);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(60, 60);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Image = global::caro.Properties.Resources.soccer_player__1_;
            this.pictureBox2.Location = new System.Drawing.Point(0, 42);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(110, 110);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // banco
            // 
            this.banco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.banco.Location = new System.Drawing.Point(217, 5);
            this.banco.Margin = new System.Windows.Forms.Padding(2);
            this.banco.Name = "banco";
            this.banco.Size = new System.Drawing.Size(690, 600);
            this.banco.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = global::caro.Properties.Resources.play;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(542, 258);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 100);
            this.button6.TabIndex = 3;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // hienchat
            // 
            this.hienchat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(228)))), ((int)(((byte)(244)))));
            this.hienchat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hienchat.Enabled = false;
            this.hienchat.Location = new System.Drawing.Point(912, 5);
            this.hienchat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hienchat.Multiline = true;
            this.hienchat.Name = "hienchat";
            this.hienchat.ReadOnly = true;
            this.hienchat.Size = new System.Drawing.Size(265, 550);
            this.hienchat.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(214)))), ((int)(((byte)(226)))));
            this.button1.BackgroundImage = global::caro.Properties.Resources.undo;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(34, 438);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 7;
            this.undo.SetToolTip(this.button1, "Undo");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(214)))), ((int)(((byte)(226)))));
            this.button3.BackgroundImage = global::caro.Properties.Resources.exit;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(121, 497);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 8;
            this.exit.SetToolTip(this.button3, "Exit");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(214)))), ((int)(((byte)(226)))));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(121, 438);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 6;
            this.redo.SetToolTip(this.button2, "Redo");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(214)))), ((int)(((byte)(226)))));
            this.button4.BackgroundImage = global::caro.Properties.Resources.newgame21;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(34, 497);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 50);
            this.button4.TabIndex = 9;
            this.newgame.SetToolTip(this.button4, "New Game");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // nhapchat
            // 
            this.nhapchat.Enabled = false;
            this.nhapchat.Location = new System.Drawing.Point(912, 559);
            this.nhapchat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nhapchat.Multiline = true;
            this.nhapchat.Name = "nhapchat";
            this.nhapchat.Size = new System.Drawing.Size(174, 37);
            this.nhapchat.TabIndex = 1;
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(214)))), ((int)(((byte)(226)))));
            this.send.BackgroundImage = global::caro.Properties.Resources.send;
            this.send.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.send.Enabled = false;
            this.send.FlatAppearance.BorderSize = 0;
            this.send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.send.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.send.Location = new System.Drawing.Point(1094, 559);
            this.send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(40, 40);
            this.send.TabIndex = 2;
            this.sendd.SetToolTip(this.send, "Send");
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rules
            // 
            this.rules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(214)))), ((int)(((byte)(226)))));
            this.rules.BackgroundImage = global::caro.Properties.Resources.rules2;
            this.rules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rules.FlatAppearance.BorderSize = 0;
            this.rules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rules.Location = new System.Drawing.Point(74, 550);
            this.rules.Margin = new System.Windows.Forms.Padding(2);
            this.rules.Name = "rules";
            this.rules.Size = new System.Drawing.Size(55, 55);
            this.rules.TabIndex = 11;
            this.ruless.SetToolTip(this.rules, "Rules");
            this.rules.UseVisualStyleBackColor = false;
            this.rules.Click += new System.EventHandler(this.rules_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(214)))), ((int)(((byte)(226)))));
            this.button7.BackgroundImage = global::caro.Properties.Resources.laughing__2_;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Enabled = false;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(1142, 559);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(35, 35);
            this.button7.TabIndex = 10;
            this.emoji.SetToolTip(this.button7, "Emoji");
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // Caro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(214)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1184, 616);
            this.Controls.Add(this.rules);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.nhapchat);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.send);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.banco);
            this.Controls.Add(this.hienchat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1000, 600);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1200, 655);
            this.MinimumSize = new System.Drawing.Size(1200, 655);
            this.Name = "Caro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Caro_FormClosing);
            this.Load += new System.EventHandler(this.Caro_Load);
            this.player1.ResumeLayout(false);
            this.player1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.player2.ResumeLayout(false);
            this.player2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel player1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel player2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel banco;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolTip redo;
        private System.Windows.Forms.ToolTip undo;
        private System.Windows.Forms.ToolTip exit;
        private System.Windows.Forms.TextBox hienchat;
        private System.Windows.Forms.TextBox nhapchat;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolTip ruless;
        private System.Windows.Forms.ToolTip sendd;
        private System.Windows.Forms.TextBox name1;
        private System.Windows.Forms.TextBox name2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolTip emoji;
        private System.Windows.Forms.Button rules;
        private System.Windows.Forms.ToolTip newgame;
    }
}

