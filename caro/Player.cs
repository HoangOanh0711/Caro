using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace caro
{
    class Player
    {
        private string name;

        private Image symbol;
        private PictureBox frame;

        public string Name { get => name; set => name = value; }
        public Image Symbol { get => symbol; set => symbol = value; }
        public PictureBox Frame { get => frame; set => frame = value; }

        public Player(string name,  Image symbol, PictureBox frame)
        {
            this.Name = name;
            this.Symbol = symbol;
            this.Frame = frame;
            this.Frame.Image = symbol;
        }
    }
}
