using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BergonziVerifica
{
    public partial class Form1 : Form
    {
        BLLPezzi BLL;
        int riga = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BLL = new BLLPezzi();
            dataGridView1.DataSource = BLL.A();
        }
        private void btnCerca_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Ricerca(textBox1.Text);
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            riga = e.RowIndex;
        }
        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int ID = int.Parse(dataGridView1[0, riga].Value.ToString());

                FormModifica Mod = new FormModifica() { ID = ID };
                Mod.ShowDialog();
                dataGridView1.DataSource = BLL.A();
            }
            else
                MessageBox.Show("Niente da modificare");
        }
        private void btnNuovo_Click(object sender, EventArgs e)
        {
            FormModifica Mod = new FormModifica() { ID = -1 };
            Mod.ShowDialog();
            dataGridView1.DataSource = BLL.A();
        }
        private void btnCancella_Click(object sender, EventArgs e)
        {
            if (riga != -1)
            {
                BLL.Elimina(int.Parse(dataGridView1[0, riga].Value.ToString()));
                dataGridView1.DataSource = BLL.A();
            }
        }

        private void btnEsporta_Click(object sender, EventArgs e)
        {
            FormEsporta esporta = new FormEsporta();
            esporta.ShowDialog();
        }
    }
}
