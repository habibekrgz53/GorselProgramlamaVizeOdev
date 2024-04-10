using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace GörselProgramlamaGörev1
{
    public partial class KitapEkle : Form
    {
        private SQLiteConnection sqliteConnection2;
        private SQLiteCommand sqliteCommand;
        private DataTable dt;
        private int IdFlag = -1;
        public KitapEkle()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadData();
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

        private void InsertData(string kitapNo, string yazarAdi, string kitapAdi, string yayinEvi, string kitapTuru, string basimTarihi)
        {
            sqliteCommand.CommandText = @"INSERT INTO Kitaplar (KitapNo, YazarAdi, KitapAdi, YayinEvi, KitapTuru, BasimTarihi) 
                                           VALUES (@kitapNo, @yazarAdi, @kitapAdi, @yayinEvi, @kitapTuru, @basimTarihi)";
            sqliteCommand.Parameters.AddWithValue("@kitapNo", kitapNo);
            sqliteCommand.Parameters.AddWithValue("@yazarAdi", yazarAdi);
            sqliteCommand.Parameters.AddWithValue("@kitapAdi", kitapAdi);
            sqliteCommand.Parameters.AddWithValue("@yayinEvi", yayinEvi);
            sqliteCommand.Parameters.AddWithValue("@kitapTuru", kitapTuru);
            sqliteCommand.Parameters.AddWithValue("@basimTarihi", basimTarihi);

            sqliteConnection2.Open();
            sqliteCommand.ExecuteNonQuery();
            sqliteConnection2.Close();
            sqliteCommand.Parameters.Clear();
        }

        private void UpdateData(int kitapID, string kitapNo, string yazarAdi, string kitapAdi, string yayinEvi, string kitapTuru, string basimTarihi)
        {
            sqliteCommand.CommandText = @"UPDATE Kitaplar 
                                           SET KitapNo = @kitapNo, 
                                               YazarAdi = @yazarAdi, 
                                               KitapAdi = @kitapAdi, 
                                               YayinEvi = @yayinEvi, 
                                               KitapTuru = @kitapTuru, 
                                               BasimTarihi = @basimTarihi 
                                           WHERE KitapID = @kitapID";
            sqliteCommand.Parameters.AddWithValue("@kitapID", kitapID);
            sqliteCommand.Parameters.AddWithValue("@kitapNo", kitapNo);
            sqliteCommand.Parameters.AddWithValue("@yazarAdi", yazarAdi);
            sqliteCommand.Parameters.AddWithValue("@kitapAdi", kitapAdi);
            sqliteCommand.Parameters.AddWithValue("@yayinEvi", yayinEvi);
            sqliteCommand.Parameters.AddWithValue("@kitapTuru", kitapTuru);
            sqliteCommand.Parameters.AddWithValue("@basimTarihi", basimTarihi);

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

        private void button1_Click(object sender, EventArgs e)
        {
            string kitapNo = textBox1.Text;
            string yazarAdi = textBox2.Text;
            string kitapAdi = textBox3.Text;
            string yayinEvi = textBox4.Text;
            string kitapTuru = textBox5.Text;
            string basimTarihi = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // SQLite için tarih formatı

            if (!string.IsNullOrWhiteSpace(kitapNo) && !string.IsNullOrWhiteSpace(yazarAdi) && !string.IsNullOrWhiteSpace(kitapAdi) &&
                !string.IsNullOrWhiteSpace(yayinEvi) && !string.IsNullOrWhiteSpace(kitapTuru))
            {
                if (IdFlag == -1)
                {
                    InsertData(kitapNo, yazarAdi, kitapAdi, yayinEvi, kitapTuru, basimTarihi);
                }
                else
                {
                    UpdateData(IdFlag, kitapNo, yazarAdi, kitapAdi, yayinEvi, kitapTuru, basimTarihi);
                    IdFlag = -1; // IdFlag'i sıfırla
                }

                LoadData();
                ResetInputs();
            }
            else
            {
                MessageBox.Show("Lütfen verileri eksiksiz giriniz.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            if (selectedRowIndex >= 0)
            {
                object kitapIDObject = dataGridView1[0, selectedRowIndex].Value;
                if (kitapIDObject != null)
                {
                    IdFlag = Convert.ToInt32(kitapIDObject); // Seçilen kitabın KitapID'sini sakla
                    DataRow selectedRow = dt.Rows[selectedRowIndex];
                    textBox1.Text = selectedRow["KitapNo"].ToString();
                    textBox2.Text = selectedRow["YazarAdi"].ToString();
                    textBox3.Text = selectedRow["KitapAdi"].ToString();
                    textBox4.Text = selectedRow["YayinEvi"].ToString();
                    textBox5.Text = selectedRow["KitapTuru"].ToString();
                    dateTimePicker1.Value = DateTime.Parse(selectedRow["BasimTarihi"].ToString());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IdFlag != -1)
            {
                DeleteData(IdFlag);
                LoadData();
                ResetInputs();
                IdFlag = -1; // IdFlag'i sıfırla
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdFlag != -1)
            {
                string kitapNo = textBox1.Text;
                string yazarAdi = textBox2.Text;
                string kitapAdi = textBox3.Text;
                string yayinEvi = textBox4.Text;
                string kitapTuru = textBox5.Text;
                string basimTarihi = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                UpdateData(IdFlag, kitapNo, yazarAdi, kitapAdi, yayinEvi, kitapTuru, basimTarihi); // IdFlag'e göre güncelleme yap
                LoadData();
                ResetInputs();
                IdFlag = -1; // IdFlag'i sıfırla
            }
        }

        private void ResetInputs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
