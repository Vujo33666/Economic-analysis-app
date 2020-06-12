using Analiza_isplativosti_projekta.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Analiza_isplativosti_projekta.Klase;
using System.Data.SqlClient;
using System.Configuration;
using Analiza_isplativosti_projekta.LINQ;
using System.Collections;
using Analiza_isplativosti_projekta.BazaPodataka;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;

namespace Analiza_isplativosti_projekta
{
    public partial class Homepage_Form : Form
    {
        public int trosak = 0;
        public int prihod = 0;
        public Homepage_Form()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            Prihodi_Form f = new Prihodi_Form();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Troskovi_Form f = new Troskovi_Form();
            f.Show();
            this.Hide();
        }

        #region Exit&Minimize
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void Homepage_Form_Load(object sender, EventArgs e)
        {
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series1"].Points.AddXY("Prihodi", prihod);
            chart1.Series["Series1"].Points.AddXY("Troškovi", trosak);
            chart1.Series["Series1"].Points.AddXY("Profit", prihod-trosak);

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblProfit", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv1.DataSource = dt;
            dgv1.Columns[0].Visible = false;
            dgv1.Columns[1].HeaderCell.Value = "Projekt";
            dgv1.Columns[2].Visible = false;
            dgv1.Columns[3].Visible = false;
            dgv1.Columns[4].HeaderCell.Value = "Prihodi";
            dgv1.Columns[5].HeaderCell.Value = "Rashodi";
            dgv1.Columns[6].HeaderCell.Value = "Profit";

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

            //ucitavanje podatka za prvu ukoliko postoji u dgv-u
            if (dgv1.RowCount>0)
            {
                label4.Text = dgv1.Rows[0].Cells[4].Value.ToString() + "kn";
                label5.Text = dgv1.Rows[0].Cells[5].Value.ToString() + "kn";
                label12.Text = dgv1.Rows[0].Cells[6].Value.ToString() + "kn";
                double temp1 = Convert.ToDouble(dgv1.Rows[0].Cells[6].Value);
                double temp2 = Convert.ToDouble(dgv1.Rows[0].Cells[5].Value);
                temp1 /= temp2;
                temp1 = Math.Round(temp1, 5);
                label17.Text = temp1.ToString();
                label1.Text = "Analiza ekonomske izvedivosti projekta:" + " '" + dgv1.Rows[0].Cells[1].Value.ToString() + "'";

            }

            
        }
        private void dgv1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProfitDataContext db1 = new ProfitDataContext();
            var varijabla = from s in db1.tblProfits select s.name;
            string[] ime = varijabla.ToArray();

            int rowIndex = e.RowIndex;
            label4.Text = dgv1.Rows[rowIndex].Cells[4].Value.ToString() + "kn";
            label5.Text = dgv1.Rows[rowIndex].Cells[5].Value.ToString() + "kn";
            label12.Text = dgv1.Rows[rowIndex].Cells[6].Value.ToString() + "kn";
            float temp1 = Convert.ToInt32(dgv1.Rows[rowIndex].Cells[6].Value);
            float temp2= Convert.ToInt32(dgv1.Rows[rowIndex].Cells[5].Value);
            temp1 /= temp2;
            label17.Text = temp1.ToString();
            label1.Text= "Analiza ekonomske izvedivosti projekta:"+ " '"+dgv1.Rows[rowIndex].Cells[1].Value.ToString() + "'";



            prihod = Convert.ToInt32(dgv1.Rows[rowIndex].Cells[4].Value);
            trosak = Convert.ToInt32(dgv1.Rows[rowIndex].Cells[5].Value);
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series1"].Points.AddXY("Prihodi", prihod);
            chart1.Series["Series1"].Points.AddXY("Troškovi", trosak);
            chart1.Series["Series1"].Points.AddXY("Profit", prihod - trosak);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Profit_Forms f = new Profit_Forms();
            f.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e) //ADD new
        {
            DodajNovi_Form f = new DodajNovi_Form();
            f.Show();
            this.Hide();
        }

        private void dgv1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Homepage_Form f = new Homepage_Form();
            f.Show();
            this.Hide();
        }
    }
}
