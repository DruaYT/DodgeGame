using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DodgeGame
{
    public partial class Form1 : Form
    {
        int playerSpeed = 5;

        int ms = 0;
        int seconds = 0;
        int minutes = 0;
        int projRate = 10;
        int player1Score = 0;
        int player2Score = 0;

        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;

        bool up2 = false;
        bool down2 = false;
        bool left2 = false;
        bool right2 = false;

        SolidBrush brush = new SolidBrush(Color.White);

        Random rand = new Random();

        Rectangle player = new Rectangle(300, 150, 10, 10);
        Rectangle player2 = new Rectangle(300, 250, 10, 10);

        public List<Rectangle> projectiles = new List<Rectangle>();
        public List<Point> pointEnd = new List<Point>();

        public Form1()
        {
            InitializeComponent();
        }

        private void resetGame()
        {
            player.Location = new Point(300, 150);
            player2.Location = new Point(300, 250);
            projRate /= 2;
            ms = 0;
            seconds = 0;
            minutes = 0;
            projectiles.Clear();
            pointEnd.Clear();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            ms += 100/20;

            if (ms % 100 == 0 && ms != 0)
            {
                ms = 0;
                seconds++;
            }
            if (seconds % 60 == 0 && seconds != 0)
            {
                seconds = 0;
                minutes++;
            }
            if (seconds == 30 && projRate <= 90)
            {
                projRate ++;
            }

            if (rand.Next(0, 100) <= projRate)
            {
                int size = rand.Next(15, 30);
                Rectangle proj = new Rectangle(rand.Next(0, this.Width/2), 0, size, size);
                Point projGoal = new Point(rand.Next(-1*this.Height/2, this.Width/2), rand.Next(5, 25));
                projectiles.Add(proj);
                pointEnd.Add(projGoal);
            }
            if (up == true && player.Y - playerSpeed > 0)
            {
                player.Y -= playerSpeed;
            }
            if (down == true && player.Y + player.Height + playerSpeed < this.Height)
            {
                player.Y += playerSpeed;
            }
            if (left == true && player.X - playerSpeed > 0)
            {
                player.X -= playerSpeed;
            }
            if (right == true && player.X + player.Width + playerSpeed < this.Width)
            {
                player.X += playerSpeed;
            }

            if (up2 == true && player2.Y - playerSpeed > 0)
            {
                player2.Y -= playerSpeed;
            }
            if (down2 == true && player2.Y + player2.Height + playerSpeed < this.Height)
            {
                player2.Y += playerSpeed;
            }
            if (left2 == true && player2.X - playerSpeed > 0)
            {
                player2.X -= playerSpeed;
            }
            if (right2 == true && player2.X + player2.Width + playerSpeed < this.Width)
            {
                player2.X += playerSpeed;
            }

            for (int i = 0; i < projectiles.Count; i++)
            {

                if (projectiles[i] != null)
                {
                    if (projectiles[i].Y < this.Height && projectiles[i].IntersectsWith(player))
                    {
                        resetGame();
                        player2Score++;
                    }
                    else if (projectiles[i].Y < this.Height && projectiles[i].IntersectsWith(player2))
                    {
                        resetGame();
                        player1Score++;
                    }
                    else if(projectiles[i].Y >= this.Height)
                    {
                        projectiles.Remove(projectiles[i]);
                        pointEnd.Remove(pointEnd[i]);
                    }
                }
            }
            TimerLabel.Text = $"{minutes:00}:{seconds:00}:{ms:00}";
            score1Label.Text = $"{player1Score}";
            score2Label.Text = $"{player2Score}";

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            brush.Color = Color.Aqua;
            e.Graphics.FillRectangle(brush, player);
            brush.Color = Color.Yellow;
            e.Graphics.FillRectangle(brush, player2);

            brush.Color = Color.HotPink;
            for(int i=0; i < projectiles.Count; i++)
            {
                int diffX = (int)Math.Pow(projectiles[i].X - pointEnd[i].X, 2);

                projectiles[i] = new Rectangle(projectiles[i].X + diffX / 10000, projectiles[i].Y + pointEnd[i].Y, projectiles[i].Width, projectiles[i].Height);
                e.Graphics.FillEllipse(brush, projectiles[i]);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                up = true;
            }
            if (e.KeyCode == Keys.A)
            {
                left = true;
            }
            if (e.KeyCode == Keys.S)
            {
                down = true;
            }
            if (e.KeyCode == Keys.D)
            {
                right = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                up2 = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left2 = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                down2 = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                right2 = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                up = false;
            }
            if (e.KeyCode == Keys.A)
            {
                left = false;
            }
            if (e.KeyCode == Keys.S)
            {
                down = false;
            }
            if (e.KeyCode == Keys.D)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                up2 = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left2 = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                down2 = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                right2 = false;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
        }
    }
}
