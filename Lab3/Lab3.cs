using Library.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Library.DAO;

namespace Lab3 {
    public partial class Lab3 : Form {
        int pageIndex;
        int pageSize;
        Developer currentDev;
        public Lab3() {
            InitializeComponent();
            pageIndex = 1;
            pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            numericUpDown1.Minimum = 1;
            int total = DeveloperDao.Total();
            numericUpDown1.Maximum = total % pageSize==0 ? total/pageSize : total/pageSize+1;
            //MessageBox.Show(pageSize + "");
        }

        private void Lab3_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (ValidInfor()) {
                int rows = DeveloperDao.Insert(new Developer(tbName.Text, tbNotes.Text, tbCity.Text, tbCountry.Text, Convert.ToInt32(tbEstablish.Text)));
                MessageBox.Show(rows + "row(s) affected");
                LoadData();
                ResetField();
            }
        }

        private void ResetField() {
            tbName.Text = "";
            tbNotes.Text = "";
            tbCity.Text = "";
            tbCountry.Text = "";
            tbEstablish.Text = "";
        }

        private bool ValidInfor() {
            bool nameCheck = false, establish = false;
            if (tbName.Text.Equals(string.Empty)) {
                nameErr.Text = "this field cannot be empty";
            }
            else {
                nameCheck = true;
                nameErr.Text = "";
            }
            if(!new Regex(@"^\d{4}$").IsMatch(tbEstablish.Text)) {
                establishErr.Text = "invalid year";
            }
            else {
                establish = true;
                establishErr.Text = "";
            }
            return nameCheck && establish;
        }
        private void LoadData() {
            int total = DeveloperDao.Total();
            numericUpDown1.Maximum = total % pageSize == 0 ? total / pageSize : total / pageSize + 1;
            numericUpDown1.Value = 1;
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            string[] colname = {"Name", "Notes", "City", "Country", "Establish"};
            foreach (string item in colname) {
                dataGridView1.Columns.Add(item, item);
                dataGridView1.Columns[item].DataPropertyName = item;
                dataGridView1.Columns[item].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            edit.Text = "Notable games";
            edit.Name = "products";
            edit.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(edit);
            dataGridView1.DataSource = DeveloperDao.GetDevelopers(pageIndex, pageSize);
        }
        private void FormatDataGridView() {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            dataGridView1.DataSource = DeveloperDao.GetDevelopers((int)numericUpDown1.Value, pageSize);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex > 0) {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "products") {
                    Developer d = ((List<Developer>)dataGridView1.DataSource)[e.RowIndex];
                    NotableGames notableGames = new NotableGames(d.ID);
                    notableGames.FormClosed += (s, evt) => {
                        LoadData();
                    };
                    notableGames.Show();
                }
                else {
                    //MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
                    return;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            //MessageBox.Show("cell content");
            if(dataGridView1.Columns[e.ColumnIndex].Name != "products")
                MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            currentDev = ((List<Developer>)dataGridView1.DataSource)[e.RowIndex];
            tbName.Text = currentDev.Name;
            tbNotes.Text = currentDev.Notes;
            tbCountry.Text = currentDev.Country;
            tbCity.Text = currentDev.City;
            tbEstablish.Text = currentDev.Establish+"";
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            if (currentDev != null) {
                currentDev.Name = tbName.Text;
                currentDev.Notes = tbNotes.Text;
                currentDev.City = tbCity.Text;
                currentDev.Country = tbCountry.Text;
                currentDev.Establish = Convert.ToInt32(tbEstablish.Text);
                int row = DeveloperDao.Update(currentDev);
                MessageBox.Show(row + "row(s) affected");
                LoadData();
            }
        }
    }
}
