namespace DodgeGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.TimerLabel = new System.Windows.Forms.Label();
            this.score1Label = new System.Windows.Forms.Label();
            this.score2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // TimerLabel
            // 
            this.TimerLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimerLabel.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.ForeColor = System.Drawing.Color.White;
            this.TimerLabel.Location = new System.Drawing.Point(221, 9);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(164, 39);
            this.TimerLabel.TabIndex = 0;
            this.TimerLabel.Text = "0:00\r\n";
            this.TimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // score1Label
            // 
            this.score1Label.BackColor = System.Drawing.Color.Transparent;
            this.score1Label.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score1Label.ForeColor = System.Drawing.Color.Cyan;
            this.score1Label.Location = new System.Drawing.Point(12, 9);
            this.score1Label.Name = "score1Label";
            this.score1Label.Size = new System.Drawing.Size(79, 39);
            this.score1Label.TabIndex = 1;
            this.score1Label.Text = "0";
            this.score1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // score2Label
            // 
            this.score2Label.BackColor = System.Drawing.Color.Transparent;
            this.score2Label.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score2Label.ForeColor = System.Drawing.Color.Yellow;
            this.score2Label.Location = new System.Drawing.Point(509, 9);
            this.score2Label.Name = "score2Label";
            this.score2Label.Size = new System.Drawing.Size(79, 39);
            this.score2Label.TabIndex = 2;
            this.score2Label.Text = "0";
            this.score2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.score2Label);
            this.Controls.Add(this.score1Label);
            this.Controls.Add(this.TimerLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Label score1Label;
        private System.Windows.Forms.Label score2Label;
    }
}

