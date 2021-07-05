using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using socketmanager;


namespace caro
{
    public partial class emoji : Form
    {
        public delegate void truyenicon(int sohinh);
        public truyenicon bieutuong;
        public emoji()
        {
            InitializeComponent();
        }       

        private void emoji_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bieutuong(1);
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            bieutuong(2);
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            bieutuong(3);
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            bieutuong(4);
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            bieutuong(5);
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            bieutuong(6);
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            bieutuong(7);
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bieutuong(8);
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bieutuong(9);
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            bieutuong(10);
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            bieutuong(11);
            this.Close();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            bieutuong(12);
            this.Close();
        }
    }
}
