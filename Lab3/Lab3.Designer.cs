namespace Lab3 {
    partial class Lab3 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEstablish = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameErr = new System.Windows.Forms.Label();
            this.notesErr = new System.Windows.Forms.Label();
            this.cityErr = new System.Windows.Forms.Label();
            this.countryErr = new System.Windows.Forms.Label();
            this.establishErr = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(152, 62);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(175, 22);
            this.tbName.TabIndex = 2;
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(152, 116);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(175, 93);
            this.tbNotes.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "notes";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(152, 234);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(175, 22);
            this.tbCity.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "city";
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(152, 291);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(175, 22);
            this.tbCountry.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "country";
            // 
            // tbEstablish
            // 
            this.tbEstablish.Location = new System.Drawing.Point(152, 348);
            this.tbEstablish.Name = "tbEstablish";
            this.tbEstablish.Size = new System.Drawing.Size(100, 22);
            this.tbEstablish.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "establish";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(102, 415);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Text = "insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(371, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(799, 371);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // nameErr
            // 
            this.nameErr.AutoSize = true;
            this.nameErr.ForeColor = System.Drawing.Color.Red;
            this.nameErr.Location = new System.Drawing.Point(177, 87);
            this.nameErr.Name = "nameErr";
            this.nameErr.Size = new System.Drawing.Size(0, 17);
            this.nameErr.TabIndex = 13;
            // 
            // notesErr
            // 
            this.notesErr.AutoSize = true;
            this.notesErr.ForeColor = System.Drawing.Color.Red;
            this.notesErr.Location = new System.Drawing.Point(282, 119);
            this.notesErr.Name = "notesErr";
            this.notesErr.Size = new System.Drawing.Size(0, 17);
            this.notesErr.TabIndex = 14;
            // 
            // cityErr
            // 
            this.cityErr.AutoSize = true;
            this.cityErr.ForeColor = System.Drawing.Color.Red;
            this.cityErr.Location = new System.Drawing.Point(282, 237);
            this.cityErr.Name = "cityErr";
            this.cityErr.Size = new System.Drawing.Size(0, 17);
            this.cityErr.TabIndex = 15;
            // 
            // countryErr
            // 
            this.countryErr.AutoSize = true;
            this.countryErr.ForeColor = System.Drawing.Color.Red;
            this.countryErr.Location = new System.Drawing.Point(282, 296);
            this.countryErr.Name = "countryErr";
            this.countryErr.Size = new System.Drawing.Size(0, 17);
            this.countryErr.TabIndex = 16;
            // 
            // establishErr
            // 
            this.establishErr.AutoSize = true;
            this.establishErr.ForeColor = System.Drawing.Color.Red;
            this.establishErr.Location = new System.Drawing.Point(177, 373);
            this.establishErr.Name = "establishErr";
            this.establishErr.Size = new System.Drawing.Size(0, 17);
            this.establishErr.TabIndex = 17;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(724, 468);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(47, 22);
            this.numericUpDown1.TabIndex = 20;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(207, 415);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Lab3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 508);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.establishErr);
            this.Controls.Add(this.countryErr);
            this.Controls.Add(this.cityErr);
            this.Controls.Add(this.notesErr);
            this.Controls.Add(this.nameErr);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.tbEstablish);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbCountry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Name = "Lab3";
            this.Text = "Lab3";
            this.Load += new System.EventHandler(this.Lab3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEstablish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label nameErr;
        private System.Windows.Forms.Label notesErr;
        private System.Windows.Forms.Label cityErr;
        private System.Windows.Forms.Label countryErr;
        private System.Windows.Forms.Label establishErr;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnUpdate;
    }
}