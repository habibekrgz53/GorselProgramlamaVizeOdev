using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GörselProgramlamaGörev1
{
    public partial class Emanetİşleri : Form
    {
        public Emanetİşleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ÖdünçAlma customdialog = new ÖdünçAlma();
            DialogResult sonuc = customdialog.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GeriVerme customdialog = new GeriVerme();
            DialogResult sonuc = customdialog.ShowDialog();

        }
    }
}
