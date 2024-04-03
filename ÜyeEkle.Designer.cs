namespace GörselProgramlamaGörev1
{
    partial class ÜyeEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(152, 216);
            button1.Name = "button1";
            button1.Size = new Size(131, 33);
            button1.TabIndex = 0;
            button1.Text = "Kaydet";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 36);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 1;
            label1.Text = "Adınızı Giriniz: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 83);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 2;
            label2.Text = "Soyadınızı Giriniz: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(152, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(396, 23);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 128);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 5;
            label3.Text = "E-Mail:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(152, 125);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(396, 23);
            textBox3.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 170);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 7;
            label4.Text = "Telefon Numarası:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(152, 33);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(396, 23);
            textBox2.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(152, 170);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(396, 23);
            textBox4.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(289, 216);
            button2.Name = "button2";
            button2.Size = new Size(131, 33);
            button2.TabIndex = 11;
            button2.Text = "Düzenle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(426, 216);
            button3.Name = "button3";
            button3.Size = new Size(122, 33);
            button3.TabIndex = 12;
            button3.Text = "Sil";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(45, 299);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(993, 261);
            dataGridView1.TabIndex = 14;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(211, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(568, 271);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "SaveMemberForm";
            // 
            // button4
            // 
            button4.Location = new Point(152, 216);
            button4.Name = "button4";
            button4.Size = new Size(131, 33);
            button4.TabIndex = 16;
            button4.Text = "Değişlikliği Kaydet";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // ÜyeEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1081, 591);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            ForeColor = SystemColors.ControlText;
            Name = "ÜyeEkle";
            Text = "ÜyeEkle";
            TransparencyKey = Color.FromArgb(64, 64, 64);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox4;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Button button4;
    }
}