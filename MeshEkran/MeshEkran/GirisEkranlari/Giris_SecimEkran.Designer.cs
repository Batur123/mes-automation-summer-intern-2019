namespace MeshEkran
{
    partial class Giris_SecimEkran
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
            this.label1 = new System.Windows.Forms.Label();
            this.OperatorButon = new System.Windows.Forms.Button();
            this.AdminButon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dBAdlariBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.firmaDBListDataSet = new MeshEkran.DataSetler.FirmaDBListDataSet();
            this.dBAdlariTableAdapter = new MeshEkran.DataSetler.FirmaDBListDataSetTableAdapters.DBAdlariTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBAdlariBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmaDBListDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(94, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lütfen giriş türünüzü seçiniz";
            // 
            // OperatorButon
            // 
            this.OperatorButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.OperatorButon.Location = new System.Drawing.Point(40, 204);
            this.OperatorButon.Name = "OperatorButon";
            this.OperatorButon.Size = new System.Drawing.Size(146, 36);
            this.OperatorButon.TabIndex = 3;
            this.OperatorButon.Text = "Operator Giriş";
            this.OperatorButon.UseVisualStyleBackColor = true;
            this.OperatorButon.Click += new System.EventHandler(this.OperatorButon_Click);
            // 
            // AdminButon
            // 
            this.AdminButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AdminButon.Location = new System.Drawing.Point(208, 204);
            this.AdminButon.Name = "AdminButon";
            this.AdminButon.Size = new System.Drawing.Size(146, 36);
            this.AdminButon.TabIndex = 4;
            this.AdminButon.Text = "Admin Giriş";
            this.AdminButon.UseVisualStyleBackColor = true;
            this.AdminButon.Click += new System.EventHandler(this.AdminButon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(111, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Veritabanı Bağlantı Durumu:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Image = global::MeshEkran.Properties.Resources.RedIcon;
            this.pictureBox3.Location = new System.Drawing.Point(360, 441);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MeshEkran.Properties.Resources.adminicon;
            this.pictureBox2.Location = new System.Drawing.Point(208, 65);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(146, 133);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MeshEkran.Properties.Resources.factoryicon;
            this.pictureBox1.Location = new System.Drawing.Point(40, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(94, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lütfen veritabanını seçiniz";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dBAdlariBindingSource, "dbName", true));
            this.comboBox1.DataSource = this.dBAdlariBindingSource;
            this.comboBox1.DisplayMember = "dbName";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(135, 295);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(126, 26);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.ValueMember = "dbName";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // dBAdlariBindingSource
            // 
            this.dBAdlariBindingSource.DataMember = "DBAdlari";
            this.dBAdlariBindingSource.DataSource = this.firmaDBListDataSet;
            // 
            // firmaDBListDataSet
            // 
            this.firmaDBListDataSet.DataSetName = "FirmaDBListDataSet";
            this.firmaDBListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dBAdlariTableAdapter
            // 
            this.dBAdlariTableAdapter.ClearBeforeFill = true;
            // 
            // Giris_SecimEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 479);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AdminButon);
            this.Controls.Add(this.OperatorButon);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Giris_SecimEkran";
            this.Text = "MES Sistemi Giriş Seçim Paneli";
            this.Load += new System.EventHandler(this.Giris_SecimEkran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBAdlariBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmaDBListDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button OperatorButon;
        private System.Windows.Forms.Button AdminButon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private MeshEkran.DataSetler.FirmaDBListDataSet firmaDBListDataSet;
        private System.Windows.Forms.BindingSource dBAdlariBindingSource;
        private MeshEkran.DataSetler.FirmaDBListDataSetTableAdapters.DBAdlariTableAdapter dBAdlariTableAdapter;
    }
}