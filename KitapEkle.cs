using gorselProgramlama;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GörselProgramlamaGörev1
{
    public partial class KitapEkle : Form
    {
        private DataTable dt = new DataTable(); // DataTable dt'yi başlatın
        public static List<Kitaplar> kitaplar = new List<Kitaplar>();

        public KitapEkle()
        {
            InitializeComponent();

           
            dt.Columns.Add("Kitap Adı");
            dt.Columns.Add("Yazarın Adı");
            dt.Columns.Add("Kitap Numarası");
            dt.Columns.Add("Yayın Evi");
            dt.Columns.Add("Türü");
            dt.Columns.Add("Basım Tarihi");
            dt.Columns.Add("Kitabın Durumu");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kitaplar kitap = new Kitaplar();
            kitap.KitapAdi = textBox1.Text;
            kitap.YazarAdi = textBox2.Text;
            kitap.KitapNo = textBox3.Text;
            kitap.YayınEvi = textBox4.Text;
            kitap.KitapTürü = textBox5.Text;
            kitap.BasımTarihi = dateTimePicker1.Bottom;


            
            kitaplar.Add(kitap);

            
            string yazilacak = JsonSerializer.Serialize<List<Kitaplar>>(kitaplar);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JSON Dosyasi|*.json";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string KitaplarListesi = dialog.FileName;
                File.WriteAllText(KitaplarListesi, yazilacak, Encoding.UTF8);
            }

            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele(); 
        }

        public void Listele()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON Dosyasi|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string data = File.ReadAllText(dialog.FileName);
                kitaplar = JsonSerializer.Deserialize<List<Kitaplar>>(data);

                
                foreach (Kitaplar kitap in kitaplar)
                {
                    DataRow row = dt.NewRow();
                    row["Kitap Adı"] = kitap.KitapAdi;
                    row["Yazarın Adı"] = kitap.YazarAdi;
                    row["Kitap Numarası"] = kitap.KitapNo;
                    row["Yayın Evi"] = kitap.YayınEvi;
                    row["Türü"] = kitap.KitapTürü;
                    row["Basım Tarihi"] = kitap.BasımTarihi;
                    row["Kitabın Durumu"] = kitap.kitabınDurum;
                    dt.Rows.Add(row);
                }

            }
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
