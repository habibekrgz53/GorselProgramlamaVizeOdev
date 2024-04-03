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
    
    public partial class ÖdünçAlma : Form
    {
        List<Kitaplar> kitaplar = new List<Kitaplar>();
        public enum kitabinDurumu { mevcut, mevcutDegil }
        public ÖdünçAlma()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string kitapAdı = textBox1.Text;
            string kitapNo = textBox3.Text;
            foreach (Kitaplar kitap in kitaplar)
            {
                if (kitap.KitapAdi == kitapAdı && kitap.KitapNo == kitapNo )
                {
                    kitap.DurumDegistir();
                    MessageBox.Show("İşlem tamamlandı.");

                    string yazilacak = JsonSerializer.Serialize<List<Kitaplar>>(kitaplar);

                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "JSON Dosyasi|*.json";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string KitaplarListesi = dialog.FileName;
                        File.WriteAllText(KitaplarListesi, yazilacak, Encoding.UTF8);
                    }
                }
                else
                    MessageBox.Show("Bu kitap mevcut değildir.");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
