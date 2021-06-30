
namespace caro
{
    partial class playcom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(playcom));
            this.back = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.PowderBlue;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.back.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.back.Image = global::caro.Properties.Resources.d1dcfb___Pale_Lavender_Color_Image___Schemecolor;
            this.back.Location = new System.Drawing.Point(60, 206);
            this.back.Margin = new System.Windows.Forms.Padding(2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(175, 50);
            this.back.TabIndex = 12;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.PowderBlue;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.start.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.start.Image = global::caro.Properties.Resources.d1dcfb___Pale_Lavender_Color_Image___Schemecolor;
            this.start.Location = new System.Drawing.Point(327, 206);
            this.start.Margin = new System.Windows.Forms.Padding(2);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(175, 50);
            this.start.TabIndex = 11;
            this.start.Text = "Start Game";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(146, 90);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 32);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Player1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(21, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Your Name 1:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(160, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "2 Players / Com";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(146, 140);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(324, 32);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "Player2";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Your Name 2:";
            // 
            // playcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(228)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(564, 311);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.back);
            this.Controls.Add(this.start);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(580, 350);
            this.MinimumSize = new System.Drawing.Size(580, 350);
            this.Name = "playcom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Caro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
    }
}