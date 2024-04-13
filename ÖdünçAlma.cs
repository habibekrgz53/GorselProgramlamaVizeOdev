using gorselProgramlama;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GörselProgramlamaGörev1
{
    
    public partial class ÖdünçAlma : Form
    {
        private SQLiteConnection sqliteConnection2;
        private SQLiteCommand sqliteCommand;
        private int bookIDCounter = 0;
        private DataTable dt = new DataTable();
        List<Kitaplar> kitaplar = new List<Kitaplar>();
        private int IdFLag = -1;
        public enum kitabinDurumu { mevcut, mevcutDegil }
        public ÖdünçAlma()
        {
            InitializeComponent();
        }

        private void InitializeDatabase()
        {
            sqliteConnection2 = new SQLiteConnection("Data Source=veri.db;Version=3;");
            sqliteCommand = new SQLiteCommand();
            sqliteCommand.Connection = sqliteConnection2;
            CreateDatabaseIfNotExists();
        }
        private void CreateDatabaseIfNotExists()
        {
            if (!System.IO.File.Exists("veri.db"))
            {
                SQLiteConnection.CreateFile("veri.db");
            }
            else
            {
                sqliteConnection2.Open();
                sqliteCommand.CommandText = @"CREATE TABLE IF NOT EXISTS Kitaplar (
                                                KitapID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                KitapNo TEXT,
                                                YazarAdi TEXT,
                                                KitapAdi TEXT,
                                                YayinEvi TEXT,
                                                KitapTuru TEXT,
                                                BasimTarihi TEXT)";
                sqliteCommand.ExecuteNonQuery();
                sqliteConnection2.Close();
            }

        }
        private void LoadData()
        {
            dt = new DataTable();
            sqliteCommand.CommandText = "SELECT * FROM Kitaplar";
            sqliteConnection2.Open();
            SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCommand);
            sqliteDataAdapter.Fill(dt);
            sqliteConnection2.Close();
            dataGridView1.DataSource = dt;
        }

        private void InsertData(string kitapNo, string yazarAdi, string kitapAdi, string yayinEvi, string kitapTuru)
        {
            sqliteCommand.CommandText = @"INSERT INTO Kitaplar (KitapNo, YazarAdi, KitapAdi, YayinEvi, KitapTuru) 
                                           VALUES (@kitapNo, @yazarAdi, @kitapAdi, @yayinEvi, @kitapTuru)";
            sqliteCommand.Parameters.AddWithValue("@kitapNo", kitapNo);
            sqliteCommand.Parameters.AddWithValue("@yazarAdi", yazarAdi);
            sqliteCommand.Parameters.AddWithValue("@kitapAdi", kitapAdi);
            sqliteCommand.Parameters.AddWithValue("@yayinEvi", yayinEvi);
            sqliteCommand.Parameters.AddWithValue("@kitapTuru", kitapTuru);

            sqliteConnection2.Open();
            sqliteCommand.ExecuteNonQuery();
            sqliteConnection2.Close();
            sqliteCommand.Parameters.Clear();
        }

        private void UpdateData(int kitapID, string kitapNo, string yazarAdi, string kitapAdi, string yayinEvi, string kitapTuru)
        {
            sqliteCommand.CommandText = @"UPDATE Kitaplar 
                                           SET KitapNo = @kitapNo, 
                                               YazarAdi = @yazarAdi, 
                                               KitapAdi = @kitapAdi, 
                                               YayinEvi = @yayinEvi, 
                                               KitapTuru = @kitapTuru, 
                                           WHERE KitapID = @kitapID";
            sqliteCommand.Parameters.AddWithValue("@kitapID", kitapID);
            sqliteCommand.Parameters.AddWithValue("@kitapNo", kitapNo);
            sqliteCommand.Parameters.AddWithValue("@yazarAdi", yazarAdi);
            sqliteCommand.Parameters.AddWithValue("@kitapAdi", kitapAdi);
            sqliteCommand.Parameters.AddWithValue("@yayinEvi", yayinEvi);
            sqliteCommand.Parameters.AddWithValue("@kitapTuru", kitapTuru);

            sqliteConnection2.Open();
            sqliteCommand.ExecuteNonQuery();
            sqliteConnection2.Close();
            sqliteCommand.Parameters.Clear();
        }

        private void DeleteData(int kitapID)
        {
            sqliteCommand.CommandText = "DELETE FROM Kitaplar WHERE KitapID = @kitapID";
            sqliteCommand.Parameters.AddWithValue("@kitapID", kitapID);
            sqliteConnection2.Open();
            sqliteCommand.ExecuteNonQuery();
            sqliteConnection2.Close();
            sqliteCommand.Parameters.Clear();
        }
        private void ResetInputsForValue()
        {
            textBox1.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kitapNo = textBox1.Text;
            string yazarAdi = textBox2.Text;
            string kitapAdi = textBox3.Text;
            string yayinEvi = textBox4.Text;
            string kitapTuru = textBox5.Text;

            foreach (Kitaplar kitap in kitaplar)
            {
                if (kitap.KitapAdi == kitapAdi && kitap.KitapNo == kitapNo )
                {
                    if (Convert.ToInt32(kitap.kitabınDurum) == 0)
                    {
                        kitap.DurumDegistir();
                        UpdateData(IdFLag, kitapNo, yazarAdi, kitapAdi, yayinEvi, kitapTuru);
                        IdFLag = -1; // IdFlag'i sıfırla
                        LoadData();
                        ResetInputsForValue();
                    }

                        
                    
                    else
                    {
                        MessageBox.Show("Lütfen verileri eksiksiz giriniz.");
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
        
       
    }
}
