using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DodgeGame
{
    public partial class Form1 : Form
    {
        int playerSpeed = 10;

        int ms = 0;
        int seconds = 0;
        int minutes = 0;
        int projRate = 1;
        int player1Score = 0;
        int player2Score = 0;

        bool playingGame = false;

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
        public List<Rectangle> rockets = new List<Rectangle>();
        public List<Point> pointEnd = new List<Point>();
        public List<int> rocketTarget = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void resetGame()
        {
            player.Location = new Point(300, 150);
            player2.Location = new Point(300, 250);
            projRate /= 2;
            projectiles.Clear();
            pointEnd.Clear();
            rockets.Clear();
            rocketTarget.Clear();
        }

        private void ToggleMenu()
        {
            if (playingGame == true)
            {
                player.Location = new Point(300, 150);
                player2.Location = new Point(300, 250);
                projRate = 1;
                projectiles.Clear();
                pointEnd.Clear();
                rockets.Clear();
                rocketTarget.Clear();
                WinnerLabel.Text = "Press [Spacebar] to Play or [Esc] to Quit!";
                WinnerLabel.ForeColor = Color.Red;
                Title.Text = "DEBRIS DODGER";
                GameTimer.Enabled = false;
                playingGame = false;
            }
            else
            {
                player.Location = new Point(300, 150);
                player2.Location = new Point(300, 250);
                projRate = 1;
                ms = 0;
                seconds = 0;
                minutes = 0;
                player1Score = 0;
                player2Score = 0;
                projectiles.Clear();
                pointEnd.Clear();
                rockets.Clear();
                rocketTarget.Clear();
                WinnerLabel.Text = "";
                Title.Text = "";
                GameTimer.Enabled = true;
                playingGame = true;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (player1Score >= 10)
            {
                WinnerLabel.ForeColor = Color.Aqua;
                WinnerLabel.Text = "Player 1 Wins!";
                GameTimer.Enabled = false;
                Refresh();
                Thread.Sleep(5000);
                ToggleMenu();
            }
            else if (player2Score >= 10)
            {
                WinnerLabel.ForeColor = Color.Yellow;
                WinnerLabel.Text = "Player 2 Wins!";
                GameTimer.Enabled = false;
                Refresh();
                Thread.Sleep(5000);
                ToggleMenu();
            }
            else
            {
                ms += 100 / 20;
            }

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
            if ((seconds == 15 || seconds == 30 || seconds == 45) && projRate <= 90)
            {
                projRate ++;
            }

            if (rand.Next(0, 100) <= projRate)
            {
                int size = rand.Next(15, 30);
                Rectangle proj = new Rectangle(rand.Next(this.Width / 3, (this.Width/3)*2), 0, size, size);
                Point projGoal = new Point(rand.Next(-600, 600), rand.Next(5, 10));
                projectiles.Add(proj);
                pointEnd.Add(projGoal);
            }
            if (rand.Next(0, 200) <= projRate/2)
            {
                int target = rand.Next(0, 1);
                int size = rand.Next(20, 60);
                Rectangle proj = new Rectangle(rand.Next(0, this.Width), 0, size, size);
                rockets.Add(proj);
                rocketTarget.Add(target);
                
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
            for (int i = 0; i < rockets.Count; i++)
            {
                if (rockets[i] != null)
                {
                    if (rockets[i].Y < this.Height && rockets[i].IntersectsWith(player))
                    {
                        resetGame();
                        player2Score++;
                    }
                    else if (rockets[i].Y < this.Height && rockets[i].IntersectsWith(player2))
                    {
                        resetGame();
                        player1Score++;
                    }
                    else if (rockets[i].Y >= this.Height)
                    {
                        rockets.Remove(rockets[i]);
                        rocketTarget.Remove(rocketTarget[i]);
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
                projectiles[i] = new Rectangle(projectiles[i].X + pointEnd[i].X / 100, projectiles[i].Y + (pointEnd[i].Y/2), projectiles[i].Width, projectiles[i].Height);
                e.Graphics.DrawLine(new Pen(Color.Red, 2), new Point(projectiles[i].X + (projectiles[i].Width / 2), projectiles[i].Y + (projectiles[i].Width / 2)), new Point((projectiles[i].X + (projectiles[i].Width / 2)) + pointEnd[i].X / 10, projectiles[i].Y + (pointEnd[i].Y*10)));
                e.Graphics.FillEllipse(brush, projectiles[i]);
            }
            brush.Color = Color.Red;

            for (int i = 0; i < rockets.Count; i++)
            {
                int diff1 = (int)Math.Sqrt(Math.Pow(rockets[i].X - player.X, 2) + Math.Pow(rockets[i].Y - player.Y, 2));
                int diff2 = (int)Math.Sqrt(Math.Pow(rockets[i].X - player2.X, 2) + Math.Pow(rockets[i].Y - player2.Y, 2));

                if (diff2 > diff1)
                {
                    if (rockets[i].X > player.X)
                    {
                        rockets[i] = new Rectangle(rockets[i].X - 1, rockets[i].Y + 1, rockets[i].Width, rockets[i].Height);
                    }
                    else if (rockets[i].X < player.X)
                    {
                        rockets[i] = new Rectangle(rockets[i].X + 1, rockets[i].Y + 1, rockets[i].Width, rockets[i].Height);
                    }
                    else
                    {
                        rockets[i] = new Rectangle(rockets[i].X, rockets[i].Y + 1, rockets[i].Width, rockets[i].Height);
                    }


                    e.Graphics.DrawLine(new Pen(Color.Red, 2), new Point(rockets[i].X + (rockets[i].Width / 2), rockets[i].Y + (rockets[i].Width / 2)), new Point(player.X + player.Width / 2, rockets[i].Y * 2));
                }
                else if (diff1 > diff2)
                {
                        if (rockets[i].X > player2.X)
                        {
                            rockets[i] = new Rectangle(rockets[i].X - 1, rockets[i].Y + 1, rockets[i].Width, rockets[i].Height);
                        }
                        else if (rockets[i].X < player2.X)
                        {
                            rockets[i] = new Rectangle(rockets[i].X + 1, rockets[i].Y + 1, rockets[i].Width, rockets[i].Height);
                        }
                        else
                        {
                            rockets[i] = new Rectangle(rockets[i].X, rockets[i].Y + 1, rockets[i].Width, rockets[i].Height);
                        }
                        e.Graphics.DrawLine(new Pen(Color.Red, 2), new Point(rockets[i].X + (rockets[i].Width / 2), rockets[i].Y + (rockets[i].Width / 2)), new Point(player2.X + player2.Width / 2, rockets[i].Y * 2));
                }
                e.Graphics.FillEllipse(brush, rockets[i]);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && playingGame == false)
            {
                ToggleMenu();
            }
            if (e.KeyCode == Keys.Escape && playingGame == false)
            {
                Close();
            }
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
