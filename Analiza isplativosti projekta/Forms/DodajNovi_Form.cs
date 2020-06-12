using Analiza_isplativosti_projekta.BazaPodataka;
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
    public partial class DodajNovi_Form : Form
    {
        public DodajNovi_Form()
        {
            InitializeComponent();
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;
        classPrihodiTroskovi p = new classPrihodiTroskovi();
        DB_PrihodiTroskovi b = new DB_PrihodiTroskovi();
        DB_Profit bb = new DB_Profit();
        classProfit pp = new classProfit();

        private void button1_Click(object sender, EventArgs e)
        {
            PrihTrosDataContext db1 = new PrihTrosDataContext();
            ProfitDataContext db2 = new ProfitDataContext();

            var varijabla = from s in db1.tblPrihTros select s.name;
            string[] ime = varijabla.ToArray();
            var varijabla2 = from s in db1.tblPrihTros select s.year;
            int[] broj = varijabla2.ToArray();

            var varijabla3 = from s in db2.tblProfits select s.name;
            string[] profit_ime = varijabla3.ToArray();
            var varijabla4 = from s in db2.tblProfits select s.year;
            int[] profit_godina = varijabla4.ToArray();
            var varijabla5 = from s in db2.tblProfits select s.ukupni_prihodi;
            int[] profit_prihodi = varijabla5.ToArray();
            var varijabla6 = from s in db2.tblProfits select s.ukupni_troskovi;
            int[] profit_troskovi = varijabla6.ToArray();

            bool temp = false;
            bool temp2 = true;
            bool temp3 = true;
            int index = 0;
            int sumaprihoda = 0;
            int sumatroskova = 0;
            int rez = 0;

            string korisnikov_unos = textBox3.Text;
            int korisnikov_unos_int = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 0; i < ime.Length; i++)
            {
                if (korisnikov_unos == ime[i] && korisnikov_unos_int == broj[i])
                {
                    temp2 = false;
                }
            }

            if (radioButton1.Checked)
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Niste unijeli naziv projekta", "Upozorenje");
                }
                else
                {
                    if (temp == int.TryParse(textBox1.Text, out rez) || temp == int.TryParse(textBox2.Text, out rez) ||  temp == int.TryParse(textBox6.Text, out rez) || temp == int.TryParse(textBox4.Text, out rez))
                    {
                        MessageBox.Show("Unesite brojeve bez slova i karaktera", "Obavijest");
                            textBox2.Text = "0";
                            textBox1.Text = "0";
                            textBox4.Text = "0";
                            textBox6.Text = "0";
                    }
                    else
                    {
                        if (temp2)
                        {
                            var result = MessageBox.Show("Potvrdite da želite dodati ove podatke.", "Obavijest", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                p.name = textBox3.Text;
                                p.year = Convert.ToInt32(numericUpDown1.Value);
                                //p.years in progress ostavit
                                p.povecanje_zarade = Convert.ToInt32(textBox1.Text);
                                p.smanjenje_troskova = Convert.ToInt32(textBox2.Text);
                                p.troskovi_rada = Convert.ToInt32(textBox6.Text);
                                p.troskovi_razvoja = Convert.ToInt32(textBox4.Text);
                                p.ukupni_prihodi = p.povecanje_zarade + p.smanjenje_troskova;
                                p.ukupni_troskovi = p.troskovi_razvoja + p.troskovi_rada;
                                bool success = b.Insert(p);
                                if (success)
                                {
                                    MessageBox.Show("Uspješno ste unijeli podatke projekta: " + p.name + " za godinu: " + p.year + ".", "Obavijest");
                                    loadFormAgain();
                                    for(int i=0;i<profit_ime.Length;i++)
                                    {
                                        if(korisnikov_unos == profit_ime[i])
                                        {
                                            temp3 = false;
                                        }
                                    }

                                    if(temp3)
                                    {
                                        pp.name = textBox3.Text;
                                        pp.year = Convert.ToInt32(numericUpDown1.Value);
                                        //pp.years in progress ostavit
                                        pp.ukupni_prihodi = p.povecanje_zarade + p.smanjenje_troskova;
                                        pp.ukupni_troskovi = p.troskovi_razvoja + p.troskovi_rada;
                                        pp.profit = pp.ukupni_prihodi - pp.ukupni_troskovi;
                                        bool success2 = bb.Insert(pp);
                                        if (!success2)
                                        {
                                            MessageBox.Show("Desila se pogreška prilikom unosa u bazu podataka profita.", "Obavijest");
                                        }
                                        loadFormAgain();
                                    }
                                    else
                                    {
                                        pp.name = textBox3.Text;
                                        pp.year = Convert.ToInt32(numericUpDown1.Value);
                                        //pp.years in progress ostavit
                                        for(int i=0;i<profit_ime.Length;i++)
                                        {
                                            if (korisnikov_unos == profit_ime[i])
                                            {
                                                sumaprihoda+=profit_prihodi[i];
                                                sumatroskova += profit_troskovi[i];
                                            }
                                        }
                                        pp.ukupni_prihodi = p.povecanje_zarade + p.smanjenje_troskova+sumaprihoda;
                                        pp.ukupni_troskovi = p.troskovi_razvoja + p.troskovi_rada+sumatroskova;
                                        pp.profit = pp.ukupni_prihodi - pp.ukupni_troskovi;
                                        bool success2 = bb.UpdateNew(pp);
                                        if (!success2)
                                        {
                                            MessageBox.Show("Desila se pogreška prilikom promjene podataka u bazu podataka profita.", "Obavijest");
                                        }
                                        loadFormAgain();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Desila se pogreška prilikom unosa podataka u bazu.", "Obavijest");
                                }
                            }
                            else
                            {
                                loadFormAgain();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Projekt pod tim imenom i godinom se već nalazi u bazi podataka. Promijenite naziv ili godinu.", "Obavijest");
                        }
                    }
                }
            }
            else if (radioButton3.Checked)
            {
                textBox3.ReadOnly = true;
                if (temp == int.TryParse(textBox1.Text, out rez) || temp == int.TryParse(textBox2.Text, out rez) || temp == int.TryParse(textBox6.Text, out rez) || temp == int.TryParse(textBox4.Text, out rez))
                {
                    MessageBox.Show("Unesite brojeve bez slova i karaktera", "Obavijest");
                }
                else
                {
                    if (temp2 == false)
                    {
                        var result = MessageBox.Show("Jeste li sigurni da želite urediti podatke?", "Obavijest", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            p.name = textBox3.Text;
                            p.year = Convert.ToInt32(numericUpDown1.Value);
                            //p.years in progress ostavit
                            p.povecanje_zarade = Convert.ToInt32(textBox1.Text);
                            p.smanjenje_troskova = Convert.ToInt32(textBox2.Text);
                            p.troskovi_rada = Convert.ToInt32(textBox6.Text);
                            p.troskovi_razvoja = Convert.ToInt32(textBox4.Text);
                            p.ukupni_prihodi = p.povecanje_zarade + p.smanjenje_troskova;
                            p.ukupni_troskovi = p.troskovi_razvoja + p.troskovi_rada;
                            bool success = b.Update(p);
                            if (success)
                            {
                                MessageBox.Show("Uspješno ste promijenili podatke projekta: " + p.name + " za godinu: " + p.year+".","Obavijest");
                                pp.name = textBox3.Text;
                                pp.year = Convert.ToInt32(numericUpDown1.Value);
                                //pp.years in progress ostavit
                                pp.ukupni_prihodi = p.povecanje_zarade + p.smanjenje_troskova;
                                pp.ukupni_troskovi = p.troskovi_razvoja + p.troskovi_rada;
                                pp.profit = pp.ukupni_prihodi - pp.ukupni_troskovi;
                                bool success2 = bb.Update(pp);
                                if (!success2)
                                {
                                    MessageBox.Show("Desila se pogreška prilikom promjene podataka u bazu podataka profita.", "Obavijest");
                                }
                                loadFormAgain();
                            }
                            else
                            {
                                MessageBox.Show("Desila se pogreška prilikom promjene podataka.", "Obavijest");
                            }
                        }
                        else
                        {
                            loadFormAgain();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ne možete promijeniti podatke projekta: " + textBox3.Text + " za godinu: " + numericUpDown1.Value + " jer ne postoje u bazi.", "Obavijest");
                    }
                }
            }
            else if (radioButton4.Checked)
            {
                if (temp2 == false)
                {
                    var result = MessageBox.Show("Jeste li sigurni da želite obrisati sve podatke projekta?", "Obavijest", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        p.name = textBox3.Text;
                        p.year = Convert.ToInt32(numericUpDown1.Value);
                        //p.years in progress ostavit
                        p.povecanje_zarade = Convert.ToInt32(textBox1.Text);
                        p.smanjenje_troskova = Convert.ToInt32(textBox2.Text);
                        p.troskovi_rada = Convert.ToInt32(textBox6.Text);
                        p.troskovi_razvoja = Convert.ToInt32(textBox4.Text);
                        p.ukupni_prihodi = p.povecanje_zarade + p.smanjenje_troskova;
                        p.ukupni_troskovi = p.troskovi_razvoja + p.troskovi_rada;
                        bool success = b.Delete(p);
                        if (success)
                        {
                            MessageBox.Show("Uspješno ste obrisali podatke projekta: " + p.name +" .", "Obavijest");
                            pp.name = textBox3.Text;
                            pp.year = Convert.ToInt32(numericUpDown1.Value);
                            //pp.years in progress ostavit
                            pp.ukupni_prihodi = p.povecanje_zarade + p.smanjenje_troskova;
                            pp.ukupni_troskovi = p.troskovi_razvoja + p.troskovi_rada;
                            pp.profit = pp.ukupni_prihodi - pp.ukupni_troskovi;
                            bool success2 = bb.Delete(pp);
                            if (!success2)
                            {
                                MessageBox.Show("Desila se pogreška prilikom brisanja baze podataka profita.", "Obavijest");
                            }
                            loadFormAgain();
                        }
                        else
                        {
                            MessageBox.Show("Desila se pogreška prilikom brisanja.", "Obavijest");
                        }
                    }
                    else
                    {
                        loadFormAgain();
                    }
                }
                else
                {
                    MessageBox.Show("Ne postoji projekt sa tim imenom i tom godinom u bazi!", "Obavijest");
                }
            }
            else
            {
                MessageBox.Show("Odaberite uslugu dodavanja novog projekta, uređivanja već postojećeg projekta ili brisanje svih podataka projekta.", "Obavijest");
            }
        }

        public void loadFormAgain()
        {
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblPrihTros", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv1.DataSource = dt;

            dgv1.Columns[0].Visible = false;
            dgv1.Columns[1].HeaderCell.Value = "Ime projekta";
            dgv1.Columns[2].HeaderCell.Value = "Godina";
            dgv1.Columns[3].Visible = false;//years in progress
            dgv1.Columns[4].HeaderCell.Value = "Porast zarade";
            dgv1.Columns[5].HeaderCell.Value = "Smanjenje troškova";
            dgv1.Columns[6].HeaderCell.Value = "Troškovi rada";
            dgv1.Columns[7].HeaderCell.Value = "Troškovi razvoja";
            dgv1.Columns[8].HeaderCell.Value = "Ukupni prihodi";
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

        private void DodajNovi_Form_Load(object sender, EventArgs e)
        {
            loadFormAgain();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SpremiBotun.Text = "Spremi";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SpremiBotun.Text = "Briši čitav projekt";
        }

        private void dgv1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox3.Text = dgv1.Rows[rowIndex].Cells[1].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal(dgv1.Rows[rowIndex].Cells[2].Value);
            textBox1.Text = dgv1.Rows[rowIndex].Cells[4].Value.ToString();
            textBox2.Text = dgv1.Rows[rowIndex].Cells[5].Value.ToString();
            textBox6.Text = dgv1.Rows[rowIndex].Cells[6].Value.ToString();
            textBox4.Text = dgv1.Rows[rowIndex].Cells[7].Value.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SpremiBotun.Text = "Promijeni podatke";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Homepage_Form f = new Homepage_Form();
            f.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
