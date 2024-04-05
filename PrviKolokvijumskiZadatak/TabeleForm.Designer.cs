namespace ADONETComplete
{
    partial class TabeleForm
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
            this.dgwPodaci = new System.Windows.Forms.DataGridView();
            this.btnNovi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.cmbIzborTabele = new System.Windows.Forms.ComboBox();
            this.lblIzborTabele = new System.Windows.Forms.Label();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.lblPretraga = new System.Windows.Forms.Label();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPodaci)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwPodaci
            // 
            this.dgwPodaci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwPodaci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPodaci.Location = new System.Drawing.Point(13, 60);
            this.dgwPodaci.Margin = new System.Windows.Forms.Padding(4);
            this.dgwPodaci.MultiSelect = false;
            this.dgwPodaci.Name = "dgwPodaci";
            this.dgwPodaci.RowHeadersWidth = 51;
            this.dgwPodaci.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwPodaci.Size = new System.Drawing.Size(1049, 443);
            this.dgwPodaci.TabIndex = 0;
            this.dgwPodaci.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwPodaci_CellContentClick);
            // 
            // btnNovi
            // 
            this.btnNovi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovi.Location = new System.Drawing.Point(856, 511);
            this.btnNovi.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovi.Name = "btnNovi";
            this.btnNovi.Size = new System.Drawing.Size(100, 28);
            this.btnNovi.TabIndex = 6;
            this.btnNovi.Text = "Novi";
            this.btnNovi.UseVisualStyleBackColor = true;
            this.btnNovi.Click += new System.EventHandler(this.btnNovi_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzmeni.Location = new System.Drawing.Point(964, 511);
            this.btnIzmeni.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(100, 28);
            this.btnIzmeni.TabIndex = 4;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObrisi.Location = new System.Drawing.Point(748, 511);
            this.btnObrisi.Margin = new System.Windows.Forms.Padding(4);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(100, 28);
            this.btnObrisi.TabIndex = 7;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // cmbIzborTabele
            // 
            this.cmbIzborTabele.FormattingEnabled = true;
            this.cmbIzborTabele.ItemHeight = 16;
            this.cmbIzborTabele.Location = new System.Drawing.Point(13, 29);
            this.cmbIzborTabele.Name = "cmbIzborTabele";
            this.cmbIzborTabele.Size = new System.Drawing.Size(138, 24);
            this.cmbIzborTabele.TabIndex = 9;
            this.cmbIzborTabele.SelectedIndexChanged += new System.EventHandler(this.cmbIzborTabele_SelectedIndexChanged);
            // 
            // lblIzborTabele
            // 
            this.lblIzborTabele.AutoSize = true;
            this.lblIzborTabele.Location = new System.Drawing.Point(10, 10);
            this.lblIzborTabele.Name = "lblIzborTabele";
            this.lblIzborTabele.Size = new System.Drawing.Size(80, 16);
            this.lblIzborTabele.TabIndex = 10;
            this.lblIzborTabele.Text = "Izbor tabele:";
            this.lblIzborTabele.Click += new System.EventHandler(this.lblIzborTabele_Click);
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(962, 29);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(100, 24);
            this.btnPretraga.TabIndex = 11;
            this.btnPretraga.Text = "Pretraga";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // lblPretraga
            // 
            this.lblPretraga.AutoSize = true;
            this.lblPretraga.Location = new System.Drawing.Point(815, 11);
            this.lblPretraga.Name = "lblPretraga";
            this.lblPretraga.Size = new System.Drawing.Size(95, 16);
            this.lblPretraga.TabIndex = 12;
            this.lblPretraga.Text = "Pretraži tabelu:";
            this.lblPretraga.Click += new System.EventHandler(this.lblPretraga_Click);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(818, 30);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(138, 22);
            this.txtPretraga.TabIndex = 13;
            // 
            // TabeleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 552);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.lblPretraga);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.lblIzborTabele);
            this.Controls.Add(this.cmbIzborTabele);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnNovi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.dgwPodaci);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TabeleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabele";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwPodaci)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwPodaci;
        private System.Windows.Forms.Button btnNovi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.ComboBox cmbIzborTabele;
        private System.Windows.Forms.Label lblIzborTabele;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.Label lblPretraga;
        private System.Windows.Forms.TextBox txtPretraga;
    }
}

