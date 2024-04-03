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

namespace GörselProgramlamaGörev1
{
    public partial class ÜyeEkle : Form
    {

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
            uyeler = new List<Uyeler>();
            dt = new DataTable();
            dt.Columns.Add("Üye ID");
            dt.Columns.Add("Üye Adı");
            dt.Columns.Add("Üye Soyadı");
            dt.Columns.Add("Üye Mail");
            dt.Columns.Add("Üye Tel");

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uyeAdi = textBox2.Text;
            string uyeSoyadi = textBox1.Text;
            string uyeMail = textBox3.Text;
            string uyeTel = textBox4.Text;
            var dataController = string.IsNullOrWhiteSpace;
            if (dataController(uyeAdi) || dataController(uyeSoyadi) || dataController(uyeMail) || dataController(uyeTel))
            {
                MessageBox.Show("Lütfen verileri eksiksiz giriniz.");
            }
            else
            {
                Uyeler uye = new Uyeler();
                uye.UyeID = ++idCounter;
                uye.UyeAdi = uyeAdi;
                uye.UyeSoyadi = uyeSoyadi;
                uye.UyeMail = uyeMail;
                uye.UyeTel = uyeTel;

                uye.TabloyaEkle(dt);
                uyeler.Add(uye);
                ResetİnputsForValue();
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

                        if (row["Üye ID"].ToString() == uyeIdObject.ToString())
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
            }
            }
    }
}
