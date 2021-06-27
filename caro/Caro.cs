using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using socketdata;
using socketmanager;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace caro
{

    public partial class Caro : Form
    {
        #region Properties
        GameBoard board;
        SocketManager socket;
        string IP = "127.0.0.1";
        int mode = 0;
        string sohinh;
        string name;
        private int _ticks;
        Bitmap haha = new Bitmap(Application.StartupPath + "\\Resources\\haha.png");
        Bitmap sad = new Bitmap(Application.StartupPath + "\\Resources\\sad.png");
        Bitmap angry = new Bitmap(Application.StartupPath + "\\Resources\\angry.png");
        int icon;
        int scoX, scoO;
        public int ScoX { get => scoX; }
        public int ScoO { get => scoO; }


        public Caro()
        {
            InitializeComponent();
            board = new GameBoard(banco);
            board.GameOver += Board_GameOver;
            //board.PlayerClicked += Board_PlayerClicked;
            NewGame();
            board.StartAI();
        }
        #endregion

        public Caro(string yourname1, string yourname2, int gameMode)
        {
            InitializeComponent();
            mode = gameMode;
            if (mode == 2 || mode == 3)
            {
                label1.Text = yourname1;
                label2.Text = yourname2;
            }
            if (mode == 1)
            {
                socket = new SocketManager();
                this.name = yourname1;
                IP = yourname2;
                hienchat.Enabled = true;
                nhapchat.Enabled = true;
                send.Enabled = true;
            }
            board = new GameBoard(banco);
            board.GameOver += Board_GameOver;
            //board.PlayerClicked += Board_PlayerClicked;
            NewGame();
        }
        #region Methods
        void NewGame()
        {
            //pgb_CountDown.Value = 0;
            //tm_CountDown.Stop();

            //undoToolStripMenuItem.Enabled = true;
            //redoToolStripMenuItem.Enabled = true;

            //btn_Undo.Enabled = true;
            //btn_Redo.Enabled = true;
            board.ListPlayers = new List<Player>()
            {
                new Player(label1.Text, Image.FromFile(Application.StartupPath + "\\Resources\\ava2.png"),
                                        Image.FromFile(Application.StartupPath + "\\Resources\\x.png"),
                                        pictureBox3),

                new Player(label2.Text, Image.FromFile(Application.StartupPath + "\\Resources\\ava1.png"),
                                   Image.FromFile(Application.StartupPath + "\\Resources\\o.png"),
                                   pictureBox4)
            };
            scoO = scoX = 0;
            board.DrawGameBoard();
        }
        void EndGame()
        {
            button1.Enabled = false;
            button2.Enabled = false;

            banco.Enabled = false;
        }

        void update_Score(int winner)
        {
            if (winner == 1)
                scoX++;
            else if (winner == 2)
                scoO++;
            textBox1.Text = ScoO.ToString();
            textBox2.Text = ScoX.ToString();
        }

        private void Caro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
                Application.Exit();
            }
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                }
                catch { }
            }
        }

        private void Board_GameOver(object sender, EventArgs e)
        {
            EndGame();

            if (board.PlayMode == 1)
                socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point()));
        }
        #endregion

        #region Button
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            board.Undo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            board.Redo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void send_Click(object sender, EventArgs e)
        {
            if (nhapchat.Text == "")
            {
                sendicon();
            }
            else
            {
                if (socket.IsServer == true)
                {
                    hienchat.Text += "- " + "" + label1.Text + ": " + nhapchat.Text + "\r\n";
                    nhapchat.Text = "";
                    socket.Send(new SocketData((int)SocketCommand.SEND_MESSAGE, hienchat.Text, new Point()));
                }
                else
                {
                    hienchat.Text += "- " + "" + label2.Text + ": " + nhapchat.Text + "\r\n";
                    nhapchat.Text = "";
                    socket.Send(new SocketData((int)SocketCommand.SEND_MESSAGE, hienchat.Text, new Point()));
                }
            }
            Listen();

        }
        #endregion

        #region Lan
        private void Caro_Load(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                Connect();
            }

        }
        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                //case (int)SocketCommand.SEND_POINT:
                //    // Có thay đổi giao diện muốn chạy ngọt phải để trong đây
                //    this.Invoke((MethodInvoker)(() =>
                //    {
                //        board.OtherPlayerClicked(data.Point);
                //        pn_GameBoard.Enabled = true;

                //        pgb_CountDown.Value = 0;
                //        tm_CountDown.Start();

                //        undoToolStripMenuItem.Enabled = true;
                //        redoToolStripMenuItem.Enabled = true;

                //        btn_Undo.Enabled = true;
                //        btn_Redo.Enabled = true;
                //    }));
                //    break;

                case (int)SocketCommand.SEND_MESSAGE:
                    hienchat.Text = data.Message;
                    break;

                case (int)SocketCommand.SEND_ICON:
                    switch (sohinh = data.Message)
                    {
                        case "1":
                            pictureBox5.Image = haha;
                            break;
                        case "2":
                            pictureBox6.Image = haha;
                            break;
                        case "3":
                            pictureBox5.Image = sad;
                            break;
                        case "4":
                            pictureBox6.Image = sad;
                            break;
                        case "5":
                            pictureBox5.Image = angry;
                            break;
                        case "6":
                            pictureBox6.Image = angry;
                            break;
                        case "7":
                            pictureBox6.Image = null;
                            pictureBox5.Image = null;
                            break;
                    }
                    break;

                //    case (int)SocketCommand.NEW_GAME:
                //        this.Invoke((MethodInvoker)(() =>
                //        {
                //            NewGame();
                //            pn_GameBoard.Enabled = false;
                //        }));
                //        break;

                //    case (int)SocketCommand.UNDO:
                //        this.Invoke((MethodInvoker)(() =>
                //        {
                //            pgb_CountDown.Value = 0;
                //            board.Undo();
                //        }));
                //        break;

                //    case (int)SocketCommand.REDO:
                //        this.Invoke((MethodInvoker)(() =>
                //        {
                //            // pgb_CountDown.Value = 0;
                //            board.Redo();
                //        }));
                //        break;

                //    case (int)SocketCommand.END_GAME:
                //        this.Invoke((MethodInvoker)(() =>
                //        {
                //            EndGame();
                //            MessageBox.Show(PlayerName + " đã chiến thắng ♥ !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }));
                //        break;

                //    case (int)SocketCommand.TIME_OUT:
                //        this.Invoke((MethodInvoker)(() =>
                //        {
                //            EndGame();
                //            MessageBox.Show("Hết giờ rồi !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }));
                //        break;

                //    case (int)SocketCommand.QUIT:
                //        this.Invoke((MethodInvoker)(() =>
                //        {
                //            tm_CountDown.Stop();
                //            EndGame();

                //            board.PlayMode = 2;
                //            socket.CloseConnect();

                //            MessageBox.Show("Đối thủ đã chạy mất dép", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }));
                //        break;

                default:
                    break;
            }
            Listen();
        }

        private void Caro_Shown(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                IP = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

                if (string.IsNullOrEmpty(IP))
                    IP = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }

        }

        private void Connect()
        {
            socket.IP = IP;
            if (!socket.ConnectServer())
            {
                socket.IsServer = true;
                socket.CreateServer();
                MessageBox.Show("Bạn đang là Server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label1.Text = name;
            }
            else
            {
                socket.IsServer = false;
                Listen();
                MessageBox.Show("Kết nối thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label2.Text = name;
            }
        }
        private void Listen()
        {
            Thread ListenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    ProcessData(data);
                }
                catch { }
            });

            ListenThread.IsBackground = true;
            ListenThread.Start();
        }
        #endregion

        #region icon
        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            if (_ticks == 2)
            {
                xoaicon();
                timer1.Stop();
                _ticks = 0;
                sohinh = "7";
                socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
            }
        }
        private void sendicon()
        {
            switch (icon)
            {
                case 0:
                    break;
                case 1:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = haha;
                        sohinh = "1";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = haha;
                        sohinh = "2";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 2:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = sad;
                        sohinh = "3";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = sad;
                        sohinh = "4";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 3:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = angry;
                        sohinh = "5";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = angry;
                        sohinh = "6";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                default:
                    break;
            }
            timer1.Start();
            Listen();
        }

        private void xoaicon()
        {
            pictureBox5.Image = null;
            pictureBox6.Image = null;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            icon = cb.SelectedIndex;
        }
    }
    #endregion
}
