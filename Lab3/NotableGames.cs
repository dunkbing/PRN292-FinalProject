using Library.DAO;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab3 {
    public partial class NotableGames : Form {
        int devid;
        List<Games> games;
        public NotableGames() {
            InitializeComponent();
        }
        public NotableGames(int devid) {
            InitializeComponent();
            this.devid = devid;
            games = GamesDao.GetGamesByDevID(devid);
            LoadData(devid);
        }

        private void LoadData(int devid) {
            string[] colnames = {"Title", "Introduction", "Genre", "Platform", "ReleaseDate" };
            dataGridView1.Columns.Clear();
            foreach (var item in colnames) {
                dataGridView1.Columns.Add(item, item);
                dataGridView1.Columns[item].DataPropertyName = item;
            }
            games = GamesDao.GetGamesByDevID(this.devid);
            dataGridView1.DataSource = games;
        }

        private void NotableGames_Load(object sender, EventArgs e) {
            LoadData(devid);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            Games editGame = games[e.RowIndex];
            int row = GamesDao.Update(editGame);
        }

        private void button1_Click(object sender, EventArgs e) {
            if (tbTitle.Text.Equals(string.Empty)) {
                titleErr.Text = "this field cannot be empty";
            } else {
                titleErr.Text = "";
                Games g = new Games();
                g.Title = tbTitle.Text;
                g.DevID = this.devid;
                g.Introduction = tbIntro.Text;
                g.Genre = tbGenre.Text;
                g.Platform = tbPlatform.Text;
                g.ReleaseDate = dateTimePicker1.Value;
                try {
                    GamesDao.Insert(g);
                    this.games.Add(g);
                    LoadData(this.devid);
                } catch (SqlException) {
                    MessageBox.Show("cannot insert duplicated title");
                }
            }
        }

    }
}
