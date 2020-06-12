﻿using Analiza_isplativosti_projekta.BazaPodataka;
using Analiza_isplativosti_projekta.Klase;
using Analiza_isplativosti_projekta.LINQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analiza_isplativosti_projekta.Forms
{
    public partial class Troskovi_Form : Form
    {
        public int trosak1 = 0;
        public int trosak2 = 0;
        public Troskovi_Form()
        {
            InitializeComponent();
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SpremiBotun_Click(object sender, EventArgs e)
        {
            
            if (radioButton2.Checked) //pregled
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Niste unijeli naziv projekta", "Upozorenje");
                }
                else
                {
                    string keywords = textBox3.Text;
                    SqlConnection conn = new SqlConnection(myconnstr);
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblPrihTros WHERE name LIKE '%" + keywords + "%' ", conn);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);


                    dgv1.Columns[0].Visible = false;
                    dgv1.Columns[1].HeaderCell.Value = "Ime projekta";
                    dgv1.Columns[2].HeaderCell.Value = "Godina";
                    dgv1.Columns[3].Visible = false;
                    dgv1.Columns[4].Visible = false;
                    dgv1.Columns[5].Visible = false;
                    dgv1.Columns[6].HeaderCell.Value = "Troškovi rada";
                    dgv1.Columns[7].HeaderCell.Value = "Troškovi razvoja";
                    dgv1.Columns[8].Visible = false;
                    dgv1.Columns[9].HeaderCell.Value = "Ukupni troškovi";

                    dgv1.EnableHeadersVisualStyles = false;
                    dgv1.AllowUserToAddRows = false;
                    dgv1.AllowUserToDeleteRows = false;
                    dgv1.BorderStyle = BorderStyle.None;
                    dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                    dgv1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgv1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(2, 163, 157);
                    dgv1.DefaultCellStyle.SelectionForeColor = Color.White;
                    dgv1.BackgroundColor = Color.FromArgb(9, 9, 42);

                    dgv1.EnableHeadersVisualStyles = false;
                    dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 115, 234);
                    dgv1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;

                }
            }
            else if(radioButton5.Checked)
            {
                loadFormAgain();
            }
            else
            {
                MessageBox.Show("Odaberite uslugu.", "Obavijest");
            }
        }

        private void Troskovi_Form_Load(object sender, EventArgs e)
        {
            chart1.Series["S1"].IsValueShownAsLabel = true;
            chart1.Series["S1"].Points.AddXY("Troškovi rada", trosak1);
            chart1.Series["S1"].Points.AddXY("Troškovi razvoja", trosak2);
            loadFormAgain();
        }

        public void loadFormAgain()
        {
            radioButton5.Checked = true;
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblPrihTros", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv1.DataSource = dt;

            dgv1.Columns[0].Visible = false;
            dgv1.Columns[1].HeaderCell.Value = "Ime projekta";
            dgv1.Columns[2].HeaderCell.Value = "Godina";
            dgv1.Columns[3].Visible = false;
            dgv1.Columns[4].Visible = false;
            dgv1.Columns[5].Visible = false;
            dgv1.Columns[6].HeaderCell.Value = "Troškovi rada";
            dgv1.Columns[7].HeaderCell.Value = "Troškovi razvoja";
            dgv1.Columns[8].Visible = false;
            dgv1.Columns[9].HeaderCell.Value = "Ukupni troškovi";

            dgv1.EnableHeadersVisualStyles = false;
            dgv1.AllowUserToAddRows = false;
            dgv1.AllowUserToDeleteRows = false;
            dgv1.BorderStyle = BorderStyle.None;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(2, 163, 157);
            dgv1.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv1.BackgroundColor = Color.FromArgb(9, 9, 42);

            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 115, 234);
            dgv1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;
        }

        private void dgv1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox3.Text = dgv1.Rows[rowIndex].Cells[1].Value.ToString();
            trosak1 = Convert.ToInt32(dgv1.Rows[rowIndex].Cells[6].Value);
            trosak2 = Convert.ToInt32(dgv1.Rows[rowIndex].Cells[7].Value);
            chart1.Series["S1"].Points.Clear();
            chart1.Series["S1"].Points.AddXY("Prihodi", trosak1);
            chart1.Series["S1"].Points.AddXY("Troškovi", trosak2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Homepage_Form f = new Homepage_Form();
            f.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SpremiBotun.Text = "Prikaz po nazivu";
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SpremiBotun.Text = "Prikaz svega";
        }
    }
}
