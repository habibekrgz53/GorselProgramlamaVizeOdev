namespace GörselProgramlamaGörev1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ÜyeEkle customdialog = new ÜyeEkle();
            DialogResult sonuc=customdialog.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KitapEkle customdialog = new KitapEkle();
            DialogResult sonuc = customdialog.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Emanetİşleri customdialog = new Emanetİşleri();
            DialogResult sonuc = customdialog.ShowDialog();
        }
    }
}
