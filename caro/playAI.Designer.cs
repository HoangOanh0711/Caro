
namespace caro
{
    partial class playAI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(playAI));
            this.back = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.PowderBlue;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.back.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.back.Image = global::caro.Properties.Resources.d1dcfb___Pale_Lavender_Color_Image___Schemecolor;
            this.back.Location = new System.Drawing.Point(61, 181);
            this.back.Margin = new System.Windows.Forms.Padding(2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(175, 50);
            this.back.TabIndex = 20;
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
            this.start.Location = new System.Drawing.Point(328, 181);
            this.start.Margin = new System.Windows.Forms.Padding(2);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(175, 50);
            this.start.TabIndex = 19;
            this.start.Text = "Start Game";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbName.Location = new System.Drawing.Point(144, 102);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(347, 32);
            this.tbName.TabIndex = 18;
            this.tbName.Text = "Player";
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(31, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Your Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(123, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 46);
            this.label1.TabIndex = 16;
            this.label1.Text = "Play With Computer";
            // 
            // playAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(228)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(564, 291);
            this.Controls.Add(this.back);
            this.Controls.Add(this.start);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(580, 330);
            this.MinimumSize = new System.Drawing.Size(580, 330);
            this.Name = "playAI";
            this.Text = "Caro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}