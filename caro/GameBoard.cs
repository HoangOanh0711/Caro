using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace caro
{
    class GameBoard
    {

        #region Properties
        private Panel board;

        private int currentPlayer;
        private TextBox playerName;
        private PictureBox turn1;
        private PictureBox turn2;


        private List<Player> listPlayers;
        private List<List<Button>> matrixPositions;

        private event EventHandler<BtnClickEvent> playerClicked;
        private event EventHandler gameOver;

        private Stack<PlayInfo> stkUndoStep;
        private Stack<PlayInfo> stkRedoStep;

        private int playMode = 0;
        private bool IsAI = false;

        public Panel Board
        {
            get { return board; }
            set { board = value; }
        }

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }



        public List<Player> ListPlayers
        {
            get { return listPlayers; }
            set { listPlayers = value; }
        }

        public List<List<Button>> MatrixPositions
        {
            get { return matrixPositions; }
            set { matrixPositions = value; }
        }

        public event EventHandler<BtnClickEvent> PlayerClicked
        {
            add { playerClicked += value; }
            remove { playerClicked -= value; }
        }

        public event EventHandler GameOver
        {
            add { gameOver += value; }
            remove { gameOver -= value; }
        }

        public Stack<PlayInfo> StkUndoStep
        {
            get { return stkUndoStep; }
            set { stkUndoStep = value; }
        }

        public Stack<PlayInfo> StkRedoStep
        {
            get { return stkRedoStep; }
            set { stkRedoStep = value; }
        }

        public int PlayMode
        {
            get { return playMode; }
            set { playMode = value; }
        }

        public PictureBox Turn1 { get => turn1; set => turn1 = value; }
        public PictureBox Turn2 { get => turn2; set => turn2 = value; }
        #endregion

        #region Intialize
        public GameBoard(Panel board)
        {
            this.Board = board;   //Nhận panel hiển thị từ form caro
            this.CurrentPlayer = 0;  //Lượt chơi 


        }
        #endregion

        #region Methods       
        public void DrawGameBoard()
        {
            board.Enabled = true;
            board.Controls.Clear();  //Xoá hết các nút đang có

            StkUndoStep = new Stack<PlayInfo>();   // khởi tạo bộ nhớ stack để undo
            StkRedoStep = new Stack<PlayInfo>();   // khởi tạo bộ nhớ stack để redo

            this.CurrentPlayer = 0;
            ChangePlayer();   //hàm cập nhật lượt chơi

            //Thông tin toạ độ của nút
            int LocX, LocY;
            //Thông tin kích thước bàn cờ
            int nRows = Constance.nRows;
            int nCols = Constance.nCols;

            Button OldButton = new Button();  //Khởi tạo 1 nút ảo để lấy vị trí tạo
            OldButton.Width = OldButton.Height = 0;
            OldButton.Location = new Point(0, 0);

            MatrixPositions = new List<List<Button>>();  //khởi tạo ma trận để lưu sơ đồ nút

            for (int i = 0; i < nRows; i++)  //thực hiện các vòng lặp để tạo từng cột từ hàng nút
            {
                MatrixPositions.Add(new List<Button>());

                for (int j = 0; j < nCols; j++)
                {
                    LocX = OldButton.Location.X + OldButton.Width;
                    LocY = OldButton.Location.Y;

                    Button btn = new Button()  //Tạo 1 nút với các thông số được truyền vào
                    {
                        Width = Constance.CellWidth,   // Kích cỡ được ấn định như 1 const trong hàm Constance
                        Height = Constance.CellHeight,

                        Location = new Point(LocX, LocY),
                        Tag = i.ToString(), // Để xác định button đang ở hàng nào

                        BackColor = Color.FromArgb(230, 218, 207),
                        BackgroundImageLayout = ImageLayout.Stretch

                    };

                    btn.Click += btn_Click;
                    MatrixPositions[i].Add(btn);  //thêm nút đã tạo vào trong ma trận 

                    Board.Controls.Add(btn);
                    OldButton = btn;
                }

                OldButton.Location = new Point(0, OldButton.Location.Y + Constance.CellHeight);
                OldButton.Width = OldButton.Height = 0;
            }
        }


        private Point GetButtonCoordinate(Button btn)
        {
            int Vertical = Convert.ToInt32(btn.Tag);
            int Horizontal = MatrixPositions[Vertical].IndexOf(btn);

            Point Coordinate = new Point(Horizontal, Vertical);
            return Coordinate;
        }

        //Hàm Tính thắng thua 
        #region Handling winning and losing  
        #region Checkchess
        //Xét theo đường ngang
        private bool CheckHorizontal(int CurrRow, int CurrCol, Image PlayerSymbol)
        {
            int NumCellsToWin = 5;
            int Count;

            if (CurrRow > Constance.nCols - 5)
                return false;
            //Xét theo toạ độ nút vừa đánh, nếu những nút lân cận giống symbol thì sẽ được cộng, đủ 5 điểm sẽ thông báo thắng
            for (Count = 1; Count < NumCellsToWin; Count++)
                if (MatrixPositions[CurrRow][CurrCol + Count].BackgroundImage != PlayerSymbol)
                    return false;

            // Xét chặn 2 đầu
            if (CurrCol == 0 || CurrCol + Count == Constance.nCols)
                return true;
            //Nếu trước hoặc sau hàng đang xét không có symbol của đối thủ thì được xét thắng
            if (MatrixPositions[CurrRow][CurrCol - 1].BackgroundImage == null || MatrixPositions[CurrRow][CurrCol + Count].BackgroundImage == null)
            {
                for (Count = 0; Count < NumCellsToWin; Count++)
                    MatrixPositions[CurrRow][CurrCol + Count].BackColor = Color.Lime; //Khi thắng ô được tô màu xanh
                return true;
            }
            return false;
        }

        //Xét theo dường thẳng
        private bool CheckVertical(int CurrRow, int CurrCol, Image PlayerSymbol)
        {
            int NumCellsToWin = 5;
            int Count;

            if (CurrRow > Constance.nRows - 5)
                return false;

            for (Count = 1; Count < NumCellsToWin; Count++)
                if (MatrixPositions[CurrRow + Count][CurrCol].BackgroundImage != PlayerSymbol)
                    return false;

            // Xét chặn 2 đầu
            if (CurrRow == 0 || CurrRow + Count == Constance.nRows)
                return true;

            if (MatrixPositions[CurrRow - 1][CurrCol].BackgroundImage == null || MatrixPositions[CurrRow + Count][CurrCol].BackgroundImage == null)
            {
                for (Count = 0; Count < NumCellsToWin; Count++)
                    MatrixPositions[CurrRow + Count][CurrCol].BackColor = Color.Lime;
                return true;
            }

            return false;
        }
        //Xét theo đường chéo chính
        private bool CheckMainDiag(int CurrRow, int CurrCol, Image PlayerSymbol)
        {
            int NumCellsToWin = 5;
            int Count;

            if (CurrRow > Constance.nRows - 5 || CurrCol > Constance.nCols - 5)
                return false;

            for (Count = 1; Count < NumCellsToWin; Count++)
                if (MatrixPositions[CurrRow + Count][CurrCol + Count].BackgroundImage != PlayerSymbol)
                    return false;

            // Xét chặn 2 đầu
            if (CurrRow == 0 || CurrRow + Count == Constance.nRows || CurrCol == 0 || CurrCol + Count == Constance.nCols)
                return true;

            if (MatrixPositions[CurrRow - 1][CurrCol - 1].BackgroundImage == null || MatrixPositions[CurrRow + Count][CurrCol + Count].BackgroundImage == null)
            {
                for (Count = 0; Count < NumCellsToWin; Count++)
                    MatrixPositions[CurrRow + Count][CurrCol + Count].BackColor = Color.Lime;
                return true;
            }

            return false;
        }
        //Xét theo đường chéo phụ
        private bool CheckExtraDiag(int CurrRow, int CurrCol, Image PlayerSymbol)
        {
            int NumCellsToWin = 5;
            int Count;

            if (CurrRow < NumCellsToWin - 1 || CurrCol > Constance.nCols - NumCellsToWin)
                return false;

            for (Count = 1; Count < NumCellsToWin; Count++)
                if (MatrixPositions[CurrRow - Count][CurrCol + Count].BackgroundImage != PlayerSymbol)
                    return false;

            // Xét chặn 2 đầu
            if (CurrRow == 4 || CurrRow == Constance.nRows - 1 || CurrRow == 0 || CurrRow + Count == Constance.nRows)
                return true;

            if (MatrixPositions[CurrRow + 1][CurrCol - 1].BackgroundImage == null || MatrixPositions[CurrRow - Count][CurrCol + Count].BackgroundImage == null)
            {
                for (Count = 0; Count < NumCellsToWin; Count++)
                    MatrixPositions[CurrRow - Count][CurrCol + Count].BackColor = Color.Lime;
                return true;
            }

            return false;
        }
        #endregion

        //Hàm isendgame gọi xét các điều kiện thắng
        private bool IsEndGame()
        {
            if (StkUndoStep.Count == Constance.nRows * Constance.nCols)
            {
                MessageBox.Show("Hòa cờ !!!");
                return true;
            }

            bool IsWin = false;
            //Gọi lần lượt các Hàm xét
            foreach (PlayInfo btn in StkUndoStep)
            {
                if (CheckHorizontal(btn.Point.Y, btn.Point.X, btn.Symbol))
                    IsWin = true;

                if (CheckVertical(btn.Point.Y, btn.Point.X, btn.Symbol))
                    IsWin = true;

                if (CheckMainDiag(btn.Point.Y, btn.Point.X, btn.Symbol))
                    IsWin = true;

                if (CheckExtraDiag(btn.Point.Y, btn.Point.X, btn.Symbol))
                    IsWin = true;
            }

            if (IsWin)
                return IsWin;
            return false;
        }

        #endregion

        #region Undo & Redo
        public bool Undo()
        {
            if (StkUndoStep.Count <= 1) //chỉ undo khi trong stack có nhiều hơn 1 quân cờ
                return false;
            //peek là lấy cái vào đầu tiên
            //pos là lấy cái vào sau cùng
            PlayInfo OldPos = StkUndoStep.Peek();
            CurrentPlayer = OldPos.CurrentPlayer == 1 ? 0 : 1;  //lùi lượt chơi lại

            bool IsUndo1 = UndoAStep();
            bool IsUndo2 = UndoAStep();

            return IsUndo1 && IsUndo2;
        }
        private bool UndoAStep()
        {
            if (StkUndoStep.Count <= 0)
                return false;

            PlayInfo OldPos = StkUndoStep.Pop();
            StkRedoStep.Push(OldPos);
            //lấy toạ độ của quân vừa đánh và trả nó về giá trị null, xoá symbol ra khỏi nút
            Button btn = MatrixPositions[OldPos.Point.Y][OldPos.Point.X];
            btn.BackgroundImage = null;

            if (StkUndoStep.Count <= 0)
                CurrentPlayer = 0;
            else
                OldPos = StkUndoStep.Peek();

            ChangePlayer();

            return true;
        }
        public bool Redo()
        {
            if (StkRedoStep.Count <= 1) 
                return false;

            PlayInfo OldPos = StkRedoStep.Peek();
            CurrentPlayer = OldPos.CurrentPlayer;

            bool IsRedo1 = RedoAStep();
            bool IsRedo2 = RedoAStep();

            return IsRedo1 && IsRedo2;
        }

        private bool RedoAStep()
        {
            if (StkRedoStep.Count <= 0)
                return false;

            PlayInfo OldPos = StkRedoStep.Pop();
            StkUndoStep.Push(OldPos);

            Button btn = MatrixPositions[OldPos.Point.Y][OldPos.Point.X];
            btn.BackgroundImage = OldPos.Symbol;

            if (StkRedoStep.Count <= 0)
                CurrentPlayer = OldPos.CurrentPlayer == 1 ? 0 : 1;
            else
                OldPos = StkRedoStep.Peek();

            ChangePlayer();

            return true;
        }

        #endregion

        #region 2 players
        private void ChangePlayer()
        {
            //Hàm thực hiện việc thay đổi lượt chơi
            int temp = CurrentPlayer; //lấy ra lượt chơi hiện tại
            temp = temp == 1 ? 0 : 1;   
            listPlayers[CurrentPlayer].Frame.Visible = true;   //hiện thị icon thể hiện lượt chơi của người tới lượt
            listPlayers[temp].Frame.Visible = false; //ẩn icon thể hiện lượt chơi của người chưa tới lượt
        }
        //event này sẽ hoạt động mỗi khi đánh 1 quân cờ, 
        private void btn_Click(object sender, EventArgs e) 
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null) //Nếu ô đó đã có người đánh sẽ thoát ra và không làm gì
                return;

            btn.BackgroundImage = ListPlayers[CurrentPlayer].Symbol;  //Đặt symbol người đánh vào ô cờ

            StkUndoStep.Push(new PlayInfo(GetButtonCoordinate(btn), CurrentPlayer, btn.BackgroundImage));
            //thêm quân cờ đánh vào bộ nhớ
            StkRedoStep.Clear();

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1; //Thay đổi lượt chơi
            ChangePlayer();  //Cập nhật lượt chơi

            if (playerClicked != null)      
                playerClicked(this, new BtnClickEvent(GetButtonCoordinate(btn)));
            if (IsEndGame())
                EndGame();   //Kiểm tra có thắng hay chưa, nếu rồi sẽ gọi hàm Endgame
            if (!(IsAI) && playMode == 3)
                StartAI();   //Xét và khởi tạo chế độ AI

            IsAI = false;

        }
        public void EndGame()
        {
            if (gameOver != null)
            {
                gameOver(this, new EventArgs());  //Dừng game lại

            }

        }
        public void OtherPlayerClicked(Point point)   //Hàm xử lý dành cho modegame1
        {
            //Sau khi nhận thông tin quân cờ từ đối thủ gửi tới, Hàm sẽ thực hiện cập nhật quân cờ lên bàn cờ giống 
            //hàm sự kiện btn_click ở trên
            Button btn = MatrixPositions[point.Y][point.X];   

            if (btn.BackgroundImage != null)
                return;

            btn.BackgroundImage = ListPlayers[CurrentPlayer].Symbol;

            StkUndoStep.Push(new PlayInfo(GetButtonCoordinate(btn), CurrentPlayer, btn.BackgroundImage));
            StkRedoStep.Clear();

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            ChangePlayer();

            if (IsEndGame())
                EndGame();
        }
        #endregion

        #region 1 player
        //Khởi tạo 2 mảng điểm tấn công và điểm phòng thủ, cho giá trị bằng 7 (trường hợp 5 cờ và bị chặn 2 đầu)
        private long[] MangDiemTanCong = new long[7] { 0, 64, 4096, 262144, 16777216, 1073741824, 68719476736 }; //
        private long[] MangDiemPhongThu = new long[7] { 0, 8, 512, 32768, 2097152, 134217728, 8589934592 }; //điểm phòng thủ mặc điểm sẽ bé hơn điểm tấn công
        //điểm phòng thủ ở mức 1 mặc định là 8 bởi vì xét xung quanh con cờ có 8 ô, do đó điểm tân công ở mức 1 sẽ lớn hơn điểm phòng thủ (8*8=64), sau đó nhân cho 64 sẽ ra mức 2

        #region Calculate attack score //tính điểm tấn công
        private long AttackVertical(int CurrRow, int CurrCol) //Điểm tấn công theo chiều dọc
        {
            long TotalScore = 0; //điểm tổng
            int ComCells = 0; //số quân của máy
            int ManCells = 0; //số quân của người chơi

            // Duyệt từ trên xuống
            for (int Count = 1; Count < 6 && CurrRow + Count < Constance.nRows; Count++)
            //Xác định biến đếm(count): duyệt từ 1 đến 5, duyệt 4 ô + ô đang đánh là 5 ô
            //&& CurrRow + Count < Constance.nRows dùng để giới hạn biên
            {
                if (MatrixPositions[CurrRow + Count][CurrCol].BackgroundImage == ListPlayers[0].Symbol)
                    //xét mảng ô cờ vị trí[CurrRow + Count][CurrCol].BackgroundImage (tức là ô tiếp theo theo chiều từ trên xuống) là quân máy thì tăng ComCells lên 1
                    ComCells += 1;
                else if (MatrixPositions[CurrRow + Count][CurrCol].BackgroundImage == ListPlayers[1].Symbol)
                {
                    //xét mảng ô cờ vị trí[CurrRow + Count][CurrCol].BackgroundImage là quân người thì tăng ManCells lên 1
                    ManCells += 1;
                    break;
                }
                else
                    break;
                //trường hợp không phải quân người cũng không phải quân máy thì thoát
            }

            // Duyệt từ dưới lên
            for (int Count = 1; Count < 6 && CurrRow - Count >= 0; Count++)
            //Xác định biến đếm: duyệt từ 1 đến 5, duyệt 4 ô + ô đang đánh là 5 ô
            //&& CurrRow - Count >= 0 dùng để giới hạn biên (duyệt ngược từ dưới lên)
            {
                if (MatrixPositions[CurrRow - Count][CurrCol].BackgroundImage == ListPlayers[0].Symbol) //ô hiện tại lùi lại nên - count
                                                                                                        //xét mảng ô cờ vị trí[CurrRow + Count][CurrCol].BackgroundImage là quân máy thì tăng ComCells lên 1
                    ComCells += 1;
                else if (MatrixPositions[CurrRow - Count][CurrCol].BackgroundImage == ListPlayers[1].Symbol)
                {
                    //xét mảng ô cờ vị trí[CurrRow + Count][CurrCol].BackgroundImage là quân người thì tăng ManCells lên 1
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            if (ManCells == 2)//Com bị chặn hai đầu
                return 0; //trả về 0 điểm

            /* Nếu ManCells == 1 => bị chặn 1 đầu => lấy điểm phòng ngự tại vị trí này nhưng 
            nên cộng thêm 1 để tăng phòng ngự cho máy cảnh giác hơn vì đã bị chặn 1 đầu */
            //nếu không bị chặn 2 đầu thì giảm điểm phòng ngự, tăng điểm tấn công
            TotalScore -= MangDiemPhongThu[ManCells + 1]; //giảm điểm
            TotalScore += MangDiemTanCong[ComCells]; //tăng điểm
            //điểm tổng sẽ bị ảnh hưởng bởi quân của người và quân của máy trên phương đang tính toán
            return TotalScore;
        }

        private long AttackHorizontal(int CurrRow, int CurrCol) //xét theo phương ngang
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt từ trái sang phải
            for (int Count = 1; Count < 6 && CurrCol + Count < Constance.nCols; Count++)
            {
                if (MatrixPositions[CurrRow][CurrCol + Count].BackgroundImage == ListPlayers[0].Symbol)
                    ComCells += 1;
                else if (MatrixPositions[CurrRow][CurrCol + Count].BackgroundImage == ListPlayers[1].Symbol)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            // Duyệt từ phải sang trái
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0; Count++)
            {
                if (MatrixPositions[CurrRow][CurrCol - Count].BackgroundImage == ListPlayers[0].Symbol)
                    ComCells += 1;
                else if (MatrixPositions[CurrRow][CurrCol - Count].BackgroundImage == ListPlayers[1].Symbol)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            if (ManCells == 2)
                return 0;

            /* Nếu ManCells == 1 => bị chặn 1 đầu => lấy điểm phòng ngự tại vị trí này nhưng 
            nên cộng thêm 1 để tăng phòng ngự cho máy cảnh giác hơn vì đã bị chặn 1 đầu */

            TotalScore -= MangDiemPhongThu[ManCells + 1];
            TotalScore += MangDiemTanCong[ComCells];

            return TotalScore;
        }

        private long AttackMainDiag(int CurrRow, int CurrCol) // Duyện xéo xuôi
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt trái trên
            for (int Count = 1; Count < 6 && CurrCol + Count < Constance.nCols && CurrRow + Count < Constance.nRows; Count++)
            // Duyệt từ trên xuống, dòng tăng lên và cột tăng lên
            {
                if (MatrixPositions[CurrRow + Count][CurrCol + Count].BackgroundImage == ListPlayers[0].Symbol)
                    ComCells += 1;
                else if (MatrixPositions[CurrRow + Count][CurrCol + Count].BackgroundImage == ListPlayers[1].Symbol)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            // Duyệt phải dưới
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0 && CurrRow - Count >= 0; Count++)
            // Duyệt từ dưới lên, dòng giảm dần và cột giảm lên
            {
                if (MatrixPositions[CurrRow - Count][CurrCol - Count].BackgroundImage == ListPlayers[0].Symbol)
                    ComCells += 1;
                else if (MatrixPositions[CurrRow - Count][CurrCol - Count].BackgroundImage == ListPlayers[1].Symbol)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            if (ManCells == 2)
                return 0;

            /* Nếu ManCells == 1 => bị chặn 1 đầu => lấy điểm phòng ngự tại vị trí này nhưng 
            nên cộng thêm 1 để tăng phòng ngự cho máy cảnh giác hơn vì đã bị chặn 1 đầu */

            TotalScore -= MangDiemPhongThu[ManCells + 1];
            TotalScore += MangDiemTanCong[ComCells];

            return TotalScore;
        }

        private long AttackExtraDiag(int CurrRow, int CurrCol) // Duyệt chéo ngược
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt phải trên
            for (int Count = 1; Count < 6 && CurrCol + Count < Constance.nCols && CurrRow - Count >= 0; Count++)
            // Duyệt từ dưới lên, dòng giảm dần và cột tăng lên
            {
                if (MatrixPositions[CurrRow - Count][CurrCol + Count].BackgroundImage == ListPlayers[0].Symbol)
                    ComCells += 1;
                else if (MatrixPositions[CurrRow - Count][CurrCol + Count].BackgroundImage == ListPlayers[1].Symbol)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            // Duyệt trái dưới
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0 && CurrRow + Count < Constance.nRows; Count++)
            //duyệt từ trên xuống cột giảm xuống và dòng tăng lên 
            {
                if (MatrixPositions[CurrRow + Count][CurrCol - Count].BackgroundImage == ListPlayers[0].Symbol)
                    ComCells += 1;
                else if (MatrixPositions[CurrRow + Count][CurrCol - Count].BackgroundImage == ListPlayers[1].Symbol)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            if (ManCells == 2)
                return 0;

            /* Nếu ManCells == 1 => bị chặn 1 đầu => lấy điểm phòng ngự tại vị trí này nhưng 
            nên cộng thêm 1 để tăng phòng ngự cho máy cảnh giác hơn vì đã bị chặn 1 đầu */

            TotalScore -= MangDiemPhongThu[ManCells + 1];
            TotalScore += MangDiemTanCong[ComCells];

            return TotalScore;
        }
        #endregion

        #region Calculate defense score // Tính điểm phòng ngự
        private long DefenseHorizontal(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt từ trên xuống
            for (int Count = 1; Count < 6 && CurrRow + Count < Constance.nRows; Count++)
            {
                if (MatrixPositions[CurrRow + Count][CurrCol].BackgroundImage == ListPlayers[0].Symbol)
                {
                    ComCells += 1; //gặp quân máy thì thoát ra
                    break;
                }
                else if (MatrixPositions[CurrRow + Count][CurrCol].BackgroundImage == ListPlayers[1].Symbol)
                    ManCells += 1; //gặp quân người thì tăng lên, và tiếp tục xét tiếp, càng nhiều quân người thì càng nguy điểm phải chặn ngay, quan trọng đối với việc phòng ngự
                else
                    break;
            }

            // Duyệt từ dưới lên
            for (int Count = 1; Count < 6 && CurrRow - Count >= 0; Count++)
            {
                if (MatrixPositions[CurrRow - Count][CurrCol].BackgroundImage == ListPlayers[0].Symbol)
                {
                    ComCells += 1;
                    break;
                }
                else if (MatrixPositions[CurrRow - Count][CurrCol].BackgroundImage == ListPlayers[1].Symbol)
                    ManCells += 1;
                else
                    break;
            }

            if (ComCells == 2)
                return 0;
            // Nếu chặn ở 2 đầu thì thoát ra
            TotalScore += MangDiemPhongThu[ManCells];

            return TotalScore;
        }

        private long DefenseVertical(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt từ trái sang phải
            for (int Count = 1; Count < 6 && CurrCol + Count < Constance.nCols; Count++)
            {
                if (MatrixPositions[CurrRow][CurrCol + Count].BackgroundImage == ListPlayers[0].Symbol)
                {
                    ComCells += 1;
                    break;
                }
                else if (MatrixPositions[CurrRow][CurrCol + Count].BackgroundImage == ListPlayers[1].Symbol)
                    ManCells += 1;
                else
                    break;
            }

            // Duyệt từ phải sang trái
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0; Count++)
            {
                if (MatrixPositions[CurrRow][CurrCol - Count].BackgroundImage == ListPlayers[0].Symbol)
                {
                    ComCells += 1;
                    break;
                }
                else if (MatrixPositions[CurrRow][CurrCol - Count].BackgroundImage == ListPlayers[1].Symbol)
                    ManCells += 1;
                else
                    break;
            }

            if (ComCells == 2)
                return 0;

            TotalScore += MangDiemPhongThu[ManCells];

            return TotalScore;
        }

        private long DefenseMainDiag(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt trái trên
            for (int Count = 1; Count < 6 && CurrCol + Count < Constance.nCols && CurrRow + Count < Constance.nRows; Count++)
            {
                if (MatrixPositions[CurrRow + Count][CurrCol + Count].BackgroundImage == ListPlayers[0].Symbol)
                {
                    ComCells += 1;
                    break;
                }
                else if (MatrixPositions[CurrRow + Count][CurrCol + Count].BackgroundImage == ListPlayers[1].Symbol)
                    ManCells += 1;
                else
                    break;
            }

            // Duyệt phải dưới
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0 && CurrRow - Count >= 0; Count++)
            {
                if (MatrixPositions[CurrRow - Count][CurrCol - Count].BackgroundImage == ListPlayers[0].Symbol)
                {
                    ComCells += 1;
                    break;
                }
                else if (MatrixPositions[CurrRow - Count][CurrCol - Count].BackgroundImage == ListPlayers[1].Symbol)
                    ManCells += 1;
                else
                    break;
            }

            if (ComCells == 2)
                return 0;

            TotalScore += MangDiemPhongThu[ManCells];

            return TotalScore;
        }

        private long DefenseExtraDiag(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt phải trên
            for (int Count = 1; Count < 6 && CurrCol + Count < Constance.nCols && CurrRow - Count >= 0; Count++)
            {
                if (MatrixPositions[CurrRow - Count][CurrCol + Count].BackgroundImage == ListPlayers[0].Symbol)
                {
                    ComCells += 1;
                    break;
                }
                else if (MatrixPositions[CurrRow - Count][CurrCol + Count].BackgroundImage == ListPlayers[1].Symbol)
                    ManCells += 1;
                else
                    break;
            }

            // Duyệt trái dưới
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0 && CurrRow + Count < Constance.nRows; Count++)
            {
                if (MatrixPositions[CurrRow + Count][CurrCol - Count].BackgroundImage == ListPlayers[0].Symbol)
                {
                    ComCells += 1;
                    break;
                }
                else if (MatrixPositions[CurrRow + Count][CurrCol - Count].BackgroundImage == ListPlayers[1].Symbol)
                    ManCells += 1;
                else
                    break;
            }

            if (ComCells == 2)
                return 0;

            TotalScore += MangDiemPhongThu[ManCells];

            return TotalScore;
        }
        #endregion
        private Point FindAiPos() //tìm kiếm nước đi
        {
            Point AiPos = new Point(); //khai báo ô cờ
            long MaxScore = 0;
            //dùng vét cạn để duyệt hết bàn cờ
            for (int i = 0; i < Constance.nRows; i++)
            {
                for (int j = 0; j < Constance.nCols; j++)
                {
                    if (MatrixPositions[i][j].BackgroundImage == null) //nếu mảng thứ cờ thứ i,j bằng 0, tức là chưa được đánh
                    {
                        long AttackScore = AttackHorizontal(i, j) + AttackVertical(i, j) + AttackMainDiag(i, j) + AttackExtraDiag(i, j);
                        long DefenseScore = DefenseHorizontal(i, j) + DefenseVertical(i, j) + DefenseMainDiag(i, j) + DefenseExtraDiag(i, j);
                        long TempScore = AttackScore > DefenseScore ? AttackScore : DefenseScore; // Xét điểm tất công hay điểm phòng ngự cao hơn, nếu đúng thì lấy điểm tấn công, sai lấy điểm phòng ngự

                        if (MaxScore < TempScore) // So sánh điểm lớn nhất và điểm tạm (temp)
                        {
                            MaxScore = TempScore;
                            AiPos = new Point(i, j); // Tránh bị chung vùng nhớ, chồng lên nhau
                        }
                    }
                }
            }

            return AiPos;
        }
        //Khởi động Ai
        public void StartAI()
        {
            IsAI = true;

            if (StkUndoStep.Count == 0) // mới bắt đầu thì cho đánh giữa bàn cờ, StkUndoStep.Count == 0 các nước đã đi bằng 0
                MatrixPositions[Constance.nRows / 4][Constance.nCols / 4].PerformClick(); //AI đánh
            else //nếu đã có thế cờ rồi
            {
                Point AiPos = FindAiPos(); //Tìm nước đi, ô cờ
                MatrixPositions[AiPos.X][AiPos.Y].PerformClick(); //đánh cờ ở vị trí x, y
            }
        }
        #endregion

        #endregion
    }
}
