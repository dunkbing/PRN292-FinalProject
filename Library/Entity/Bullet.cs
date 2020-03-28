using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace Library.Entity {
    public class Bullet : PictureBox {
        public string direction { get; set; }
        public int speed = 20;
        Timer t = new Timer();
        public int bulletLeft;
        public int bulletTop;
        public Vector vect;

        public void MakeBullet(Panel panel) {
            this.BackColor = System.Drawing.Color.White;
            this.Size = new System.Drawing.Size(5, 5);
            this.Tag = "bullet";
            this.Left = bulletLeft;
            this.Top = bulletTop;
            this.BringToFront();
            panel.Controls.Add(this);
            t.Interval = speed;
            t.Tick += new EventHandler(tm_tick);
            t.Start();
        }

        private void tm_tick(object sender, EventArgs e) {
            switch (direction) {
                case "left": this.Left -= speed; break;
                case "right": this.Left += speed; break;
                case "up": this.Top -= speed; break;
                case "down": this.Top += speed; break;
            }
            this.Left += Convert.ToInt32(vect.X)*speed;
            this.Top += Convert.ToInt32(vect.Y)*speed;
            if (this.Left < 10 || this.Left > 860 || this.Top < 60 || this.Top > 600) {
                t.Stop();
                t.Dispose();
                this.Dispose();
                t = null;
            }
        }
    }
}
