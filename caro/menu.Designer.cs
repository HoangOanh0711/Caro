
namespace caro
{
    partial class menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.twoplay = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.playcom = new System.Windows.Forms.Button();
            this.playvscom = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.instructions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // twoplay
            // 
            this.twoplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.twoplay.BackColor = System.Drawing.Color.Transparent;
            this.twoplay.BackgroundImage = global::caro.Properties.Resources.xanhnhat;
            this.twoplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoplay.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.twoplay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.twoplay.Location = new System.Drawing.Point(91, 265);
            this.twoplay.Margin = new System.Windows.Forms.Padding(2);
            this.twoplay.Name = "twoplay";
            this.twoplay.Size = new System.Drawing.Size(250, 40);
            this.twoplay.TabIndex = 0;
            this.twoplay.Text = "2 Players in LAN";
            this.twoplay.UseVisualStyleBackColor = false;
            this.twoplay.Click += new System.EventHandler(this.twoplay_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::caro.Properties.Resources.tic_tac_toe;
            this.pictureBox1.Location = new System.Drawing.Point(91, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // playcom
            // 
            this.playcom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playcom.BackColor = System.Drawing.Color.Transparent;
            this.playcom.BackgroundImage = global::caro.Properties.Resources.xanhnhat;
            this.playcom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playcom.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playcom.Location = new System.Drawing.Point(91, 309);
            this.playcom.Margin = new System.Windows.Forms.Padding(2);
            this.playcom.Name = "playcom";
            this.playcom.Size = new System.Drawing.Size(250, 40);
            this.playcom.TabIndex = 4;
            this.playcom.Text = "2 Players / Com";
            this.playcom.UseVisualStyleBackColor = false;
            this.playcom.Click += new System.EventHandler(this.playcom_Click);
            // 
            // playvscom
            // 
            this.playvscom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playvscom.BackColor = System.Drawing.Color.Transparent;
            this.playvscom.BackgroundImage = global::caro.Properties.Resources.xanhnhat;
            this.playvscom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playvscom.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playvscom.Location = new System.Drawing.Point(91, 353);
            this.playvscom.Margin = new System.Windows.Forms.Padding(2);
            this.playvscom.Name = "playvscom";
            this.playvscom.Size = new System.Drawing.Size(250, 40);
            this.playvscom.TabIndex = 5;
            this.playvscom.Text = "Player vs Com";
            this.playvscom.UseVisualStyleBackColor = false;
            this.playvscom.Click += new System.EventHandler(this.playvscom_Click);
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.BackgroundImage = global::caro.Properties.Resources.xanhnhat;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exit.Location = new System.Drawing.Point(91, 441);
            this.exit.Margin = new System.Windows.Forms.Padding(2);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(250, 40);
            this.exit.TabIndex = 6;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // instructions
            // 
            this.instructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instructions.BackColor = System.Drawing.Color.Transparent;
            this.instructions.BackgroundImage = global::caro.Properties.Resources.xanhnhat;
            this.instructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instructions.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.instructions.Location = new System.Drawing.Point(91, 397);
            this.instructions.Margin = new System.Windows.Forms.Padding(2);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(250, 40);
            this.instructions.TabIndex = 7;
            this.instructions.Text = "Instructions";
            this.instructions.UseVisualStyleBackColor = false;
            this.instructions.Click += new System.EventHandler(this.instructions_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(214)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(434, 491);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.playvscom);
            this.Controls.Add(this.playcom);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.twoplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(450, 530);
            this.MinimumSize = new System.Drawing.Size(450, 530);
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button twoplay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button playcom;
        private System.Windows.Forms.Button playvscom;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button instructions;
    }
}