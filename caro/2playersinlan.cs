using System;
using System.Windows.Forms;
using socketmanager;
using System.Threading;
using socketdata;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace caro
{
    public partial class _2playersinlan : Form
    {
        public _2playersinlan()
        {
            InitializeComponent();
        }
        
        
        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            menu menu = new menu();
            menu.Show();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string ip = txbIP.Text;
            int mod = 1;
            Caro caro = new Caro(name, ip, mod);
            caro.Show();
            this.Hide();
        }

        private void _2playersinlan_Shown(object sender, EventArgs e)
        {
            SocketManager Socket = new SocketManager();
            txbIP.Text = Socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(txbIP.Text))
                txbIP.Text = Socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
        }
    }
}

