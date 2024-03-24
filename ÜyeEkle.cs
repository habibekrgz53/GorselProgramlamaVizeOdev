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
            Uyeler uye=new Uyeler();
            uye.UyeAdi = textBox1.Text;
            uye.UyeSoyadi = textBox2.Text;



        }
    }
}
