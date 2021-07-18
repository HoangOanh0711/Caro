using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace caro
{
    public partial class playAI : Form
    {
        public playAI()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string yourname1 = tbName.Text;
            string yourname2 = "Computer";
            int mod = 3;
            Caro caro = new Caro(yourname1, yourname2, mod);
            caro.Show();
            this.Hide();

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            menu menu = new menu();
            menu.Show();
        }
    }
}
