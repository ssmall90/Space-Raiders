using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Space_Raiders
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer backGroundMusic;
        WindowsMediaPlayer ShootingSound;
        WindowsMediaPlayer Explosion;

        PictureBox[] stars;
        int backGroundSpeed;
        int playerSpeed;
        Random random;

        PictureBox[] bullets;
        int bulletSpeed;

        PictureBox[] bonusBullets;
        int bonusBulletSpeed;

        PictureBox[] enemyBullets;
        int enemyBulletsSpeed;

        PictureBox[] enemies;
        int enemySpeed;

        PictureBox[] bonuses;
        int bonusSpeed;

        int score;
        int level;
        int difficulty;
        bool pause;
        bool gameIsOver;
        int start = 0;



        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            pause = false;
            gameIsOver = false;
            score = 0;
            level = 1;
            difficulty = 9;


            //Background Settings
            backGroundSpeed = 4;
            stars = new PictureBox[10];
            random = new Random();

            //Player Settings
            playerSpeed = 4;
            bulletSpeed = 20;
            bullets = new PictureBox[3];
            bonuses = new PictureBox[2];
            bonusBullets = new PictureBox[6];
            bonusBulletSpeed = 30;

            //Enemy Settings
            enemySpeed = 2;
            enemyBullets = new PictureBox[10];
            enemyBulletsSpeed = 3;


            //bonus Settings 
            bonusSpeed = 3;


            Image bullet = Image.FromFile(@"asserts\munition.png"); // Load Image For Bullets

            //Load Enemy Images
            Image enemy1 = Image.FromFile(@"asserts\E1.png");
            Image enemy2 = Image.FromFile(@"asserts\E2.png");
            Image enemy3 = Image.FromFile(@"asserts\E3.png");
            Image boss1 = Image.FromFile(@"asserts\Boss1.png");
            Image boss2 = Image.FromFile(@"asserts\Boss2.png");

            //Load Bonus Images
            Image bonus1 = Image.FromFile(@"asserts\star1.png");
            Image bonus2 = Image.FromFile(@"asserts\star2.png");


            // Generate Enemies
            enemies = new PictureBox[10];
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 50, -50);
            }

            enemies[0].Image = boss1;
            enemies[1].Image = enemy1;
            enemies[2].Image = enemy2;
            enemies[3].Image = enemy1;
            enemies[4].Image = enemy3;
            enemies[5].Image = enemy1;
            enemies[6].Image = enemy2;
            enemies[7].Image = enemy2;
            enemies[8].Image = enemy3;
            enemies[9].Image = boss2;


            //Generate Bonuses

            bonuses = new PictureBox[2];
            {
                for (int i = 0; i < bonuses.Length; i++)
                {
                    bonuses[i] = new PictureBox();
                    bonuses[i].Size = new Size(40, 40);
                    bonuses[i].SizeMode = PictureBoxSizeMode.Zoom;
                    bonuses[i].BorderStyle = BorderStyle.None;
                    bonuses[i].Visible = false;
                    this.Controls.Add(bonuses[i]);
                    bonuses[i].Location = new Point((i + 1) * 50, -150);
                }
                bonuses[0].Image = bonus1;
                bonuses[1].Image = bonus2;
            }

            //Load Game Sounds
            backGroundMusic = new WindowsMediaPlayer();
            ShootingSound = new WindowsMediaPlayer();
            Explosion = new WindowsMediaPlayer();

            backGroundMusic.URL = "songs\\GameSong.mp3";
            ShootingSound.URL = "songs\\shoot.mp3";
            Explosion.URL = "songs\\boom.mp3";

            backGroundMusic.settings.setMode("loop", true);
            backGroundMusic.settings.volume = 5;
            ShootingSound.settings.volume = 1;
            Explosion.settings.volume = 3;


            //Create Player Bullets
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox();
                bullets[i].Size = new Size(8, 8);
                bullets[i].Image = bullet;
                bullets[i].SizeMode = PictureBoxSizeMode.Zoom;
                bullets[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(bullets[i]);
            }

            //Create Player Bonus Bullets 

            for (int i = 0; i < bonusBullets.Length; i++)
            {
                bonusBullets[i] = new PictureBox();
                bonusBullets[i].Size = new Size(8, 8);
                bonusBullets[i].BackColor = Color.Blue;
                bonusBullets[i].SizeMode = PictureBoxSizeMode.Zoom;
                bonusBullets[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(bonusBullets[i]);
            }

            //Create Enemy Bullets 
            for (int i = 0; i < enemyBullets.Length; i++)
            {
                enemyBullets[i] = new PictureBox();
                enemyBullets[i].Size = new Size(2, 15);
                enemyBullets[i].Visible = false;
                enemyBullets[i].BackColor = Color.Green;
                int x = random.Next(0, 10);
                enemyBullets[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemyBullets[i]);
            }


            // Create Background 
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(random.Next(20, 580), random.Next(-10, 400));
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Yellow;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.White;
                }
                this.Controls.Add(stars[i]);

            }

            backGroundMusic.controls.play();
        }

        //Timers *Anything With Tick At End*
        private void MoveBackGround_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backGroundSpeed;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backGroundSpeed - 2;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 580)
            {
                Player.Left += playerSpeed;
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 5)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 400)
            {
                Player.Top += playerSpeed;
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // Handle Key Strokes
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    RightMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    LeftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Up)
                {
                    UpMoveTimer.Start();
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) // Handle Release Of Key Strokes
        {

            if (e.KeyCode == Keys.Space)
            {
                if (!gameIsOver)
                {
                    if (pause)
                    {
                        StartTimers();
                        label1.Visible = false;
                        backGroundMusic.controls.play();
                        pause = false;
                    }
                    else
                    {
                        label1.Location = new Point(this.Width / 2 - 150, 150);
                        label1.Text = "PAUSED";
                        label1.Visible = true;
                        backGroundMusic.controls.pause();
                        StopTimers();
                        pause = true;
                    }
                }

            }
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();
        }

        private void ShootBullet_Tick(object sender, EventArgs e)
        {
            bonusBullets[0].Visible = false;
            bonusBullets[1].Visible = false;
            bonusBullets[2].Visible = false;
            bonusBullets[3].Visible = false;
            bonusBullets[4].Visible = false;
            bonusBullets[5].Visible = false;

            for (int i = 0; i < bullets.Length; i++)
            {


                if (bullets[i].Top > 0)
                {
                    bullets[i].Visible = true;
                    bullets[i].Top -= bulletSpeed;
                    Collision();
                    Collision3();
                }
                else
                {
                    bullets[i].Visible = false;
                    bullets[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                    ShootingSound.controls.play();
                }
            }
        }

        private void MoveEnemyTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemySpeed);
        }

        private void MoveEnemies(PictureBox[] array, int speed) // Move Enemies Down Screen
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -10);
                }
            }
        }

        private void EnemyShootTimer_Tick(object sender, EventArgs e) // Fire Enemy Bullets
        {
            for (int i = 0; i < (enemyBullets.Length - difficulty); i++)
            {
                if (enemyBullets[i].Top < this.Height)
                {
                    enemyBullets[i].Visible = true;
                    enemyBullets[i].Top += enemyBulletsSpeed;
                    Collision2();
                }
                else
                {
                    int x = random.Next(0, 10);
                    enemyBullets[i].Visible = false;
                    enemyBullets[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
            }
        }

        private void Collision() // Handle Collisions Player Shoots Enemy Player Hits Enemy
        {
            for (int i = 0; i < enemies.Length; i++)
            {

                if (bullets[0].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    bullets[1].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    bullets[2].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    bonusBullets[0].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    bonusBullets[1].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    bonusBullets[2].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    bonusBullets[3].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    bonusBullets[4].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    bonusBullets[5].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    Explosion.controls.play();

                    score += 1;
                    scoreLabel.Text = (score < 10) ? "Score: " + "0" + score.ToString() : score.ToString();

                    if (score % 20 == 0)
                    {
                        ReleaseBonus.Enabled = true;
                    }

                    if (score % 30 == 0)
                    {
                        level += 1;
                        levelLabel.Text = (level < 10) ? "Level: " + "0" + level.ToString() : level.ToString();

                        if (enemySpeed <= 10 && enemyBulletsSpeed <= 10 && difficulty >= 0)
                        {
                            difficulty--;
                            enemyBulletsSpeed++;
                            enemySpeed++;
                        }

                        if (level == 10)
                        {
                            GameOver("Game Complete");
                        }
                    }

                    enemies[i].Location = new Point((i + 1) * 50, -100);
                }
                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    Explosion.settings.volume = 30;
                    Explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game Over");

                }


            }

        }

        private void Collision2() // Enemy Shoots Player
        {
            for (int i = 0; i < enemyBullets.Length; i++)
            {
                if (enemyBullets[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemyBullets[i].Visible = false;
                    Explosion.settings.volume = 30;
                    Explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game Over");
                }
            }
        }

        private void Collision3()
        {

            
                for (int i = 0; i < bonuses.Length; i++)
                {

                    if (bullets[0].Bounds.IntersectsWith(bonuses[i].Bounds) ||
                        bullets[1].Bounds.IntersectsWith(bonuses[i].Bounds) ||
                        bullets[2].Bounds.IntersectsWith(bonuses[i].Bounds))
                    {
                        bonuses[i].Location = new Point((i + 1) * 50, -10);
                        ShootBullet.Stop();
                        BonusBulletsMove.Start();
                        BonusCount.Start();

                    }

                }

    

        }

        private void GameOver(string msg) // Handle Player Enemy Collions Or Game Completion
        {
            label1.Text = msg;
            label1.Location = new Point(this.Width / 2 - 200, 80);
            label1.Visible = true;
            Replay.Visible = true;
            Exit.Visible = true;
            backGroundMusic.controls.stop();
            StopTimers();
        }

        private void StopTimers()
        {
            MoveBackGround.Stop();
            MoveEnemyTimer.Stop();
            ShootBullet.Stop();
            EnemyShootTimer.Stop();
            BonusBulletsMove.Stop();
            ReleaseBonus.Stop();
        }

        private void StartTimers()
        {
            MoveBackGround.Start();
            MoveEnemyTimer.Start();
            ShootBullet.Start();
            EnemyShootTimer.Start();
        }

        private void Replay_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void MoveBonus(PictureBox[] bonus)
        {

            int speed = 3;
            int x = random.Next(0, 1);
            bonus[x].Visible = true;
            bonus[x].Top += speed;

            if (bonus[x].Top > this.Height)
            {
                bonus[x].Location = new Point((x + random.Next(1, 10)) * 50, -100);
            }

        }

        private void ReleaseBonus_Tick(object sender, EventArgs e)
        {
            if (BonusBulletsMove.Enabled)
            {
                bonuses[0].Location = new Point((random.Next(1, 10)) * 50, -100);
                bonuses[1].Location = new Point((random.Next(1, 10)) * 50, -100);
                return;
            }
            else
            {
                MoveBonus(bonuses);
            }


        }

        private void BonusBulletsMove_Tick(object sender, EventArgs e)
        {

            bullets[0].Visible = false;
            bullets[1].Visible = false;
            bullets[2].Visible = false;

            for (int i = 0; i < bonusBullets.Length; i++)
            {
                if (bonusBullets[i].Top > 0)
                {
                    bonusBullets[i].Visible = true;
                    bonusBullets[i].Top -= bonusBulletSpeed;
                    Collision();

                }
                else
                {
                    bonusBullets[i].Visible = false;
                    bonusBullets[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                    ShootingSound.controls.play();
                }
            }

        }

        private async void BonusCount_Tick(object sender, EventArgs e)
        {

            start++;
 

            if (start == 10)
            {
                start = 0;
                BonusBulletsMove.Stop();
                ShootBullet.Start();
                BonusCount.Stop();

            }

        }
    }
}
