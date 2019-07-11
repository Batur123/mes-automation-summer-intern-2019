namespace MeshEkran
{
    partial class Giris_Operator
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
            this.label4 = new System.Windows.Forms.Label();
            this.SifreBox = new System.Windows.Forms.TextBox();
            this.KullaniciAdBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GirisYapButon = new System.Windows.Forms.Button();
            this.GeriDonButon = new System.Windows.Forms.PictureBox();
            this.KapatButon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GeriDonButon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KapatButon)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(92, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "MAS Operatör Panel Giriş Ekranı";
            // 
            // SifreBox
            // 
            this.SifreBox.BackColor = System.Drawing.Color.White;
            this.SifreBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SifreBox.Location = new System.Drawing.Point(110, 70);
            this.SifreBox.Multiline = true;
            this.SifreBox.Name = "SifreBox";
            this.SifreBox.Size = new System.Drawing.Size(178, 29);
            this.SifreBox.TabIndex = 15;
            // 
            // KullaniciAdBox
            // 
            this.KullaniciAdBox.BackColor = System.Drawing.Color.White;
            this.KullaniciAdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KullaniciAdBox.Location = new System.Drawing.Point(110, 36);
            this.KullaniciAdBox.Multiline = true;
            this.KullaniciAdBox.Name = "KullaniciAdBox";
            this.KullaniciAdBox.Size = new System.Drawing.Size(178, 28);
            this.KullaniciAdBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(58, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kullanıcı Adı:";
            // 
            // GirisYapButon
            // 
            this.GirisYapButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GirisYapButon.Location = new System.Drawing.Point(111, 105);
            this.GirisYapButon.Name = "GirisYapButon";
            this.GirisYapButon.Size = new System.Drawing.Size(177, 35);
            this.GirisYapButon.TabIndex = 11;
            this.GirisYapButon.Text = "Giriş Yap";
            this.GirisYapButon.UseVisualStyleBackColor = true;
            this.GirisYapButon.Click += new System.EventHandler(this.GirisYapButon_Click);
            // 
            // GeriDonButon
            // 
            this.GeriDonButon.BackColor = System.Drawing.Color.Transparent;
            this.GeriDonButon.Image = global::MeshEkran.Properties.Resources.BackIcon;
            this.GeriDonButon.Location = new System.Drawing.Point(205, 208);
            this.GeriDonButon.Name = "GeriDonButon";
            this.GeriDonButon.Size = new System.Drawing.Size(77, 81);
            this.GeriDonButon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GeriDonButon.TabIndex = 18;
            this.GeriDonButon.TabStop = false;
            this.GeriDonButon.Click += new System.EventHandler(this.GeriDonButon_Click);
            // 
            // KapatButon
            // 
            this.KapatButon.BackColor = System.Drawing.Color.Transparent;
            this.KapatButon.Image = global::MeshEkran.Properties.Resources.QuitIcon;
            this.KapatButon.Location = new System.Drawing.Point(288, 208);
            this.KapatButon.Name = "KapatButon";
            this.KapatButon.Size = new System.Drawing.Size(77, 81);
            this.KapatButon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.KapatButon.TabIndex = 17;
            this.KapatButon.TabStop = false;
            this.KapatButon.Click += new System.EventHandler(this.KapatButon_Click);
            // 
            // Giris_Operator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 298);
            this.Controls.Add(this.GeriDonButon);
            this.Controls.Add(this.KapatButon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SifreBox);
            this.Controls.Add(this.KullaniciAdBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GirisYapButon);
            this.Name = "Giris_Operator";
            this.Text = "Giris_Operator";
            ((System.ComponentModel.ISupportInitialize)(this.GeriDonButon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KapatButon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GeriDonButon;
        private System.Windows.Forms.PictureBox KapatButon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SifreBox;
        private System.Windows.Forms.TextBox KullaniciAdBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GirisYapButon;
    }
}