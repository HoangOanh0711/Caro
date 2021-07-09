using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace caro
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void twoplay_Click(object sender, EventArgs e)
        {
            _2playersinlan _2playersinlan = new _2playersinlan();
            _2playersinlan.Show();
            this.Hide();

        }

        private void playcom_Click(object sender, EventArgs e)
        {
            playcom player1 = new playcom();
            player1.Show();
            this.Hide();
        }

        private void playvscom_Click(object sender, EventArgs e)
        {
            playAI PlayAI = new playAI();
            PlayAI.Show();
            this.Hide();
        }


        private void menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
