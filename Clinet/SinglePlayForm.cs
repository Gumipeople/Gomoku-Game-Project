using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/* 
 * Graphics 객체: 어떠한 그림을 그리기 위한 객체
 * MessageBox 객체: 어떠한 메세지를 화면에 출력하기 위함
 * SolidBrush 객체 : 말 그대로 Brush
 * Color 객체: 특정 색상을 표현할 수 있음
 * Pen 객체: 펜 색상
 */

namespace Clinet
{
    public partial class SinglePlayForm : Form
    {
        private const int rectSize = 33; // 오목판 셀 크기
        private const int numOfEdge = 15; // 오목판의 선의 수

        private enum Horse { none = 0, BLACK, WHITE };
        private Horse[,] board = new Horse[numOfEdge, numOfEdge];
        private Horse nowPlayer = Horse.BLACK;
        
        public SinglePlayForm()
        {
            InitializeComponent();
        }

        private void SinglePlayForm_Load(object sender, EventArgs e)
        {

        }

        private void boardPicture_Click(object sender, EventArgs e)
        {

        }

        private void boardPicture_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = this.boardPicture.CreateGraphics();
            int x = e.X / rectSize;
            int y = e.Y / rectSize;
            if (x < 0 || y < 0 || x >= numOfEdge || y >= numOfEdge)
            {
                MessageBox.Show("테두리를 벗어날 수 없습니다.");
                return;
            }
            if (nowPlayer == Horse.BLACK)
            {
                SolidBrush brush = new SolidBrush(Color.Black);
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize);

            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.White);
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize);
            }
        }

        private void boardPicture_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

            graphics.DrawLine(pen, rectSize / 2, rectSize / 2, rectSize * numOfEdge - rectSize / 2, rectSize / 2);
            graphics.DrawLine(pen, rectSize / 2, rectSize * numOfEdge - rectSize / 2, rectSize * numOfEdge - rectSize / 2, rectSize * numOfEdge - rectSize / 2);
            graphics.DrawLine(pen, rectSize / 2, rectSize / 2, rectSize / 2, rectSize * numOfEdge - rectSize / 2);
            graphics.DrawLine(pen, rectSize * numOfEdge - rectSize / 2, rectSize / 2, rectSize * numOfEdge - rectSize / 2, rectSize * numOfEdge - rectSize / 2);

            for (int i = rectSize + rectSize / 2; i < rectSize * numOfEdge - rectSize / 2; i += rectSize)
            {
                graphics.DrawLine(pen, i, rectSize / 2, i, rectSize * numOfEdge - rectSize / 2);
                graphics.DrawLine(pen, rectSize / 2, i, rectSize * numOfEdge - rectSize / 2, i);
            }
        }

        private void status_Click(object sender, EventArgs e)
        {


        }

        private void playButton_Click(object sender, EventArgs e)
        {

        }
    }
}
