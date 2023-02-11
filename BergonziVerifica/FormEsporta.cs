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
    public partial class FormEsporta : Form
    {
        BLLPezzi BLL;
        List<int> ls;
        public FormEsporta()
        {
            InitializeComponent();
        }
        private void FormEsporta_Load(object sender, EventArgs e)
        {
            BLL = new BLLPezzi();
            DataTable table = BLL.CMBCase();
            ls = new List<int>();
            foreach (DataRow elem in table.Rows)
            {
                comboBox1.Items.Add(elem[0]);
                ls.Add(int.Parse(elem[1].ToString()));
            }
            comboBox1.SelectedItem = comboBox1.Items[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str = BLL.Esporta(ls[comboBox1.SelectedIndex]);

            Close();
        }
    }
}
