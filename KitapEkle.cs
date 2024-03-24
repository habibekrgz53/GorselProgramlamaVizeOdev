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
    public partial class KitapEkle : Form
    {
        private List<Kitaplar> kitaplar;
        public KitapEkle()
        {
            InitializeComponent();
            kitaplar = new List<Kitaplar>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kitaplar kitap=new Kitaplar();
            kitap.KitapAdi = textBox1.Text;
            kitap.YazarAdi = textBox2.Text;
            kitap.KitapNo = Convert.ToInt32(textBox3.Text);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
