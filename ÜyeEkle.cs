using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GörselProgramlamaGörev1
{
    public partial class ÜyeEkle : Form
    {
        private SQLiteConnection sqliteConnection;
        private SQLiteCommand sqliteCommand;
        private SQLiteDataAdapter sqliteDataAdapter;
        private DataTable dt;
        private long idCounter = 0;
        private int IdFlag = -1;

        public ÜyeEkle()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadData();
        }

        private void InitializeDatabase()
        {
            sqliteConnection = new SQLiteConnection("Data Source=veri.db;Version=3;");
            sqliteCommand = new SQLiteCommand();
            sqliteCommand.Connection = sqliteConnection;
            sqliteDataAdapter = new SQLiteDataAdapter(sqliteCommand);
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
                sqliteConnection.Open();
                sqliteCommand.CommandText = "CREATE TABLE Uyeler (UyeID INTEGER PRIMARY KEY, UyeAdi TEXT, UyeSoyadi TEXT, UyeMail TEXT, UyeTel TEXT)";
                sqliteCommand.ExecuteNonQuery();
                sqliteConnection.Close();
            }
            

        }

        private void LoadData()
        {
            dt = new DataTable();
            sqliteCommand.CommandText = "SELECT * FROM Uyeler";
            sqliteConnection.Open();
            sqliteDataAdapter.Fill(dt);
            sqliteConnection.Close();
            dataGridView1.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                idCounter = dt.AsEnumerable().Max(row => row.Field<long>("UyeID"));
            }
        }

        private void InsertData(string uyeAdi, string uyeSoyadi, string uyeMail, string uyeTel)
        {
            sqliteCommand.CommandText = "INSERT INTO Uyeler (UyeID, UyeAdi, UyeSoyadi, UyeMail, UyeTel) VALUES (@id, @adi, @soyadi, @mail, @tel)";
            sqliteCommand.Parameters.AddWithValue("@id", ++idCounter);
            sqliteCommand.Parameters.AddWithValue("@adi", uyeAdi);
            sqliteCommand.Parameters.AddWithValue("@soyadi", uyeSoyadi);
            sqliteCommand.Parameters.AddWithValue("@mail", uyeMail);
            sqliteCommand.Parameters.AddWithValue("@tel", uyeTel);
            sqliteConnection.Open();
            sqliteCommand.ExecuteNonQuery();
            sqliteConnection.Close();
            sqliteCommand.Parameters.Clear();
        }

        private void UpdateData(int id, string uyeAdi, string uyeSoyadi, string uyeMail, string uyeTel)
        {
            sqliteCommand.CommandText = "UPDATE Uyeler SET UyeAdi=@adi, UyeSoyadi=@soyadi, UyeMail=@mail, UyeTel=@tel WHERE UyeID=@id";
            sqliteCommand.Parameters.AddWithValue("@id", id);
            sqliteCommand.Parameters.AddWithValue("@adi", uyeAdi);
            sqliteCommand.Parameters.AddWithValue("@soyadi", uyeSoyadi);
            sqliteCommand.Parameters.AddWithValue("@mail", uyeMail);
            sqliteCommand.Parameters.AddWithValue("@tel", uyeTel);
            sqliteConnection.Open();
            sqliteCommand.ExecuteNonQuery();
            sqliteConnection.Close();
            sqliteCommand.Parameters.Clear();
        }

        private void DeleteData(int id)
        {
            sqliteCommand.CommandText = "DELETE FROM Uyeler WHERE UyeID=@id";
            sqliteCommand.Parameters.AddWithValue("@id", id);
            sqliteConnection.Open();
            sqliteCommand.ExecuteNonQuery();
            sqliteConnection.Close();
            sqliteCommand.Parameters.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uyeAdi = textBox2.Text;
            string uyeSoyadi = textBox1.Text;
            string uyeMail = textBox3.Text;
            string uyeTel = textBox4.Text;

            if (!string.IsNullOrWhiteSpace(uyeAdi) && !string.IsNullOrWhiteSpace(uyeSoyadi) && !string.IsNullOrWhiteSpace(uyeMail) && !string.IsNullOrWhiteSpace(uyeTel))
            {
                InsertData(uyeAdi, uyeSoyadi, uyeMail, uyeTel);
                LoadData();
                ResetInputs();
            }
            else
            {
                MessageBox.Show("Lütfen verileri eksiksiz giriniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            if (selectedRowIndex >= 0)
            {
                object uyeIdObject = dataGridView1[0, selectedRowIndex].Value;
                if (uyeIdObject != null)
                {
                    string uyeID = uyeIdObject.ToString();
                    string uyeAdi = dataGridView1[1, selectedRowIndex].Value.ToString();
                    string uyeSoyadi = dataGridView1[2, selectedRowIndex].Value.ToString();
                    string uyeMail = dataGridView1[3, selectedRowIndex].Value.ToString();
                    string uyeTel = dataGridView1[4, selectedRowIndex].Value.ToString();
                    IdFlag = Convert.ToInt32(uyeID);

                    textBox1.Text = uyeSoyadi;
                    textBox2.Text = uyeAdi;
                    textBox3.Text = uyeMail;
                    textBox4.Text = uyeTel;
                    button1.Visible = false;
                    button4.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir üye seçiniz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IdFlag > -1)
            {
                string uyeAdi = textBox2.Text;
                string uyeSoyadi = textBox1.Text;
                string uyeMail = textBox3.Text;
                string uyeTel = textBox4.Text;

                UpdateData(IdFlag, uyeAdi, uyeSoyadi, uyeMail, uyeTel);
                LoadData();
                ResetInputs();
                button1.Visible = true;
                button4.Visible = false;
                IdFlag = -1;
            }
            else
            {
                MessageBox.Show("Lütfen bir geçerli bir üye seçiniz.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            if (selectedRowIndex >= 0)
            {
                object uyeIdObject = dataGridView1[0, selectedRowIndex].Value;
                if (uyeIdObject != null)
                {
                    int uyeID = Convert.ToInt32(uyeIdObject);
                    DeleteData(uyeID);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir üye seçiniz.");
            }
        }

        private void ResetInputs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void ÜyeEkle_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}