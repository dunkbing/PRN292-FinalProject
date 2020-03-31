using Library.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace Lab3 {
    public partial class wtf : Form {
        public wtf() {
            InitializeComponent();
        }

        private void keyDown(object sender, KeyEventArgs e) {
            if (gameOver) return;
            if (e.KeyCode == Keys.Left) {
                goLeft = true;
                facing = "left";
                player.Image = Properties.Resources.spaceship_left;
            }
            if (e.KeyCode == Keys.Right) {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.spaceship_right;
            }
            if (e.KeyCode == Keys.Up) {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.spaceship;
            }
            if (e.KeyCode == Keys.Down) {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.spaceship_down;
            }
        }

        private void keyUp(object sender, KeyEventArgs e) {
            if (gameOver) return;
            switch (e.KeyCode) {
                case Keys.Left: goLeft = false; break;
                case Keys.Right: goRight = false; break;
                case Keys.Up: goUp = false; break;
                case Keys.Down: goDown = false; break;
            }
            if (e.KeyCode == Keys.Space && ammo > 0) {
                //reduce ammo by 1
                ammo--;
                Shoot(facing);
                if (ammo < 1) DropAmmo();
            }
        }

        private void gameLoop(object sender, EventArgs e) {
            if (playerHealth > 1) {
                progressBar1.Value = Convert.ToInt32(playerHealth);
            }
            else {
                player.Image = Properties.Resources.spaceship; //show player dead img
                timer1.Stop();
                gameOver = true;
            }

            ammoLb.Text = "Ammo: " + ammo;//show ammo
            killLb.Text = "Kills " + score;//show total kills
            if (playerHealth < 20) {
                progressBar1.ForeColor = System.Drawing.Color.Red;
            }
            if (goLeft && player.Left > 0) {
                player.Left -= speed;
            }
            if (goRight && player.Left + player.Width < this.Width) {
                player.Left += speed;
            }
            if (goUp && player.Top > 60) {
                player.Top -= speed;
            }
            if (goDown && player.Top + player.Height < this.Height) {
                player.Top += speed;
            }
            foreach (Control item in panel1.Controls) {
                if (item is PictureBox && item.Tag.ToString() == "ammo") {
                    if (((PictureBox)item).Bounds.IntersectsWith(player.Bounds)) {
                        panel1.Controls.Remove((PictureBox)item);
                        ((PictureBox)item).Dispose();
                        ammo += 5;
                    }
                }
                if (item is PictureBox && item.Tag.ToString() == "bullet") {
                    if (item.Left < 1 || item.Left > panel1.Width || item.Top < 10 || item.Top > panel1.Height) {
                        panel1.Controls.Remove(item);
                        item.Dispose();
                    }
                }
                if (item is PictureBox && item.Tag.ToString() == "monster") {
                    if (((PictureBox)item).Bounds.IntersectsWith(player.Bounds)) {
                        playerHealth -= 1;
                    }
                    if (((PictureBox)item).Left > player.Left) {
                        ((PictureBox)item).Left -= zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.monster_left;
                    }
                    if (((PictureBox)item).Top > player.Top) {
                        ((PictureBox)item).Top -= zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.monster_up;
                    }
                    if (((PictureBox)item).Left < player.Left) {
                        ((PictureBox)item).Left += zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.monster_right;
                    }
                    if (((PictureBox)item).Top < player.Top) {
                        ((PictureBox)item).Top += zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.monster_down;
                    }
                }
                foreach (Control control in panel1.Controls) {
                    if ((control is PictureBox && control.Tag.ToString() == "bullet") && (item is PictureBox && item.Tag.ToString() == "monster")) {
                        if (item.Bounds.IntersectsWith(control.Bounds)) {
                            score++;
                            this.panel1.Controls.Remove(control);
                            control.Dispose();
                            this.panel1.Controls.Remove(item);
                            item.Dispose();
                            SpawnEnemies();
                        }
                    }
                }
            }
        }
        private void DropAmmo() {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = rnd.Next(10, panel1.Width - 60);
            ammo.Top = rnd.Next(10, panel1.Height - 60);
            ammo.Tag = "ammo";
            panel1.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }
        private void Shoot(string direct) {
            Bullet bullet = new Bullet();
            bullet.direction = direct;
            bullet.bulletLeft = player.Left + (player.Width / 2);
            bullet.bulletTop = player.Top + (player.Height / 2);
            bullet.MakeBullet(panel1);
        }
        private void SpawnEnemies() {
            PictureBox monster = new PictureBox();
            monster.Tag = "monster";
            monster.Image = Properties.Resources.monster_down;
            monster.Left = rnd.Next(0, panel1.Width);
            monster.Top = rnd.Next(60, panel1.Height);
            monster.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.Controls.Add(monster);
            player.BringToFront();
        }

        //variables
        bool goUp;
        bool goDown;
        bool goLeft;
        bool goRight;
        string facing = "up";
        double playerHealth = 100;
        int speed = 10;
        int ammo = 1000;
        int zombieSpeed = 3;
        int score = 0;
        bool gameOver = false;
        Random rnd = new Random();

        private void shoot(object sender, MouseEventArgs e) {
            Vector v = new Vector(e.X, e.Y);
            Bullet bullet = new Bullet();
            bullet.bulletLeft = player.Left + (player.Width / 2);
            bullet.bulletTop = player.Top + (player.Height / 2);
            bullet.vect = v - new Vector(bullet.bulletLeft, bullet.bulletTop);
            bullet.vect.Normalize();
            bullet.MakeBullet(panel1);
        }
    }
}
