﻿namespace GörselProgramlamaGörev1
{
    partial class ÖdünçAlma
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
            label2 = new Label();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 57);
            label2.Name = "label2";
            label2.Size = new Size(147, 15);
            label2.TabIndex = 8;
            label2.Text = "Kitabın Numarasını Giriniz:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(187, 54);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(369, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(187, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(369, 23);
            textBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 5;
            label1.Text = "Kitabın Adını Giriniz:";
            // 
            // button1
            // 
            button1.Location = new Point(187, 201);
            button1.Name = "button1";
            button1.Size = new Size(84, 29);
            button1.TabIndex = 9;
            button1.Text = "Onayla";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(304, 201);
            button2.Name = "button2";
            button2.Size = new Size(86, 29);
            button2.TabIndex = 10;
            button2.Text = "İptal Et";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-1, 259);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 192);
            dataGridView1.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 92);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 18;
            label3.Text = "Yazar  Adı: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 107);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 122);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 20;
            label5.Text = "Kitap Türü:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 154);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 21;
            label6.Text = "Yayın Evi:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(187, 89);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(369, 23);
            textBox2.TabIndex = 22;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(187, 122);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(369, 23);
            textBox4.TabIndex = 23;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(187, 154);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(369, 23);
            textBox5.TabIndex = 24;
            // 
            // ÖdünçAlma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "ÖdünçAlma";
            Text = "ÖdünçAlma";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox textBox3;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox5;
    }
}