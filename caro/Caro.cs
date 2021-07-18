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
        string name;
        int icon, temp, scoX, scoO;
        public int ScoX { get => scoX; }
        public int ScoO { get => scoO; }


        string sohinh;
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
        

        public Caro(string yourname1, string yourname2, int gameMode)
        {
            InitializeComponent();
            this.mode = gameMode;  
            scoO = scoX = 0;

            if (mode == 2 || mode == 3)   // chế độ chơi chung 1 máy và chơi cùng AI
            {
                name1.Text = yourname1;
                name2.Text = yourname2;
                board = new GameBoard(banco);   //khởi tạo và truyền panel bàn cờ vào hàm Gameboard
                setname();  //khởi tạo tên người chơi
                board.PlayMode = mode;  
                board.GameOver += Board_GameOver;   // Set chế độ tính gameover
                board.PlayerClicked += Board_PlayerClicked;   // Set chế độ truyền quân khi dùng lan
                NewGame();  //Gọi hàm NewGame
            }
            if (mode == 1)    // chế độ chơi 2 người trong LAN
            {
                socket = new SocketManager();   // Khởi tạo socket
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
            //Hàm khởi tạo người chơi, truyền thông tin cần thiết vào 

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

            board.DrawGameBoard();  //Vẽ bàn cờ, tạo các nút cờ đánh
        }

        void EndGame()  //Hàm gọi mỗi khi kết thúc trận
        {
            button1.Enabled = false;
            button2.Enabled = false;
            banco.Enabled = false;
        }

        void update_Score(int winner)  //Cập nhật điểm 
        {
            if (winner == 1) // nếu player1 win thì cộng điểm
                scoX++;
            else if (winner == 2)  // nếu player2 win thì cộng điểm
                scoO++;
            textBox1.Text = ScoO.ToString();
            textBox2.Text = ScoX.ToString();
        }

        private void Caro_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                //this.Hide();
                e.Cancel=true;

                return;
            }
            
            if (this.mode == 1)
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                    //Gửi SocketCommand QUIT
                    socket.CloseConnect();
                    //Đóng tất cả kết nối
                }
                catch { socket.CloseConnect(); }
            }
            //Khởi tạo và trở về menu
            if (this.mode != 1)
            {
                menu _menu = new menu();
                _menu.Show();
            }
        }

        private void Board_GameOver(object sender, EventArgs e)
        {
            //Mỗi khi kết thúc 1 game hàm sẽ được gọi ra để tính điểm và thông báo
            EndGame();
            temp = board.CurrentPlayer; //xét lượt chơi hiện tại
            if (temp == 1)  //nếu lượt chơi là player1
            {
                update_Score(2); //cộng điểm cho player2
            }
            else if (temp == 0)   //và ngược lại
                update_Score(1);
            MessageBox.Show(board.ListPlayers[temp == 1 ? 0 : 1].Name + " đã chiến thắng ♥ !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Hiện Tên người chiên thắng
            if (board.PlayMode == 1)
                socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point()));
            //Nếu là modegame1, gửi SocketCommand ENGGAME
        }
        #endregion

        #region Button

        private void button3_Click(object sender, EventArgs e)  //Nút EXIT
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            board.Undo();  //Gọi hàm thực hiện lệnh Undo
            if (board.PlayMode == 1)
                socket.Send(new SocketData((int)SocketCommand.UNDO, "", new Point()));
            //Gửi SocketCommand UNDO
        }

        private void button2_Click(object sender, EventArgs e)
        {
            board.Redo();   //Gọi hàm thực hiện lệnh Redo
            if (board.PlayMode == 1)
                socket.Send(new SocketData((int)SocketCommand.REDO, "", new Point()));
            //Gửi SocketCommand REDO
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewGame();
            //Nút khởi tạo game mới
            if (board.PlayMode == 1)
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
                    //Gửi SocketCommand NewGame
                    if (socket.IsServer == false)
                        banco.Enabled = false;
                }
                catch { }
            }

        }

        private void send_Click(object sender, EventArgs e)
        {
            if (nhapchat.Text == "")
                return;
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

        private void button6_Click(object sender, EventArgs e) //Nút này dành riêng cho ModeGame1 
        {
            try
            {
                socket.Send(new SocketData((int)SocketCommand.START, "", new Point()));
                //Gửi SocketCommand Start
                socket.Send(new SocketData((int)SocketCommand.NAMESE, name1.Text, new Point()));
                ////Gửi SocketCommand NAMESE, Truyền tên của người chơi ở máy server để máy client cập nhật tên
                Start(); //Gọi hàm Start
                Listen();  //Bắt đầu tạo Listen để nhận tất thông tin điều kiện
            }
            catch
            {
                MessageBox.Show("Vui lòng chờ bạn chơi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Nếu chưa ai vào phòng thì không thể bắt đầu
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
            rules Rule = new rules(); //Hiện thị hướng dẫn game
            Rule.Show();
        }
        #endregion

        #region Lan
        private void Board_PlayerClicked(object sender, BtnClickEvent e)
        {
            // Mỗi khi click vào 1 quân cờ sẽ được gọi hàm này
            if (board.PlayMode == 1)   //Đối với chế độ LAN
            {
                try
                {
                    banco.Enabled = false;
                    socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));
                    //Gửi toạ độ nút vừa đánh tới máy đối thủ

                    button1.Enabled = false;
                    button2.Enabled = false;

                    Listen();
                    //Lắng nghe những gì người chơi kia gửi lại
                }
                catch
                {
                    EndGame();
                    MessageBox.Show("Không có kết nối nào tới máy đối thủ", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Báo lỗi khi không có kết nối giữa 2 máy
                }
            }
        }
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
                        //Nhận và thực hiện cập nhật nút lên bàn cờ 
                        board.OtherPlayerClicked(data.Point);
                        banco.Enabled = true;

                        button1.Enabled = true;
                        button2.Enabled = true;
                    }));
                    break;

                case (int)SocketCommand.SEND_MESSAGE:
                    hienchat.Text = data.Message; //cập nhật nội dung chat lên ô hiện chat
                    break;

                case (int)SocketCommand.NAMECL:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        name2.Text = data.Message;  //cập nhật tên của player2 lên textbox
                        board.ListPlayers[1].Name = data.Message;  //cập nhật tên của player2 vào listplayer
                    }));
                    break;

                case (int)SocketCommand.NAMESE:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        name1.Text = data.Message;  //cập nhật tên của player1 lên textbox
                        board.ListPlayers[0].Name = data.Message;  //cập nhật tên của player1 vào listplayer
                        socket.Send(new SocketData((int)SocketCommand.NAMECL, name2.Text, new Point()));
                        //gửi tên của player2 cho player1 cập nhật
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
                        NewGame();   //Khởi tạo newgame
                        if (this.mode == 1 && socket.IsServer == false)
                            banco.Enabled = false;

                    }));
                    break;

                case (int)SocketCommand.UNDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        board.Undo(); //thực hiện lệnh undo
                    }));
                    break;

                case (int)SocketCommand.REDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        board.Redo();  //thực hiện lệnh redo
                    }));
                    break;

                case (int)SocketCommand.END_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        EndGame();  //thực hiện hàm endgame
                    }));
                    break;

                case (int)SocketCommand.QUIT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        banco.Controls.Clear();
                        EndGame();
                        socket.CloseConnect();  //đóng kết nối
                        MessageBox.Show("Đối thủ đã thoát khỏi phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        socket.IsServer = true;
                        Connect();  //tạo ra 1 kết nối mới
                    }));
                    break;

                case (int)SocketCommand.START:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        Start();  //thực hiện hàm start
                    }));
                    break;
            }
            Listen();
        }
        private void Start()
        {
            // enable những chức năng có của game và thực hiện newgame
            button6.Visible = false;
            button4.Enabled = true;
            setname();
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
                //chỉ hiện thị nút start cho chủ phòng
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
            //disable những chức năng cho đến khi bấm nút start
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
            if (socket.IsServer == false)
            {
                //nếu phòng đã đủ server và client thì sẽ được thoát ra
                MessageBox.Show("Phòng đã đầy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
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

        private void rules_Click(object sender, EventArgs e)
        {
            rules rule = new rules();
            rule.Show();
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
