using System;
using System.Data;
using System.Data.SQLite;
<<<<<<< HEAD
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
=======
>>>>>>> b7d493828dd03738720c6d3cebc80d89527f3197
using System.Windows.Forms;

namespace GörselProgramlamaGörev1
{
    public partial class KitapEkle : Form
    {
        private SQLiteConnection sqliteConnection2;
        private SQLiteCommand sqliteCommand;
<<<<<<< HEAD
        private int IdFLag = -1;
        private int bookIDCounter = 0;
        private DataTable dt = new DataTable();
        public static List<Kitaplar> kitaplar = new List<Kitaplar>();

=======
        private DataTable dt;
        private int IdFlag = -1;
>>>>>>> b7d493828dd03738720c6d3cebc80d89527f3197
        public KitapEkle()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadData();
<<<<<<< HEAD


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
=======
>>>>>>> b7d493828dd03738720c6d3cebc80d89527f3197
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
<<<<<<< HEAD
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
                if (IdFLag== -1)
                {
                    InsertData(kitapNo, yazarAdi, kitapAdi, yayinEvi, kitapTuru, basimTarihi);
                }
                else
                {
                    UpdateData(IdFLag, kitapNo, yazarAdi, kitapAdi, yayinEvi, kitapTuru, basimTarihi);
                    IdFLag = -1; // IdFlag'i sıfırla
                }

                LoadData();
                ResetInputsForValue();
            }
            else
            {
                MessageBox.Show("Lütfen verileri eksiksiz giriniz.");
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
            if (IdFLag != -1)
            {
                DeleteData(IdFLag);
                LoadData();
                ResetInputsForValue();
                IdFLag = -1; // IdFlag'i sıfırla
            }
        }
    
    

      

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdFLag != -1)
            {
                string kitapNo = textBox1.Text;
                string yazarAdi = textBox2.Text;
                string kitapAdi = textBox3.Text;
                string yayinEvi = textBox4.Text;
                string kitapTuru = textBox5.Text;
                string basimTarihi = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                UpdateData(IdFLag, kitapNo, yazarAdi, kitapAdi, yayinEvi, kitapTuru, basimTarihi); // IdFlag'e göre güncelleme yap
                LoadData();
                ResetInputsForValue();
                IdFLag = -1; // IdFlag'i sıfırla
            }
            button2.Visible = false;
            button1.Visible = true;
        }

                
            
       
=======
>>>>>>> b7d493828dd03738720c6d3cebc80d89527f3197
    }
}
