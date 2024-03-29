using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using gorselProgramlama;
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
    public partial class ÜyeEkle : Form
    {

        private List<Uyeler> uyeler;

        public ÜyeEkle()
        {
            InitializeComponent();
            uyeler = new List<Uyeler>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uyeler uye = new Uyeler();
            uye.UyeAdi = textBox1.Text;
            uye.UyeSoyadi = textBox2.Text;
            uye.UyeMail = textBox3.Text;
            uye.UyeTel = textBox4.Text;
            this.Close();

        }

        private void ÜyeEkle_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
