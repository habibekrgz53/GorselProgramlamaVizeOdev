using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
using System.Data.SQLite;

namespace GörselProgramlamaGörev1
{
    public partial class ÜyeEkle : Form
    {
        private SQLiteConnection sqliteConnection;
        private SQLiteCommand sqliteCommand;
        private SQLiteDataAdapter sqliteDataAdapter;
        private List<Uyeler> uyeler;
        private DataTable dt;
        private int idCounter = 0;
        private int IdFlag=-1;
        private void ResetİnputsForValue()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public ÜyeEkle()
        {
            InitializeComponent();
            InitializeDataBase();
            LoadData();
            

            dataGridView1.DataSource = dt;
        }
        private void InitializeDataBase()
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
          //      sqliteCommand.ExecuteNonQuery();
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
                idCounter = (int)dt.AsEnumerable().Max(row => row.Field<long>("UyeID"));
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
            var dataController = string.IsNullOrWhiteSpace;
            if (!string.IsNullOrWhiteSpace(uyeAdi) && !string.IsNullOrWhiteSpace(uyeSoyadi) && !string.IsNullOrWhiteSpace(uyeMail) && !string.IsNullOrWhiteSpace(uyeTel))
            {
                InsertData(uyeAdi, uyeSoyadi, uyeMail, uyeTel);
                LoadData();
                ResetİnputsForValue();
            }
            else
            {
                MessageBox.Show("Lütfen verileri eksiksiz giriniz.");
            }


        }


        private void button2_Click(object sender, EventArgs e)
        {

            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;


            object uyeIdObject = dataGridView1[0, selectedRowIndex].Value;
            object uyeAdiObject = dataGridView1[1, selectedRowIndex].Value;
            object uyeSoyadiObject = dataGridView1[2, selectedRowIndex].Value;
            object uyeMailObject = dataGridView1[3, selectedRowIndex].Value;
            object uyeTelObject = dataGridView1[4, selectedRowIndex].Value;

            var dataController = string.IsNullOrWhiteSpace;


            if (uyeIdObject == null)
            {
                MessageBox.Show("Lütfen geçerli üye seçiniz.");
            }
            else
            {
                string uyeID = uyeIdObject.ToString();
                string uyeAdi = uyeAdiObject.ToString();
                string uyeSoyadi = uyeSoyadiObject.ToString();
                string uyeMail = uyeMailObject.ToString();
                string uyeTel = uyeTelObject.ToString();
                IdFlag =Convert.ToInt32(uyeIdObject);

                textBox1.Text = uyeSoyadi;
                textBox2.Text = uyeAdi;
                textBox3.Text = uyeMail;
                textBox4.Text = uyeTel;
                button1.Visible = false;
                button4.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            

            string uyeAdi = textBox2.Text;
            string uyeSoyadi=textBox1.Text;
            string uyeMail = textBox3.Text;
            string uyeTel = textBox4.Text;

            Uyeler guncelUye= new Uyeler();

            if (IdFlag>-1)
            {
                guncelUye.UyeID = IdFlag;
                guncelUye.UyeAdi= uyeAdi;
                guncelUye.UyeSoyadi= uyeSoyadi;
                guncelUye.UyeMail= uyeMail;
                guncelUye.UyeTel= uyeTel;
                guncelUye.TabloyaEkle(dt);
                ResetİnputsForValue();
            }
            else
            {
                MessageBox.Show("Lütfen bir geçerli bir üye seçiniz.");
            }
            button1.Visible = true;
            IdFlag = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;


            object uyeIdObject = dataGridView1[0, selectedRowIndex].Value;
            if (uyeIdObject == null)
            {
                MessageBox.Show("Lütfen geçerli bir üye seçiniz.");
            }
            else
            {
                int rowIndex = -1;
                foreach (DataRow row in dt.Rows)
                {

                        if (row["UyeID"].ToString() == uyeIdObject.ToString())
                    {
                        rowIndex = row.Table.Rows.IndexOf(row);
                        
                        break; 
                    }
                }

                if (rowIndex != -1)
                {
                    dt.Rows.RemoveAt(rowIndex);
                    
                }
                
                dt.AcceptChanges();
                rowIndex--;
            }
            }
    }
}
