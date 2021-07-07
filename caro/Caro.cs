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
        
        string IP;
        int mode = 0;
        string sohinh;
        string name;
        private int _ticks;
        Bitmap happy1 = new Bitmap(Application.StartupPath + "\\Resources\\happy (1).png");
        Bitmap happy = new Bitmap(Application.StartupPath + "\\Resources\\happy.png");
        Bitmap sad = new Bitmap(Application.StartupPath + "\\Resources\\sad1.png");
        Bitmap crying = new Bitmap(Application.StartupPath + "\\Resources\\crying.png");
        Bitmap cute = new Bitmap(Application.StartupPath + "\\Resources\\cute.png");
        Bitmap laughing2 = new Bitmap(Application.StartupPath + "\\Resources\\laughing (2).png");
        Bitmap laughing = new Bitmap(Application.StartupPath + "\\Resources\\laughing.png");
        Bitmap serious = new Bitmap(Application.StartupPath + "\\Resources\\serious.png");
        Bitmap surprised = new Bitmap(Application.StartupPath + "\\Resources\\surprised.png");
        Bitmap angry = new Bitmap(Application.StartupPath + "\\Resources\\angry1.png");
        Bitmap angry1 = new Bitmap(Application.StartupPath + "\\Resources\\angry11.png");
        Bitmap vain = new Bitmap(Application.StartupPath + "\\Resources\\vain.png");
        int icon, temp, scoX, scoO;
        public int ScoX { get => scoX; }
        public int ScoO { get => scoO; }

        public Caro(string yourname1, string yourname2, int gameMode)
        {
            InitializeComponent();
            this.mode = gameMode;
            scoO = scoX = 0;

            if (mode == 2 || mode == 3)
            {
                name1.Text = yourname1;
                name2.Text = yourname2;
                board = new GameBoard(banco);
                setname();
                board.PlayMode = mode;
                board.GameOver += Board_GameOver;
                board.PlayerClicked += Board_PlayerClicked;
                NewGame();
            }
            if (mode == 1)
            {
                socket = new SocketManager();
                this.name = yourname1;
                this.IP = yourname2;
                board = new GameBoard(banco);
                setname();
                board.PlayMode = mode;
                board.GameOver += Board_GameOver;
                board.PlayerClicked += Board_PlayerClicked;
            }

        }

        public Caro(int bieutuong)
        {
            this.icon = bieutuong;
            InitializeComponent();
        }

        public void setname()
        {
            board.ListPlayers = new List<Player>()
            {
                new Player(name1.Text,Image.FromFile(Application.StartupPath + "\\Resources\\x.png"),
                                        pictureBox3),

                new Player(name2.Text,Image.FromFile(Application.StartupPath + "\\Resources\\o.png"),
                                        pictureBox4)
            };
        }

        #endregion

        #region Methods

        void NewGame()
        {

            button1.Enabled = true;
            button2.Enabled = true;

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

        private void Board_PlayerClicked(object sender, BtnClickEvent e)
        {
            if (board.PlayMode == 1)
            {
                try
                {
                    banco.Enabled = false;
                    socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));

                    button1.Enabled = false;
                    button2.Enabled = false;

                    Listen();
                }
                catch
                {
                    EndGame();
                    MessageBox.Show("Không có kết nối nào tới máy đối thủ", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void Caro_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                e.Cancel = true;
                if (this.mode == 1)
                {
                    try
                    {
                        socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                        socket.CloseConnect();
                    }
                    catch { socket.CloseConnect(); }
                }
                Application.Exit();

            }
        }

        private void Board_GameOver(object sender, EventArgs e)
        {
            EndGame();
            temp = board.CurrentPlayer;
            if (temp == 1)
            {
                update_Score(2);
            }
            else if (temp == 0)
                update_Score(1);
            MessageBox.Show(board.ListPlayers[temp == 1 ? 0 : 1].Name + " đã chiến thắng ♥ !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (board.PlayMode == 1)
                socket.Send(new SocketData((int)SocketCommand.UNDO, "", new Point()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            board.Redo();
            if (board.PlayMode == 1)
                socket.Send(new SocketData((int)SocketCommand.REDO, "", new Point()));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewGame();

            if (board.PlayMode == 1)
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));

                    if (socket.IsServer == false)
                        banco.Enabled = false;
                }
                catch { }
            }

        }

        private void send_Click(object sender, EventArgs e)
        {
            sendicon();
            if (socket.IsServer == true)
            {
                hienchat.Text += "- " + "" + name1.Text + ": " + nhapchat.Text + "\r\n";
                nhapchat.Text = "";
                socket.Send(new SocketData((int)SocketCommand.SEND_MESSAGE, hienchat.Text, new Point()));
            }
            else
            {
                hienchat.Text += "- " + "" + name2.Text + ": " + nhapchat.Text + "\r\n";
                nhapchat.Text = "";
                socket.Send(new SocketData((int)SocketCommand.SEND_MESSAGE, hienchat.Text, new Point()));
            }
            Listen();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                socket.Send(new SocketData((int)SocketCommand.START, "", new Point()));
                socket.Send(new SocketData((int)SocketCommand.NAMESE, name1.Text, new Point()));
                Start();
                Listen();
            }
            catch
            {
                MessageBox.Show("Vui lòng chờ bạn chơi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            emoji i = new emoji();
            i.bieutuong = new emoji.truyenicon(loadicon);
            i.Show();
            i.FormClosed += DoAnyThing;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            rules Rule = new rules();
            Rule.Show();
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
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        board.OtherPlayerClicked(data.Point);
                        banco.Enabled = true;

                        button1.Enabled = true;
                        button2.Enabled = true;
                    }));
                    break;

                case (int)SocketCommand.SEND_MESSAGE:
                    hienchat.Text = data.Message;
                    break;

                case (int)SocketCommand.NAMECL:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        name2.Text = data.Message;
                        board.ListPlayers[1].Name = data.Message;
                    }));
                    break;

                case (int)SocketCommand.NAMESE:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        name1.Text = data.Message;
                        board.ListPlayers[0].Name = data.Message;
                        socket.Send(new SocketData((int)SocketCommand.NAMECL, name2.Text, new Point()));
                    }));
                    break;

                case (int)SocketCommand.SEND_ICON:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        switch (sohinh = data.Message)
                        {
                            case "1":
                                pictureBox5.Image = happy1;
                                break;
                            case "2":
                                pictureBox6.Image = happy1;
                                break;
                            case "3":
                                pictureBox5.Image = happy;
                                break;
                            case "4":
                                pictureBox6.Image = happy;
                                break;
                            case "5":
                                pictureBox5.Image = laughing;
                                break;
                            case "6":
                                pictureBox6.Image = laughing;
                                break;
                            case "7":
                                pictureBox5.Image = laughing2;
                                break;
                            case "8":
                                pictureBox6.Image = laughing2;
                                break;
                            case "9":
                                pictureBox5.Image = sad;
                                break;
                            case "10":
                                pictureBox6.Image = sad;
                                break;
                            case "11":
                                pictureBox5.Image = angry1;
                                break;
                            case "12":
                                pictureBox6.Image = angry1;
                                break;
                            case "13":
                                pictureBox5.Image = angry;
                                break;
                            case "14":
                                pictureBox6.Image = angry;
                                break;
                            case "15":
                                pictureBox5.Image = crying;
                                break;
                            case "16":
                                pictureBox6.Image = crying;
                                break;
                            case "17":
                                pictureBox5.Image = cute;
                                break;
                            case "18":
                                pictureBox6.Image = cute;
                                break;
                            case "19":
                                pictureBox5.Image = surprised;
                                break;
                            case "20":
                                pictureBox6.Image = surprised;
                                break;
                            case "21":
                                pictureBox5.Image = serious;
                                break;
                            case "22":
                                pictureBox6.Image = serious;
                                break;
                            case "23":
                                pictureBox5.Image = vain;
                                break;
                            case "24":
                                pictureBox6.Image = vain;
                                break;
                            case "25":
                                pictureBox6.Image = null;
                                pictureBox5.Image = null;
                                break;
                        }
                    }));
                    break;

                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        if (this.mode == 1 && socket.IsServer == false)
                            banco.Enabled = false;

                    }));
                    break;

                case (int)SocketCommand.UNDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        board.Undo();
                    }));
                    break;

                case (int)SocketCommand.REDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        board.Redo();
                    }));
                    break;

                case (int)SocketCommand.END_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        EndGame();
                    }));
                    break;

                case (int)SocketCommand.QUIT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        banco.Controls.Clear();
                        EndGame();
                        socket.CloseConnect();
                        MessageBox.Show("Đối thủ đã thoát khỏi phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Connect();
                    }));
                    break;

                case (int)SocketCommand.START:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        Start();
                    }));
                    break;

                default:
                    break;
            }
            Listen();
        }
        private void Start()
        {
            button6.Visible = false;
            button4.Enabled = true;

            button7.Enabled = true;
            send.Enabled = true;
            nhapchat.Enabled = true;
            NewGame();
            if (socket.IsServer == false)
            {
                banco.Enabled = false;
            }
        }

        private void beforeStart()
        {
            if (socket.IsServer == true)
            {
                button6.Visible = true;
                if (banco.Contains(button6))
                {
                    button6.BringToFront();
                }
            }
            if (socket.IsServer == false)
            {
                button6.Visible = false;
            }
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;

            button7.Enabled = false;
            send.Enabled = false;
            nhapchat.Enabled = false;
            hienchat.Clear();

        }

        private void Connect()
        {
            socket.IP = this.IP;
            if (!socket.ConnectServer())
            {
                socket.IsServer = true;
                socket.CreateServer();
                MessageBox.Show("Bạn đang là chủ phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                name1.Text = name;
                name2.Text = "";
            }
            else
            {
                socket.IsServer = false;
                Listen();
                MessageBox.Show("Kết nối thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Đợi chủ phòng bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                name2.Text = name;
                name1.Text = "";
            }
            beforeStart();
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
                icon = 0;
                xoaicon();
                timer1.Stop();
                _ticks = 0;
                sohinh = "25";
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
                        pictureBox5.Image = happy1;
                        sohinh = "1";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = happy1;
                        sohinh = "2";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 2:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = happy;
                        sohinh = "3";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = happy;
                        sohinh = "4";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 3:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = laughing;
                        sohinh = "5";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = laughing;
                        sohinh = "6";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 4:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = laughing2;
                        sohinh = "7";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = laughing2;
                        sohinh = "8";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 5:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = sad;
                        sohinh = "9";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = sad;
                        sohinh = "10";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 6:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = angry1;
                        sohinh = "11";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = angry1;
                        sohinh = "12";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 7:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = angry;
                        sohinh = "13";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = angry;
                        sohinh = "14";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 8:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = crying;
                        sohinh = "15";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = crying;
                        sohinh = "16";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 9:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = cute;
                        sohinh = "17";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = cute;
                        sohinh = "18";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 10:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = surprised;
                        sohinh = "19";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = surprised;
                        sohinh = "20";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 11:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = serious;
                        sohinh = "21";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = serious;
                        sohinh = "22";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                case 12:
                    if (socket.IsServer == true)
                    {
                        pictureBox5.Image = vain;
                        sohinh = "23";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    else
                    {
                        pictureBox6.Image = vain;
                        sohinh = "24";
                        socket.Send(new SocketData((int)SocketCommand.SEND_ICON, sohinh, new Point()));
                    }
                    break;
                default:
                    break;
            }
            timer1.Start();
            Listen();
        }

       
        void DoAnyThing(object sender, EventArgs e)
        {
            sendicon();
        }

        private void loadicon(int data)
        {
            icon = data;
        }

        private void xoaicon()
        {
            pictureBox5.Image = null;
            pictureBox6.Image = null;
        }

        
    }
    #endregion
}
