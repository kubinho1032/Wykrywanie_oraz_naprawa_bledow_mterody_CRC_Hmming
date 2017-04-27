namespace CRC_HAMMING
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_sygnal_wyjsciowy = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_poprawione_dane_z_crc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_przeslane_dane = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_dane_crc_hamming = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_wygenerowane_crc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_wprowadzone_dane = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CRC_gbox = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_ilosc_przeslanych_danych = new System.Windows.Forms.TextBox();
            this.tb_ilosc_wprowadzonych_danych = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tb_ilosc_bledow_niewykrytych = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_pozycja_bledu = new System.Windows.Forms.TextBox();
            this.tb_ilosc_bledow = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tb_test_crc = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.CRC_gbox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Symuluj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(291, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detekcja i korekcja błedów";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(229, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "CRC 12, CRC 16, CRC 32, Kod Hamminga";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(26, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 142);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dane wejściowe";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(81, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Generuj dane wejściowe";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(182, 69);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 49);
            this.label3.TabIndex = 0;
            this.label3.Text = "Wprowadź dane w postaci binarnej:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox13);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(26, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 111);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zakłócenia";
            // 
            // textBox13
            // 
            this.textBox13.Enabled = false;
            this.textBox13.Location = new System.Drawing.Point(128, 83);
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(182, 22);
            this.textBox13.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(10, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 15);
            this.label16.TabIndex = 3;
            this.label16.Text = "Liczba błędów";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, 26);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(182, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Brak";
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(8, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 43);
            this.label4.TabIndex = 1;
            this.label4.Text = "Wprowadź błędy (np. 1,3,5)";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(13, 66);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(145, 20);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Generuj zakłócenia";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_sygnal_wyjsciowy);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.tb_poprawione_dane_z_crc);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tb_przeslane_dane);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tb_dane_crc_hamming);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tb_wygenerowane_crc);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tb_wprowadzone_dane);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(373, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 331);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dane wyjściowe";
            // 
            // tb_sygnal_wyjsciowy
            // 
            this.tb_sygnal_wyjsciowy.Location = new System.Drawing.Point(131, 275);
            this.tb_sygnal_wyjsciowy.Multiline = true;
            this.tb_sygnal_wyjsciowy.Name = "tb_sygnal_wyjsciowy";
            this.tb_sygnal_wyjsciowy.ReadOnly = true;
            this.tb_sygnal_wyjsciowy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_sygnal_wyjsciowy.Size = new System.Drawing.Size(142, 43);
            this.tb_sygnal_wyjsciowy.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(7, 278);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 41);
            this.label11.TabIndex = 10;
            this.label11.Text = "Sygnał wyjściowy bez danych kontrolnych:";
            // 
            // tb_poprawione_dane_z_crc
            // 
            this.tb_poprawione_dane_z_crc.Location = new System.Drawing.Point(131, 226);
            this.tb_poprawione_dane_z_crc.Multiline = true;
            this.tb_poprawione_dane_z_crc.Name = "tb_poprawione_dane_z_crc";
            this.tb_poprawione_dane_z_crc.ReadOnly = true;
            this.tb_poprawione_dane_z_crc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_poprawione_dane_z_crc.Size = new System.Drawing.Size(142, 43);
            this.tb_poprawione_dane_z_crc.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(7, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 41);
            this.label10.TabIndex = 8;
            this.label10.Text = "Dane + CRC z poprawionymi błędami:";
            // 
            // tb_przeslane_dane
            // 
            this.tb_przeslane_dane.Location = new System.Drawing.Point(131, 177);
            this.tb_przeslane_dane.Multiline = true;
            this.tb_przeslane_dane.Name = "tb_przeslane_dane";
            this.tb_przeslane_dane.ReadOnly = true;
            this.tb_przeslane_dane.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_przeslane_dane.Size = new System.Drawing.Size(142, 43);
            this.tb_przeslane_dane.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Sygnał przesłany:";
            // 
            // tb_dane_crc_hamming
            // 
            this.tb_dane_crc_hamming.Location = new System.Drawing.Point(131, 128);
            this.tb_dane_crc_hamming.Multiline = true;
            this.tb_dane_crc_hamming.Name = "tb_dane_crc_hamming";
            this.tb_dane_crc_hamming.ReadOnly = true;
            this.tb_dane_crc_hamming.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_dane_crc_hamming.Size = new System.Drawing.Size(142, 43);
            this.tb_dane_crc_hamming.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 40);
            this.label8.TabIndex = 4;
            this.label8.Text = "Dane + CRC + kod Hamminga:";
            // 
            // tb_wygenerowane_crc
            // 
            this.tb_wygenerowane_crc.Location = new System.Drawing.Point(131, 77);
            this.tb_wygenerowane_crc.Multiline = true;
            this.tb_wygenerowane_crc.Name = "tb_wygenerowane_crc";
            this.tb_wygenerowane_crc.ReadOnly = true;
            this.tb_wygenerowane_crc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_wygenerowane_crc.Size = new System.Drawing.Size(142, 43);
            this.tb_wygenerowane_crc.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Dane + CRC:";
            // 
            // tb_wprowadzone_dane
            // 
            this.tb_wprowadzone_dane.Location = new System.Drawing.Point(131, 28);
            this.tb_wprowadzone_dane.Multiline = true;
            this.tb_wprowadzone_dane.Name = "tb_wprowadzone_dane";
            this.tb_wprowadzone_dane.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_wprowadzone_dane.Size = new System.Drawing.Size(142, 43);
            this.tb_wprowadzone_dane.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Wprowadzone dane:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(84, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Wybierz rodzaj CRC";
            // 
            // CRC_gbox
            // 
            this.CRC_gbox.Controls.Add(this.radioButton3);
            this.CRC_gbox.Controls.Add(this.radioButton2);
            this.CRC_gbox.Controls.Add(this.radioButton1);
            this.CRC_gbox.Controls.Add(this.label5);
            this.CRC_gbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CRC_gbox.Location = new System.Drawing.Point(26, 351);
            this.CRC_gbox.Name = "CRC_gbox";
            this.CRC_gbox.Size = new System.Drawing.Size(325, 67);
            this.CRC_gbox.TabIndex = 6;
            this.CRC_gbox.TabStop = false;
            this.CRC_gbox.Text = "CRC";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(164, 41);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(146, 20);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "CRC 32 (Domyślnie)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(88, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 20);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "CRC 16";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 41);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 20);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "CRC 12";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tb_ilosc_przeslanych_danych);
            this.groupBox4.Controls.Add(this.tb_ilosc_wprowadzonych_danych);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox4.Location = new System.Drawing.Point(665, 257);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(199, 161);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Informacje";
            // 
            // tb_ilosc_przeslanych_danych
            // 
            this.tb_ilosc_przeslanych_danych.Location = new System.Drawing.Point(95, 121);
            this.tb_ilosc_przeslanych_danych.Name = "tb_ilosc_przeslanych_danych";
            this.tb_ilosc_przeslanych_danych.ReadOnly = true;
            this.tb_ilosc_przeslanych_danych.Size = new System.Drawing.Size(94, 22);
            this.tb_ilosc_przeslanych_danych.TabIndex = 3;
            // 
            // tb_ilosc_wprowadzonych_danych
            // 
            this.tb_ilosc_wprowadzonych_danych.Location = new System.Drawing.Point(95, 59);
            this.tb_ilosc_wprowadzonych_danych.Name = "tb_ilosc_wprowadzonych_danych";
            this.tb_ilosc_wprowadzonych_danych.ReadOnly = true;
            this.tb_ilosc_wprowadzonych_danych.Size = new System.Drawing.Size(94, 22);
            this.tb_ilosc_wprowadzonych_danych.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(7, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 60);
            this.label13.TabIndex = 1;
            this.label13.Text = "Przesłane dane nadmiarowe:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(7, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 53);
            this.label12.TabIndex = 0;
            this.label12.Text = "Przesłane dane rzeczywiste:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.tb_test_crc);
            this.groupBox5.Controls.Add(this.tb_ilosc_bledow_niewykrytych);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.tb_pozycja_bledu);
            this.groupBox5.Controls.Add(this.tb_ilosc_bledow);
            this.groupBox5.Location = new System.Drawing.Point(665, 87);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(199, 164);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Błędy";
            // 
            // tb_ilosc_bledow_niewykrytych
            // 
            this.tb_ilosc_bledow_niewykrytych.Location = new System.Drawing.Point(95, 92);
            this.tb_ilosc_bledow_niewykrytych.Name = "tb_ilosc_bledow_niewykrytych";
            this.tb_ilosc_bledow_niewykrytych.ReadOnly = true;
            this.tb_ilosc_bledow_niewykrytych.Size = new System.Drawing.Size(100, 20);
            this.tb_ilosc_bledow_niewykrytych.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(10, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 35);
            this.label15.TabIndex = 4;
            this.label15.Text = "Ilość błędów niewykrytych:";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(10, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 30);
            this.label17.TabIndex = 3;
            this.label17.Text = "Pozycja bitu błędu:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Ilość błędów:";
            // 
            // tb_pozycja_bledu
            // 
            this.tb_pozycja_bledu.Location = new System.Drawing.Point(95, 60);
            this.tb_pozycja_bledu.Name = "tb_pozycja_bledu";
            this.tb_pozycja_bledu.ReadOnly = true;
            this.tb_pozycja_bledu.Size = new System.Drawing.Size(100, 20);
            this.tb_pozycja_bledu.TabIndex = 1;
            // 
            // tb_ilosc_bledow
            // 
            this.tb_ilosc_bledow.Location = new System.Drawing.Point(95, 28);
            this.tb_ilosc_bledow.Name = "tb_ilosc_bledow";
            this.tb_ilosc_bledow.ReadOnly = true;
            this.tb_ilosc_bledow.Size = new System.Drawing.Size(100, 20);
            this.tb_ilosc_bledow.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 87);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 16);
            this.label18.TabIndex = 3;
            this.label18.Text = "Długość";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(123, 87);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(182, 22);
            this.textBox3.TabIndex = 4;
            // 
            // tb_test_crc
            // 
            this.tb_test_crc.Location = new System.Drawing.Point(95, 126);
            this.tb_test_crc.Name = "tb_test_crc";
            this.tb_test_crc.ReadOnly = true;
            this.tb_test_crc.Size = new System.Drawing.Size(100, 20);
            this.tb_test_crc.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(10, 129);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 32);
            this.label19.TabIndex = 7;
            this.label19.Text = "CRC wykryte błędy:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 492);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.CRC_gbox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.CRC_gbox.ResumeLayout(false);
            this.CRC_gbox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_sygnal_wyjsciowy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_poprawione_dane_z_crc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_przeslane_dane;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_dane_crc_hamming;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_wygenerowane_crc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_wprowadzone_dane;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox CRC_gbox;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tb_ilosc_przeslanych_danych;
        private System.Windows.Forms.TextBox tb_ilosc_wprowadzonych_danych;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_pozycja_bledu;
        private System.Windows.Forms.TextBox tb_ilosc_bledow;
        private System.Windows.Forms.TextBox tb_ilosc_bledow_niewykrytych;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tb_test_crc;
    }
}

