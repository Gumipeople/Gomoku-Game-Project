using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinet
{
    public partial class MultiPlayForm : Form
    {
        private const int rectSize = 33; // 오목판 셀 크기
        private const int numOfEdge = 15; // 오목판의 선의 수

        private enum Horse { none = 0, BLACK, WHITE };
        private Horse[,] board = new Horse[numOfEdge, numOfEdge];
        private Horse nowPlayer = Horse.BLACK;

        private bool playing = false;

        private bool judge()
        {
            for (int i = 0; i < numOfEdge - 4; i++)
                for (int j = 0; j < numOfEdge; j++)
                    if (board[i, j] == nowPlayer && board[i + 1, j] == nowPlayer && board[i + 2, j] == nowPlayer &&
                        board[i + 3, j] == nowPlayer && board[i + 4, j] == nowPlayer)
                        return true;
            for (int i = 0; i < numOfEdge; i++)
                for (int j = 4; j < numOfEdge; j++)
                    if (board[i, j] == nowPlayer && board[i, j - 1] == nowPlayer && board[i, j - 2] == nowPlayer &&
                        board[i, j - 3] == nowPlayer && board[i, j - 4] == nowPlayer)
                        return true;
            for (int i = 0; i < numOfEdge - 4; i++)
                for (int j = 0; j < numOfEdge - 4; j++)
                    if (board[i, j] == nowPlayer && board[i + 1, j + 1] == nowPlayer && board[i + 2, j + 2] == nowPlayer &&
                        board[i + 3, j + 3] == nowPlayer && board[i + 4, j + 4] == nowPlayer)
                        return true;
            for (int i = 4; i < numOfEdge; i++)
                for (int j = 0; j < numOfEdge - 4; j++)
                    if (board[i, j] == nowPlayer && board[i - 1, j] == nowPlayer && board[i - 2, j + 2] == nowPlayer &&
                        board[i - 3, j + 3] == nowPlayer && board[i - 4, j + 4] == nowPlayer)
                        return true;
            return false;
        }

        private void refresh()
        {
            this.boardPicture.Refresh();
            for (int i = 0; i < numOfEdge; i++)
                for (int j = 0; j < numOfEdge; j++)
                    board[i, j] = Horse.none;
        }
        public MultiPlayForm()
        {
            InitializeComponent();
            this.playButton.Enabled = false;
        }

        private void boardPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (!playing)
            {
                MessageBox.Show("게임을 실행해주세요.");
                return;
            }
            Graphics g = this.boardPicture.CreateGraphics();
            int x = e.X / rectSize;
            int y = e.Y / rectSize;
            if (x < 0 || y < 0 || x >= numOfEdge || y >= numOfEdge)
            {
                MessageBox.Show("테두리를 벗어날 수 없습니다.");
                return;
            }
            if (board[x, y] != Horse.none) return;
            board[x, y] = nowPlayer;
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
            if (judge())
            {
                status.Text = nowPlayer.ToString() + "플레이어가 승리했습니다.";
                playing = false;
                playButton.Text = "게임시작";
            }
            else
            {
                nowPlayer = (nowPlayer == Horse.BLACK) ? Horse.WHITE : Horse.BLACK;
                status.Text = nowPlayer.ToString() + " 플레이어의 차례입니다.";
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

        private void roomTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            this.enterButton.Enabled = false;
            this.playButton.Enabled = true;
            this.status.Text = "[" + roomTextBox.Text + "]번 방에 접속 했습니다.";
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                refresh();
                playing = true;
                playButton.Text = "재시작";
                status.Text = nowPlayer.ToString() + " 플레이어의 차례입니다.";
            }
            else
            {
                refresh();
                status.Text = "게임이 재시작되었습니다.";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
