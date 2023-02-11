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
    public partial class FormModifica : Form
    {
        public int ID { get; set; }
        BLLPezzi BLL;
        List<int> listID;
        public FormModifica()
        {
            InitializeComponent();
        }
        private void FormModifica_Load(object sender, EventArgs e)
        {
            BLL = new BLLPezzi();
            listID = new List<int>();

            DataTable table = BLL.CMBCase();
            foreach (DataRow elem in table.Rows)
            {
                cmbCasa.Items.Add(elem[0]);
                listID.Add(int.Parse(elem[1].ToString()));
            }

            if (ID != -1)
            {
                table = BLL.SelectCMB(ID);
                cmbCasa.SelectedItem = table.Rows[0][0];
                txtNome.Text = table.Rows[0][1].ToString();
                txtDescrizione.Text = table.Rows[0][2].ToString();
                txtTipo.Text = table.Rows[0][3].ToString();
                numAnno.Value = int.Parse(table.Rows[0][4].ToString());
            }
            else
            {
                cmbCasa.SelectedItem = cmbCasa.Items[0];
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ID != -1)
                BLL.Modifica(ID, txtNome.Text, txtDescrizione.Text, txtTipo.Text, (int)numAnno.Value, listID[cmbCasa.SelectedIndex]);
            else
                BLL.PopolaPezzi(txtNome.Text, txtDescrizione.Text, txtTipo.Text, (int)numAnno.Value, listID[cmbCasa.SelectedIndex]);

            Close();
        }
    }
}
