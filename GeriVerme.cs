using gorselProgramlama;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GörselProgramlamaGörev1
{
    public partial class GeriVerme : Form
    {
        List<Kitaplar> kitaplar = new List<Kitaplar>();
        public GeriVerme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kitapAdı = textBox1.Text;
            string kitapNo = textBox3.Text;
            foreach(Kitaplar kitap in kitaplar) 
            { 
                if(kitap.KitapAdi==kitapAdı && kitap.KitapNo == kitapNo)
                {
                    if (Convert.ToInt32(kitap.kitabınDurum) == 1)
                    {
                        kitap.kitabınDurum = 0;
                    }
                    else
                        MessageBox.Show("Bu kitap zaten mevcuttur.");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON Dosyasi|*.json";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string KitaplarListesi = dialog.FileName;
                kitaplar = JsonSerializer.Deserialize<List<Kitaplar>>(File.ReadAllText(KitaplarListesi, Encoding.UTF8));
            }
        }
    }
}
