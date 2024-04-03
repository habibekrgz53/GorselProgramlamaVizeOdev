using gorselProgramlama;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        private int IdFLag = -1;
        private int bookIDCounter = 0;
        private DataTable dt = new DataTable(); // DataTable dt'yi başlatın
        public static List<Kitaplar> kitaplar = new List<Kitaplar>();

        public KitapEkle()
        {
            InitializeComponent();
            dt.Columns.Add("Kitap ID");
            dt.Columns.Add("Kitap Numarası");
            dt.Columns.Add("Yazar Adı");
            dt.Columns.Add("Kitap Adı");
            dt.Columns.Add("Yayın Evi");
            dt.Columns.Add("Türü");
            dt.Columns.Add("Basım Tarihi");
            dt.Columns.Add("Kitabın Durumu");

            dataGridView1.DataSource = dt;


        }
        private void ResetInputsForValue()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Kitaplar kitap = new Kitaplar();
            kitap.KitapNo = textBox1.Text;
            kitap.YazarAdi = textBox2.Text;
            kitap.KitapAdi = textBox3.Text;
            kitap.YayınEvi = textBox4.Text;
            kitap.KitapTürü = textBox5.Text;
            kitap.BasımTarihi = dateTimePicker1.Text;
            kitap.KitapID = ++bookIDCounter;

            kitap.TabloyaEkle(dt);
            kitaplar.Add(kitap);


            string yazilacak = JsonSerializer.Serialize<List<Kitaplar>>(kitaplar);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JSON Dosyasi|*.json";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string KitaplarListesi = dialog.FileName;
                File.WriteAllText(KitaplarListesi, yazilacak, Encoding.UTF8);
            }

            ResetInputsForValue();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;

            object KitapIdObject = dataGridView1[0, selectedRowIndex].Value;
            object KitapNoObject = dataGridView1[1, selectedRowIndex].Value;
            object yazarAdiObject = dataGridView1[2, selectedRowIndex].Value;
            object kitapAdiObject = dataGridView1[3, selectedRowIndex].Value;
            object yayinEviObject = dataGridView1[4, selectedRowIndex].Value;
            object kitapTuruObject = dataGridView1[5, selectedRowIndex].Value;
            object basimTarihiObject = dataGridView1[6, selectedRowIndex].Value;
            object kitabinDurumuObject = dataGridView1[7, selectedRowIndex].Value;


            var dataController = string.IsNullOrWhiteSpace;


            if (KitapIdObject == null)
            {
                MessageBox.Show("Lütfen geçerli üye seçiniz.");
            }
            else
            {
                string kitapID = KitapIdObject.ToString();
                string kitapNo = KitapNoObject.ToString();
                string yazarAdi = yazarAdiObject.ToString();
                string kitapAdi = kitapAdiObject.ToString();
                string yayinEvi = yayinEviObject.ToString();
                string kitapTuru = kitapTuruObject.ToString();
                string basimTarihi = basimTarihiObject.ToString();
                string kitapDurum = kitabinDurumuObject.ToString();

                textBox1.Text = kitapNo;
                textBox2.Text = yazarAdi;
                textBox3.Text = kitapAdi;
                textBox4.Text = yayinEvi;
                textBox5.Text = kitapTuru;
                dateTimePicker1.Text = basimTarihi;
                IdFLag = Convert.ToInt32(kitapID);


                button1.Visible = false;
                button2.Visible = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;

            object KitapIdObject = dataGridView1[0, selectedRowIndex].Value;

            if (KitapIdObject == null)
            {
                MessageBox.Show("Lütfen geçerli bir üye seçiniz.");
            }
            else
            {
                int rowIndex = -1;
                foreach (DataRow row in dt.Rows)
                {

                    if (row["Kitap ID"].ToString() == KitapIdObject.ToString())
                    {
                        rowIndex = row.Table.Rows.IndexOf(row);
                        break;
                    }
                }

                if (rowIndex != -1)
                {
                    dt.Rows.RemoveAt(rowIndex);
                    int index = kitaplar.FindIndex(kitap => kitap.KitapID == Convert.ToInt32(KitapIdObject.ToString()));
                    kitaplar.RemoveAt(index);

                    string yazilacak = JsonSerializer.Serialize<List<Kitaplar>>(kitaplar);

                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "JSON Dosyasi|*.json";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string KitaplarListesi = dialog.FileName;
                        File.WriteAllText(KitaplarListesi, yazilacak, Encoding.UTF8);
                    }
                }

                dt.AcceptChanges();
            }
        }
    
    

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON Dosyasi|*.json";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string KitaplarListesi = dialog.FileName;
                kitaplar = JsonSerializer.Deserialize<List<Kitaplar>>(File.ReadAllText(KitaplarListesi, Encoding.UTF8));
                dt.Clear();
                foreach (Kitaplar kitap in kitaplar)
                {
                    kitap.TabloyaEkle(dt);
                }
                bookIDCounter = kitaplar.Count;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kitaplar guncelKitap= new Kitaplar();
            var dataController= string.IsNullOrWhiteSpace;
            
            string kitapNo=textBox1.Text;
            string yazarAdi=textBox2.Text;
            string kitapAdi=textBox3.Text;
            string yayinEvi=textBox4.Text;
            string kitapTuru=textBox5.Text;
            string basimTarihi = dateTimePicker1.Text;

            if (dataController(kitapNo) || dataController(yazarAdi) || dataController(kitapAdi) || dataController(yayinEvi) || dataController(kitapTuru) || dataController(basimTarihi))
            {
                MessageBox.Show("Lütfen tüm verileri eksiksiz giriniz.");
            }

            else 
            {
                if (IdFLag > -1)
                {
                    guncelKitap.KitapID = IdFLag;
                    guncelKitap.KitapNo = kitapNo;
                    guncelKitap.YazarAdi = yazarAdi;
                    guncelKitap.KitapAdi = kitapAdi;
                    guncelKitap.YayınEvi = yayinEvi;
                    guncelKitap.KitapTürü = kitapTuru;
                    guncelKitap.BasımTarihi = basimTarihi;

                    guncelKitap.TabloyaEkle(dt);
                    int index =kitaplar.FindIndex(kitap=>kitap.KitapID == IdFLag);
                    if(index != -1)
                    {
                        kitaplar[index] = guncelKitap;
                        IdFLag = -1;

                        string yazilacak = JsonSerializer.Serialize<List<Kitaplar>>(kitaplar);

                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.Filter = "JSON Dosyasi|*.json";
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            string KitaplarListesi = dialog.FileName;
                            File.WriteAllText(KitaplarListesi, yazilacak, Encoding.UTF8);
                        }
                        ResetInputsForValue();
                    }
                }
                button2.Visible = false;
                button1.Visible = true;
            }
        }
    }
}
