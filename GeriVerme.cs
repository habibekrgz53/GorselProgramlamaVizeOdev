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

namespace GörselProgramlamaGörev1
{
    public partial class GeriVerme : Form
    {
        private SQLiteConnection sqliteConnection2;
        private SQLiteCommand sqliteCommand;
        List<Kitaplar> kitaplar = new List<Kitaplar>();
        public GeriVerme()
        {
            InitializeComponent();
        }
        private void UpdateData(string kitapNo,string kitapAdi)
        {
            sqliteCommand.CommandText = @"UPDATE Kitaplar 
                                           SET KitapNo = @kitapNo, 
                                               KitapAdi = @kitapAdi, 
                                            WHERE KitapID = @kitapID";
            
            sqliteCommand.Parameters.AddWithValue("@kitapNo", kitapNo);
            sqliteCommand.Parameters.AddWithValue("@kitapAdi", kitapAdi);
            sqliteConnection2.Open();
            sqliteCommand.ExecuteNonQuery();
            sqliteConnection2.Close();
            sqliteCommand.Parameters.Clear();
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
                        UpdateData(kitapNo, kitapAdı);
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

        
    }
}
