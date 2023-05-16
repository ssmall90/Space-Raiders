namespace Space_Raiders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MoveBackGround = new System.Windows.Forms.Timer(this.components);
            this.Player = new System.Windows.Forms.PictureBox();
            this.LeftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.RightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.DownMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.UpMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.ShootBullet = new System.Windows.Forms.Timer(this.components);
            this.MoveEnemyTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemyShootTimer = new System.Windows.Forms.Timer(this.components);
            this.Exit = new System.Windows.Forms.Button();
            this.Replay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.ReleaseBonus = new System.Windows.Forms.Timer(this.components);
            this.BonusBulletsMove = new System.Windows.Forms.Timer(this.components);
            this.BonusCount = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveBackGround
            // 
            this.MoveBackGround.Enabled = true;
            this.MoveBackGround.Interval = 10;
            this.MoveBackGround.Tick += new System.EventHandler(this.MoveBackGround_Tick);
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.InitialImage = null;
            this.Player.Location = new System.Drawing.Point(275, 400);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(50, 50);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // LeftMoveTimer
            // 
            this.LeftMoveTimer.Interval = 5;
            this.LeftMoveTimer.Tick += new System.EventHandler(this.LeftMoveTimer_Tick);
            // 
            // RightMoveTimer
            // 
            this.RightMoveTimer.Interval = 5;
            this.RightMoveTimer.Tick += new System.EventHandler(this.RightMoveTimer_Tick);
            // 
            // DownMoveTimer
            // 
            this.DownMoveTimer.Interval = 5;
            this.DownMoveTimer.Tick += new System.EventHandler(this.DownMoveTimer_Tick);
            // 
            // UpMoveTimer
            // 
            this.UpMoveTimer.Interval = 5;
            this.UpMoveTimer.Tick += new System.EventHandler(this.UpMoveTimer_Tick);
            // 
            // ShootBullet
            // 
            this.ShootBullet.Enabled = true;
            this.ShootBullet.Interval = 20;
            this.ShootBullet.Tick += new System.EventHandler(this.ShootBullet_Tick);
            // 
            // MoveEnemyTimer
            // 
            this.MoveEnemyTimer.Enabled = true;
            this.MoveEnemyTimer.Tick += new System.EventHandler(this.MoveEnemyTimer_Tick);
            // 
            // EnemyShootTimer
            // 
            this.EnemyShootTimer.Enabled = true;
            this.EnemyShootTimer.Interval = 20;
            this.EnemyShootTimer.Tick += new System.EventHandler(this.EnemyShootTimer_Tick);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Yellow;
            this.Exit.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(200, 290);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(200, 50);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Visible = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Replay
            // 
            this.Replay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Replay.BackColor = System.Drawing.Color.Yellow;
            this.Replay.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Replay.Location = new System.Drawing.Point(200, 190);
            this.Replay.Name = "Replay";
            this.Replay.Size = new System.Drawing.Size(200, 50);
            this.Replay.TabIndex = 2;
            this.Replay.Text = "Replay";
            this.Replay.UseVisualStyleBackColor = false;
            this.Replay.Visible = false;
            this.Replay.Click += new System.EventHandler(this.Replay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(43, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 79);
            this.label1.TabIndex = 3;
            this.label1.Text = "Space Raiders";
            this.label1.Visible = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.Yellow;
            this.scoreLabel.Location = new System.Drawing.Point(37, 14);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(68, 20);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "Score: ";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.Color.Yellow;
            this.levelLabel.Location = new System.Drawing.Point(455, 12);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(93, 23);
            this.levelLabel.TabIndex = 5;
            this.levelLabel.Text = "Level: 01";
            // 
            // ReleaseBonus
            // 
            this.ReleaseBonus.Tick += new System.EventHandler(this.ReleaseBonus_Tick);
            // 
            // BonusBulletsMove
            // 
            this.BonusBulletsMove.Interval = 50;
            this.BonusBulletsMove.Tick += new System.EventHandler(this.BonusBulletsMove_Tick);
            // 
            // BonusCount
            // 
            this.BonusCount.Interval = 1000;
            this.BonusCount.Tick += new System.EventHandler(this.BonusCount_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Replay);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Player);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.Text = "Space Raiders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MoveBackGround;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer LeftMoveTimer;
        private System.Windows.Forms.Timer RightMoveTimer;
        private System.Windows.Forms.Timer DownMoveTimer;
        private System.Windows.Forms.Timer UpMoveTimer;
        private System.Windows.Forms.Timer ShootBullet;
        private System.Windows.Forms.Timer MoveEnemyTimer;
        private System.Windows.Forms.Timer EnemyShootTimer;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Replay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Timer ReleaseBonus;
        private System.Windows.Forms.Timer BonusBulletsMove;
        private System.Windows.Forms.Timer BonusCount;
    }
}

