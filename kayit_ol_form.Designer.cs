namespace Teknoloji_Magazasi
{
    partial class kayit_ol_form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kayit_ol_form));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_kayitkullaniciadi = new System.Windows.Forms.TextBox();
            this.txt_kayitsifre = new System.Windows.Forms.TextBox();
            this.txt_kayitemailadress = new System.Windows.Forms.TextBox();
            this.btn_kayitol2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_gerigellll = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_adres = new System.Windows.Forms.RichTextBox();
            this.txt_kullaniciSoyadi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(394, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(394, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Email Adres :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(394, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Yetki :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(394, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Şifre :";
            // 
            // txt_kayitkullaniciadi
            // 
            this.txt_kayitkullaniciadi.Location = new System.Drawing.Point(590, 69);
            this.txt_kayitkullaniciadi.Name = "txt_kayitkullaniciadi";
            this.txt_kayitkullaniciadi.Size = new System.Drawing.Size(147, 20);
            this.txt_kayitkullaniciadi.TabIndex = 0;
            this.txt_kayitkullaniciadi.TextChanged += new System.EventHandler(this.txt_kayitkullaniciadi_TextChanged);
            // 
            // txt_kayitsifre
            // 
            this.txt_kayitsifre.Location = new System.Drawing.Point(590, 140);
            this.txt_kayitsifre.Name = "txt_kayitsifre";
            this.txt_kayitsifre.PasswordChar = '*';
            this.txt_kayitsifre.Size = new System.Drawing.Size(147, 20);
            this.txt_kayitsifre.TabIndex = 2;
            this.txt_kayitsifre.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txt_kayitemailadress
            // 
            this.txt_kayitemailadress.Location = new System.Drawing.Point(590, 225);
            this.txt_kayitemailadress.Name = "txt_kayitemailadress";
            this.txt_kayitemailadress.Size = new System.Drawing.Size(147, 20);
            this.txt_kayitemailadress.TabIndex = 3;
            // 
            // btn_kayitol2
            // 
            this.btn_kayitol2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kayitol2.Location = new System.Drawing.Point(397, 400);
            this.btn_kayitol2.Name = "btn_kayitol2";
            this.btn_kayitol2.Size = new System.Drawing.Size(340, 38);
            this.btn_kayitol2.TabIndex = 5;
            this.btn_kayitol2.Text = "Kayıt Ol";
            this.btn_kayitol2.UseVisualStyleBackColor = true;
            this.btn_kayitol2.Click += new System.EventHandler(this.btn_kayitol2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(637, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Müşteri";
            // 
            // btn_gerigellll
            // 
            this.btn_gerigellll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_gerigellll.ImageIndex = 0;
            this.btn_gerigellll.Location = new System.Drawing.Point(3, 3);
            this.btn_gerigellll.Name = "btn_gerigellll";
            this.btn_gerigellll.Size = new System.Drawing.Size(90, 43);
            this.btn_gerigellll.TabIndex = 6;
            this.btn_gerigellll.Text = "Geri";
            this.btn_gerigellll.UseVisualStyleBackColor = true;
            this.btn_gerigellll.Click += new System.EventHandler(this.btn_gerigellll_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "balckbackbutton.ico");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(392, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 29);
            this.label8.TabIndex = 9;
            this.label8.Text = "YENİ KAYIT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(394, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Kullanıcı Soyadı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(397, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Adres :";
            // 
            // txt_adres
            // 
            this.txt_adres.Location = new System.Drawing.Point(590, 289);
            this.txt_adres.Name = "txt_adres";
            this.txt_adres.Size = new System.Drawing.Size(147, 105);
            this.txt_adres.TabIndex = 4;
            this.txt_adres.Text = "";
            // 
            // txt_kullaniciSoyadi
            // 
            this.txt_kullaniciSoyadi.Location = new System.Drawing.Point(590, 102);
            this.txt_kullaniciSoyadi.Name = "txt_kullaniciSoyadi";
            this.txt_kullaniciSoyadi.Size = new System.Drawing.Size(147, 20);
            this.txt_kullaniciSoyadi.TabIndex = 1;
            this.txt_kullaniciSoyadi.TextChanged += new System.EventHandler(this.txt_kullaniciSoaydi_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(761, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kayit_ol_form
            // 
            this.AcceptButton = this.btn_kayitol2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_adres);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_gerigellll);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_kayitol2);
            this.Controls.Add(this.txt_kayitemailadress);
            this.Controls.Add(this.txt_kayitsifre);
            this.Controls.Add(this.txt_kullaniciSoyadi);
            this.Controls.Add(this.txt_kayitkullaniciadi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "kayit_ol_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0";
            this.Load += new System.EventHandler(this.kayit_ol_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_kayitkullaniciadi;
        private System.Windows.Forms.TextBox txt_kayitsifre;
        private System.Windows.Forms.TextBox txt_kayitemailadress;
        private System.Windows.Forms.Button btn_kayitol2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_gerigellll;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txt_adres;
        private System.Windows.Forms.TextBox txt_kullaniciSoyadi;
        private System.Windows.Forms.Button button1;
    }
}